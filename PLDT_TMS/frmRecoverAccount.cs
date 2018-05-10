using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace PLDT_TMS
{
    public partial class frmRecoverAccount : Form
    {
        public frmRecoverAccount()
        {
            InitializeComponent();
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
        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtVerifyPassword_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtRecoveryKey_KeyPress(object sender, KeyPressEventArgs e)
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
        bool validusername = false;
        bool validworkgroup = false;
        string workgroup;
        string active;
        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() != "")
            {
                string forReader_username = "Select * from " + txtDatabase.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                MySqlDataReader reader_username = Program.Query(forReader_username);
                {
                    if (reader_username.Read())
                    {
                        workgroup = reader_username.GetString(2);
                        active = reader_username.GetString(8);
                        validusername = true;
                    }
                    reader_username.Close();
                    if (workgroup == cboWorkgroup.Text)
                    {
                        validworkgroup = true;
                    }
                    string forReader_usertype = "Select * from " + txtDatabase.Text + ".tbl_users" + " where usertype like '" + "admin" + "' and username collate latin1_general_cs like '" + txtUsername.Text + "'";
                    MySqlDataReader reader_usertype = Program.Query(forReader_usertype);
                    if (reader_usertype.Read() == true)
                    {
                        validworkgroup = true;
                        MessageBox.Show(workgroup);
                    }
                    reader_usertype.Close();
                    if (validworkgroup == true && validusername == true)
                    {
                        if (active == "activated")
                        {
                            grbUsername.Enabled = false;
                            grbUsername.BackColor = SystemColors.WindowFrame;
                            grbPassword.Enabled = true;
                            grbPassword.BackColor= Color.LightGray;
                        }
                        else
                        {
                            MessageBox.Show("Account is deactivated. Please consult your administrator.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Account is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }
            else
            {
                MessageBox.Show("Username is required.","System",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsername.Focus();
            }
        }
        string recoverykey;
        int counter;
        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim() != "")
            {
                if (txtNewPassword.Text.Length > 5)
                {
                    if (txtVerifyPassword.Text.Trim() != "")
                    {
                        if (txtVerifyPassword.Text.Length > 5)
                        {
                            if (txtNewPassword.Text == txtVerifyPassword.Text)
                            {
                                if (txtRecoveryKey.Text.Length == txtRecoveryKey.MaxLength)
                                {
                                    string forReader = "Select * from " + txtDatabase.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                    MySqlDataReader reader = Program.Query(forReader);
                                    while (reader.Read())
                                    {
                                        recoverykey = reader.GetString(9);
                                    }
                                    reader.Close();
                                    if (recoverykey != "00000000")
                                    {
                                        if (recoverykey == txtRecoveryKey.Text)
                                        {
                                            string forUpdate = "update " + txtDatabase.Text + ".tbl_users" + " set password = '" + txtNewPassword.Text + "', recoverykey = '" + "00000000" + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                                            Program.Query(forUpdate).Close();
                                            MessageBox.Show("Your account [" + txtUsername.Text + "] at workgroup [" + cboWorkgroup.Text + "] has been successfully recovered. Please restart application.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            action = "account";
                                            shadow();
                                            Application.Exit();
                                        }
                                        else
                                        {
                                            counter++;
                                            if (counter == 3)
                                            {
                                                Application.Exit();
                                            }
                                            MessageBox.Show("Invalid recovery key.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No recovery key has been generated for this account or the key may already had expired. Please consult your administrator.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Application.Exit();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Recovery key length is not valid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtRecoveryKey.Select(0, txtRecoveryKey.MaxLength);
                                    txtRecoveryKey.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Verify password length is too short", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtNewPassword.Select(0, txtNewPassword.MaxLength);
                                txtNewPassword.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Passwords do not match", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNewPassword.Text = "";
                            txtVerifyPassword.Text = "";
                            txtNewPassword.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Verify password length is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNewPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("New password length is too short", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Select(0, txtNewPassword.MaxLength);
                    txtNewPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("New password length is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Focus();
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
        private void btnVerifyDatabase_Click(object sender, EventArgs e)
        {
            if (txtDatabase.Text.Trim() != "")
            {
                MySqlDataReader reader = Program.Query("Select * from login_tms.tbl_database where databasename collate latin1_general_cs like '" + txtDatabase.Text + "'");
                {
                    if (reader.Read())
                    {
                        grbUsername.Enabled = true;
                        grbUsername.BackColor= Color.LightGray;
                        grbDatabase.Enabled = false;
                        grbDatabase.BackColor = SystemColors.WindowFrame;
                        string forReader_workgroup = "Select * from " + txtDatabase.Text + ".tbl_workgroup" + " order by workgroup";
                        MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                        while (reader_workgroup.Read())
                        {
                            cboWorkgroup.Items.Add(reader_workgroup.GetString(0));
                        }
                        reader_workgroup.Close();
                        string forReader_recoverykey = "Select * from " + txtDatabase.Text + ".tbl_users" + " where recoverykey not like '" + "00000000" + "'";
                        MySqlDataReader reader_recoverykey = Program.Query(forReader_recoverykey);
                        while (reader_recoverykey.Read())
                        {
                            cboData.Items.Add(reader_recoverykey.GetString(0));
                        }
                        reader_recoverykey.Close();
                        for (int i = 0; i < cboData.Items.Count; i++)
                        {
                            string value = cboData.GetItemText(cboData.Items[i]);
                            string forReader_cboData = "Select * from " + txtDatabase.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + value + "'";
                            MySqlDataReader reader_cboData = Program.Query(forReader_cboData);
                            while (reader_cboData.Read())
                            {
                                DateTime t1 = Convert.ToDateTime(reader_cboData.GetString(10));
                                t1 = t1.AddMinutes(10);
                                DateTime now = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                                int time = DateTime.Compare(t1, now);
                                if (time <= 0)
                                {
                                    string forUpdate = "update " + txtDatabase.Text + ".tbl_users" + " set recoverykey = '" + "00000000" + "' where username collate latin1_general_cs = '" + value + "'";
                                    Program.Query(forUpdate).Close();
                                }
                            }
                            reader_cboData.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid database.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    reader.Close();
                }
            }
            else
                {
                    MessageBox.Show("Database name is required.","System",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtDatabase.Focus();
                }
        }
        private void btnVerifyReset_Click(object sender, EventArgs e)
        {
            if (txtDatabaseReset.Text.Trim() != "")
            {
                MySqlDataReader reader = Program.Query("Select * from login_tms.tbl_database where databasename collate latin1_general_cs like '" + txtDatabaseReset.Text + "'");
                {
                    if (reader.Read())
                    {
                        grbAccountReset.Enabled = true;
                        grbAccountReset.BackColor= Color.LightGray;
                        grbDatabaseReset.Enabled = false;
                        grbDatabaseReset.BackColor = SystemColors.WindowFrame;
                    }
                    else
                    {
                        MessageBox.Show("Invalid database.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    reader.Close();
                }
            }
            else
            {
                MessageBox.Show("Database name is required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDatabaseReset.Focus();
            }
        }
        private void btnResetProgram_Click(object sender, EventArgs e)
        {
            if (txtUsernameReset.Text.Trim() != "")
            {
                if (txtPasswordReset.Text.Trim() != "")
                {
                    if (txtUsernameReset.Text == "adminpldt" && txtPasswordReset.Text == "pLdt@dm1n_1928")
                    {
                        string forUpdate = "update " + txtDatabaseReset.Text + ".tbl_app" + " set enablelog = '" + "0" + "'";
                        Program.Query(forUpdate).Close();
                        string forDelete = "truncate table " + txtDatabaseReset.Text + ".tbl_current";
                        Program.Query(forDelete).Close();
                        string forUpdate2 = "update " + txtDatabaseReset.Text + ".tbl_usercount" + " set usercount = '" + "0" + "'";
                        Program.Query(forUpdate2).Close();
                        action = "program";
                        shadow();
                        MessageBox.Show("Program reset successful.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Account is invalid or is not allowed for this action.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("Password is required", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username is required.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
        }
        private void txtDatabaseReset_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPasswordReset_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtUsernameReset_KeyPress(object sender, KeyPressEventArgs e)
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
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        grbDatabase.Enabled = true;
                        grbDatabase.BackColor= Color.LightGray;
                        grbUsername.Enabled = false;
                        grbUsername.BackColor = SystemColors.WindowFrame;
                        grbPassword.Enabled = false;
                        grbPassword.BackColor = SystemColors.WindowFrame;
                        txtUsername.Text = "";
                        txtDatabase.Text = "";
                        cboWorkgroup.Text = "";
                        cboWorkgroup.SelectedIndex = -1;
                        txtRecoveryKey.Text = "";
                        txtVerifyPassword.Text = "";
                        txtNewPassword.Text = "";
                        txtDatabase.Focus();
                        AcceptButton = btnVerifyReset;
                        break;
                    }
                case 1:
                    {
                        grbAccountReset.Enabled = false;
                        grbAccountReset.BackColor = SystemColors.WindowFrame;
                        txtPasswordReset.Text = "";
                        txtUsernameReset.Text = "";
                        grbDatabaseReset.Enabled = true;
                        grbDatabaseReset.BackColor= Color.LightGray;
                        txtDatabaseReset.Text = "";
                        txtDatabaseReset.Focus();
                        AcceptButton = btnVerifyDatabase;
                        break;
                    }
            }
        }
        private void frmRecoverAccount_Load(object sender, EventArgs e)
        {
            txtDatabase.Focus();
        }
        string activity;
        string action;
        private void shadow()
        {
            switch (action)
            {
                case "account":
                    {
                        activity = "Account [ " + txtUsername.Text + " ] was recovered.";
                        break;
                    }
                case "program":
                    {
                        activity = "Program reset was done.";
                        break;
                    }
            }
            shadowTrail();
        }
        private void shadowTrail()
        {
            switch (action)
            {
                case "account":
                    {
                        string username = txtUsername.Text;
                        string workgroup = cboWorkgroup.Text;
                        string databasename = txtDatabase.Text;
                        Program.AuditTrail(activity, username, workgroup, databasename);
                        break;
                    }
                case "program":
                    {
                        string username = "adminpldt";
                        string workgroup = "admin";
                        string databasename = txtDatabaseReset.Text;
                        Program.AuditTrail(activity, username, workgroup, databasename);
                        break;
                    }
            }
        }
    }
}