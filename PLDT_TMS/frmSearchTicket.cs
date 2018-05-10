using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PLDT_TMS
{
    public partial class frmSearchTicket : Form
    {
        //IMPORTANT
        public string username_;
        public string workgroup_;
        public string db_;
        //IMPORTANT
        public bool doubleclicked_, endorsed_;
        public string ticketnumber_;
        string count;
        int tablecount = 50;
        int tableshow = 0;
        int limiter = 0;
        double outage;
        string read;
        public frmSearchTicket()
        {
            InitializeComponent();
        }
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
        private void frmSearchTicket_Load(object sender, EventArgs e)
        {
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;
            lblDatabase_.Text = db_;
            if (doubleclicked_ == true)
            {
                doubleclicked_ = false;
                cboSearchType.SelectedIndex = 1;
                txtSearch.Text = ticketnumber_;
                btnSearch.PerformClick();
            }
            else
            {
                cboSearchType.SelectedIndex = 0;
                lsvData.Focus();
                getInfo();
            }
            string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " order by workgroup";
            MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
            while (reader_workgroup.Read())
            {
                cboWorkgroup.Items.Add(reader_workgroup.GetString(0));
            }
            reader_workgroup.Close();
            string forReader_remarks = "Select * from " + lblDatabase_.Text + ".tbl_remarks" + " order by remarks";
            MySqlDataReader reader_remarks = Program.Query(forReader_remarks);
            while (reader_remarks.Read())
            {
                cboRemarks.Items.Add(reader_remarks.GetString(0));
            }
            reader_remarks.Close();
            dtpReported.Value = DateTime.Now;
            dtpReportedDate.Value = DateTime.Now;
            dtpSearch.Value = DateTime.Now;
            dtpUpdated.Value = DateTime.Now;
            dtpUpdatedDate.Value = DateTime.Now;
            if (endorsed_ == true)
            {
                if (MessageBox.Show("Change endorsement status to [Noted]?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string statusdate = DateTime.Now.ToString("yyyy-MM-dd"), statustime = DateTime.Now.ToString("HH:mm:ss");
                    string forUpdate = "update " + lblDatabase_.Text + ".tbl_endorsements" + " set status = '" + "Noted" + "', statusdate = '" + statusdate + " " + statustime + "' where ticketnumber like '" + ticketnumber_ + "' and status like '" + "Open" + "'";
                    Program.Query(forUpdate).Close();
                    endorsed_ = false;
                }
            }
            else
            {
                endorsed_ = false;
            }
        }
        string mark;
        private void getInfo()
        {
            switch (cboSearchType.SelectedIndex)
            {
                case 1:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where ticketnumber like '" + txtSearch.Text + "%" + "' order by ticketnumber limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = reader.GetString(8);
                            lst.SubItems.Add(reporteddate + " " + reportedtime);
                            var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = reader.GetString(10);
                            lst.SubItems.Add(updateddate + " " + updatedtime);
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(4));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(6));
                            mark = reader.GetString(11);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            outage = Math.Round(double.Parse(reader.GetString(13)),3);
                            if (outage < 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Gold;
                            }
                            else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Orange;
                            }
                            else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Tomato;
                            }
                            else if (outage >= 48 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Red;
                            }
                            else
                            {
                                if (mark == "CLOSED")
                                {
                                    lst.BackColor = Color.White;
                                }
                                else
                                {
                                    lst.BackColor = Color.LightGray;
                                }
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnMore.BackColor = SystemColors.WindowFrame;
                            btnLess.Enabled = false;
                            btnLess.BackColor = SystemColors.WindowFrame;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 2:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where plnumber like '" + txtSearch.Text + "%" + "' order by plnumber limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = reader.GetString(8);
                            lst.SubItems.Add(reporteddate + " " + reportedtime);
                            var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = reader.GetString(10);
                            lst.SubItems.Add(updateddate + " " + updatedtime);
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(4));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(6));
                            mark = reader.GetString(11);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            outage = Math.Round(double.Parse(reader.GetString(13)),3);
                            if (outage < 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Gold;
                            }
                            else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Orange;
                            }
                            else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Tomato;
                            }
                            else if (outage >= 48 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Red;
                            }
                            else
                            {
                                if (mark == "CLOSED")
                                {
                                    lst.BackColor = Color.White;
                                }
                                else
                                {
                                    lst.BackColor = Color.LightGray;
                                }
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnMore.BackColor = SystemColors.WindowFrame;
                            btnLess.Enabled = false;
                            btnLess.BackColor = SystemColors.WindowFrame;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 3:
                    {
                        var date = Convert.ToDateTime(dtpSearch.Value).ToString("yyyy-MM-dd");
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + date + "' order by reporteddate limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = reader.GetString(8);
                            lst.SubItems.Add(reporteddate + " " + reportedtime);
                            var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = reader.GetString(10);
                            lst.SubItems.Add(updateddate + " " + updatedtime);
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(4));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(6));
                            mark = reader.GetString(11);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            outage = Math.Round(double.Parse(reader.GetString(13)), 3);
                            if (outage < 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Gold;
                            }
                            else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Orange;
                            }
                            else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Tomato;
                            }
                            else if (outage >= 48 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Red;
                            }
                            else
                            {
                                if (mark == "CLOSED")
                                {
                                    lst.BackColor = Color.White;
                                }
                                else
                                {
                                    lst.BackColor = Color.LightGray;
                                }
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnMore.BackColor = SystemColors.WindowFrame;
                            btnLess.Enabled = false;
                            btnLess.BackColor = SystemColors.WindowFrame;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 4:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where servicetype like '" + txtSearch.Text + "%" + "' order by servicetype limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = reader.GetString(8);
                            lst.SubItems.Add(reporteddate + " " + reportedtime);
                            var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = reader.GetString(10);
                            lst.SubItems.Add(updateddate + " " + updatedtime);
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(4));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(6));
                            mark = reader.GetString(11);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            outage = Math.Round(double.Parse(reader.GetString(13)),3);
                            if (outage < 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Gold;
                            }
                            else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Orange;
                            }
                            else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Tomato;
                            }
                            else if (outage >= 48 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Red;
                            }
                            else
                            {
                                if (mark == "CLOSED")
                                {
                                    lst.BackColor = Color.White;
                                }
                                else
                                {
                                    lst.BackColor = Color.LightGray;
                                }
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnMore.BackColor = SystemColors.WindowFrame;
                            btnLess.Enabled = false;
                            btnLess.BackColor = SystemColors.WindowFrame;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 5:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where workgroup like '" + txtSearch.Text + "%" + "' order by workgroup limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = reader.GetString(8);
                            lst.SubItems.Add(reporteddate + " " + reportedtime);
                            var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = reader.GetString(10);
                            lst.SubItems.Add(updateddate + " " + updatedtime);
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(4));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(6));
                            mark = reader.GetString(11);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            outage = Math.Round(double.Parse(reader.GetString(13)),3);
                            if (outage < 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Gold;
                            }
                            else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Orange;
                            }
                            else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Tomato;
                            }
                            else if (outage >= 48 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Red;
                            }
                            else
                            {
                                if (mark == "CLOSED")
                                {
                                    lst.BackColor = Color.White;
                                }
                                else
                                {
                                    lst.BackColor = Color.LightGray;
                                }
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnMore.BackColor = SystemColors.WindowFrame;
                            btnLess.Enabled = false;
                            btnLess.BackColor = SystemColors.WindowFrame;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 6:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where remarks like '" + txtSearch.Text + "%" + "' order by remarks limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = reader.GetString(8);
                            lst.SubItems.Add(reporteddate + " " + reportedtime);
                            var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = reader.GetString(10);
                            lst.SubItems.Add(updateddate + " " + updatedtime);
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(4));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(6));
                            mark = reader.GetString(11);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            outage = Math.Round(double.Parse(reader.GetString(13)),3);
                            if (outage < 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Gold;
                            }
                            else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Orange;
                            }
                            else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Tomato;
                            }
                            else if (outage >= 48 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Red;
                            }
                            else
                            {
                                if (mark == "CLOSED")
                                {
                                    lst.BackColor = Color.White;
                                }
                                else
                                {
                                    lst.BackColor = Color.LightGray;
                                }
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnMore.BackColor = SystemColors.WindowFrame;
                            btnLess.Enabled = false;
                            btnLess.BackColor = SystemColors.WindowFrame;
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
                        string forQuery_ = "Select count(*) from " + lblDatabase_.Text + ".tbl_tickets";
                        MySqlCommand query_ = new MySqlCommand(forQuery_, conn);
                        conn.Open();
                        count = query_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow.Text = count;
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = reader.GetString(8);
                            lst.SubItems.Add(reporteddate + " " + reportedtime);
                            var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = reader.GetString(10);
                            lst.SubItems.Add(updateddate + " " + updatedtime);
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(4));
                            lst.SubItems.Add(reader.GetString(2));
                            lst.SubItems.Add(reader.GetString(5));
                            lst.SubItems.Add(reader.GetString(6));
                            lst.SubItems.Add(reader.GetString(11));
                            lsvData.Items.Add(lst);
                            outage = Math.Round(double.Parse(reader.GetString(13)),3);
                            if (outage < 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Gold;
                            }
                            else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Orange;
                            }
                            else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Tomato;
                            }
                            else if (outage >= 48 && mark != "CLOSED")
                            {
                                lst.BackColor = Color.Red;
                            }
                            else
                            {
                                if (mark == "CLOSED")
                                {
                                    lst.BackColor = Color.White;
                                }
                                else
                                {
                                    lst.BackColor = Color.LightGray;
                                }
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 0)
                        {
                            btnMore.Enabled = false;
                            btnMore.BackColor = SystemColors.WindowFrame;
                            btnLess.Enabled = false;
                            btnLess.BackColor = SystemColors.WindowFrame;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
            }
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
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        cboSearch.Items.Clear();
                        cboSearch.Visible = false;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 2:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        cboSearch.Items.Clear();
                        cboSearch.Visible = false;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 3:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = false;
                        dtpSearch.Visible = true;
                        cboSearch.Items.Clear();
                        cboSearch.Visible = false;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 4:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = false;
                        dtpSearch.Visible = false;
                        cboSearch.Items.Clear();
                        cboSearch.Items.Add("--- Wired ---");
                        string forSearchWired = "Select * from " + lblDatabase_.Text + ".tbl_wiredservicetype";
                        MySqlDataReader wired = Program.Query(forSearchWired);
                        while (wired.Read())
                        {
                            cboSearch.Items.Add(wired.GetString(0));
                        }
                        wired.Close();
                        cboSearch.Items.Add("--- Wireless ---");
                        string forSearchWireless = "Select * from " + lblDatabase_.Text + ".tbl_wirelessservicetype";
                        MySqlDataReader wireless = Program.Query(forSearchWireless);
                        while (wireless.Read())
                        {
                            cboSearch.Items.Add(wireless.GetString(0));
                        }
                        wireless.Close();
                        cboSearch.SelectedIndex = -1;
                        cboSearch.Visible = true;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 5:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = false;
                        dtpSearch.Visible = false;
                        cboSearch.Items.Clear();
                        string forSearchWorkgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup";
                        MySqlDataReader group = Program.Query(forSearchWorkgroup);
                        while (group.Read())
                        {
                            cboSearch.Items.Add(group.GetString(0));
                        }
                        group.Close();
                        cboSearch.SelectedIndex = -1;
                        cboSearch.Visible = true;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 6:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = false;
                        dtpSearch.Visible = false;
                        cboSearch.Items.Clear();
                        cboSearch.Items.Add("--- Wired ---");
                        string forSearchWired = "Select * from " + lblDatabase_.Text + ".tbl_wiredfaulttype";
                        MySqlDataReader wired = Program.Query(forSearchWired);
                        while (wired.Read())
                        {
                            cboSearch.Items.Add(wired.GetString(0));
                        }
                        wired.Close();
                        cboSearch.Items.Add("--- Wireless ---");
                        string forSearchWireless = "Select * from " + lblDatabase_.Text + ".tbl_wirelessfaulttype";
                        MySqlDataReader wireless = Program.Query(forSearchWireless);
                        while (wireless.Read())
                        {
                            cboSearch.Items.Add(wireless.GetString(0));
                        }
                        wireless.Close();
                        cboSearch.SelectedIndex = -1;
                        cboSearch.SelectedIndex = -1;
                        cboSearch.Visible = true;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 7:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = false;
                        dtpSearch.Visible = false;
                        cboSearch.Items.Clear();
                        string forSearchRemarks = "Select * from " + lblDatabase_.Text + ".tbl_remarks";
                        MySqlDataReader rem = Program.Query(forSearchRemarks);
                        while (rem.Read())
                        {
                            cboSearch.Items.Add(rem.GetString(0));
                        }
                        rem.Close();
                        cboSearch.Items.Add("OPEN");
                        cboSearch.SelectedIndex = -1;
                        cboSearch.Visible = true;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 8:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        cboSearch.Items.Clear();
                        cboSearch.Visible = false;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                 default:
                    {
                        txtSearch.Text = "";
                        txtSearch.Enabled = false;
                        txtSearch.BackColor = SystemColors.WindowFrame;
                        btnSearch.Enabled = false;
                        btnSearch.BackColor = SystemColors.WindowFrame;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        cboSearch.Items.Clear();
                        cboSearch.Visible = false;
                        getInfo();
                        lblCount.Text = "";
                        btnMore.Enabled = true;
                        btnMore.BackColor = SystemColors.Control;
                        break;
                    }
            }
        }
        private void lsvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvData.SelectedItems.Count == 0)
            {
                btnEdit.Enabled = false;
                btnEdit.BackColor = SystemColors.WindowFrame;
                ClearForms();
                return;
            }
            else
            {
                btnEdit.Enabled = true;
                btnEdit.BackColor = SystemColors.Control;
                ListViewItem item = lsvData.SelectedItems[0];
                switch (item.SubItems[4].Text)
                {
                    case "wired":
                        {
                            cboTicketType.SelectedIndex = 0;
                            break;
                        }
                    case "wireless":
                        {
                            cboTicketType.SelectedIndex = 1;
                            break;
                        }
                }
                txtTicketNumber.Text = item.SubItems[0].Text;
                txtPLNumber.Text = item.SubItems[1].Text;
                var reporteddate = Convert.ToDateTime(item.SubItems[2].Text).ToString("MMM dd yyyy");
                var updateddate = Convert.ToDateTime(item.SubItems[3].Text).ToString("MMM dd yyyy");
                DateTime reportdate;
                if (DateTime.TryParse(reporteddate, out reportdate))
                {
                    dtpReportedDate.Value = reportdate;
                }
                DateTime updatedate;
                if (DateTime.TryParse(updateddate, out updatedate))
                {
                    dtpUpdatedDate.Value = updatedate;
                }
                string forReader = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where ticketnumber like '" + txtTicketNumber.Text + "'";
                MySqlDataReader reader = Program.Query(forReader);
                {
                    while (reader.Read())
                    {
                        outage = double.Parse(reader.GetString(13));
                        txtOutage.Text = Math.Round(outage, 3).ToString();
                    }
                }
                reader.Close();
                cboServiceType.Text = item.SubItems[5].Text;
                cboWorkgroup.Text = item.SubItems[6].Text;
                cboFaultType.Text = item.SubItems[7].Text;
                txtDescription.Text = item.SubItems[8].Text;
                cboRemarks.Text = item.SubItems[9].Text;
            }
        }
        private void ClearForms()
        {
            txtDescription.Text = "";
            txtPLNumber.Text = "";
            dtpReportedDate.Value = DateTime.Now;
            dtpUpdatedDate.Value = DateTime.Now;
            txtTicketNumber.Text = "";
            cboRemarks.Text = "";
            cboServiceType.Text = "";
            cboWorkgroup.Text = "";
            cboFaultType.Text = "";
            cboTicketType.Text = "";
            txtOtherRemarks.Text = "";
            txtOutage.Text = "";
            txtOtherRemarks.BackColor = SystemColors.Control;
        }
        string prevticketnumber;
        string prevplnumber;
        DateTime prevdatereported;
        string prevservicetype;
        string prevworkgroup;
        string prevdescription;
        string prevremarks;
        string prevotherremarks;
        string prevtickettype;
        string prevfaulttype;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            switch (btnEdit.Text)
            {
                case "Edit details":
                    {
                        btnClose.Text = "Reset";
                        btnEdit.Text = "Update details";
                        lsvData.Enabled = false;
                        lsvData.BackColor = SystemColors.WindowFrame;
                        txtTicketNumber.ReadOnly = false;
                        txtPLNumber.ReadOnly = false;
                        cboFaultType.Enabled = true;
                        cboFaultType.BackColor = SystemColors.Control;
                        cboTicketType.Enabled = true;
                        cboTicketType.BackColor = SystemColors.Control;
                        txtDescription.ReadOnly = false;
                        txtDescription.BackColor = Color.White;
                        if (cboRemarks.Text == "OTHERS")
                        {
                            txtOtherRemarks.ReadOnly = false;
                            txtOtherRemarks.BackColor = Color.White;
                        }
                        cboRemarks.Enabled = true;
                        cboRemarks.BackColor = SystemColors.Control;
                        cboServiceType.Enabled = true;
                        cboServiceType.BackColor = SystemColors.Control;
                        cboWorkgroup.Enabled = true;
                        cboWorkgroup.BackColor = SystemColors.Control;
                        cboServiceType.Items.Clear();
                        cboFaultType.Items.Clear();
                        switch (cboTicketType.SelectedIndex)
                        {
                            case 0:
                                {
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
                                    break;
                                }
                            case 1:
                                {
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
                                    break;
                                }
                        }
                        prevticketnumber = txtTicketNumber.Text;
                        prevplnumber = txtPLNumber.Text;
                        prevdatereported = dtpUpdatedDate.Value;
                        prevservicetype = cboServiceType.Text;
                        prevworkgroup = cboWorkgroup.Text;
                        prevdescription = txtDescription.Text;
                        prevremarks = cboRemarks.Text;
                        prevotherremarks = txtOtherRemarks.Text;
                        prevtickettype = cboTicketType.Text;
                        prevfaulttype = cboFaultType.Text;
                        break;
                    }
                case "Update details":
                    {
                        if (prevticketnumber == txtTicketNumber.Text && prevplnumber == txtPLNumber.Text && prevdatereported == dtpReportedDate.Value && prevservicetype == cboServiceType.Text && prevworkgroup == cboWorkgroup.Text && prevdescription == txtDescription.Text && prevremarks == cboRemarks.Text && prevotherremarks == txtOtherRemarks.Text)
                        {
                            MessageBox.Show("No change done.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (txtTicketNumber.Text.Length == txtTicketNumber.MaxLength)
                            {
                                if (prevticketnumber == txtTicketNumber.Text && prevplnumber == txtPLNumber.Text)
                                {
                                    switch (cboTicketType.SelectedIndex)
                                    {
                                        case 0:
                                            {
                                                string forReader_servicetype = "Select * from " + lblDatabase_.Text + ".tbl_wiredservicetype" + " where servicetype like '" + cboServiceType.Text + "'";
                                                MySqlDataReader reader_servicetype = Program.Query(forReader_servicetype);
                                                if (reader_servicetype.Read())
                                                {
                                                    string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + cboWorkgroup.Text + "'";
                                                    MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                                                    if (reader_workgroup.Read())
                                                    {
                                                        string forReader_faulttype = "Select * from " + lblDatabase_.Text + ".tbl_wiredfaulttype" + " where faulttype like '" + cboFaultType.Text + "'";
                                                        MySqlDataReader reader_faulttype = Program.Query(forReader_faulttype);
                                                        if (reader_faulttype.Read())
                                                        {
                                                            if (txtDescription.Text.Trim() != "")
                                                            {
                                                                string forReader_remarks = "Select * from " + lblDatabase_.Text + ".tbl_remarks" + " where remarks like '" + cboRemarks.Text + "'";
                                                                MySqlDataReader reader_remarks = Program.Query(forReader_remarks);
                                                                if (reader_remarks.Read())
                                                                {
                                                                    if (cboRemarks.Text != "OTHERS")
                                                                    {
                                                                        txtOtherRemarks.Text = "none";
                                                                        string reportdate = dtpUpdatedDate.Value.ToShortDateString();
                                                                        string prevreporteddate = prevdatereported.ToShortDateString();
                                                                        if (dtpReportedDate.Value > DateTime.Now)
                                                                        {
                                                                            MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            dtpReportedDate.Focus();
                                                                        }
                                                                        else
                                                                        {
                                                                            if (MessageBox.Show("Ticket details:\n\nReport Date: " + prevreporteddate + " >>> " + reportdate + "\nTicket Number: " + prevticketnumber + " >>> " + txtTicketNumber.Text + "\nPL Number: " + prevplnumber + " >>> " + txtPLNumber.Text + "\nTicket type: " + prevtickettype + " >>> " + cboTicketType.Text + "\nService Type: " + prevservicetype + " >>> " + cboServiceType.Text + "\nWorkgroup: " + prevworkgroup + " >>> " + cboWorkgroup.Text + "\nFault type: " + prevfaulttype + " >>> " + cboFaultType.Text + "\nDescription: " + prevdescription + " >>> " + txtDescription.Text + "\nRemarks: " + prevremarks + " >>> " + cboRemarks.Text + "\nOther remarks: " + prevotherremarks + " >>> " + txtOtherRemarks.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                            {
                                                                                string nowdate = DateTime.Now.ToString("yyyy-MM-dd"), nowtime = DateTime.Now.ToString("HH:mm:ss");
                                                                                string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set ticketnumber = '" + txtTicketNumber.Text + "', plnumber = '" + txtPLNumber.Text + "', servicemedium = '" + cboTicketType.Text + "', faulttype = '" + cboFaultType.Text + "', workgroup= '" + cboWorkgroup.Text + "', servicetype= '" + cboServiceType.Text + "', updateddate = '" + nowdate + "', updatedtime = '" + nowtime + "', description = '" + txtDescription.Text + "', remarks = '" + cboRemarks.Text + "', otherremarks = '" + txtOtherRemarks.Text + "' where ticketnumber collate latin1_general_cs = '" + prevticketnumber + "'";
                                                                                Program.Query(forUpdate).Close();
                                                                                shadow();
                                                                                MessageBox.Show("Ticket successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                ClearForms();
                                                                                btnEdit.Text = "Edit details";
                                                                                btnClose.Text = "Reset";
                                                                                btnClose.PerformClick();
                                                                                lsvData.Enabled = true;
                                                                                lsvData.BackColor = SystemColors.ControlDark;
                                                                                getInfo();
                                                                            }
                                                                            else
                                                                            {
                                                                                return;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (txtOtherRemarks.Text.Trim() != "")
                                                                        {
                                                                            string reportdate = dtpUpdatedDate.Value.ToShortDateString();
                                                                            string prevreporteddate = prevdatereported.ToShortDateString();
                                                                            if (dtpReportedDate.Value > DateTime.Now)
                                                                            {
                                                                                MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                dtpReportedDate.Focus();
                                                                            }
                                                                            else
                                                                            {
                                                                                if (MessageBox.Show("Ticket details:\n\nReport Date: " + prevreporteddate + " >>> " + reportdate + "\nTicket Number: " + prevticketnumber + " >>> " + txtTicketNumber.Text + "\nPL Number: " + prevplnumber + " >>> " + txtPLNumber.Text + "\nTicket type: " + prevtickettype + " >>> " + cboTicketType.Text + "\nService Type: " + prevservicetype + " >>> " + cboServiceType.Text + "\nWorkgroup: " + prevworkgroup + " >>> " + cboWorkgroup.Text + "\nFault type: " + prevfaulttype + " >>> " + cboFaultType.Text + "\nDescription: " + prevdescription + " >>> " + txtDescription.Text + "\nRemarks: " + prevremarks + " >>> " + cboRemarks.Text + "\nOther remarks: " + prevotherremarks + " >>> " + txtOtherRemarks.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                                {
                                                                                    string nowdate = DateTime.Now.ToString("yyyy-MM-dd"), nowtime = DateTime.Now.ToString("HH:mm:ss");
                                                                                    string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set ticketnumber = '" + txtTicketNumber.Text + "', plnumber = '" + txtPLNumber.Text + "', servicemedium = '" + cboTicketType.Text + "', faulttype = '" + cboFaultType.Text + "', workgroup= '" + cboWorkgroup.Text + "', servicetype= '" + cboServiceType.Text + "', updateddate = '" + nowdate + "', updatedtime = '" + nowtime + "', description = '" + txtDescription.Text + "', remarks = '" + cboRemarks.Text + "', otherremarks = '" + txtOtherRemarks.Text + "' where ticketnumber collate latin1_general_cs = '" + prevticketnumber + "'";
                                                                                    Program.Query(forUpdate).Close();
                                                                                    shadow();
                                                                                    MessageBox.Show("Ticket successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                    ClearForms();
                                                                                    btnEdit.Text = "Edit details";
                                                                                    lsvData.Enabled = true;
                                                                                    btnClose.Text = "Reset";
                                                                                    btnClose.PerformClick();
                                                                                    getInfo();
                                                                                }
                                                                                else
                                                                                {
                                                                                    return;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show("Other remarks is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            txtOtherRemarks.Focus();
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Remarks is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    cboRemarks.Select(0, cboRemarks.MaxLength);
                                                                    cboRemarks.Focus();
                                                                }
                                                                reader_remarks.Close();
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Description is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                txtDescription.Focus();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Invalid fault type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            cboFaultType.Select(0, cboFaultType.MaxLength);
                                                            cboFaultType.Focus();
                                                        }
                                                        reader_faulttype.Close();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Invalid workgroup.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        cboWorkgroup.Select(0, cboWorkgroup.MaxLength);
                                                        cboWorkgroup.Focus();
                                                    }
                                                    reader_workgroup.Close();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Invalid service type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    cboServiceType.Select(0, cboServiceType.MaxLength);
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
                                                    string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + cboWorkgroup.Text + "'";
                                                    MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                                                    if (reader_workgroup.Read())
                                                    {
                                                        string forReader_faulttype = "Select * from " + lblDatabase_.Text + ".tbl_wirelessfaulttype" + " where faulttype like '" + cboFaultType.Text + "'";
                                                        MySqlDataReader reader_faulttype = Program.Query(forReader_faulttype);
                                                        if (reader_faulttype.Read())
                                                        {
                                                            if (txtDescription.Text.Trim() != "")
                                                            {
                                                                string forReader_remarks = "Select * from " + lblDatabase_.Text + ".tbl_remarks" + " where remarks like '" + cboRemarks.Text + "'";
                                                                MySqlDataReader reader_remarks = Program.Query(forReader_remarks);
                                                                if (reader_remarks.Read())
                                                                {
                                                                    if (cboRemarks.Text != "OTHERS")
                                                                    {
                                                                            txtOtherRemarks.Text = "none";
                                                                            string reportdate = dtpUpdatedDate.Value.ToShortDateString();
                                                                            string prevreporteddate = prevdatereported.ToShortDateString();
                                                                            if (dtpReportedDate.Value > DateTime.Now)
                                                                            {
                                                                                MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                dtpReportedDate.Focus();
                                                                            }
                                                                            else
                                                                            {
                                                                                if (MessageBox.Show("Ticket details:\n\nReport Date: " + prevreporteddate + " >>> " + reportdate + "\nTicket Number: " + prevticketnumber + " >>> " + txtTicketNumber.Text + "\nPL Number: " + prevplnumber + " >>> " + txtPLNumber.Text + "\nTicket type: " + prevtickettype + " >>> " + cboTicketType.Text + "\nService Type: " + prevservicetype + " >>> " + cboServiceType.Text + "\nWorkgroup: " + prevworkgroup + " >>> " + cboWorkgroup.Text + "\nFault type: " + prevfaulttype + " >>> " + cboFaultType.Text + "\nDescription: " + prevdescription + " >>> " + txtDescription.Text + "\nRemarks: " + prevremarks + " >>> " + cboRemarks.Text + "\nOther remarks: " + prevotherremarks + " >>> " + txtOtherRemarks.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                                {
                                                                                    string nowdate = DateTime.Now.ToString("yyyy-MM-dd"), nowtime = DateTime.Now.ToString("HH:mm:ss");
                                                                                    string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set ticketnumber = '" + txtTicketNumber.Text + "', plnumber = '" + txtPLNumber.Text + "', servicemedium = '" + cboTicketType.Text + "', faulttype = '" + cboFaultType.Text + "', workgroup= '" + cboWorkgroup.Text + "', servicetype= '" + cboServiceType.Text + "', updateddate = '" + nowdate + "', updatedtime = '" + nowtime + "', description = '" + txtDescription.Text + "', remarks = '" + cboRemarks.Text + "', otherremarks = '" + txtOtherRemarks.Text + "' where ticketnumber collate latin1_general_cs = '" + prevticketnumber + "'";
                                                                                    Program.Query(forUpdate).Close();
                                                                                    shadow();
                                                                                    MessageBox.Show("Ticket successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                    ClearForms();
                                                                                    btnEdit.Text = "Edit details";
                                                                                    lsvData.Enabled = true;
                                                                                lsvData.BackColor = SystemColors.ControlDark;
                                                                                    btnClose.Text = "Reset";
                                                                                    btnClose.PerformClick();
                                                                                    getInfo();
                                                                                }
                                                                                else
                                                                                {
                                                                                    return;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (txtOtherRemarks.Text.Trim() != "")
                                                                            {
                                                                                string reportdate = dtpUpdatedDate.Value.ToShortDateString();
                                                                                string prevreporteddate = prevdatereported.ToShortDateString();
                                                                                if (dtpReportedDate.Value > DateTime.Now)
                                                                                {
                                                                                    MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    dtpReportedDate.Focus();
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (MessageBox.Show("Ticket details:\n\nReport Date: " + prevreporteddate + " >>> " + reportdate + "\nTicket Number: " + prevticketnumber + " >>> " + txtTicketNumber.Text + "\nPL Number: " + prevplnumber + " >>> " + txtPLNumber.Text + "\nTicket type: " + prevtickettype + " >>> " + cboTicketType.Text + "\nService Type: " + prevservicetype + " >>> " + cboServiceType.Text + "\nWorkgroup: " + prevworkgroup + " >>> " + cboWorkgroup.Text + "\nFault type: " + prevfaulttype + " >>> " + cboFaultType.Text + "\nDescription: " + prevdescription + " >>> " + txtDescription.Text + "\nRemarks: " + prevremarks + " >>> " + cboRemarks.Text + "\nOther remarks: " + prevotherremarks + " >>> " + txtOtherRemarks.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                                    {
                                                                                        string nowdate = DateTime.Now.ToString("yyyy-MM-dd"), nowtime = DateTime.Now.ToString("HH:mm:ss");
                                                                                        string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set ticketnumber = '" + txtTicketNumber.Text + "', plnumber = '" + txtPLNumber.Text + "', servicemedium = '" + cboTicketType.Text + "', faulttype = '" + cboFaultType.Text + "', workgroup= '" + cboWorkgroup.Text + "', servicetype= '" + cboServiceType.Text + "', updateddate = '" + nowdate + "', updatedtime = '" + nowtime + "', description = '" + txtDescription.Text + "', remarks = '" + cboRemarks.Text + "', otherremarks = '" + txtOtherRemarks.Text + "' where ticketnumber collate latin1_general_cs = '" + prevticketnumber + "'";
                                                                                        Program.Query(forUpdate).Close();
                                                                                        shadow();
                                                                                        MessageBox.Show("Ticket successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                        ClearForms();
                                                                                        btnEdit.Text = "Edit details";
                                                                                        lsvData.Enabled = true;
                                                                                    lsvData.BackColor = SystemColors.ControlDark;
                                                                                    getInfo();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        return;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("Other remarks is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                txtOtherRemarks.Focus();
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Remarks is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                        cboRemarks.Select(0, cboRemarks.MaxLength);
                                                                        cboRemarks.Focus();
                                                                    }
                                                                    reader_remarks.Close();
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Description is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    txtDescription.Focus();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Invalid fault type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                cboFaultType.Select(0, cboFaultType.MaxLength);
                                                                cboFaultType.Focus();
                                                            }
                                                            reader_faulttype.Close();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Invalid workgroup.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            cboWorkgroup.Select(0, cboWorkgroup.MaxLength);
                                                            cboWorkgroup.Focus();
                                                        }
                                                        reader_workgroup.Close();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Invalid service type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        cboServiceType.Select(0, cboServiceType.MaxLength);
                                                        cboServiceType.Focus();
                                                    }
                                                    reader_servicetype.Close();
                                                break;
                                                }
                                    }
                                }
                                else
                                {
                                    string forReader_ticketnumber = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where ticketnumber like '" + txtTicketNumber.Text + "'";
                                    MySqlDataReader reader_ticketnumber = Program.Query(forReader_ticketnumber);
                                    if (!reader_ticketnumber.Read())
                                    {
                                        string forReader_plnumber = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where plnumber like '" + txtPLNumber.Text + "'";
                                        MySqlDataReader reader_plnumber = Program.Query(forReader_plnumber);
                                        if (!reader_plnumber.Read())
                                        {
                                            switch (cboTicketType.SelectedIndex)
                                            {
                                                case 0:
                                                    {
                                                        string forReader_servicetype = "Select * from " + lblDatabase_.Text + ".tbl_wiredservicetype" + " where servicetype like '" + cboServiceType.Text + "'";
                                                        MySqlDataReader reader_servicetype = Program.Query(forReader_servicetype);
                                                        if (reader_servicetype.Read())
                                                        {
                                                            string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + cboWorkgroup.Text + "'";
                                                            MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                                                            if (reader_workgroup.Read())
                                                            {
                                                                string forReader_faulttype = "Select * from " + lblDatabase_.Text + ".tbl_wiredfaulttype" + " where faulttype like '" + cboFaultType.Text + "'";
                                                                MySqlDataReader reader_faulttype = Program.Query(forReader_faulttype);
                                                                if (reader_faulttype.Read())
                                                                {
                                                                    if (txtDescription.Text.Trim() != "")
                                                                    {
                                                                        string forReader_remarks = "Select * from " + lblDatabase_.Text + ".tbl_remarks" + " where remarks like '" + cboRemarks.Text + "'";
                                                                        MySqlDataReader reader_remarks = Program.Query(forReader_remarks);
                                                                        if (reader_remarks.Read())
                                                                        {
                                                                            if (cboRemarks.Text != "OTHERS")
                                                                            {
                                                                                    txtOtherRemarks.Text = "none";
                                                                                    string reportdate = dtpUpdatedDate.Value.ToShortDateString();
                                                                                    string prevreporteddate = prevdatereported.ToShortDateString();
                                                                                    if (dtpReportedDate.Value > DateTime.Now)
                                                                                    {
                                                                                        MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        dtpReportedDate.Focus();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (MessageBox.Show("Ticket details:\n\nReport Date: " + prevreporteddate + " >>> " + reportdate + "\nTicket Number: " + prevticketnumber + " >>> " + txtTicketNumber.Text + "\nPL Number: " + prevplnumber + " >>> " + txtPLNumber.Text + "\nTicket type: " + prevtickettype + " >>> " + cboTicketType.Text + "\nService Type: " + prevservicetype + " >>> " + cboServiceType.Text + "\nWorkgroup: " + prevworkgroup + " >>> " + cboWorkgroup.Text + "\nFault type: " + prevfaulttype + " >>> " + cboFaultType.Text + "\nDescription: " + prevdescription + " >>> " + txtDescription.Text + "\nRemarks: " + prevremarks + " >>> " + cboRemarks.Text + "\nOther remarks: " + prevotherremarks + " >>> " + txtOtherRemarks.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                                        {
                                                                                            string nowdate = DateTime.Now.ToString("yyyy-MM-dd"), nowtime = DateTime.Now.ToString("HH:mm:ss");
                                                                                            string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set ticketnumber = '" + txtTicketNumber.Text + "', plnumber = '" + txtPLNumber.Text + "', servicemedium = '" + cboTicketType.Text + "', faulttype = '" + cboFaultType.Text + "', workgroup= '" + cboWorkgroup.Text + "', servicetype= '" + cboServiceType.Text + "', updateddate = '" + nowdate + "', updatedtime = '" + nowtime + "', description = '" + txtDescription.Text + "', remarks = '" + cboRemarks.Text + "', otherremarks = '" + txtOtherRemarks.Text + "' where ticketnumber collate latin1_general_cs = '" + prevticketnumber + "'";
                                                                                            Program.Query(forUpdate).Close();
                                                                                            shadow();
                                                                                            MessageBox.Show("Ticket successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                            ClearForms();
                                                                                            btnEdit.Text = "Edit details";
                                                                                            lsvData.Enabled = true;
                                                                                        lsvData.BackColor = SystemColors.ControlDark;
                                                                                        btnClose.Text = "Reset";
                                                                                            btnClose.PerformClick();
                                                                                            getInfo();
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            return;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (txtOtherRemarks.Text.Trim() != "")
                                                                                    {
                                                                                        string reportdate = dtpUpdatedDate.Value.ToShortDateString();
                                                                                        string prevreporteddate = prevdatereported.ToShortDateString();
                                                                                        if (dtpReportedDate.Value > DateTime.Now)
                                                                                        {
                                                                                            MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                            dtpReportedDate.Focus();
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (MessageBox.Show("Ticket details:\n\nReport Date: " + prevreporteddate + " >>> " + reportdate + "\nTicket Number: " + prevticketnumber + " >>> " + txtTicketNumber.Text + "\nPL Number: " + prevplnumber + " >>> " + txtPLNumber.Text + "\nTicket type: " + prevtickettype + " >>> " + cboTicketType.Text + "\nService Type: " + prevservicetype + " >>> " + cboServiceType.Text + "\nWorkgroup: " + prevworkgroup + " >>> " + cboWorkgroup.Text + "\nFault type: " + prevfaulttype + " >>> " + cboFaultType.Text + "\nDescription: " + prevdescription + " >>> " + txtDescription.Text + "\nRemarks: " + prevremarks + " >>> " + cboRemarks.Text + "\nOther remarks: " + prevotherremarks + " >>> " + txtOtherRemarks.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                                            {
                                                                                                string nowdate = DateTime.Now.ToString("yyyy-MM-dd"), nowtime = DateTime.Now.ToString("HH:mm:ss");
                                                                                                string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set ticketnumber = '" + txtTicketNumber.Text + "', plnumber = '" + txtPLNumber.Text + "', servicemedium = '" + cboTicketType.Text + "', faulttype = '" + cboFaultType.Text + "', workgroup= '" + cboWorkgroup.Text + "', servicetype= '" + cboServiceType.Text + "', updateddate = '" + nowdate + "', updatedtime = '" + nowtime + "', description = '" + txtDescription.Text + "', remarks = '" + cboRemarks.Text + "', otherremarks = '" + txtOtherRemarks.Text + "' where ticketnumber collate latin1_general_cs = '" + prevticketnumber + "'";
                                                                                                Program.Query(forUpdate).Close();
                                                                                                shadow();
                                                                                                MessageBox.Show("Ticket successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                                ClearForms();
                                                                                                btnEdit.Text = "Edit details";
                                                                                                lsvData.Enabled = true;
                                                                                            lsvData.BackColor = SystemColors.ControlDark;
                                                                                            btnClose.Text = "Reset";
                                                                                                btnClose.PerformClick();
                                                                                                getInfo();
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        MessageBox.Show("Other remarks is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        txtOtherRemarks.Focus();
                                                                                    }
                                                                                }
                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show("Remarks is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            cboRemarks.Select(0, cboRemarks.MaxLength);
                                                                            cboRemarks.Focus();
                                                                        }
                                                                        reader_remarks.Close();
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Description is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                        txtDescription.Focus();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Invalid fault type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    cboFaultType.Select(0, cboFaultType.MaxLength);
                                                                    cboFaultType.Focus();
                                                                }
                                                                reader_faulttype.Close();
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Invalid workgroup.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                cboWorkgroup.Select(0, cboWorkgroup.MaxLength);
                                                                cboWorkgroup.Focus();
                                                            }
                                                            reader_workgroup.Close();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Invalid service type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            cboServiceType.Select(0, cboServiceType.MaxLength);
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
                                                            string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + cboWorkgroup.Text + "'";
                                                            MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                                                            if (reader_workgroup.Read())
                                                            {
                                                                string forReader_faulttype = "Select * from " + lblDatabase_.Text + ".tbl_wirelessfaulttype" + " where faulttype like '" + cboFaultType.Text + "'";
                                                                MySqlDataReader reader_faulttype = Program.Query(forReader_faulttype);
                                                                if (reader_faulttype.Read())
                                                                {
                                                                    if (txtDescription.Text.Trim() != "")
                                                                    {
                                                                        string forReader_remarks = "Select * from " + lblDatabase_.Text + ".tbl_remarks" + " where remarks like '" + cboRemarks.Text + "'";
                                                                        MySqlDataReader reader_remarks = Program.Query(forReader_remarks);
                                                                        if (reader_remarks.Read())
                                                                        {
                                                                            if (cboRemarks.Text != "OTHERS")
                                                                            {
                                                                                    txtOtherRemarks.Text = "none";
                                                                                    string reportdate = dtpUpdatedDate.Value.ToShortDateString();
                                                                                    string prevreporteddate = prevdatereported.ToShortDateString();
                                                                                    if (dtpReportedDate.Value > DateTime.Now)
                                                                                    {
                                                                                        MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        dtpReportedDate.Focus();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (MessageBox.Show("Ticket details:\n\nReport Date: " + prevreporteddate + " >>> " + reportdate + "\nTicket Number: " + prevticketnumber + " >>> " + txtTicketNumber.Text + "\nPL Number: " + prevplnumber + " >>> " + txtPLNumber.Text + "\nTicket type: " + prevtickettype + " >>> " + cboTicketType.Text + "\nService Type: " + prevservicetype + " >>> " + cboServiceType.Text + "\nWorkgroup: " + prevworkgroup + " >>> " + cboWorkgroup.Text + "\nFault type: " + prevfaulttype + " >>> " + cboFaultType.Text + "\nDescription: " + prevdescription + " >>> " + txtDescription.Text + "\nRemarks: " + prevremarks + " >>> " + cboRemarks.Text + "\nOther remarks: " + prevotherremarks + " >>> " + txtOtherRemarks.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                                        {
                                                                                            string nowdate = DateTime.Now.ToString("yyyy-MM-dd"), nowtime = DateTime.Now.ToString("HH:mm:ss");
                                                                                            string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set ticketnumber = '" + txtTicketNumber.Text + "', plnumber = '" + txtPLNumber.Text + "', servicemedium = '" + cboTicketType.Text + "', faulttype = '" + cboFaultType.Text + "', workgroup= '" + cboWorkgroup.Text + "', servicetype= '" + cboServiceType.Text + "', updateddate = '" + nowdate + "', updatedtime = '" + nowtime + "', description = '" + txtDescription.Text + "', remarks = '" + cboRemarks.Text + "', otherremarks = '" + txtOtherRemarks.Text + "' where ticketnumber collate latin1_general_cs = '" + prevticketnumber + "'";
                                                                                            Program.Query(forUpdate).Close();
                                                                                            shadow();
                                                                                            MessageBox.Show("Ticket successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                            ClearForms();
                                                                                            btnEdit.Text = "Edit details";
                                                                                            lsvData.Enabled = true;
                                                                                        lsvData.BackColor = SystemColors.ControlDark;
                                                                                        btnClose.Text = "Reset";
                                                                                            btnClose.PerformClick();
                                                                                            getInfo();
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            return;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (txtOtherRemarks.Text.Trim() != "")
                                                                                    {
                                                                                        string reportdate = dtpUpdatedDate.Value.ToShortDateString();
                                                                                        string prevreporteddate = prevdatereported.ToShortDateString();
                                                                                        if (dtpReportedDate.Value > DateTime.Now)
                                                                                        {
                                                                                            MessageBox.Show("Date exceeds today's date.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                            dtpReportedDate.Focus();
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (MessageBox.Show("Ticket details:\n\nReport Date: " + prevreporteddate + " >>> " + reportdate + "\nTicket Number: " + prevticketnumber + " >>> " + txtTicketNumber.Text + "\nPL Number: " + prevplnumber + " >>> " + txtPLNumber.Text + "\nTicket type: " + prevtickettype + " >>> " + cboTicketType.Text + "\nService Type: " + prevservicetype + " >>> " + cboServiceType.Text + "\nWorkgroup: " + prevworkgroup + " >>> " + cboWorkgroup.Text + "\nFault type: " + prevfaulttype + " >>> " + cboFaultType.Text + "\nDescription: " + prevdescription + " >>> " + txtDescription.Text + "\nRemarks: " + prevremarks + " >>> " + cboRemarks.Text + "\nOther remarks: " + prevotherremarks + " >>> " + txtOtherRemarks.Text + "\n\nUpdate details?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                                            {
                                                                                                string nowdate = DateTime.Now.ToString("yyyy-MM-dd"), nowtime = DateTime.Now.ToString("HH:mm:ss");
                                                                                                string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set ticketnumber = '" + txtTicketNumber.Text + "', plnumber = '" + txtPLNumber.Text + "', servicemedium = '" + cboTicketType.Text + "', faulttype = '" + cboFaultType.Text + "', workgroup= '" + cboWorkgroup.Text + "', servicetype= '" + cboServiceType.Text + "', updateddate = '" + nowdate + "', updatedtime = '" + nowtime + "', description = '" + txtDescription.Text + "', remarks = '" + cboRemarks.Text + "', otherremarks = '" + txtOtherRemarks.Text + "' where ticketnumber collate latin1_general_cs = '" + prevticketnumber + "'";
                                                                                                Program.Query(forUpdate).Close();
                                                                                                shadow();
                                                                                                MessageBox.Show("Ticket successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                                ClearForms();
                                                                                                btnEdit.Text = "Edit details";
                                                                                                lsvData.Enabled = true;
                                                                                            lsvData.BackColor = SystemColors.ControlDark;
                                                                                            btnClose.Text = "Reset";
                                                                                                btnClose.PerformClick();
                                                                                                getInfo();
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        MessageBox.Show("Other remarks is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        txtOtherRemarks.Focus();
                                                                                    }
                                                                                }
                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show("Remarks is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            cboRemarks.Select(0, cboRemarks.MaxLength);
                                                                            cboRemarks.Focus();
                                                                        }
                                                                        reader_remarks.Close();
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Description is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                        txtDescription.Focus();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Invalid fault type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    cboFaultType.Select(0, cboFaultType.MaxLength);
                                                                    cboFaultType.Focus();
                                                                }
                                                                reader_faulttype.Close();
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Invalid workgroup.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                cboWorkgroup.Select(0, cboWorkgroup.MaxLength);
                                                                cboWorkgroup.Focus();
                                                            }
                                                            reader_workgroup.Close();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Invalid service type.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            cboServiceType.Select(0, cboServiceType.MaxLength);
                                                            cboServiceType.Focus();
                                                        }
                                                        reader_servicetype.Close();
                                                        break;
                                                    }
                                            }
                                        }

                                        else
                                        {
                                            MessageBox.Show("PL Number already exists.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            }
                            else
                            {
                                MessageBox.Show("Ticket number length not valid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTicketNumber.Select(0, txtTicketNumber.MaxLength);
                                txtTicketNumber.Focus();
                            }
                        }
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
                        btnEdit.Enabled = false;
                        btnEdit.BackColor = SystemColors.WindowFrame;
                        btnEdit.Text = "Edit details";
                        btnClose.Text = "Close";
                        lsvData.Enabled = true;
                        lsvData.BackColor = SystemColors.ControlDark;
                        txtTicketNumber.ReadOnly = true;
                        txtPLNumber.ReadOnly = true;
                        dtpReportedDate.Enabled = false;
                        txtDescription.ReadOnly = true;
                        txtDescription.BackColor = DefaultBackColor;
                        if (cboRemarks.Text == "OTHERS")
                        {
                            txtOtherRemarks.ReadOnly = true;
                            txtOtherRemarks.BackColor = DefaultBackColor;
                        }
                        cboRemarks.Enabled = false;
                        cboRemarks.BackColor = SystemColors.WindowFrame;
                        cboServiceType.Enabled = false;
                        cboServiceType.BackColor = SystemColors.WindowFrame;
                        cboWorkgroup.Enabled = false;
                        cboWorkgroup.BackColor = SystemColors.WindowFrame;
                        cboTicketType.Enabled = false;
                        cboTicketType.BackColor = SystemColors.WindowFrame;
                        cboFaultType.Enabled = false;
                        cboFaultType.BackColor = SystemColors.WindowFrame;
                        break;
                    }
            }
        }
        private void cboRemarks_TextChanged(object sender, EventArgs e)
        {
            if (cboRemarks.Text == "OTHERS")
            {
                txtOtherRemarks.ReadOnly = false;
            }
            else
            {
                txtOtherRemarks.ReadOnly = true;
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
        string activity;
        private void shadow()
        {
            activity = "Ticket (" + prevticketnumber + ") has been updated into ticket (" + txtTicketNumber.Text + ").";

            shadowTrail();
        }
        private void shadowTrail()
        {
            string username = lblUsername_.Text;
            string workgroup = lblWorkgroup_.Text;
            string databasename = lblDatabase_.Text;
            Program.AuditTrail(activity, username, workgroup,databasename);
        }
        private void txtPLNumber_Leave(object sender, EventArgs e)
        {
            txtPLNumber.Text = txtPLNumber.Text.ToUpper();
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
                    btnLess.BackColor = SystemColors.WindowFrame;
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
                    MessageBox.Show("End of records.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnMore.Enabled = false;
                    btnMore.BackColor = SystemColors.WindowFrame;
                    counter = 50;
                }
            }
            getInfo();
            btnLess.Enabled = true;
            btnLess.BackColor = SystemColors.Control;
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
        private void cboTicketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFaultType.Items.Clear();
            cboServiceType.Items.Clear();
            cboServiceType.Text = "";
            cboFaultType.Text = "";
            switch (cboTicketType.SelectedIndex)
            {
                case 0:
                    {
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
                        break;
                    }
                case 1:
                    {
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
                        break;
                    }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (txtSearch.Visible)
            {
                case true:
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
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_tickets" + " where ticketnumber like '" + txtSearch.Text + "%" + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    resetCounter();
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where ticketnumber like '" + txtSearch.Text + "%" + "' order by ticketnumber limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                                        var reportedtime = reader.GetString(8);
                                        lst.SubItems.Add(reporteddate + " " + reportedtime);
                                        var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                                        var updatedtime = reader.GetString(10);
                                        lst.SubItems.Add(updateddate + " " + updatedtime);
                                        lst.SubItems.Add(reader.GetString(3));
                                        lst.SubItems.Add(reader.GetString(4));
                                        lst.SubItems.Add(reader.GetString(2));
                                        lst.SubItems.Add(reader.GetString(5));
                                        lst.SubItems.Add(reader.GetString(6));
                                        lst.SubItems.Add(reader.GetString(11));
                                        lsvData.Items.Add(lst);
                                    }
                                    reader.Close();
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
                                    foreach (ListViewItem lst in lsvData.Items)
                                    {
                                        var reporteddate = Convert.ToDateTime(lst.SubItems[2].Text).ToString("yyyy-MM-dd HH:mm:ss");
                                        var updateddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        mark = lst.SubItems[9].Text;

                                        DateTime reportdate;
                                        if (DateTime.TryParse(reporteddate, out reportdate))
                                        {
                                            dtpReported.Value = reportdate;
                                        }
                                        DateTime updatedate;
                                        if (DateTime.TryParse(updateddate, out updatedate))
                                        {
                                            dtpUpdated.Value = updatedate;
                                        }
                                        DateTime report_date = Convert.ToDateTime(dtpReported.Value);
                                        DateTime update_date = Convert.ToDateTime(dtpUpdated.Value);
                                        TimeSpan result = (update_date - report_date);
                                        double outage = result.TotalHours;
                                        if (outage < 4 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Thistle;
                                        }
                                        else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.LimeGreen;
                                        }
                                        else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.GreenYellow;
                                        }
                                        else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Gold;
                                        }
                                        else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Orange;
                                        }
                                        else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Tomato;
                                        }
                                        else if (outage >= 48 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Red;
                                        }
                                        else
                                        {
                                            lst.BackColor = Color.White;
                                        }
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
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_tickets" + " where plnumber like '" + txtSearch.Text + "%" + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    resetCounter();
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where plnumber like '" + txtSearch.Text + "%" + "' order by plnumber limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                                        var reportedtime = reader.GetString(8);
                                        lst.SubItems.Add(reporteddate + " " + reportedtime);
                                        var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                                        var updatedtime = reader.GetString(10);
                                        lst.SubItems.Add(updateddate + " " + updatedtime);
                                        lst.SubItems.Add(reader.GetString(3));
                                        lst.SubItems.Add(reader.GetString(4));
                                        lst.SubItems.Add(reader.GetString(2));
                                        lst.SubItems.Add(reader.GetString(5));
                                        lst.SubItems.Add(reader.GetString(6));
                                        lst.SubItems.Add(reader.GetString(11));
                                        lsvData.Items.Add(lst);
                                    }
                                    reader.Close();
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
                                    foreach (ListViewItem lst in lsvData.Items)
                                    {
                                        var reporteddate = Convert.ToDateTime(lst.SubItems[2].Text).ToString("yyyy-MM-dd HH:mm:ss");
                                        var updateddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        mark = lst.SubItems[9].Text;
                                        DateTime reportdate;
                                        if (DateTime.TryParse(reporteddate, out reportdate))
                                        {
                                            dtpReported.Value = reportdate;
                                        }
                                        DateTime updatedate;
                                        if (DateTime.TryParse(updateddate, out updatedate))
                                        {
                                            dtpUpdated.Value = updatedate;
                                        }
                                        DateTime report_date = Convert.ToDateTime(dtpReported.Value);
                                        DateTime update_date = Convert.ToDateTime(dtpUpdated.Value);
                                        TimeSpan result = (update_date - report_date);
                                        double outage = result.TotalHours;
                                        if (outage < 4 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Thistle;
                                        }
                                        else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.LimeGreen;
                                        }
                                        else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.GreenYellow;
                                        }
                                        else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Gold;
                                        }
                                        else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Orange;
                                        }
                                        else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Tomato;
                                        }
                                        else if (outage >= 48 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Red;
                                        }
                                        else
                                        {
                                            lst.BackColor = Color.White;
                                        }
                                    }
                                    break;
                                }
                            case 8:
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
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_tickets" + " where description like '" + "%" + txtSearch.Text + "%" + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    resetCounter();
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where description like '" + "%" + txtSearch.Text + "%" + "' order by ticketnumber limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                                        var reportedtime = reader.GetString(8);
                                        lst.SubItems.Add(reporteddate + " " + reportedtime);
                                        var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                                        var updatedtime = reader.GetString(10);
                                        lst.SubItems.Add(updateddate + " " + updatedtime);
                                        lst.SubItems.Add(reader.GetString(3));
                                        lst.SubItems.Add(reader.GetString(4));
                                        lst.SubItems.Add(reader.GetString(2));
                                        lst.SubItems.Add(reader.GetString(5));
                                        lst.SubItems.Add(reader.GetString(6));
                                        lst.SubItems.Add(reader.GetString(11));
                                        lsvData.Items.Add(lst);
                                    }
                                    reader.Close();
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
                                    foreach (ListViewItem lst in lsvData.Items)
                                    {
                                        var reporteddate = Convert.ToDateTime(lst.SubItems[2].Text).ToString("yyyy-MM-dd HH:mm:ss");
                                        var updateddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        mark = lst.SubItems[9].Text;

                                        DateTime reportdate;
                                        if (DateTime.TryParse(reporteddate, out reportdate))
                                        {
                                            dtpReported.Value = reportdate;
                                        }
                                        DateTime updatedate;
                                        if (DateTime.TryParse(updateddate, out updatedate))
                                        {
                                            dtpUpdated.Value = updatedate;
                                        }
                                        DateTime report_date = Convert.ToDateTime(dtpReported.Value);
                                        DateTime update_date = Convert.ToDateTime(dtpUpdated.Value);
                                        TimeSpan result = (update_date - report_date);
                                        double outage = result.TotalHours;
                                        if (outage < 4 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Thistle;
                                        }
                                        else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.LimeGreen;
                                        }
                                        else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.GreenYellow;
                                        }
                                        else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Gold;
                                        }
                                        else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Orange;
                                        }
                                        else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Tomato;
                                        }
                                        else if (outage >= 48 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Red;
                                        }
                                        else
                                        {
                                            lst.BackColor = Color.White;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }
                case false:
                    {
                        switch (cboSearch.Visible)
                        {
                            case true:
                                {
                                    switch (cboSearchType.SelectedIndex)
                                    {
                                        case 4:
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
                                                string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_tickets" + " where servicetype like '" + cboSearch.Text + "'";
                                                MySqlCommand query_ = new MySqlCommand(que, conn);
                                                conn.Open();
                                                count = query_.ExecuteScalar().ToString();
                                                conn.Close();
                                                txtTotalRow.Text = count;
                                                resetCounter();
                                                string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where servicetype like '" + cboSearch.Text + "' order by servicetype limit " + tableshow + "," + tablecount;
                                                MySqlDataReader reader = Program.Query(query);
                                                lsvData.Items.Clear();
                                                while (reader.Read())
                                                {
                                                    ListViewItem lst = new ListViewItem(reader.GetString(0));
                                                    lst.SubItems.Add(reader.GetString(1));
                                                    var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                                                    var reportedtime = reader.GetString(8);
                                                    lst.SubItems.Add(reporteddate + " " + reportedtime);
                                                    var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                                                    var updatedtime = reader.GetString(10);
                                                    lst.SubItems.Add(updateddate + " " + updatedtime);
                                                    lst.SubItems.Add(reader.GetString(3));
                                                    lst.SubItems.Add(reader.GetString(4));
                                                    lst.SubItems.Add(reader.GetString(2));
                                                    lst.SubItems.Add(reader.GetString(5));
                                                    lst.SubItems.Add(reader.GetString(6));
                                                    lst.SubItems.Add(reader.GetString(11));
                                                    lsvData.Items.Add(lst);
                                                }
                                                reader.Close();
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
                                                foreach (ListViewItem lst in lsvData.Items)
                                                {
                                                    var reporteddate = Convert.ToDateTime(lst.SubItems[2].Text).ToString("yyyy-MM-dd HH:mm:ss");
                                                    var updateddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    mark = lst.SubItems[9].Text;
                                                    DateTime reportdate;
                                                    if (DateTime.TryParse(reporteddate, out reportdate))
                                                    {
                                                        dtpReported.Value = reportdate;
                                                    }
                                                    DateTime updatedate;
                                                    if (DateTime.TryParse(updateddate, out updatedate))
                                                    {
                                                        dtpUpdated.Value = updatedate;
                                                    }
                                                    DateTime report_date = Convert.ToDateTime(dtpReported.Value);
                                                    DateTime update_date = Convert.ToDateTime(dtpUpdated.Value);
                                                    TimeSpan result = (update_date - report_date);
                                                    double outage = result.TotalHours;
                                                    if (outage < 4 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Thistle;
                                                    }
                                                    else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.LimeGreen;
                                                    }
                                                    else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.GreenYellow;
                                                    }
                                                    else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Gold;
                                                    }
                                                    else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Orange;
                                                    }
                                                    else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Tomato;
                                                    }
                                                    else if (outage >= 48 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Red;
                                                    }
                                                    else
                                                    {
                                                        lst.BackColor = Color.White;
                                                    }
                                                }
                                                break;
                                            }
                                        case 5:
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
                                                string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_tickets" + " where workgroup like '" + cboSearch.Text + "'";
                                                MySqlCommand query_ = new MySqlCommand(que, conn);
                                                conn.Open();
                                                count = query_.ExecuteScalar().ToString();
                                                conn.Close();
                                                txtTotalRow.Text = count;
                                                resetCounter();
                                                string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where workgroup like '" + cboSearch.Text + "' order by workgroup limit " + tableshow + "," + tablecount;
                                                MySqlDataReader reader = Program.Query(query);
                                                lsvData.Items.Clear();
                                                while (reader.Read())
                                                {
                                                    ListViewItem lst = new ListViewItem(reader.GetString(0));
                                                    lst.SubItems.Add(reader.GetString(1));
                                                    var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                                                    var reportedtime = reader.GetString(8);
                                                    lst.SubItems.Add(reporteddate + " " + reportedtime);
                                                    var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                                                    var updatedtime = reader.GetString(10);
                                                    lst.SubItems.Add(updateddate + " " + updatedtime);
                                                    lst.SubItems.Add(reader.GetString(3));
                                                    lst.SubItems.Add(reader.GetString(4));
                                                    lst.SubItems.Add(reader.GetString(2));
                                                    lst.SubItems.Add(reader.GetString(5));
                                                    lst.SubItems.Add(reader.GetString(6));
                                                    lst.SubItems.Add(reader.GetString(11));
                                                    lsvData.Items.Add(lst);
                                                }
                                                reader.Close();
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
                                                foreach (ListViewItem lst in lsvData.Items)
                                                {
                                                    var reporteddate = Convert.ToDateTime(lst.SubItems[2].Text).ToString("yyyy-MM-dd HH:mm:ss");
                                                    var updateddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    mark = lst.SubItems[9].Text;

                                                    DateTime reportdate;
                                                    if (DateTime.TryParse(reporteddate, out reportdate))
                                                    {
                                                        dtpReported.Value = reportdate;
                                                    }
                                                    DateTime updatedate;
                                                    if (DateTime.TryParse(updateddate, out updatedate))
                                                    {
                                                        dtpUpdated.Value = updatedate;
                                                    }
                                                    DateTime report_date = Convert.ToDateTime(dtpReported.Value);
                                                    DateTime update_date = Convert.ToDateTime(dtpUpdated.Value);
                                                    TimeSpan result = (update_date - report_date);
                                                    double outage = result.TotalHours;
                                                    if (outage < 4 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Thistle;
                                                    }
                                                    else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.LimeGreen;
                                                    }
                                                    else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.GreenYellow;
                                                    }
                                                    else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Gold;
                                                    }
                                                    else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Orange;
                                                    }
                                                    else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Tomato;
                                                    }
                                                    else if (outage >= 48 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Red;
                                                    }
                                                    else
                                                    {
                                                        lst.BackColor = Color.White;
                                                    }
                                                }
                                                break;
                                            }
                                        case 6:
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
                                                string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_tickets" + " where faulttype like '" + cboSearch.Text + "'";
                                                MySqlCommand query_ = new MySqlCommand(que, conn);
                                                conn.Open();
                                                count = query_.ExecuteScalar().ToString();
                                                conn.Close();
                                                txtTotalRow.Text = count;
                                                resetCounter();
                                                string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where faulttype like '" + cboSearch.Text + "' order by faulttype limit " + tableshow + "," + tablecount;
                                                MySqlDataReader reader = Program.Query(query);
                                                lsvData.Items.Clear();
                                                while (reader.Read())
                                                {
                                                    ListViewItem lst = new ListViewItem(reader.GetString(0));
                                                    lst.SubItems.Add(reader.GetString(1));
                                                    var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                                                    var reportedtime = reader.GetString(8);
                                                    lst.SubItems.Add(reporteddate + " " + reportedtime);
                                                    var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                                                    var updatedtime = reader.GetString(10);
                                                    lst.SubItems.Add(updateddate + " " + updatedtime);
                                                    lst.SubItems.Add(reader.GetString(3));
                                                    lst.SubItems.Add(reader.GetString(4));
                                                    lst.SubItems.Add(reader.GetString(2));
                                                    lst.SubItems.Add(reader.GetString(5));
                                                    lst.SubItems.Add(reader.GetString(6));
                                                    lst.SubItems.Add(reader.GetString(11));
                                                    lsvData.Items.Add(lst);
                                                }
                                                reader.Close();
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
                                                foreach (ListViewItem lst in lsvData.Items)
                                                {
                                                    var reporteddate = Convert.ToDateTime(lst.SubItems[2].Text).ToString("yyyy-MM-dd HH:mm:ss");
                                                    var updateddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    mark = lst.SubItems[9].Text;

                                                    DateTime reportdate;
                                                    if (DateTime.TryParse(reporteddate, out reportdate))
                                                    {
                                                        dtpReported.Value = reportdate;
                                                    }
                                                    DateTime updatedate;
                                                    if (DateTime.TryParse(updateddate, out updatedate))
                                                    {
                                                        dtpUpdated.Value = updatedate;
                                                    }
                                                    DateTime report_date = Convert.ToDateTime(dtpReported.Value);
                                                    DateTime update_date = Convert.ToDateTime(dtpUpdated.Value);
                                                    TimeSpan result = (update_date - report_date);
                                                    double outage = result.TotalHours;
                                                    if (outage < 4 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Thistle;
                                                    }
                                                    else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.LimeGreen;
                                                    }
                                                    else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.GreenYellow;
                                                    }
                                                    else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Gold;
                                                    }
                                                    else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Orange;
                                                    }
                                                    else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Tomato;
                                                    }
                                                    else if (outage >= 48 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Red;
                                                    }
                                                    else
                                                    {
                                                        lst.BackColor = Color.White;
                                                    }
                                                }
                                                break;
                                            }
                                        case 7:
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
                                                string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_tickets" + " where remarks like '" + cboSearch.Text + "'";
                                                MySqlCommand query_ = new MySqlCommand(que, conn);
                                                conn.Open();
                                                count = query_.ExecuteScalar().ToString();
                                                conn.Close();
                                                txtTotalRow.Text = count;
                                                resetCounter();
                                                string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where remarks like '" + cboSearch.Text + "' order by remarks limit " + tableshow + "," + tablecount;
                                                MySqlDataReader reader = Program.Query(query);
                                                lsvData.Items.Clear();
                                                while (reader.Read())
                                                {
                                                    ListViewItem lst = new ListViewItem(reader.GetString(0));
                                                    lst.SubItems.Add(reader.GetString(1));
                                                    var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                                                    var reportedtime = reader.GetString(8);
                                                    lst.SubItems.Add(reporteddate + " " + reportedtime);
                                                    var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                                                    var updatedtime = reader.GetString(10);
                                                    lst.SubItems.Add(updateddate + " " + updatedtime);
                                                    lst.SubItems.Add(reader.GetString(3));
                                                    lst.SubItems.Add(reader.GetString(4));
                                                    lst.SubItems.Add(reader.GetString(2));
                                                    lst.SubItems.Add(reader.GetString(5));
                                                    lst.SubItems.Add(reader.GetString(6));
                                                    lst.SubItems.Add(reader.GetString(11));
                                                    lsvData.Items.Add(lst);
                                                }
                                                reader.Close();
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
                                                foreach (ListViewItem lst in lsvData.Items)
                                                {
                                                    var reporteddate = Convert.ToDateTime(lst.SubItems[2].Text).ToString("yyyy-MM-dd HH:mm:ss");
                                                    var updateddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    mark = lst.SubItems[9].Text;

                                                    DateTime reportdate;
                                                    if (DateTime.TryParse(reporteddate, out reportdate))
                                                    {
                                                        dtpReported.Value = reportdate;
                                                    }
                                                    DateTime updatedate;
                                                    if (DateTime.TryParse(updateddate, out updatedate))
                                                    {
                                                        dtpUpdated.Value = updatedate;
                                                    }
                                                    DateTime report_date = Convert.ToDateTime(dtpReported.Value);
                                                    DateTime update_date = Convert.ToDateTime(dtpUpdated.Value);
                                                    TimeSpan result = (update_date - report_date);
                                                    double outage = result.TotalHours;
                                                    if (outage < 4 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Thistle;
                                                    }
                                                    else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.LimeGreen;
                                                    }
                                                    else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.GreenYellow;
                                                    }
                                                    else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Gold;
                                                    }
                                                    else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Orange;
                                                    }
                                                    else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Tomato;
                                                    }
                                                    else if (outage >= 48 && mark != "CLOSED")
                                                    {
                                                        lst.BackColor = Color.Red;
                                                    }
                                                    else
                                                    {
                                                        lst.BackColor = Color.White;
                                                    }
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case false:
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
                                    var date = Convert.ToDateTime(dtpSearch.Value).ToString("yyyy-MM-dd");
                                    //Change TOTAL ROW COUNT
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + date + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    resetCounter();
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + date + "' order by reportedtime limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                                        var reportedtime = reader.GetString(8);
                                        lst.SubItems.Add(reporteddate + " " + reportedtime);
                                        var updateddate = Convert.ToDateTime(reader.GetString(9)).ToString("MMM dd yyyy");
                                        var updatedtime = reader.GetString(10);
                                        lst.SubItems.Add(updateddate + " " + updatedtime);
                                        lst.SubItems.Add(reader.GetString(3));
                                        lst.SubItems.Add(reader.GetString(4));
                                        lst.SubItems.Add(reader.GetString(2));
                                        lst.SubItems.Add(reader.GetString(5));
                                        lst.SubItems.Add(reader.GetString(6));
                                        lst.SubItems.Add(reader.GetString(11));
                                        lsvData.Items.Add(lst);
                                    }
                                    reader.Close();
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
                                    foreach (ListViewItem lst in lsvData.Items)
                                    {
                                        var reporteddate = Convert.ToDateTime(lst.SubItems[2].Text).ToString("yyyy-MM-dd HH:mm:ss");
                                        var updateddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        mark = lst.SubItems[9].Text;

                                        DateTime reportdate;
                                        if (DateTime.TryParse(reporteddate, out reportdate))
                                        {
                                            dtpReported.Value = reportdate;
                                        }
                                        DateTime updatedate;
                                        if (DateTime.TryParse(updateddate, out updatedate))
                                        {
                                            dtpUpdated.Value = updatedate;
                                        }
                                        DateTime report_date = Convert.ToDateTime(dtpReported.Value);
                                        DateTime update_date = Convert.ToDateTime(dtpUpdated.Value);
                                        TimeSpan result = (update_date - report_date);
                                        double outage = result.TotalHours;
                                        if (outage < 4 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Thistle;
                                        }
                                        else if (outage < 8 && outage >= 4 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.LimeGreen;
                                        }
                                        else if (outage < 12 && outage >= 8 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.GreenYellow;
                                        }
                                        else if (outage < 16 && outage >= 12 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Gold;
                                        }
                                        else if (outage < 24 && outage >= 16 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Orange;
                                        }
                                        else if (outage < 48 && outage >= 24 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Tomato;
                                        }
                                        else if (outage >= 48 && mark != "CLOSED")
                                        {
                                            lst.BackColor = Color.Red;
                                        }
                                        else
                                        {
                                            lst.BackColor = Color.White;
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        private void cboRemarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboRemarks.Text)
            {
                case "OTHERS":
                    {
                        txtOtherRemarks.Visible = true;
                        break;
                    }
                default:
                    {
                        txtOtherRemarks.Visible = false;
                        break;
                    }
            }
        }
        private void lsvData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lsvData.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ctmSearchTicket.Show(Cursor.Position);
                }
            }
        }
        private void editTicketDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSearch.Text == "--- Wired ---" || cboSearch.Text == "--- Wireless ---")
            {
                cboSearch.SelectedIndex = -1;
            }
        }

        private void endorseTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmEndorseTickets)
                {
                    f.Focus();
                    return;
                }
           } 
            frmEndorseTickets tickets = new frmEndorseTickets();
            tickets.db_ = lblDatabase_.Text;
            tickets.username_ = lblUsername_.Text;
            tickets.workgroup_ = lblWorkgroup_.Text;
            tickets.txtTicketNumber.Text = txtTicketNumber.Text;
            tickets.Show();
        }
    }
}