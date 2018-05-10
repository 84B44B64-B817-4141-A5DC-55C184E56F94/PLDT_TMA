using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PLDT_TMS
{
    public partial class frmAdminMaintenance : Form
    {
        public frmAdminMaintenance()
        {
            InitializeComponent();
        }
        //IMPORTANT
        public string db_;
        public string username_;
        public string workgroup_;
        string read;
        //IMPORTANT
        string clear_action;
        bool formChange = false;
        string count;
        int tablecount = 50;
        int tableshow = 0;
        int limiter = 0;
        string username;
        string usertype;
        string workgroup;
        string status;
        string firstname;
        string middleinitial;
        string lastname;
        string contactnumber;
        string action;
        private void resetCounter()
        {
            tablecount = 50;
            tableshow = 0;
            limiter = 0;
            txtShowRow.Text = "0";
        }
        private void buttonReader()
        {
            if (lsvData.Items.Count < 50)
            {
                btnMore.Enabled = false;
                btnMore.BackColor = SystemColors.WindowFrame;
                btnLess.Enabled = false;
                btnLess.BackColor = SystemColors.WindowFrame;
                txtRow.Text = lsvData.Items.Count.ToString();
            }
            else
            {
                btnMore.Enabled = true;
                btnMore.BackColor = SystemColors.Control;
                btnLess.Enabled = false;
                btnLess.BackColor = SystemColors.WindowFrame;
                txtRow.Text = "50";
            }
        }
        private void chkViewRecovery_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkViewRecovery.Checked)
            {
                case false:
                    {
                        txtRecovery.PasswordChar = '*';
                        break;
                    }
                case true:
                    {
                        txtRecovery.PasswordChar = '\0';
                        break;
                    }
            }
        }
        string finalString;
        private void KeyGenerator()
        {
            finalString = "";
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            finalString = new String(stringChars);
        }
        string password;
        private void PasswordGenerator()
        {
            password = "";
            var passchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=-][{}'/.,<>?";
            var keyChars = new char[8];
            var key = new Random();

            for (int i = 0; i < keyChars.Length; i++)
            {
                keyChars[i] = passchars[key.Next(passchars.Length)];
            }

            password = new String(keyChars);
        }
        string recoverykey;
        private void btnRecovery_Click(object sender, EventArgs e)
        {
            string forReader = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
            MySqlDataReader reader = Program.Query(forReader);
            while (reader.Read())
            {
                recoverykey = reader.GetString(9);
            }
            reader.Close();
            if (recoverykey != "00000000")
            {
                if (MessageBox.Show("Generate new recovery key?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    KeyGenerator();
                    txtRecovery.Text = finalString;
                    string recoverykeylife = DateTime.Now.ToString("HH:mm:ss");
                    string forUpdate = "update " + lblDatabase_.Text + ".tbl_users" + " set recoverykey = '" + finalString + "', recoverykeylife = '" + recoverykeylife + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                    Program.Query(forUpdate).Close();
                    MessageBox.Show("New recovery key generated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            else
            {
                KeyGenerator();
                txtRecovery.Text = finalString;
                string recoverykeylife = DateTime.Now.ToString("HH:mm:ss");
                string forUpdate = "update " + lblDatabase_.Text + ".tbl_users" + " set recoverykey = '" + finalString + "', recoverykeylife = '" + recoverykeylife + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                Program.Query(forUpdate).Close();
                MessageBox.Show("Recovery key generated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            action = "key";
            shadow();
        }

        private void lsvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvData.SelectedItems.Count == 0)
            {
                btnLogout.Visible = false;
                clear_action = "edit";
                btnEdit.Enabled = false;
                btnEdit.BackColor = SystemColors.WindowFrame;
                ClearForms();
                return;
            }
            else
            {
                btnLogout.Text = "Force Log-out";
                btnLogout.Visible = true;
                txtRecovery.PasswordChar = '*';
                chkViewRecovery.Checked = false;
                clear_action = "edit";
                btnEdit.Enabled = true;
                btnEdit.BackColor = SystemColors.Control;
                grbPassword.Enabled = true;
                grbPassword.BackColor = Color.DarkSeaGreen;
                ListViewItem item = lsvData.SelectedItems[0];
                txtUsername.Text = item.SubItems[0].Text;
                username = txtUsername.Text;
                cboUserType.Text = item.SubItems[1].Text;
                usertype = cboUserType.Text;
                if (usertype == "admin")
                {
                    cboWorkgroup.SelectedIndex = -1;
                    workgroup = "none";
                }
                else
                {
                    cboWorkgroup.Text = item.SubItems[2].Text;
                    workgroup = cboWorkgroup.Text;
                }
                cboStatus.Text = item.SubItems[3].Text;
                status = cboStatus.Text;
                string forReader_accountholder = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                MySqlDataReader reader_accountholder = Program.Query(forReader_accountholder);
                while (reader_accountholder.Read())
                {
                    txtFirstName.Text = reader_accountholder.GetString(4);
                    firstname = txtFirstName.Text;
                    txtMiddleInitial.Text = reader_accountholder.GetString(6);
                    middleinitial = txtMiddleInitial.Text;
                    txtLastName.Text = reader_accountholder.GetString(5);
                    lastname = txtLastName.Text;
                    txtContactNumber.Text = reader_accountholder.GetString(7);
                    contactnumber = txtContactNumber.Text;
                    txtRecovery.Text = reader_accountholder.GetString(9);
                }
                reader_accountholder.Close();
            }
        }
        private void frmAdminMaintenance_Load(object sender, EventArgs e)
        {
            lblDatabase_.Text = db_;
            lblWorkgroup_.Text = workgroup_;
            lblUsername_.Text = username_;
            getInfo();
            string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup " + " order by workgroup";
            MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
            while (reader_workgroup.Read())
            {
                cboWorkgroup.Items.Add(reader_workgroup.GetString(0));
            }
            reader_workgroup.Close();
            cboSearchType.SelectedIndex = 0;
        }
        private void getInfo()
        {
            switch (cboSearchType.SelectedIndex)
            {
                case 1:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username like '" + txtSearch.Text + "%" + "' and username not like '" + "adminpldt" + "' order by username limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(8));
                            lst.SubItems.Add(reader.GetString(4) + " " + reader.GetString(6) + " " + reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(7));
                            lsvData.Items.Add(lst);
                        }
                        reader.Close();
                        foreach (ListViewItem lst in lsvData.Items)
                        {
                            usertype = lst.SubItems[1].ToString();
                            status = lst.SubItems[3].ToString();

                            if (usertype == "ListViewSubItem: {user}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Wheat;
                            }
                            else if (usertype == "ListViewSubItem: {admin}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Aquamarine;
                            }
                            else
                            {
                                lst.BackColor = Color.LightGray;
                            }
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 2:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where workgroup like '" + txtSearch.Text + "%" + "' order by workgroup limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(8));
                            lst.SubItems.Add(reader.GetString(4) + " " + reader.GetString(6) + " " + reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(7));
                            lsvData.Items.Add(lst);
                        }
                        reader.Close();
                        foreach (ListViewItem lst in lsvData.Items)
                        {
                            usertype = lst.SubItems[1].ToString();
                            status = lst.SubItems[3].ToString();

                            if (usertype == "ListViewSubItem: {user}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Wheat;
                            }
                            else if (usertype == "ListViewSubItem: {admin}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Aquamarine;
                            }
                            else
                            {
                                lst.BackColor = Color.LightGray;
                            }
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                default:
                    {
                        string line;
                        StreamReader file = new StreamReader("config.ini");
                        while ((line = file.ReadLine()) != null)
                        {
                            read = line;
                            line = line.Remove(4, line.Length - 4);
                            if (line == "ip_a")
                            {
                                read = read.Remove(0, 11);
                            }
                        }
                        file.Close();
                        string ConnectionString = "datasource=" + read + ";port=3306;username=root;password=mySQL09122016;";
                        MySqlConnection conn = new MySqlConnection("datasource= " + read + ";port=3306;username=root;password=mySQL09122016");
                        MySqlCommand query_ = new MySqlCommand("SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_users" + "", conn);
                        conn.Open();
                        count = query_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow.Text = count;
                        lsvData.Items.Clear();
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username not like '" + "adminpldt" + "' order by username limit " + tableshow + "," + tablecount;
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(8));
                            lst.SubItems.Add(reader.GetString(4) + " " + reader.GetString(6) + " " + reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(7));
                            lsvData.Items.Add(lst);
                        }
                        reader.Close();
                        foreach (ListViewItem lst in lsvData.Items)
                        {
                            usertype = lst.SubItems[1].ToString();
                            status = lst.SubItems[3].ToString();

                            if (usertype == "ListViewSubItem: {user}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Wheat;
                            }
                            else if (usertype == "ListViewSubItem: {admin}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Aquamarine;
                            }
                            else
                            {
                                lst.BackColor = Color.LightGray;
                            }
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
            }
        }
        private void ClearForms()
        {
            switch (clear_action)
            {
                case "edit":
                    {
                        txtUsername.ReadOnly = true;
                        formChange = false;
                        txtUsername.Text = username;
                        cboUserType.Enabled = false;
                        cboUserType.BackColor = SystemColors.WindowFrame;
                        cboUserType.Text = usertype;
                        cboWorkgroup.Enabled = false;
                        cboWorkgroup.BackColor = SystemColors.WindowFrame;
                        cboWorkgroup.Text = workgroup;
                        cboStatus.Enabled = false;
                        cboStatus.BackColor = SystemColors.WindowFrame;
                        cboStatus.Text = status;
                        txtFirstName.ReadOnly = true;
                        txtFirstName.Text = firstname;
                        txtLastName.ReadOnly = true;
                        txtLastName.Text = lastname;
                        txtMiddleInitial.ReadOnly = true;
                        txtMiddleInitial.Text = middleinitial;
                        txtContactNumber.ReadOnly = true;
                        txtContactNumber.Text = contactnumber;
                        btnAdd.Enabled = true;
                        btnAdd.BackColor = SystemColors.Control;
                        btnEdit.Text = "Edit";
                        btnClose.Text = "Close";
                        grbPassword.Enabled = false;
                        grbPassword.BackColor = SystemColors.WindowFrame;
                        lsvData.Enabled = true;
                        lsvData.BackColor = SystemColors.ControlDark;
                        break;
                    }
                case "add":
                    {
                        cboStatus.SelectedIndex = -1;
                        cboUserType.SelectedIndex = -1;
                        formChange = false;
                        cboWorkgroup.SelectedIndex = -1;
                        txtUsername.ReadOnly = true;
                        txtUsername.Text = "";
                        cboUserType.Enabled = false;
                        cboUserType.BackColor = SystemColors.WindowFrame;
                        cboUserType.Text = "";
                        cboWorkgroup.Enabled = false;
                        cboWorkgroup.BackColor = SystemColors.WindowFrame;
                        cboWorkgroup.Text = "";
                        cboStatus.Enabled = false;
                        cboStatus.BackColor = SystemColors.WindowFrame;
                        cboStatus.Text = "";
                        txtFirstName.ReadOnly = true;
                        txtFirstName.Text = "";
                        txtLastName.ReadOnly = true;
                        txtLastName.Text = "";
                        txtMiddleInitial.ReadOnly = true;
                        txtMiddleInitial.Text = "";
                        txtContactNumber.ReadOnly = true;
                        txtContactNumber.Text = "";
                        btnAdd.Enabled = true;
                        btnAdd.BackColor = SystemColors.Control;
                        btnAdd.Text = "Add";
                        btnClose.Text = "Close";
                        grbPassword.Enabled = false;
                        grbPassword.BackColor = SystemColors.WindowFrame;
                        lsvData.Enabled = true;
                        lsvData.BackColor = SystemColors.ControlDark;
                        btnAdd.Enabled = true;
                        btnAdd.BackColor = SystemColors.Control;
                        break;
                    }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            switch (btnClose.Text)
            {
                case "Close":
                    {
                        Close();
                        break;
                    }
                case "Reset":
                    {
                        ClearForms();
                        btnAdd.Enabled = true;
                        btnAdd.BackColor = SystemColors.Control;
                        btnAdd.Text = "Add";
                        btnEdit.Enabled = false;
                        btnEdit.BackColor = SystemColors.WindowFrame;
                        break;
                    }
            }
        }
        string account_workgroup;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (btnAdd.Text)
            {
                case "Add":
                    {
                        clear_action = "add";
                        ClearForms();
                        lsvData.Enabled = false;
                        lsvData.BackColor = SystemColors.WindowFrame;
                        btnEdit.Enabled = false;
                        btnEdit.BackColor = SystemColors.WindowFrame;
                        btnClose.Text = "Reset";
                        txtUsername.ReadOnly = false;
                        txtContactNumber.ReadOnly = false;
                        txtFirstName.ReadOnly = false;
                        txtLastName.ReadOnly = false;
                        txtMiddleInitial.ReadOnly = false;
                        cboStatus.Enabled = true;
                        cboStatus.BackColor = SystemColors.Control;
                        cboUserType.Enabled = true;
                        cboUserType.BackColor = SystemColors.Control;
                        cboWorkgroup.Enabled = true;
                        cboWorkgroup.BackColor = SystemColors.Control;
                        if (usertype == "admin")
                        {
                            cboWorkgroup.Enabled = false;
                            cboWorkgroup.BackColor = SystemColors.WindowFrame;
                        }
                        btnAdd.Text = "Save";
                        lsvData.Enabled = false;
                        lsvData.BackColor = SystemColors.WindowFrame;
                        btnAdd.Enabled = false;
                        btnAdd.BackColor = SystemColors.WindowFrame;
                        formChange = true;
                        break;
                    }
                case "Save":
                    {
                        if (txtUsername.Text.Trim() != "")
                        {
                            if (txtUsername.Text.Length > 5)
                            {
                                string forReader_username = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                MySqlDataReader reader_username = Program.Query(forReader_username);
                                if (!reader_username.Read())
                                {
                                    if (cboUserType.Text.Trim() != "")
                                    {
                                        if (cboUserType.Text == "admin")
                                        {
                                            account_workgroup = "none";
                                        }
                                        if (cboWorkgroup.Text.Trim() != "" || cboUserType.Text == "admin")
                                        {
                                            if (cboUserType.Text != "admin")
                                            {
                                                account_workgroup = cboWorkgroup.Text;
                                            }
                                            if (cboStatus.Text.Trim() != "")
                                            {
                                                if (cboStatus.Text == "deactivated")
                                                {
                                                    MessageBox.Show("Note: This account is set as deactivated.", "System", MessageBoxButtons.OK, MessageBoxIcon.None);
                                                }
                                                if (txtFirstName.Text.Trim() != "")
                                                {
                                                    if (txtMiddleInitial.Text.Trim() == "")
                                                    {
                                                        txtMiddleInitial.Text = ".";
                                                    }
                                                    if (txtLastName.Text.Trim() != "")
                                                    {
                                                        if (txtContactNumber.Text.Trim() == "")
                                                        {
                                                            txtContactNumber.Text = "none";
                                                        }
                                                        if (MessageBox.Show("Account details:\n\nAccount Holder: " + txtFirstName.Text + " " + txtMiddleInitial.Text + " " + txtLastName.Text + "\nContact Number: " + txtContactNumber.Text + "\nUsername: " + txtUsername.Text + "\nWorkgroup: " + account_workgroup + "\nUsertype: " + cboUserType.Text + "\n\nAdd this account?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                        {
                                                            PasswordGenerator();
                                                            KeyGenerator();
                                                            txtRecovery.Text = finalString;
                                                            string recoverykeylife = DateTime.Now.ToString("HH:mm:ss");
                                                            string accessdate = DateTime.Now.ToString("yyyy-MM-dd"), accesstime = DateTime.Now.ToString("HH:mm:ss");
                                                            string forInsert = "Insert into " + lblDatabase_.Text + ".tbl_users" + " (username,password,workgroup,usertype,firstname,lastname,middleinitial,contactnumber,status,recoverykey,recoverykeylife,lastaccessdate,lastaccesstime) Values ('" + txtUsername.Text + "','" + password + "','" + account_workgroup + "','" + cboUserType.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtMiddleInitial.Text + "','" + txtContactNumber.Text + "','" + cboStatus.Text + "','" + txtRecovery.Text + "','" + recoverykeylife + "', '" + accessdate + "','" + accesstime + "')";
                                                            Program.Query(forInsert).Close();
                                                            MessageBox.Show("Account successfully created. To set password, go to Login Screen>Recover Account and apply this code: " + txtRecovery.Text + "\n\n(Press Ctrl+C to Copy)", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            action = "add";
                                                            shadow();
                                                            clear_action = "add";
                                                            ClearForms();
                                                            getInfo();
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Last name is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        txtLastName.Focus();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("First name is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    txtFirstName.Focus();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Account status required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                cboStatus.Focus();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Workgroup required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            cboWorkgroup.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("User Type required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        cboUserType.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Username exists.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtUsername.Select(0, txtUsername.MaxLength);
                                    txtUsername.Focus();
                                }
                                reader_username.Close();
                            }
                            else
                            {
                                MessageBox.Show("Username length is not valid");
                                txtUsername.Select(0, txtUsername.MaxLength);
                                txtUsername.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Focus();
                        }
                    }
                    break;
            }
        }
        string activity;
        private void shadow()
        {
            if (action == "add")
            {
                activity = cboUserType.Text + " account with Username: [" + txtUsername.Text + "] at [" + cboWorkgroup.Text + "] workgroup added.";
            }
            else if (action == "edit")
            {
                activity = "Account [" + txtUsername.Text + "] has been updated.";
            }
            else if (action == "key")
            {
                activity = "Account [" + txtUsername.Text + "] has been provided with a recovery key.";
            }
            shadowTrail();
        }
        private void shadowTrail()
        {
            string username = lblUsername_.Text;
            string workgroup = "none";
            string databasename = lblDatabase_.Text;
            Program.AuditTrail(activity, username, workgroup, databasename);
        }
        private void ButtonHandler()
        {
            switch (clear_action)
            {
                case "add":
                    {
                        if ((cboUserType.Text.Trim() != "" || cboUserType.SelectedIndex != -1) && (cboStatus.Text.Trim() != "" || cboStatus.SelectedIndex != -1) && (cboWorkgroup.Text.Trim() != "" || cboWorkgroup.SelectedIndex != 1) && txtFirstName.Text.Trim() != "" && txtLastName.Text.Trim() != "")
                        {
                            btnAdd.Enabled = true;
                            btnAdd.BackColor = SystemColors.Control;
                        }
                        else
                        {
                            btnAdd.Enabled = false;
                            btnAdd.BackColor = SystemColors.WindowFrame;
                        }
                        if ((cboUserType.Text.Trim() != "" || cboUserType.SelectedIndex != -1) || (cboStatus.Text.Trim() != "" || cboStatus.SelectedIndex != -1) || (cboWorkgroup.Text.Trim() != "" || cboWorkgroup.SelectedIndex != 1) || txtFirstName.Text.Trim() != "" || txtLastName.Text.Trim() != "" || txtMiddleInitial.Text.Trim() != "" || txtContactNumber.Text.Trim() != "")
                        {
                            btnClose.Text = "Reset";
                        }
                        else
                        {
                            btnClose.Text = "Close";
                        }
                        break;
                    }
                case "edit":
                    {
                        if ((cboUserType.Text.Trim() != "" || cboUserType.SelectedIndex != -1) && (cboStatus.Text.Trim() != "" || cboStatus.SelectedIndex != -1) && (cboWorkgroup.Text.Trim() != "" || cboWorkgroup.SelectedIndex != 1) && txtFirstName.Text.Trim() != "" && txtLastName.Text.Trim() != "")
                        {
                            btnEdit.Enabled = true;
                            btnEdit.BackColor = SystemColors.Control;
                        }
                        else
                        {
                            btnEdit.Enabled = false;
                            btnEdit.BackColor = SystemColors.WindowFrame;
                        }
                        if ((cboUserType.Text.Trim() != "" || cboUserType.SelectedIndex != -1) || (cboStatus.Text.Trim() != "" || cboStatus.SelectedIndex != -1) || (cboWorkgroup.Text.Trim() != "" || cboWorkgroup.SelectedIndex != 1) || txtFirstName.Text.Trim() != "" || txtLastName.Text.Trim() != "" || txtMiddleInitial.Text.Trim() != "" || txtContactNumber.Text.Trim() != "")
                        {
                            btnClose.Text = "Reset";
                        }
                        else
                        {
                            btnClose.Text = "Close";
                        }
                        break;
                    }
            }
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void txtMiddleInitial_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void cboUserType_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
            if (cboUserType.Text == "admin")
            {
                cboWorkgroup.Enabled = false;
                cboWorkgroup.BackColor = SystemColors.WindowFrame;
                cboWorkgroup.Text = "none";
            }
            else
            {
                if (formChange == true)
                {
                    cboWorkgroup.Enabled = true;
                    cboWorkgroup.BackColor = SystemColors.Control;
                }
            }
        }
        private void cboWorkgroup_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void cboStatus_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsSymbol(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsSymbol(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtMiddleInitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
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
        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txtMiddleInitial_Leave(object sender, EventArgs e)
        {
            txtMiddleInitial.Text = txtMiddleInitial.Text.ToUpper();
        }
        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSearchType.SelectedIndex)
            {
                case 1:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 2:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                default:
                    {
                        txtSearch.Enabled = false;
                        txtSearch.BackColor = SystemColors.WindowFrame;
                        btnSearch.Enabled = false;
                        btnSearch.BackColor = SystemColors.WindowFrame;
                        txtSearch.Text = "";
                        getInfo();
                        lblCount.Text = "";
                        break;
                    }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            switch (btnEdit.Text)
            {
                case "Edit":
                    {
                        txtUsername.ReadOnly = true;
                        cboUserType.Enabled = true;
                        cboUserType.BackColor = SystemColors.Control;
                        cboWorkgroup.Enabled = true;
                        cboWorkgroup.BackColor = SystemColors.Control;
                        cboStatus.Enabled = true;
                        cboStatus.BackColor = SystemColors.Control;
                        txtFirstName.ReadOnly = false;
                        txtLastName.ReadOnly = false;
                        txtMiddleInitial.ReadOnly = false;
                        txtContactNumber.ReadOnly = false;
                        btnAdd.Enabled = false;
                        btnAdd.BackColor = SystemColors.WindowFrame;
                        btnEdit.Text = "Update";
                        btnClose.Text = "Reset";
                        grbPassword.Enabled = false;
                        grbPassword.BackColor = SystemColors.WindowFrame;
                        lsvData.Enabled = false;
                        lsvData.BackColor = SystemColors.WindowFrame;
                        clear_action = "edit";
                        formChange = true;
                        if (cboUserType.Text == "admin")
                        {
                            cboWorkgroup.Enabled = false;
                            cboWorkgroup.BackColor = SystemColors.WindowFrame;
                            account_workgroup = "none";
                        }
                        break;
                    }
                case "Update":
                    {
                        if (cboUserType.Text == usertype && cboStatus.Text == status && cboWorkgroup.Text == workgroup && txtContactNumber.Text == contactnumber && txtFirstName.Text == firstname && txtLastName.Text == lastname && txtMiddleInitial.Text == middleinitial)
                        {
                            MessageBox.Show("No change is done.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (cboUserType.Text.Trim() != "")
                            {
                                if (cboWorkgroup.Text.Trim() != "" || cboUserType.Text == "admin")
                                {
                                    if (cboUserType.Text != "admin")
                                    {
                                        account_workgroup = cboWorkgroup.Text;
                                    }
                                    if (cboStatus.Text.Trim() != "")
                                    {
                                        if (txtFirstName.Text.Trim() != "")
                                        {
                                            if (txtMiddleInitial.Text.Trim() == "")
                                            {
                                                txtMiddleInitial.Text = ".";
                                            }
                                            if (txtLastName.Text.Trim() != "")
                                            {
                                                if (txtContactNumber.Text.Trim() == "")
                                                {
                                                    txtContactNumber.Text = "none";
                                                }
                                                if (MessageBox.Show("Account details:\n\nAccount Holder: " + firstname + " " + middleinitial + " " + lastname + " >>>" + txtFirstName.Text + " " + txtMiddleInitial.Text + " " + txtLastName.Text + "\nContact Number: " + contactnumber + " >>> " + txtContactNumber.Text + "\nUsername: " + txtUsername.Text + "\nWorkgroup: " + workgroup + " >>> " + account_workgroup + "\nUsertype: " + usertype + " >>> " + cboUserType.Text + "\nStatus: " + status + " >>> " + cboStatus.Text + "\n\nUpdate account?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                {
                                                    switch (cboStatus.Text)
                                                    {
                                                        case "activated":
                                                            {
                                                                PasswordGenerator();
                                                                KeyGenerator();
                                                                txtRecovery.Text = finalString;
                                                                string recoverykeylife = DateTime.Now.ToString("HH:mm:ss");
                                                                string lastaccess = DateTime.Now.ToString("yyyy-MM-dd");
                                                                string forUpdate = "update " + lblDatabase_.Text + ".tbl_users" + " set workgroup = '" + account_workgroup + "', usertype = '" + cboUserType.Text + "', firstname = '" + txtFirstName.Text + "', lastname = '" + txtLastName.Text + "', middleinitial = '" + txtMiddleInitial.Text + "', contactnumber = '" + txtContactNumber.Text + "', status = '" + cboStatus.Text + "', lastaccessdate = '" + lastaccess + "', lastaccesstime = '" + recoverykeylife + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                                                                Program.Query(forUpdate).Close();
                                                                MessageBox.Show("Account successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                action = "edit";
                                                                shadow();
                                                                clear_action = "edit";
                                                                ClearForms();
                                                                clear_action = "add";
                                                                ClearForms();
                                                                btnEdit.Enabled = false;
                                                                btnEdit.BackColor= SystemColors.WindowFrame;
                                                                getInfo();
                                                                break;
                                                            }
                                                        case "deactivated":
                                                            {
                                                                PasswordGenerator();
                                                                KeyGenerator();
                                                                txtRecovery.Text = finalString;
                                                                string recoverykeylife = DateTime.Now.ToString("HH:mm:ss");
                                                                string forUpdate = "update " + lblDatabase_.Text + ".tbl_users" + " set workgroup = '" + account_workgroup + "', usertype = '" + cboUserType.Text + "', firstname = '" + txtFirstName.Text + "', lastname = '" + txtLastName.Text + "', middleinitial = '" + txtMiddleInitial.Text + "', contactnumber = '" + txtContactNumber.Text + "', status = '" + cboStatus.Text + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                                                                Program.Query(forUpdate).Close();
                                                                MessageBox.Show("Account successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                action = "edit";
                                                                shadow();
                                                                clear_action = "edit";
                                                                ClearForms();
                                                                clear_action = "add";
                                                                ClearForms();
                                                                btnEdit.Enabled = false;
                                                                btnEdit.BackColor = SystemColors.WindowFrame;
                                                                getInfo();
                                                                break;
                                                            }
                                                    }
                                                }
                                                else
                                                {
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Last name is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                txtLastName.Focus();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("First name is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            txtFirstName.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Account status required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        cboStatus.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Workgroup required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cboWorkgroup.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("User Type required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cboUserType.Focus();
                            }
                        }
                        break;
                    }
            }
        }
        private void btnLess_Click(object sender, EventArgs e)
        {
            int counter = 50;
            while (counter != 0)
            {
                counter--;
                tableshow--;
                limiter--;
                if (limiter == 0)
                {
                    btnLess.Enabled = false;
                    btnLess.BackColor= SystemColors.WindowFrame;
                    counter = 0;
                }
            }
            getInfo();
            btnMore.Enabled = true;
            btnMore.BackColor = SystemColors.Control;
            txtShowRow.Text = tableshow.ToString();
            txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
        }
        private void btnMore_Click(object sender, EventArgs e)
        {
            int disabler = (tableshow + lsvData.Items.Count + 50);
            if (disabler >= int.Parse(count))
            {
                btnMore.Enabled = false;
                btnMore.BackColor = SystemColors.WindowFrame;
            }
            int counter = 0;
            while (counter != 50)
            {
                counter++;
                tableshow++;
                limiter++;
                if (limiter == int.Parse(count))
                {
                    btnMore.Enabled = false;
                    btnMore.BackColor = SystemColors.WindowFrame;
                    counter = 50;
                }
            }
            getInfo();
            btnLess.Enabled = true;
            btnLess.BackColor= SystemColors.WindowFrame;
            txtShowRow.Text = tableshow.ToString();
            if (limiter == int.Parse(count))
            {
                txtRow.Text = lsvData.Items.Count.ToString();
            }
            else
            {
                txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cboSearchType.SelectedIndex)
            {
                case 1:
                    {
                        string line;
                        StreamReader file = new StreamReader("config.ini");
                        while ((line = file.ReadLine()) != null)
                        {
                            read = line;
                            line = line.Remove(4, line.Length - 4);
                            if (line == "ip_a")
                            {
                                read = read.Remove(0, 11);
                            }
                        }
                        file.Close();
                        string ConnectionString = "datasource=" + read + ";port=3306;username=root;password=mySQL09122016;";
                        MySqlConnection conn = new MySqlConnection("datasource= " + read + ";port=3306;username=root;password=mySQL09122016");
                        string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_users" + " where username like '" + txtSearch.Text + "%" + "' and username not like '" + "adminpldt" + "'";
                        MySqlCommand query_ = new MySqlCommand(que, conn);
                        conn.Open();
                        count = query_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow.Text = count;
                        resetCounter();
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username like '" + txtSearch.Text + "%" + "' and username not like '" + "adminpldt" + "' order by username limit " + tableshow + "," + tablecount;
                        MySqlDataReader reader = Program.Query(query);
                        lsvData.Items.Clear();
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(8));
                            lst.SubItems.Add(reader.GetString(4) + " " + reader.GetString(6) + " " + reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(7));
                            lsvData.Items.Add(lst);
                        }
                        reader.Close();
                        foreach (ListViewItem lst in lsvData.Items)
                        {
                            usertype = lst.SubItems[1].ToString();
                            status = lst.SubItems[3].ToString();

                            if (usertype == "ListViewSubItem: {user}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Wheat;
                            }
                            else if (usertype == "ListViewSubItem: {admin}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Aquamarine;
                            }
                            else
                            {
                                lst.BackColor = Color.LightGray;
                            }
                        }
                        buttonReader();
                        if (lsvData.Items.Count == 0)
                        {
                            lblCount.Text = "No records found.";
                            lblCount.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblCount.Text = txtTotalRow.Text + " record/s found.";
                            lblCount.ForeColor = Color.Black;
                        }
                        break;
                    }
                case 2:
                    {
                        string line;
                        StreamReader file = new StreamReader("config.ini");
                        while ((line = file.ReadLine()) != null)
                        {
                            read = line;
                            line = line.Remove(4, line.Length - 4);
                            if (line == "ip_a")
                            {
                                read = read.Remove(0, 11);
                            }
                        }
                        file.Close();
                        string ConnectionString = "datasource=" + read + ";port=3306;username=root;password=mySQL09122016;";
                        MySqlConnection conn = new MySqlConnection("datasource= " + read + ";port=3306;username=root;password=mySQL09122016");
                        string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_users" + " where workgroup like '" + txtSearch.Text + "%" + "' and username not like '" + "adminpldt" + "'";
                        MySqlCommand query_ = new MySqlCommand(que, conn);
                        conn.Open();
                        count = query_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow.Text = count;
                        resetCounter();
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where workgroup like '" + txtSearch.Text + "%" + "' and username not like '" + "adminpldt" + "' order by workgroup limit " + tableshow + "," + tablecount;
                        MySqlDataReader reader = Program.Query(query);
                        lsvData.Items.Clear();
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(8));
                            lst.SubItems.Add(reader.GetString(4) + " " + reader.GetString(6) + " " + reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(7));
                            lsvData.Items.Add(lst);
                        }
                        reader.Close();
                        foreach (ListViewItem lst in lsvData.Items)
                        {
                            usertype = lst.SubItems[1].ToString();
                            status = lst.SubItems[3].ToString();

                            if (usertype == "ListViewSubItem: {user}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Wheat;
                            }
                            else if (usertype == "ListViewSubItem: {admin}" && status != "ListViewSubItem: {deactivated}")
                            {
                                lst.BackColor = Color.Aquamarine;
                            }
                            else
                            {
                                lst.BackColor = Color.LightGray;
                            }
                        }
                        buttonReader();
                        if (lsvData.Items.Count == 0)
                        {
                            lblCount.Text = "No records found.";
                            lblCount.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblCount.Text = txtTotalRow.Text + " record/s found.";
                            lblCount.ForeColor = Color.Black;
                        }
                        break;
                    }
            }
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            btnMore.Enabled = false;
            btnMore.BackColor= SystemColors.WindowFrame;
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            btnMore.Enabled = true;
            btnMore.BackColor = SystemColors.Control;
            btnSearch.PerformClick();
        }
        string passchecker;
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (username == lblUsername_.Text)
            {
                MessageBox.Show("Selected account is being used for Force Log-out feature.\nAction is invalid", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (btnLogout.Text)
            {
                case "Force Log-out":
                    {
                        btnLogout.Text = "Cancel";
                        txtLogout.Text = "";
                        lblLogout.Visible = true;
                        txtLogout.Visible = true;
                        grbSearch.Enabled = false;
                        grbSearch.BackColor= SystemColors.WindowFrame;
                        grbScroll.Enabled = false;
                        grbScroll.BackColor = SystemColors.WindowFrame;
                        grbDetails.Enabled = false;
                        grbDetails.BackColor= SystemColors.WindowFrame;
                        grbPassword.Enabled = false;
                        grbPassword.BackColor= SystemColors.WindowFrame;
                        lsvData.Enabled = false;
                        lsvData.BackColor= SystemColors.WindowFrame;
                        AcceptButton = btnLogout;
                        txtLogout.Focus();
                        break;
                    }
                case "Cancel":
                    {
                        btnLogout.Text = "Force Log-out";
                        lblLogout.Visible = false;
                        txtLogout.Visible = false;
                        grbSearch.Enabled = true;
                        grbSearch.BackColor = SystemColors.Control;
                        grbScroll.Enabled = true;
                        grbScroll.BackColor = SystemColors.Control;
                        grbDetails.Enabled = true;
                        grbDetails.BackColor = SystemColors.Control;
                        grbPassword.Enabled = true;
                        grbPassword.BackColor = SystemColors.Control;
                        lsvData.Enabled = true;
                        lsvData.BackColor = SystemColors.ControlDark;
                        AcceptButton = null;
                        break;
                    }
                case "Confirm":
                    {
                        string forPassword = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + lblUsername_.Text + "'";
                        MySqlDataReader passwordchecker = Program.Query(forPassword);
                        while (passwordchecker.Read())
                        {
                            passchecker = passwordchecker.GetString(1);
                        }
                        passwordchecker.Close();
                        if (passchecker == txtLogout.Text)
                        {
                            string forCurrent = "Select * from " + lblDatabase_.Text + ".tbl_current" + " where username collate latin1_general_cs like '" + username + "'";
                            MySqlDataReader userchecker = Program.Query(forCurrent);
                            if (!userchecker.Read())
                            {
                                MessageBox.Show("User is not currently logged in.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLogout.Text = "Force Log-out";
                                lblLogout.Visible = false;
                                txtLogout.Visible = false;
                                grbSearch.Enabled = true;
                                grbSearch.BackColor = Color.DarkSeaGreen;
                                grbDetails.Enabled = true;
                                grbDetails.BackColor = Color.DarkSeaGreen;
                                grbScroll.Enabled = true;
                                grbScroll.BackColor = Color.DarkSeaGreen;
                                grbPassword.Enabled = true;
                                grbPassword.BackColor = Color.DarkSeaGreen;
                                lsvData.Enabled = true;
                                lsvData.BackColor = SystemColors.ControlDark;
                                AcceptButton = null;
                            }
                            else
                            {
                                if (MessageBox.Show("WARNING: The selected account will be forcefully logged out of the system!\n\nDo you want to force log-out this account?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                                {
                                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_current" + " from " + lblDatabase_.Text + ".tbl_current" + " where username collate latin1_general_cs like '" + username + "'";
                                    Program.Query(forDelete).Close();
                                    MessageBox.Show("Account [ " + username + " ] was logged out.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnLogout.Text = "Force Log-out";
                                    lblLogout.Visible = false;
                                    txtLogout.Visible = false;
                                    grbSearch.Enabled = true;
                                    grbSearch.BackColor = Color.DarkSeaGreen;
                                    grbDetails.Enabled = true;
                                    grbDetails.BackColor = Color.DarkSeaGreen;
                                    grbScroll.Enabled = true;
                                    grbScroll.BackColor = Color.DarkSeaGreen;
                                    grbPassword.Enabled = true;
                                    grbPassword.BackColor = Color.DarkSeaGreen;
                                    lsvData.Enabled = true;
                                    lsvData.BackColor = SystemColors.ControlDark;
                                    AcceptButton = null;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid password.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnLogout.Text = "Force Log-out";
                            lblLogout.Visible = false;
                            txtLogout.Visible = false;
                            grbSearch.Enabled = true;
                            grbSearch.BackColor = Color.DarkSeaGreen;
                            grbDetails.Enabled = true;
                            grbDetails.BackColor = Color.DarkSeaGreen;
                            grbScroll.Enabled = true;
                            grbScroll.BackColor = Color.DarkSeaGreen;
                            grbPassword.Enabled = true;
                            grbPassword.BackColor = Color.DarkSeaGreen;
                            lsvData.Enabled = true;
                            lsvData.BackColor = SystemColors.ControlDark;
                            AcceptButton = null;
                        }
                        break;
                    }
            }
        }

        private void txtLogout_TextChanged(object sender, EventArgs e)
        {
            if (txtLogout.Text.Trim() == "" && btnLogout.Text == "Confirm")
            {
                btnLogout.Text = "Cancel";
            }
            else if (txtLogout.Text.Trim() != "" && btnLogout.Text == "Cancel")
            {
                btnLogout.Text = "Confirm";
            }
        }

        private void txtLogout_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
