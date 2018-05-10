using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PLDT_TMS
{
    public partial class frmCritical : Form
    {
        //IMPORTANT
        public string usertype_;
        public string username_;
        public string workgroup_;
        public string db_;
        string read;
        //IMPORTANT
        int tablecount = 50;
        int tableshow = 0;
        int limiter = 0;
        string count;
        int row;
        int disabler;
        bool formIsOpen;
        public frmCritical()
        {
            InitializeComponent();
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
        private void frmCritical_Load(object sender, EventArgs e)
        {
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;
            lblDatabase_.Text = db_;
            getInfo();
        }
        void getInfo()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

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
            string forQuerydaily = "Select count(*) from " + lblDatabase_.Text + ".tbl_tickets" + " where remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "' and outage >= '" + 16 + "'";
            MySqlCommand querydaily_ = new MySqlCommand(forQuerydaily, conn);
            conn.Open();
            count = querydaily_.ExecuteScalar().ToString();
            conn.Close();
            txtTotalRow.Text = count;
            if (int.Parse(count) <= 50)
            {
                btnMore.Enabled = false;
            }
            else
            {
                btnMore.Enabled = true;
            }
            string query = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "' and outage >= '" + 16 + "' order by outage desc limit " + tableshow + "," + tablecount;
            lsvData.Items.Clear();
            MySqlDataReader reader = Program.Query(query);
            while (reader.Read())
            {
                ListViewItem lst = new ListViewItem(reader.GetString(0));
                var reporteddate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                var reportedtime = Convert.ToDateTime(reader.GetString(8)).ToString("HH:mm:ss");
                string date = reporteddate + " " + reportedtime;
                lst.SubItems.Add(date);
                double outage = double.Parse(reader.GetString(13));
                lst.SubItems.Add((Math.Round(outage, 3)).ToString());
                lst.SubItems.Add(reader.GetString(2));
                lsvData.Items.Add(lst);
            }
            reader.Close();
            foreach (ListViewItem lst in lsvData.Items)
            {
                double outage = double.Parse(lst.SubItems[2].Text);

                if (outage < 16 && outage >= 12)
                {
                    lst.BackColor = Color.Gold;
                }
                else if (outage < 24 && outage >= 16)
                {
                    lst.BackColor = Color.Orange;
                }
                else if (outage < 48 && outage >= 24)
                {
                    lst.BackColor = Color.Tomato;
                }
                else if (outage >= 48)
                {
                    lst.BackColor = Color.Red;
                }
                else
                {
                    lst.BackColor = Color.White;
                }
            }
            txtRow.Text = (tableshow + lsvData.Items.Count).ToString();
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
                bool formRead = true;
                try
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is frmSearchTicket && formRead != false)
                        {
                            var Question = MessageBox.Show("Ticket registry is already open. Open another instance?", "System", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (Question == DialogResult.No)
                            {
                                f.Close();
                                formIsOpen = true;
                            }
                            else if (Question == DialogResult.Cancel)
                            {
                                return;
                            }
                            else
                            {
                                formRead = false;
                            }
                        }
                        else
                        {
                            formIsOpen = false;
                        }
                    }
                }
                catch
                {
                    frmSearchTicket searchticket = new frmSearchTicket();
                    searchticket.doubleclicked_ = true;
                    searchticket.ticketnumber_ = ticketnumber;
                    searchticket.username_ = lblUsername_.Text;
                    searchticket.workgroup_ = lblWorkgroup_.Text;
                    searchticket.db_ = lblDatabase_.Text;
                    searchticket.Show();
                }
            }
            switch (formIsOpen)
            {
                case false:
                    {

                        frmSearchTicket searchticket = new frmSearchTicket();
                        searchticket.doubleclicked_ = true;
                        searchticket.ticketnumber_ = ticketnumber;
                        searchticket.username_ = lblUsername_.Text;
                        searchticket.workgroup_ = lblWorkgroup_.Text;
                        searchticket.db_ = lblDatabase_.Text;
                        searchticket.Show();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}