using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Sockets;
using System.Drawing;

namespace PLDT_TMS
{
    public partial class frmLogin : Form
    {
        //important
        string db;
        string activity;
        bool process;
        string action;
        string statuschecker;
        int enablelog = 0;
        int usercount = 0;
        int counter = 0;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            switch (btnClose.Text)
            {
                case "Reset":
                    {
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtDatabase.Text = "";
                        txtUsername.Focus();
                        chkAdmin.Checked = false;
                        cboWorkgroup.SelectedIndex = -1;
                        cboWorkgroup.Text = "";
                        grbDatabase.Enabled = true;
                        grbDatabase.BackColor = Color.LightGray;
                        grbMain.Enabled = false;
                        grbMain.BackColor = SystemColors.WindowFrame;
                        txtDatabase.Enabled = true;
                        txtDatabase.BackColor= SystemColors.Control;
                        btnClose.Text = "Close";
                        AcceptButton = btnVerify;
                        break;
                    }
                case "Close":
                    {
                        Application.Exit();
                        break;
                    }
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    MessageBox.Show(ip.ToString());
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void shadow()
        {
            if (process == true)
            {
                if (action == "login success")
                {
                    activity = txtUsername.Text + " login successful.";
                }
                else if (action == "login failed")
                {
                    activity = txtUsername.Text + " login failed. Exceeded limit.";
                }
            }
            shadowTrail();
        }
        private void shadowTrail()
        {
            string username = txtUsername.Text;
            string workgroup = cboWorkgroup.Text;
            string databasename = txtDatabase.Text;

            Program.AuditTrail(activity, username, workgroup, databasename);

            process = false;
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Username required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else
            {
                if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Password required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                }
                else
                {
                    if (txtPassword.TextLength <= 5)
                    {
                        MessageBox.Show("Password too short.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Select(0, txtPassword.MaxLength);
                        txtPassword.Focus();
                    }
                    else
                    {
                        switch (chkAdmin.Checked)
                        {
                            case false:
                                {
                                        if (cboWorkgroup.SelectedIndex == -1 || cboWorkgroup.Text.Trim() == "")
                                        {
                                            MessageBox.Show("Workgroup required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            cboWorkgroup.Focus();
                                        }
                                        else
                                        {
                                            string forReader_cboWorkgroup = "Select * from " + db + ".tbl_workgroup" + " where workgroup like '" + cboWorkgroup.Text + "'";
                                            MySqlDataReader reader_cboWorkgroup = Program.Query(forReader_cboWorkgroup);
                                            if (reader_cboWorkgroup.Read())
                                            {
                                                string forReader_status = "Select * from " + db + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";

                                                MySqlDataReader reader_status = Program.Query(forReader_status);

                                                while (reader_status.Read())
                                                {
                                                    statuschecker = reader_status.GetString(8);
                                                }
                                                reader_status.Close();

                                                if (statuschecker == "deactivated")
                                                {
                                                    counter++;
                                                    if (counter == 3)
                                                    {
                                                        action = "login failed";
                                                        process = true;
                                                        shadow();
                                                        MessageBox.Show("Maximum login attempts reached. Application is shutting down.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        Application.Exit();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Account is deactivated. Please consult your administrator.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                    txtUsername.Text = "";
                                                    txtPassword.Text = "";
                                                    cboWorkgroup.Text = "";
                                                    chkAdmin.Checked = false;
                                                    txtDatabase.Text = "";
                                                    cboWorkgroup.SelectedIndex = -1;
                                                    grbDatabase.Enabled = true;
                                                    grbDatabase.BackColor = Color.LightGray;
                                                grbMain.Enabled = false;
                                                    grbMain.BackColor= SystemColors.WindowFrame;
                                                    txtDatabase.Focus();
                                                    return;
                                                }
                                                else
                                                {
                                                    string forReader = "Select * from " + db + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "' and password collate latin1_general_cs like '" + txtPassword.Text + "' and workgroup like '" + cboWorkgroup.Text + "' and usertype like '" + "user" + "'";
                                                    MySqlDataReader reader = Program.Query(forReader);
                                                    if (reader.Read())
                                                    {
                                                        string forLastAccess = "Select * from " + db + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                        MySqlDataReader reader_lastaccess = Program.Query(forLastAccess);
                                                        while (reader_lastaccess.Read())
                                                        {
                                                            var lastdateaccess = Convert.ToDateTime(reader_lastaccess.GetString(11)).ToString("MMM dd yyyy");
                                                            var lasttimeaccess = Convert.ToDateTime(reader_lastaccess.GetString(12)).ToString("HH:mm:ss");
                                                            DateTime t1 = Convert.ToDateTime(lastdateaccess + " " + lasttimeaccess);
                                                            t1 = t1.AddMonths(1);
                                                            DateTime now = Convert.ToDateTime(DateTime.Now.ToString("MMM dd yyyy"));
                                                            int time = DateTime.Compare(t1, now);
                                                            if (time > 0)
                                                            {
                                                                string accessdate = DateTime.Now.ToString("yyyy-MM-dd");
                                                                string accesstime = DateTime.Now.ToString("HH:mm:ss");
                                                                string forUpdate = "update " + txtDatabase.Text + ".tbl_users" + " set lastaccessdate = '" + accessdate + "', lastaccesstime = '" + accesstime + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                                                                Program.Query(forUpdate).Close();
                                                            }
                                                            else
                                                            {
                                                                string forUpdate = "update " + txtDatabase.Text + ".tbl_users" + " set status = '" + "deactivated" + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                                                                Program.Query(forUpdate).Close();
                                                            }
                                                        }
                                                        reader_lastaccess.Close();
                                                        string forReader_Check = "Select * from " + db + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                        MySqlDataReader reader_check = Program.Query(forReader_Check);
                                                        while (reader_check.Read())
                                                        {
                                                            statuschecker = reader_check.GetString(8);
                                                        }
                                                        reader_check.Close();
                                                        if (statuschecker == "deactivated")
                                                        {
                                                            counter++;
                                                            if (counter == 3)
                                                            {
                                                                action = "login failed";
                                                                process = true;
                                                                shadow();
                                                                MessageBox.Show("Maximum login attempts reached. Application is shutting down.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                Application.Exit();
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Account is deactivated. Please consult your administrator.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                            txtUsername.Text = "";
                                                            txtPassword.Text = "";
                                                            chkAdmin.Checked = false;
                                                            cboWorkgroup.Text = "";
                                                            txtDatabase.Text = "";
                                                            cboWorkgroup.SelectedIndex = -1;
                                                            grbDatabase.Enabled = true;
                                                        grbDatabase.BackColor= Color.LightGray;
                                                        grbMain.Enabled = false;
                                                        grbMain.BackColor = SystemColors.WindowFrame;
                                                            txtDatabase.Focus();
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            string forEnableLog = "Select * from " + db + ".tbl_app";
                                                            MySqlDataReader reader_enablelog = Program.Query(forEnableLog);
                                                            while (reader_enablelog.Read())
                                                            {
                                                                enablelog = int.Parse(reader_enablelog.GetString(2));
                                                            }
                                                            reader_enablelog.Close();
                                                            if (enablelog == 0)
                                                            {
                                                                MessageBox.Show("Logging in is disabled. Please consult your administrator.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                string forReader_Current = "Select * from " + db + ".tbl_current" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                                MySqlDataReader reader_current = Program.Query(forReader_Current);
                                                                if (reader_current.Read() != true)
                                                                {
                                                                    counter = 0;
                                                                    string forInsert = "Insert into " + db + ".tbl_current" + "(username) Values ('" + txtUsername.Text + "')";
                                                                    Program.Query(forInsert).Close();
                                                                    frmMain main = new frmMain();
                                                                    main.username_ = txtUsername.Text;
                                                                    main.workgroup_ = cboWorkgroup.Text;
                                                                    main.usertype_ = "user";
                                                                    main.db_ = txtDatabase.Text;
                                                                    action = "login success";
                                                                    process = true;
                                                                    shadow();
                                                                    main.Show();
                                                                    Close();
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Account is currently logged in.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    btnClose.PerformClick();
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        counter++;
                                                        if (counter == 3)
                                                        {
                                                            action = "login failed";
                                                            process = true;
                                                            shadow();
                                                            MessageBox.Show("Maximum login attempts reached. Application is shutting down.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                            Application.Exit();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Invalid login credentials.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                        btnClose.PerformClick();
                                                        return;
                                                    }
                                                    reader.Close();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Invalid workgroup.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                cboWorkgroup.Text = "";
                                                cboWorkgroup.SelectedIndex = -1;
                                                cboWorkgroup.Focus();
                                            }
                                            reader_cboWorkgroup.Close();
                                        }
                                    break;
                                }
                            case true:
                                {
                                            string admin_user = "adminpldt";
                                            string admin_password = "pLdt@dm1n_@dm1npLdt";
                                            if (txtUsername.Text == admin_user && txtPassword.Text == admin_password)
                                            {
                                                string forReader_user = "Select * from " + db + ".tbl_usercount";
                                                MySqlDataReader reader_user = Program.Query(forReader_user);
                                                while (reader_user.Read())
                                                {
                                                    usercount = int.Parse(reader_user.GetString(0));
                                                }
                                                reader_user.Close();
                                                if (usercount < 1)
                                                {
                                                    string forReader_Current = "Select * from " + db + ".tbl_current" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                    MySqlDataReader reader_current = Program.Query(forReader_Current);
                                                    if (reader_current.Read() != true)
                                                    {
                                                        counter = 0;
                                                        string forInsert = "Insert into " + db + ".tbl_current" + "(username) Values ('" + txtUsername.Text + "')";
                                                        Program.Query(forInsert).Close();
                                                        frmSplash splash = new frmSplash();
                                                        splash.username_ = txtUsername.Text;
                                                        splash.workgroup_ = "ADMIN";
                                                        splash.usertype_ = "admin";
                                                        splash.db_ = txtDatabase.Text;
                                                        splash.Show();
                                                        Close();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Account is currently logged in.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        btnClose.PerformClick();
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    string forReader_Current = "Select * from " + db + ".tbl_current" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                    MySqlDataReader reader_current = Program.Query(forReader_Current);
                                                    if (reader_current.Read() != true)
                                                    {
                                                        counter = 0;
                                                        string forInsert = "Insert into " + db + ".tbl_current" + "(username) Values ('" + txtUsername.Text + "')";
                                                        Program.Query(forInsert).Close();
                                                        frmMain main = new frmMain();
                                                        main.username_ = txtUsername.Text;
                                                        main.workgroup_ = "ADMIN";
                                                        main.usertype_ = "admin";
                                                        main.db_ = txtDatabase.Text;
                                                        action = "login success";
                                                        process = true;
                                                        shadow();
                                                        main.Show();
                                                        Close();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Account is currently logged in.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        btnClose.PerformClick();
                                                        return;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                string forReader_status = "Select * from " + db + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                MySqlDataReader reader_status = Program.Query(forReader_status);
                                                while (reader_status.Read())
                                                {
                                                    statuschecker = reader_status.GetString(8);
                                                }
                                                reader_status.Close();
                                                if (statuschecker == "deactivated")
                                                {
                                                    counter++;
                                                    if (counter == 3)
                                                    {
                                                        action = "login failed";
                                                        process = true;
                                                        shadow();
                                                        MessageBox.Show("Maximum login attempts reached. Application is shutting down.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        Application.Exit();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Account is deactivated. Please consult your administrator.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                    btnClose.PerformClick();
                                                    return;
                                                }
                                                else
                                                {
                                                    string forReader = "Select * from " + db + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "' and password collate latin1_general_cs like '" + txtPassword.Text + "' and usertype like '" + "admin" + "'";
                                                    MySqlDataReader reader = Program.Query(forReader);
                                                    if (reader.Read())
                                                    {
                                                        string forLastAccess = "Select * from " + db + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                        MySqlDataReader reader_lastaccess = Program.Query(forLastAccess);
                                                        while (reader_lastaccess.Read())
                                                        {
                                                            var lastdateaccess = Convert.ToDateTime(reader_lastaccess.GetString(11)).ToString("MMM dd yyyy");
                                                            var lasttimeaccess = Convert.ToDateTime(reader_lastaccess.GetString(12)).ToString("HH:mm:ss");
                                                            DateTime t1 = Convert.ToDateTime(lastdateaccess + " " + lasttimeaccess);
                                                            t1 = t1.AddMonths(1);
                                                            DateTime now = Convert.ToDateTime(DateTime.Now.ToString("MMM dd yyyy"));
                                                            int time = DateTime.Compare(t1, now);
                                                            if (time > 0)
                                                            {
                                                                string accessdate = DateTime.Now.ToString("yyyy-MM-dd");
                                                                string accesstime = DateTime.Now.ToString("HH:mm:ss");
                                                                string forUpdate = "update " + txtDatabase.Text + ".tbl_users" + " set lastaccessdate = '" + accessdate + "', lastaccesstime = '" + accesstime + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                                                                Program.Query(forUpdate).Close();
                                                            }
                                                            else
                                                            {
                                                                string forUpdate = "update " + txtDatabase.Text + ".tbl_users" + " set status = '" + "deactivated" + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                                                                Program.Query(forUpdate).Close();
                                                            }
                                                        }
                                                        reader_lastaccess.Close();
                                                        string forReader_Check = "Select * from " + db + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                        MySqlDataReader reader_check = Program.Query(forReader_Check);
                                                        while (reader_check.Read())
                                                        {
                                                            statuschecker = reader_check.GetString(8);
                                                        }
                                                        reader_check.Close();
                                                        if (statuschecker == "deactivated")
                                                        {
                                                            counter++;
                                                            if (counter == 3)
                                                            {
                                                                action = "login failed";
                                                                process = true;
                                                                shadow();
                                                                MessageBox.Show("Maximum login attempts reached. Application is shutting down.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                Application.Exit();
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Account is deactivated. Please consult your administrator.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                            btnClose.PerformClick();
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            string forReader_user = "Select * from " + db + ".tbl_usercount";
                                                            MySqlDataReader reader_user = Program.Query(forReader_user);
                                                            while (reader_user.Read())
                                                            {
                                                                usercount = int.Parse(reader_user.GetString(0));
                                                            }
                                                            reader_user.Close();
                                                            if (usercount < 1)
                                                            {
                                                                string forReader_Current = "Select * from " + db + ".tbl_current" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                                MySqlDataReader reader_current = Program.Query(forReader_Current);
                                                                if (reader_current.Read() != true)
                                                                {
                                                                    counter = 0;

                                                                    string forInsert = "Insert into " + db + ".tbl_current" + "(username) Values ('" + txtUsername.Text + "')";
                                                                    Program.Query(forInsert).Close();

                                                                    frmSplash splash = new frmSplash();
                                                                    splash.username_ = txtUsername.Text;
                                                                    splash.workgroup_ = "ADMIN";
                                                                    splash.usertype_ = "admin";
                                                                    splash.db_ = txtDatabase.Text;
                                                                    splash.Show();
                                                                    Close();
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Account is currently logged in.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    btnClose.PerformClick();
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                string forReader_Current = "Select * from " + db + ".tbl_current" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                                MySqlDataReader reader_current = Program.Query(forReader_Current);
                                                                if (reader_current.Read() != true)
                                                                {
                                                                    counter = 0;
                                                                    string forInsert = "Insert into " + db + ".tbl_current" + "(username) Values ('" + txtUsername.Text + "')";
                                                                    Program.Query(forInsert).Close();
                                                                    frmMain main = new frmMain();
                                                                    main.username_ = txtUsername.Text;
                                                                    main.workgroup_ = "ADMIN";
                                                                    main.usertype_ = "admin";
                                                                    main.db_ = txtDatabase.Text;
                                                                    action = "login success";
                                                                    process = true;
                                                                    shadow();
                                                                    main.Show();
                                                                    Close();
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Account is currently logged in.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    btnClose.PerformClick();
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        counter++;
                                                        if (counter == 3)
                                                        {
                                                            action = "login failed";
                                                            process = true;
                                                            shadow();
                                                            MessageBox.Show("Maximum login attempts reached. Application is shutting down.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                            Application.Exit();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Invalid login credentials.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                        btnClose.PerformClick();
                                                        return;
                                                    }
                                                    reader.Close();
                                                }
                                            }
                                    break;
                                }
                        }
                    }
                }
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            timDelay.Stop();
            ActiveControl = txtDatabase;
        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                {
                    ((TextBox)sender).SelectAll();
                }
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                if (sender != null)
                {
                    ((TextBox)sender).Copy();
                }

            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (sender != null)
                {
                    ((TextBox)sender).Paste();
                }
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                if (sender != null)
                {
                    ((TextBox)sender).Cut();
                }
            }
            else
            {
                return;
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                {
                    ((TextBox)sender).SelectAll();
                }
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (sender != null)
                {
                    ((TextBox)sender).Paste();
                }
            }
            else
            {
                return;
            }
        }
        int x = 0;
        private void timDelay_Tick(object sender, EventArgs e)
        {
            while (x != 2)
            {
                cboWorkgroup.Enabled = false;
                cboWorkgroup.BackColor = SystemColors.WindowFrame;
                x++;
            }
            cboWorkgroup.Enabled = true;
            cboWorkgroup.BackColor= SystemColors.Control;
            txtUsername.Focus();
            AcceptButton = btnEnter;
            timDelay.Stop();
        }
        private void cboWorkgroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void lblRecover_Click(object sender, EventArgs e)
        {
            frmRecoverAccount recover = new frmRecoverAccount();
            recover.ShowDialog();
        }
        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkAdmin.Checked)
            {
                case true:
                    {
                        cboWorkgroup.Enabled = false;
                        cboWorkgroup.BackColor = SystemColors.WindowFrame;
                        cboWorkgroup.SelectedIndex = -1;
                        break;
                    }
                case false:
                    {
                        cboWorkgroup.Enabled = true;
                        cboWorkgroup.BackColor= SystemColors.Control;
                        break;
                    }
            }
        }
        private void txtDatabase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = Program.Query("Select * from login_tms.tbl_database where databasename collate latin1_general_cs like '" + txtDatabase.Text + "'");
            if (reader.Read())
            {
                cboWorkgroup.Enabled = false;
                cboWorkgroup.BackColor = SystemColors.WindowFrame;
                cboWorkgroup.Items.Clear();
                db = txtDatabase.Text;
                string forReader_workgroup = "Select * from " + db + ".tbl_workgroup" + " order by workgroup";
                MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                while (reader_workgroup.Read())
                {
                    cboWorkgroup.Items.Add(reader_workgroup.GetString(0));
                }
                reader_workgroup.Close();
                timDelay.Start();
                grbDatabase.Enabled = false;
                grbDatabase.BackColor = SystemColors.WindowFrame;
                grbMain.Enabled = true;
                grbMain.BackColor= Color.LightGray;
                btnClose.Text = "Reset";
                txtUsername.Focus();
                AcceptButton = btnEnter;
                string accessdate = DateTime.Now.ToString("yyyy-MM-dd");
                string accesstime = DateTime.Now.ToString("HH:mm:ss");
                string forUpdate = "update " + txtDatabase.Text + ".tbl_users" + " set lastaccessdate = '" + accessdate + "', lastaccesstime = '" + accesstime + "' where username collate latin1_general_cs = '" + "adminpldt" + "'";
                Program.Query(forUpdate).Close();
            }
            else
            {
                MessageBox.Show("Database name doesn't exist.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDatabase.Text = "";
                cboWorkgroup.Enabled = true;
                cboWorkgroup.BackColor= SystemColors.Control;
                txtDatabase.Focus();
            }
            reader.Close();
        }
        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            if (txtDatabase.Text.Trim() != "")
            {
                if (txtDatabase.Text.Contains(@"\"))
                {
                    char[] antiBackSlash = {'\\'};
                    txtDatabase.Text = txtDatabase.Text.TrimEnd(antiBackSlash);
                    txtDatabase.SelectionStart = txtDatabase.Text.Length;
                    txtDatabase.SelectionLength = 0;
                }
                btnVerify.Enabled = true;
                btnVerify.BackColor= SystemColors.Control;
            }
            else
            {
                btnVerify.Enabled = false;
                btnVerify.BackColor = SystemColors.Control;
            }
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() != "" || txtPassword.Text.Trim() != "" || cboWorkgroup.Text.Trim() != "")
            {
                btnEnter.Enabled = true;
                btnEnter.BackColor= SystemColors.Control;
            }
            else
            {
                btnEnter.Enabled = false;
                btnEnter.BackColor = SystemColors.WindowFrame;
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() != "" || txtPassword.Text.Trim() != "" || cboWorkgroup.Text.Trim() != "")
            {
                if (txtPassword.Text.Contains(@"\"))
                {
                    char[] antiBackSlash = { '\\' };
                    txtPassword.Text = txtDatabase.Text.TrimEnd(antiBackSlash);
                    txtPassword.SelectionStart = txtDatabase.Text.Length;
                    txtPassword.SelectionLength = 0;
                }
                btnEnter.Enabled = true;
                btnEnter.BackColor= SystemColors.Control;
            }
            else
            {
                btnEnter.Enabled = false;
                btnEnter.BackColor = SystemColors.WindowFrame;
            }
        }
        private void cboWorkgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() != "" || txtPassword.Text.Trim() != "" || cboWorkgroup.Text.Trim() != "")
            {
                btnEnter.Enabled = true;
                btnEnter.BackColor= SystemColors.Control;
            }
            else
            {
                btnEnter.Enabled = false;
                btnEnter.BackColor = SystemColors.WindowFrame;
            }
        }
    }
}