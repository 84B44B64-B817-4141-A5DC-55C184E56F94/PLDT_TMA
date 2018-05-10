using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PLDT_TMS
{
    public partial class frmEndorseTickets : Form
    {
        //IMPORTANT
        public string usertype_;
        public string username_;
        public string workgroup_;
        public string db_;
        string read;
        //IMPORTANT
        public frmEndorseTickets()
        {
            InitializeComponent();
        }
        private void txtTicketNumber_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtTicketNumber_TextChanged(object sender, EventArgs e)
        {
            buttonHandler();
        }
        void buttonHandler()
        {
            if (cboEndorsee.Text.Trim() != "" && txtNote.Text.Trim() != "" && cboWorkgroup.Text.Trim() != "")
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
            if (cboEndorsee.Text.Trim() != "" || txtNote.Text.Trim() != "" || cboWorkgroup.Text.Trim() != "")
            {
                btnCancel.Text = "Reset";
            }
            else
            {
                btnCancel.Text = "Close";
            }
        }
        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            buttonHandler();
        }
        private void cboEndorsee_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonHandler();
        }
        private void fmrEndorseTickets_Load(object sender, EventArgs e)
        {
            lblDatabase_.Text = db_;
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;
            string forReader_username = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + lblUsername_.Text + "'";
            MySqlDataReader reader_username = Program.Query(forReader_username);
            while (reader_username.Read())
            {
                txtEndorser.Text = reader_username.GetString(5) + ", " + reader_username.GetString(4) + " " + reader_username.GetString(6) + ".";
                txtFromWorkgroup.Text = reader_username.GetString(2);
            }
            reader_username.Close();
            string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup";
            MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
            while (reader_workgroup.Read())
            {
                cboWorkgroup.Items.Add(reader_workgroup.GetString(0));
            }
            reader_workgroup.Close();
            cboEndorsee.Items.Add("Morning Shift");
            cboEndorsee.Items.Add("Afternoon Shift");
            cboEndorsee.Items.Add("Graveyard Shift");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Reset")
            {
                cboEndorsee.Text = "";
                cboEndorsee.SelectedIndex = -1;
                cboWorkgroup.Text = "";
                cboWorkgroup.SelectedIndex = -1;
                txtNote.Text = "";
                chkAdmin.Checked = false;
            }
            else
            {
                Close();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save this endorsement?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string forReader = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where ticketnumber like '" + txtTicketNumber.Text + "' and status not like '" + "Noted" + "'";
                MySqlDataReader reader = Program.Query(forReader);
                if (reader.Read() != true)
                {
                    string dateendorsed = dtpEndorsedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    if (chkAdmin.Checked == false)
                    {
                        string forInsert = "Insert into " + lblDatabase_.Text + ".tbl_endorsements" + "(ticketnumber,endorser,endorsedate,endorsee,workgroup,note,status,statusdate) Values ('" + txtTicketNumber.Text + "','" + txtEndorser.Text + "','" + dateendorsed + "','" + cboEndorsee.Text + "','" + cboWorkgroup.Text + "','" + txtNote.Text + "','" + "Open" + "','" + dateendorsed + "')";
                        Program.Query(forInsert).Close();
                    }
                    else
                    {
                        string forInsert = "Insert into " + lblDatabase_.Text + ".tbl_endorsements" + "(ticketnumber,endorser,endorsedate,endorsee,workgroup,note,status,statusdate) Values ('" + txtTicketNumber.Text + "','" + txtEndorser.Text + "','" + dateendorsed + "','" + cboEndorsee.Text + "','" + "admin" + "','" + txtNote.Text + "','" + "Open" + "','" + dateendorsed + "')";
                        Program.Query(forInsert).Close();
                    }
                    shadow();
                    MessageBox.Show("Endorsement successfully filed.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    if (MessageBox.Show("Ticket is already endorsed. Re-endorse ticket?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string dateendorsed = dtpEndorsedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        if (chkAdmin.Checked == false)
                        {
                            string forUpdate = "update " + lblDatabase_.Text + ".tbl_endorsements" + " set ticketnumber = '" + txtTicketNumber.Text + "', endorser = '" + txtEndorser.Text + "', endorsedate = '" + dateendorsed + "', endorsee = '" + cboEndorsee.Text + "', workgroup = '" + cboWorkgroup.Text + "', note = '" + txtNote.Text + "', status = '" + "Open" + "', statusdate = '" + dateendorsed + "' where ticketnumber like '" + txtTicketNumber.Text + "'";
                            Program.Query(forUpdate).Close();
                        }
                        else
                        {
                            string forUpdate = "update " + lblDatabase_.Text + ".tbl_endorsements" + " set ticketnumber = '" + txtTicketNumber.Text + "', endorser = '" + txtEndorser.Text + "', endorsedate = '" + dateendorsed + "', endorsee = '" + cboEndorsee.Text + "', workgroup = '" + "admin" + "', note = '" + txtNote.Text + "', status = '" + "Open" + "', statusdate = '" + dateendorsed + "' where ticketnumber like '" + txtTicketNumber.Text + "'";
                            Program.Query(forUpdate).Close();
                        }
                        shadow();
                        MessageBox.Show("Endorsement successfully filed.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
            else
            {
                return;
            }
        }
        private void radShift_CheckedChanged(object sender, EventArgs e)
        {
            if (radShift.Checked == true)
            {
                radPerson.Checked = false;
                cboEndorsee.Items.Clear();
                cboEndorsee.Items.Add("Morning Shift");
                cboEndorsee.Items.Add("Afternoon Shift");
                cboEndorsee.Items.Add("Graveyard Shift");
            }
        }
        private void radPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (radPerson.Checked == true)
            {
                if (chkAdmin.Checked == true)
                {
                    cboEndorsee.Items.Clear();
                    radShift.Checked = false;
                    string forReader_endorsee = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where usertype like '" + "admin" + "' and username collate latin1_general_cs not like '" + lblUsername_.Text + "' and username not like '" + "adminpldt" + "'";
                    MySqlDataReader reader_endorsee = Program.Query(forReader_endorsee);
                    while (reader_endorsee.Read())
                    {
                        cboEndorsee.Items.Add(reader_endorsee.GetString(5) + ", " + reader_endorsee.GetString(4) + " " + reader_endorsee.GetString(6) + ".");
                    }
                    reader_endorsee.Close();
                }
                else
                {
                    cboEndorsee.Items.Clear();
                    radShift.Checked = false;
                    string forReader_endorsee = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs not like '" + lblUsername_.Text + "' and username not like '" + "adminpldt" + "' and workgroup like '" + cboWorkgroup.Text + "'";
                    MySqlDataReader reader_endorsee = Program.Query(forReader_endorsee);
                    while (reader_endorsee.Read())
                    {
                        cboEndorsee.Items.Add(reader_endorsee.GetString(5) + ", " + reader_endorsee.GetString(4) + " " + reader_endorsee.GetString(6) + ".");
                    }
                    reader_endorsee.Close();
                }
            }
        }
        private void cboWorkgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonHandler();
            if (radPerson.Checked == true)
            {
                radShift.PerformClick();
                radPerson.PerformClick();
            }
        }
        string activity;
        private void shadow()
        {
            activity = "Endorsement for [ #" + txtTicketNumber.Text + " ] was endorsed by [ " + txtEndorser.Text + " ] to [ " + cboEndorsee.Text + " ].";
            shadowTrail();
        }
        private void shadowTrail()
        {
            string username = lblUsername_.Text;
            string workgroup = lblWorkgroup_.Text;
            string databasename = lblDatabase_.Text;
            Program.AuditTrail(activity, username, workgroup, databasename);
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked == true)
            {
                cboWorkgroup.Enabled = false;
                cboWorkgroup.SelectedIndex = -1;
                cboWorkgroup.Text = "";
            }
            else
            {
                cboWorkgroup.Enabled = true;
            }
        }
    }
}