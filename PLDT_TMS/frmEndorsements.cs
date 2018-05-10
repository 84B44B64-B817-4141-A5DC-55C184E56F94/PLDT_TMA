using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PLDT_TMS
{
    public partial class frmEndorsements : Form
    {
        public frmEndorsements()
        {
            InitializeComponent();
        }
        //IMPORTANT7
        public string usertype_;
        public string username_;
        public string workgroup_;
        public string db_;
        string count;
        int tablecount = 50;
        int tableshow = 0;
        int disabler, limiter;
        string read;
        private void frmEndorsements_Load(object sender, EventArgs e)
        {
            lblDatabase_.Text = db_;
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;

            getInfo();
        }
        //IMPORTANT
        string mark;
        void getInfo()
        {
            switch (cboSearchType.SelectedIndex)
            {
                case 1:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorser like '" + txtSearch.Text + "%" + "' order by endorsedate limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            lst.SubItems.Add(reader.GetString(3));
                            var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                            lst.SubItems.Add(endorsedate);
                            lst.SubItems.Add(reader.GetString(4));
                            mark = reader.GetString(6);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            if (mark == "Open")
                            {
                                lst.BackColor = Color.LightGray;
                            }
                            else if (mark == "Noted")
                            {
                                lst.BackColor = Color.LightGreen;
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnLess.Enabled = false;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 2:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsee like '" + txtSearch.Text + "%" + "' order by endorsedate limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            lst.SubItems.Add(reader.GetString(3));
                            var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                            lst.SubItems.Add(endorsedate);
                            lst.SubItems.Add(reader.GetString(4));
                            mark = reader.GetString(6);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            if (mark == "Open")
                            {
                                lst.BackColor = Color.LightGray;
                            }
                            else if (mark == "Noted")
                            {
                                lst.BackColor = Color.LightGreen;
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnLess.Enabled = false;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 3:
                    {
                        var date = Convert.ToDateTime(dtpSearch.Value).ToString("yyyy-MM-dd");
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsedate like '" + date + "' order by endorsedate limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            lst.SubItems.Add(reader.GetString(3));
                            var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                            lst.SubItems.Add(endorsedate);
                            lst.SubItems.Add(reader.GetString(4));
                            mark = reader.GetString(6);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            if (mark == "Open")
                            {
                                lst.BackColor = Color.LightGray;
                            }
                            else if (mark == "Noted")
                            {
                                lst.BackColor = Color.LightGreen;
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnLess.Enabled = false;
                        }
                        txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
                        break;
                    }
                case 4:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where workgroup like '" + txtSearch.Text + "%" + "' order by endorsedate limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            lst.SubItems.Add(reader.GetString(3));
                            var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                            lst.SubItems.Add(endorsedate);
                            lst.SubItems.Add(reader.GetString(4));
                            mark = reader.GetString(6);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            if (mark == "Open")
                            {
                                lst.BackColor = Color.LightGray;
                            }
                            else
                            {
                                lst.BackColor = Color.LightGreen;
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnLess.Enabled = false;
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
                        string forQuery = "Select count(*) from " + lblDatabase_.Text + ".tbl_endorsements";
                        MySqlCommand query_ = new MySqlCommand(forQuery, conn);
                        conn.Open();
                        count = query_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow.Text = count;
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            lst.SubItems.Add(reader.GetString(3));
                            var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                            lst.SubItems.Add(endorsedate);
                            lst.SubItems.Add(reader.GetString(4));
                            mark = reader.GetString(6);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            if (mark == "Open")
                            {
                                lst.BackColor = Color.LightGray;
                            }
                            else if (mark == "Noted")
                            {
                                lst.BackColor = Color.LightGreen;
                            }
                        }
                        reader.Close();
                        if (lsvData.Items.Count < 50)
                        {
                            btnMore.Enabled = false;
                            btnLess.Enabled = false;
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
                        btnSearch.Enabled = true;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 2:
                    {
                        txtSearch.Enabled = true;
                        btnSearch.Enabled = true;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 3:
                    {
                        txtSearch.Enabled = true;
                        btnSearch.Enabled = true;
                        txtSearch.Visible = false;
                        dtpSearch.Visible = true;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 4:
                    {
                        txtSearch.Enabled = true;
                        btnSearch.Enabled = true;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                default:
                    {
                        txtSearch.Text = "";
                        txtSearch.Enabled = false;
                        btnSearch.Enabled = false;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        getInfo();
                        lblCount.Text = "";
                        btnMore.Enabled = true;
                        break;
                    }
            }
        }
        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ticketnumber;
            string endorser;
            string endorsee;
            string endorsedate;
            string workgroup;
            string status;
            if (lsvData.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                ListViewItem item = lsvData.SelectedItems[0];
                ticketnumber = item.SubItems[0].Text;
                endorser = item.SubItems[1].Text;
                endorsee = item.SubItems[2].Text;
                endorsedate = item.SubItems[3].Text;
                workgroup = item.SubItems[4].Text;
                status = item.SubItems[5].Text;

                frmEndorsementDetails details = new frmEndorsementDetails();
                details.username_ = lblUsername_.Text;
                details.workgroup_ = lblWorkgroup_.Text;
                details.db_ = lblDatabase_.Text;
                details.txtTicketNumber.Text = ticketnumber;
                details.txtEndorser.Text = endorser;
                details.txtEndorseDate.Text = endorsedate;
                details.txtEndorsee.Text = endorsee;
                details.txtWorkgroup.Text = workgroup;
                details.txtStatus.Text = status;
                details.ShowDialog();
            }
        }
        private void viewTicketDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ticketnumber;
            if (lsvData.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                ListViewItem item = lsvData.SelectedItems[0];
                ticketnumber = item.SubItems[0].Text;
                string status = item.SubItems[5].Text;
                if (status == "Open")
                {
                    frmSearchTicket searchticket = new frmSearchTicket();
                    searchticket.endorsed_ = true;
                    searchticket.doubleclicked_ = true;
                    searchticket.ticketnumber_ = ticketnumber;
                    searchticket.username_ = lblUsername_.Text;
                    searchticket.workgroup_ = lblWorkgroup_.Text;
                    searchticket.db_ = lblDatabase_.Text;
                    searchticket.Show();
                    getInfo();
                }
                else
                {
                    frmSearchTicket searchticket = new frmSearchTicket();
                    searchticket.doubleclicked_ = true;
                    searchticket.ticketnumber_ = ticketnumber;
                    searchticket.username_ = lblUsername_.Text;
                    searchticket.workgroup_ = lblWorkgroup_.Text;
                    searchticket.db_ = lblDatabase_.Text;
                    searchticket.Show();
                    getInfo();
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
                    counter = 0;
                }
            }
            getInfo();
            btnMore.Enabled = true;
            txtShowRow.Text = tableshow.ToString();
            txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
        }
        private void btnMore_Click(object sender, EventArgs e)
        {
            disabler = (tableshow + lsvData.Items.Count + 50);
            if (disabler >= int.Parse(count))
            {
                btnMore.Enabled = false;
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
                    counter = 50;
                }
            }
            getInfo();
            if (limiter == int.Parse(count))
            {
                MessageBox.Show("End of records.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMore.Enabled = false;
                counter = 50;
            }
            btnLess.Enabled = true;
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
                btnLess.Enabled = false;
                txtRow.Text = lsvData.Items.Count.ToString();
            }
            else
            {
                btnMore.Enabled = true;
                btnLess.Enabled = false;
                txtRow.Text = "50";
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
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_endorsements" + " where endorser like '" + txtSearch.Text + "%" + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    resetCounter();
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorser like '" + txtSearch.Text + "%" + "' order by endorsedate limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        lst.SubItems.Add(reader.GetString(3));
                                        var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                        lst.SubItems.Add(endorsedate);
                                        lst.SubItems.Add(reader.GetString(4));
                                        mark = reader.GetString(6);
                                        lst.SubItems.Add(mark);
                                        lsvData.Items.Add(lst);
                                        if (mark == "Open")
                                        {
                                            lst.BackColor = Color.LightGray;
                                        }
                                        else if (mark == "Noted")
                                        {
                                            lst.BackColor = Color.LightGreen;
                                        }
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
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsee like '" + txtSearch.Text + "%" + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    resetCounter();
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsee like '" + txtSearch.Text + "%" + "' order by endorsedate limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        lst.SubItems.Add(reader.GetString(3));
                                        var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                        lst.SubItems.Add(endorsedate);
                                        lst.SubItems.Add(reader.GetString(4));
                                        mark = reader.GetString(6);
                                        lst.SubItems.Add(mark);
                                        lsvData.Items.Add(lst);
                                        if (mark == "Open")
                                        {
                                            lst.BackColor = Color.LightGray;
                                        }
                                        else if (mark == "Noted")
                                        {
                                            lst.BackColor = Color.LightGreen;
                                        }
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
                                    break;
                                }
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
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_endorsements" + " where workgroup like '" + txtSearch.Text + "%" + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    resetCounter();
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where workgroup like '" + txtSearch.Text + "%" + "' order by endorsedate limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        lst.SubItems.Add(reader.GetString(3));
                                        var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                        lst.SubItems.Add(endorsedate);
                                        lst.SubItems.Add(reader.GetString(4));
                                        mark = reader.GetString(6);
                                        lst.SubItems.Add(mark);
                                        lsvData.Items.Add(lst);

                                        if (mark == "Open")
                                        {
                                            lst.BackColor = Color.LightGray;
                                        }
                                        else if (mark == "Noted")
                                        {
                                            lst.BackColor = Color.LightGreen;
                                        }
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
                        string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsedate like '" + date + "'";
                        MySqlCommand query_ = new MySqlCommand(que, conn);
                        conn.Open();
                        count = query_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow.Text = count;
                        resetCounter();
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsedate like '" + date + "' order by endorsedate limit " + tableshow + "," + tablecount;
                        MySqlDataReader reader = Program.Query(query);
                        lsvData.Items.Clear();
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            lst.SubItems.Add(reader.GetString(3));
                            var endorsedate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                            lst.SubItems.Add(endorsedate);
                            lst.SubItems.Add(reader.GetString(4));
                            mark = reader.GetString(6);
                            lst.SubItems.Add(mark);
                            lsvData.Items.Add(lst);
                            if (mark == "Open")
                            {
                                lst.BackColor = Color.LightGray;
                            }
                            else if (mark == "Noted")
                            {
                                lst.BackColor = Color.LightGreen;
                            }
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
                        break;
                    }
            }
        }
    }
}