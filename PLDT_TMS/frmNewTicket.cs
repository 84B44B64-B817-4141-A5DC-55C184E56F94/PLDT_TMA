using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PLDT_TMS
{
    public partial class frmNewTicket : Form
    {
        //IMPORTANT
        public string username_;
        public string workgroup_;
        public string db_;
        //IMPORTANT
        int servicemedium;
        string activity;
        public frmNewTicket()
        {
            InitializeComponent();
        }
        private void radWired_CheckedChanged(object sender, EventArgs e)
        {
            if (radWired.Checked == true)
            {
                servicemedium = 0;
                radWireless.Checked = false;
                grbDetails.Enabled = true;
                cboFaultType.Items.Clear();
                cboServiceType.Items.Clear();
                cboFaultType.Text = "";
                cboServiceType.Text = "";
                cboWorkgroup.Text = "";
                cboWorkgroup.SelectedIndex = -1;
                cboServiceType.SelectedIndex = -1;
                cboFaultType.SelectedIndex = -1;
                string forReader_servicetype = "Select * from " + lblDatabase_.Text + ".tbl_wiredservicetype" + " order by servicetype";
                MySqlDataReader reader_servicetype = Program.Query(forReader_servicetype);
                while (reader_servicetype.Read())
                {
                    cboServiceType.Items.Add(reader_servicetype.GetString(0));
                }
                reader_servicetype.Close();
                string forReader_faulttype = "Select * from " + lblDatabase_.Text + ".tbl_wiredfaulttype" + " order by faulttype";
                MySqlDataReader reader_faulttype = Program.Query(forReader_faulttype);
                while (reader_faulttype.Read())
                {
                    cboFaultType.Items.Add(reader_faulttype.GetString(0));
                }
                reader_faulttype.Close();
            }
        }
        private void radWireless_CheckedChanged(object sender, EventArgs e)
        {
            if (radWireless.Checked == true)
            {
                servicemedium = 1;
                radWired.Checked = false;
                grbDetails.Enabled = true;
                cboFaultType.Items.Clear();
                cboServiceType.Items.Clear();
                cboFaultType.Text = "";
                cboServiceType.Text = "";
                cboWorkgroup.Text = "";
                cboWorkgroup.SelectedIndex = -1;
                cboServiceType.SelectedIndex = -1;
                cboFaultType.SelectedIndex = -1;
                string forReader_servicetype = "Select * from " + lblDatabase_.Text + ".tbl_wirelessservicetype" + " order by servicetype";
                MySqlDataReader reader_servicetype = Program.Query(forReader_servicetype);
                while (reader_servicetype.Read())
                {
                    cboServiceType.Items.Add(reader_servicetype.GetString(0));
                }
                reader_servicetype.Close();
                string forReader_faulttype = "Select * from " + lblDatabase_.Text + ".tbl_wirelessfaulttype" + " order by faulttype";
                MySqlDataReader reader_faulttype = Program.Query(forReader_faulttype);
                while (reader_faulttype.Read())
                {
                    cboFaultType.Items.Add(reader_faulttype.GetString(0));
                }
                reader_faulttype.Close();
            }
        }
        private void frmNewTicket_Load(object sender, EventArgs e)
        {
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;
            lblDatabase_.Text = db_;
            string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " order by workgroup";
            MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
            while (reader_workgroup.Read())
            {
                cboWorkgroup.Items.Add(reader_workgroup.GetString(0));
            }
            reader_workgroup.Close();

            dtpDateReported.Value = DateTime.Now;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (servicemedium)
            {
                case 0:
                    {
                        string forReader_servicetype = "Select * from " + lblDatabase_.Text + ".tbl_wiredservicetype" + " where servicetype like '" + cboServiceType.Text + "'";
                        MySqlDataReader reader_servicetype = Program.Query(forReader_servicetype);
                        if (reader_servicetype.Read())
                        {
                            if (txtTicketNumber.TextLength == txtTicketNumber.MaxLength)
                            {
                                string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + cboWorkgroup.Text + "'";
                                MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                                if (reader_workgroup.Read())
                                {
                                    string forReader_faulttype = "Select * from " + lblDatabase_.Text + ".tbl_wiredfaulttype" + " where faulttype like '" + cboFaultType.Text + "'";
                                    MySqlDataReader reader_faulttype = Program.Query(forReader_faulttype);
                                    {
                                        if (reader_faulttype.Read())
                                        {
                                            string reportdate = dtpDateReported.Value.ToShortDateString();
                                            if (MessageBox.Show("Ticket Details:\n\nReport Date: " + reportdate + "\nService Medium: Wired\nService Type: " + cboServiceType.Text + "\nTicket Number: " + txtTicketNumber.Text + "\nPL Number: " + txtPLNumber.Text + "\nWorkgroup: " + cboWorkgroup.Text + "\nFault Type: " + cboFaultType.Text + "\nDescription: " + txtDescription.Text + "\n\nCreate this ticket?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                string forReader_ticketnumber = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where ticketnumber like '" + txtTicketNumber.Text + "'";
                                                MySqlDataReader reader_ticketnumber = Program.Query(forReader_ticketnumber);
                                                if (!reader_ticketnumber.Read())
                                                {
                                                    string forReader_plnumber = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where plnumber like '" + txtPLNumber.Text + "'";
                                                    MySqlDataReader reader_plnumber = Program.Query(forReader_plnumber);
                                                    if (!reader_plnumber.Read())
                                                    {
                                                        if (dtpDateReported.Value > DateTime.Now)
                                                        {
                                                            MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            dtpDateReported.Focus();
                                                        }
                                                        else
                                                        {
                                                            string reporteddate = dtpDateReported.Value.ToString("yyyy-MM-dd"), reportedtime = dtpDateReported.Value.ToString("HH:mm:ss");
                                                            string forInsert = "Insert into " + lblDatabase_.Text + ".tbl_tickets" + "(ticketnumber,plnumber,workgroup,servicemedium,servicetype,faulttype,description,reporteddate,reportedtime,updateddate,updatedtime,remarks,otherremarks,outage) Values ('" + txtTicketNumber.Text + "','" + txtPLNumber.Text + "','" + cboWorkgroup.Text + "','" + "wired" + "','" + cboServiceType.Text + "','" + cboFaultType.Text + "','" + txtDescription.Text + "','" + reporteddate + "','" + reportedtime + "','" + reporteddate + "','" + reportedtime + "','" + "OPEN" + "','" + "none" + "','" + "0" + "')";
                                                            Program.Query(forInsert).Close();
                                                            string datenow = DateTime.Now.ToString();
                                                            MessageBox.Show("Ticket Number (" + txtTicketNumber.Text + ") is successfully created.\nCreated on: " + datenow, "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            activity = "Ticket #" + txtTicketNumber.Text + " created.";
                                                            shadowTrail();
                                                            ClearForm();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("PL number already exists.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        txtPLNumber.Select(0, txtPLNumber.MaxLength);
                                                        txtPLNumber.Focus();
                                                        return;
                                                    }
                                                    reader_plnumber.Close();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Ticket already exists.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    txtTicketNumber.Select(0, txtTicketNumber.MaxLength);
                                                    txtTicketNumber.Focus();
                                                    return;
                                                }
                                                reader_ticketnumber.Close();
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid fault type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            cboFaultType.Text = "";
                                            cboFaultType.Focus();
                                        }
                                        reader_faulttype.Close();
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show("Invalid workgroup.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cboWorkgroup.Text = "";
                                    cboWorkgroup.Focus();
                                }
                                reader_workgroup.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ticket number length not valid.");
                                txtTicketNumber.Select(0, txtTicketNumber.MaxLength);
                                txtTicketNumber.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid service type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboServiceType.Text = "";
                            cboServiceType.Focus();
                        }
                        reader_servicetype.Close();
                        break;
                    }
                case 1:
                    {
                        string forReader_servicetype = "Select * from " + lblDatabase_.Text + ".tbl_wirelessservicetype" + " where servicetype like '" + cboServiceType.Text + "'";
                        MySqlDataReader reader_servicetype = Program.Query(forReader_servicetype);
                        if (reader_servicetype.Read())
                        {
                            if (txtTicketNumber.TextLength == txtTicketNumber.MaxLength)
                            {
                                string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + cboWorkgroup.Text + "'";
                                MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                                if (reader_workgroup.Read())
                                {
                                    string forReader_faulttype = "Select * from " + lblDatabase_.Text + ".tbl_wirelessfaulttype" + " where faulttype like '" + cboFaultType.Text + "'";
                                    MySqlDataReader reader_faulttype = Program.Query(forReader_faulttype);
                                    {
                                        if (reader_faulttype.Read())
                                        {
                                            string reportdate = dtpDateReported.Value.ToShortDateString();
                                            if (MessageBox.Show("Ticket Details:\n\nReport Date: " + reportdate + "\nService Medium: Wireless\nService Type: " + cboServiceType.Text + "\nTicket Number: " + txtTicketNumber.Text + "\nPL Number: " + txtPLNumber.Text + "\nWorkgroup: " + cboWorkgroup.Text + "\nFault Type: " + cboFaultType.Text + "\nDescription: " + txtDescription.Text + "\n\nCreate this ticket?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                string forReader_ticketnumber = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where ticketnumber like '" + txtTicketNumber.Text + "'";
                                                MySqlDataReader reader_ticketnumber = Program.Query(forReader_ticketnumber);
                                                if (!reader_ticketnumber.Read())
                                                {
                                                    string forReader_plnumber = "Select * from "+ lblDatabase_.Text + ".tbl_tickets" + " where plnumber like '" + txtPLNumber.Text + "'";
                                                    MySqlDataReader reader_plnumber = Program.Query(forReader_plnumber);
                                                    if (!reader_plnumber.Read())
                                                    {
                                                        if (dtpDateReported.Value > DateTime.Now)
                                                        {
                                                            MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            dtpDateReported.Focus();
                                                        }
                                                        else
                                                        {
                                                            string reporteddate = dtpDateReported.Value.ToString("yyyy-MM-dd"), reportedtime = dtpDateReported.Value.ToString("HH:mm:ss");
                                                            string forInsert = "Insert into " + lblDatabase_.Text + ".tbl_tickets" + "(ticketnumber,plnumber,workgroup,servicemedium,servicetype,faulttype,description,reporteddate,reportedtime,updateddate,updatedtime,remarks,otherremarks,outage) Values ('" + txtTicketNumber.Text + "','" + txtPLNumber.Text + "','" + cboWorkgroup.Text + "','" + "wireless" + "','" + cboServiceType.Text + "','" + cboFaultType.Text + "','" + txtDescription.Text + "','" + reporteddate + "','" + reportedtime + "','" + reporteddate + "','" + reportedtime + "','" + "OPEN" + "', '" + "none" + "','" + "0" + "')";
                                                            Program.Query(forInsert).Close();
                                                            string datenow = DateTime.Now.ToString();
                                                            MessageBox.Show("Ticket Number (" + txtTicketNumber.Text + ") is successfully created.\nCreated on: " + datenow, "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            activity = "Ticket #" + txtTicketNumber.Text + " created.";
                                                            shadowTrail();
                                                            ClearForm();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("PL number already exists.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        txtPLNumber.Select(0, txtPLNumber.MaxLength);
                                                        txtPLNumber.Focus();
                                                        return;
                                                    }
                                                    reader_plnumber.Close();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Ticket already exists.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    txtTicketNumber.Select(0, txtTicketNumber.MaxLength);
                                                    txtTicketNumber.Focus();
                                                    return;
                                                }
                                                reader_ticketnumber.Close();
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid fault type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            cboFaultType.Text = "";
                                            cboFaultType.Focus();
                                        }
                                        reader_faulttype.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid workgroup.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cboWorkgroup.Text = "";
                                    cboWorkgroup.Focus();
                                }
                                reader_workgroup.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ticket number length not valid.");
                                txtTicketNumber.Select(0, txtTicketNumber.MaxLength);
                                txtTicketNumber.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid service type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboServiceType.Text = "";
                            cboServiceType.Focus();
                        }
                        reader_servicetype.Close();
                        break;
                        }
                default:
                    {
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
                        ClearForm();
                        btnClose.Text = "Close";
                        break;
                    }
            }
        }
        private void txtPLNumber_KeyPress(object sender, KeyPressEventArgs e)
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
        private void ButtonHandler()
        {
            if (cboServiceType.Text.Trim() != "" && cboFaultType.Text.Trim() != "" && cboWorkgroup.Text.Trim() != "" && txtTicketNumber.Text.Trim() != "" && txtPLNumber.Text.Trim() != "" && txtDescription.Text.Trim() != "")
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
            if (cboServiceType.Text.Trim() != "" || cboFaultType.Text.Trim() != "" || cboWorkgroup.Text.Trim() != "" || txtTicketNumber.Text.Trim() != "" || txtPLNumber.Text.Trim() != "" || txtDescription.Text.Trim() != "")
            {
                btnClose.Text = "Reset";
            }
            else
            {
                btnClose.Text = "Close";
            }
        }
        private void ClearForm()
        {
            cboFaultType.Text = "";
            cboFaultType.SelectedIndex = -1;
            cboWorkgroup.Text = "";
            cboWorkgroup.SelectedIndex = -1;
            cboServiceType.Text = "";
            cboServiceType.SelectedIndex = -1;
            txtTicketNumber.Text = "";
            txtPLNumber.Text = "";
            txtDescription.Text = "";
            radWired.Checked = false;
            radWireless.Checked = false;
            grbDetails.Enabled = false;
            btnClose.Text = "Close";
        }
        private void txtTicketNumber_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void txtPLNumber_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void cboServiceType_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void cboWorkgroup_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void cboFaultType_TextChanged(object sender, EventArgs e)
        {
            ButtonHandler();
        }
        private void shadowTrail()
        {
            string username = lblUsername_.Text;
            string workgroup = lblWorkgroup_.Text;
            string databasename = lblDatabase_.Text;
            Program.AuditTrail(activity,username,workgroup,databasename);
        }
        private void txtTicketNumber_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPLNumber_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPLNumber_Leave(object sender, EventArgs e)
        {
            txtPLNumber.Text = txtPLNumber.Text.ToUpper();
        }
    }
}