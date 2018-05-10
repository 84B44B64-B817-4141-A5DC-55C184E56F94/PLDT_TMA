using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace PLDT_TMS
{
    public partial class frmUserMaintenance : Form
    {
        //IMPORTANT
        public string username_;
        public string workgroup_;
        public string db_;
        //IMPORTANT
        public frmUserMaintenance()
        {
            InitializeComponent();
        }
        private void frmUserMaintenance_Load(object sender, EventArgs e)
        {
            lblDatabase_.Text = db_;
            string forReader = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
            MySqlDataReader reader = Program.Query(forReader);
            while (reader.Read())
            {
                txtFirstName.Text = reader.GetString(4);
                txtMiddleInitial.Text = reader.GetString(6);
                txtLastName.Text = reader.GetString(5);
                txtContactNumber.Text = reader.GetString(7);
            }
            reader.Close();
        }
        private void txtContactDetails_KeyPress(object sender, KeyPressEventArgs e)
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
        string firstname;
        string lastname;
        string middleinitial;
        string contactnumber;
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
                        btnClose.Text = "Close";
                        btnDetails.Text = "Change details";
                        grbPassword.Enabled = true;
                        grbPassword.BackColor = Color.DarkSeaGreen;
                        break;
                    }
            }
        }
        private void ClearForms()
        {
            txtFirstName.Text = firstname;
            txtLastName.Text = lastname;
            txtMiddleInitial.Text = middleinitial;
            txtContactNumber.Text = contactnumber;
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtMiddleInitial.ReadOnly = true;
            txtContactNumber.ReadOnly = true;
        }
        string action;
        string activity;
        private void shadow()
        {
                if (action == "user details")
                {
                    activity = txtUsername.Text + " details changed.";
                }
                else if (action == "password")
                {
                    activity = txtUsername.Text + " password changed.";
                }
            shadowTrail();
        }
        private void shadowTrail()
        {
            string username = txtUsername.Text;
            string workgroup = txtWorkgroup.Text;
            string databasename = lblDatabase_.Text;
            Program.AuditTrail(activity, username, workgroup, databasename);
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            switch (btnDetails.Text)
            {
                case "Change details":
                    {
                        firstname = txtFirstName.Text;
                        lastname = txtLastName.Text;
                        middleinitial = txtMiddleInitial.Text;
                        contactnumber = txtContactNumber.Text;
                        btnDetails.Text = "Save details";
                        btnClose.Text = "Reset";
                        grbPassword.Enabled = false;
                        grbPassword.BackColor = SystemColors.WindowFrame;
                        txtFirstName.ReadOnly = false;
                        txtLastName.ReadOnly = false;
                        txtMiddleInitial.ReadOnly = false;
                        txtContactNumber.ReadOnly = false;
                        break;
                    }
                case "Save details":
                    {
                        if (txtContactNumber.Text.Trim() == "")
                        {
                            txtContactNumber.Text = "N/A";
                        }

                        if (MessageBox.Show("User details:\n\nFirst Name: " + firstname + " >>> " + txtFirstName.Text + "\nMiddle Initial: " + middleinitial + " >>> " + txtMiddleInitial.Text + "\nLast Name: " + lastname + " >>> " + txtLastName.Text + "\nContact Details: " + contactnumber + " >>> " + txtContactNumber.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            string forUpdate = "update " + lblDatabase_.Text + ".tbl_users" + " set firstname = '" + txtFirstName.Text + "', lastname = '" + txtLastName.Text + "', middleinitial= '" + txtMiddleInitial.Text + "', contactnumber=  '" + txtContactNumber.Text + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                            Program.Query(forUpdate).Close();
                            action = "user details";
                            shadow();
                            MessageBox.Show("User details successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            firstname = txtFirstName.Text;
                            lastname = txtLastName.Text;
                            middleinitial = txtMiddleInitial.Text;
                            contactnumber = txtContactNumber.Text;
                            btnDetails.Text = "Change details";
                            btnClose.Text = "Close";
                            ClearForms();
                            grbPassword.Enabled = true;
                            grbPassword.BackColor = Color.DarkSeaGreen;
                        }
                        else
                        {
                            return;
                        }
                        break;
                    }
            }
        }
        string password;
        private void btnPassword_Click(object sender, EventArgs e)
        {
            switch (btnPassword.Text)
            {
                case "Change Password":
                    {
                        txtNewPassword.Enabled = true;
                        txtNewPassword.BackColor = SystemColors.Control;
                        txtVerifyPassword.Enabled = true;
                        txtVerifyPassword.BackColor = SystemColors.Control;
                        txtOldPassword.Text = "";
                        txtOldPassword.ReadOnly = false;
                        btnPassword.Text = "Update Password";
                        grbDetails.Enabled = false;
                        grbDetails.BackColor = SystemColors.WindowFrame;
                        break;
                    }
                case "Update Password":
                    {
                        if (txtOldPassword.Text.Trim() != "")
                        {
                            if (txtNewPassword.Text.Length > 5)
                            {
                                if (txtNewPassword.Text.Trim() != "")
                                {
                                    if (txtNewPassword.Text.Length > 5)
                                    {
                                        if (txtVerifyPassword.Text.Trim() != "")
                                        {
                                            if (txtVerifyPassword.Text.Length > 5)
                                            {
                                                if (MessageBox.Show("Update password?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                {
                                                    string forReader = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + txtUsername.Text + "'";
                                                    MySqlDataReader reader = Program.Query(forReader);
                                                    while (reader.Read())
                                                    {
                                                        password = reader.GetString(1);
                                                    }
                                                    reader.Close();
                                                    if (password == txtOldPassword.Text)
                                                    {
                                                        if (txtNewPassword.Text == txtVerifyPassword.Text)
                                                        {
                                                            if (txtNewPassword.Text != txtOldPassword.Text)
                                                            {
                                                                string forUpdate = "update " + lblDatabase_.Text + ".tbl_users" + " set password = '" + txtNewPassword.Text + "' where username collate latin1_general_cs = '" + txtUsername.Text + "'";
                                                                Program.Query(forUpdate).Close();
                                                                MessageBox.Show("Password successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                action = "password";
                                                                shadow();
                                                                password = "";
                                                                txtNewPassword.Text = "";
                                                                txtVerifyPassword.Text = "";
                                                                txtOldPassword.Text = "00000000000000000000";
                                                                txtOldPassword.ReadOnly = true;
                                                                txtNewPassword.Enabled = false;
                                                                txtNewPassword.BackColor = SystemColors.WindowFrame;
                                                                txtVerifyPassword.Enabled = false;
                                                                txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                                                btnPassword.Text = "Change Password";
                                                                grbDetails.Enabled = true;
                                                                grbDetails.BackColor = Color.DarkSeaGreen;
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Password is still the same.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                txtNewPassword.Text = "";
                                                                password = "";
                                                                txtVerifyPassword.Text = "";
                                                                txtOldPassword.Text = "00000000000000000000";
                                                                txtOldPassword.ReadOnly = true;
                                                                txtNewPassword.Enabled = false;
                                                                txtNewPassword.BackColor = SystemColors.WindowFrame;
                                                                txtVerifyPassword.Enabled = false;
                                                                txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                                                btnPassword.Text = "Change Password";
                                                                grbDetails.Enabled = true;
                                                                grbDetails.BackColor = Color.DarkSeaGreen;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Passwords in [New Password] and [Verify Password] do not match.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            txtNewPassword.Text = "";
                                                            password = "";
                                                            txtVerifyPassword.Text = "";
                                                            txtOldPassword.Text = "00000000000000000000";
                                                            txtOldPassword.ReadOnly = true;
                                                            txtNewPassword.Enabled = false;
                                                            txtNewPassword.BackColor = SystemColors.WindowFrame;
                                                            txtVerifyPassword.Enabled = false;
                                                            txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                                            btnPassword.Text = "Change Password";
                                                            grbDetails.Enabled = true;
                                                            grbDetails.BackColor = Color.DarkSeaGreen;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Wrong old password.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        txtNewPassword.Text = "";
                                                        password = "";
                                                        txtVerifyPassword.Text = "";
                                                        txtOldPassword.Text = "00000000000000000000";
                                                        txtOldPassword.ReadOnly = true;
                                                        txtNewPassword.Enabled = false;
                                                        txtVerifyPassword.Enabled = false;
                                                        grbDetails.Enabled = true;
                                                        btnPassword.Text = "Change Password";
                                                    }
                                                }
                                                else
                                                {
                                                    txtNewPassword.Text = "";
                                                    txtVerifyPassword.Text = "";
                                                    password = "";
                                                    txtOldPassword.Text = "00000000000000000000";
                                                    txtOldPassword.ReadOnly = true;
                                                    txtNewPassword.Enabled = false;
                                                    txtNewPassword.BackColor = SystemColors.WindowFrame;
                                                    grbDetails.Enabled = true;
                                                    grbDetails.BackColor = Color.DarkSeaGreen;
                                                    txtVerifyPassword.Enabled = false;
                                                    txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                                    btnPassword.Text = "Change Password";
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Verify password length is too short.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                txtNewPassword.Text = "";
                                                password = "";
                                                txtVerifyPassword.Text = "";
                                                txtOldPassword.Text = "00000000000000000000";
                                                txtOldPassword.ReadOnly = true;
                                                grbDetails.Enabled = true;
                                                grbDetails.BackColor = Color.DarkSeaGreen;
                                                txtNewPassword.Enabled = false;
                                                txtNewPassword.BackColor = SystemColors.WindowFrame;
                                                txtVerifyPassword.Enabled = false;
                                                txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                                btnPassword.Text = "Change Password";
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Verify password is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            txtNewPassword.Text = "";
                                            password = "";
                                            txtVerifyPassword.Text = "";
                                            txtOldPassword.Text = "00000000000000000000";
                                            txtOldPassword.ReadOnly = true;
                                            txtNewPassword.Enabled = false;
                                            txtNewPassword.BackColor = SystemColors.WindowFrame;
                                            grbDetails.Enabled = true;
                                            grbDetails.BackColor = Color.DarkSeaGreen;
                                            txtVerifyPassword.Enabled = false;
                                            txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                            btnPassword.Text = "Change Password";
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("New password length is too short.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtNewPassword.Text = "";
                                        password = "";
                                        txtVerifyPassword.Text = "";
                                        txtOldPassword.Text = "00000000000000000000";
                                        txtOldPassword.ReadOnly = true;
                                        txtNewPassword.Enabled = false;
                                        txtNewPassword.BackColor = SystemColors.WindowFrame;
                                        grbDetails.Enabled = true;
                                        grbDetails.BackColor = Color.DarkSeaGreen;
                                        txtVerifyPassword.Enabled = false;
                                        txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                        btnPassword.Text = "Change Password";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("New password is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtNewPassword.Text = "";
                                    password = "";
                                    txtVerifyPassword.Text = "";
                                    txtOldPassword.Text = "00000000000000000000";
                                    txtOldPassword.ReadOnly = true;
                                    txtNewPassword.Enabled = false;
                                    txtNewPassword.BackColor = SystemColors.WindowFrame;
                                    txtVerifyPassword.Enabled = false;
                                    txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                    grbDetails.Enabled = true;
                                    grbDetails.BackColor = Color.DarkSeaGreen;
                                    btnPassword.Text = "Change Password";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Old password length is too short.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtNewPassword.Text = "";
                                password = "";
                                txtVerifyPassword.Text = "";
                                txtOldPassword.Text = "00000000000000000000";
                                txtOldPassword.ReadOnly = true;
                                txtNewPassword.Enabled = false;
                                txtNewPassword.BackColor = SystemColors.WindowFrame;
                                grbDetails.Enabled = true;
                                grbDetails.BackColor = Color.DarkSeaGreen;
                                txtVerifyPassword.Enabled = false;
                                txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                                btnPassword.Text = "Change Password";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Old password is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNewPassword.Text = "";
                            password = "";
                            txtVerifyPassword.Text = "";
                            txtOldPassword.Text = "00000000000000000000";
                            txtOldPassword.ReadOnly = true;
                            txtNewPassword.Enabled = false;
                            txtNewPassword.BackColor = SystemColors.WindowFrame;
                            txtVerifyPassword.Enabled = false;
                            txtVerifyPassword.BackColor = SystemColors.WindowFrame;
                            grbDetails.Enabled = true;
                            grbDetails.BackColor = Color.DarkSeaGreen;
                            btnPassword.Text = "Change Password";
                        }
                        break;
                    }
            }
        }
    }
}