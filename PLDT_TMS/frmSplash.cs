using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PLDT_TMS
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }
        //IMPORTANT
        public string usertype_;
        public string username_;
        public string workgroup_;
        public string db_;
        string activity;
        bool process;
        string action;
        string statuschecker;
        System.Threading.Thread outage_updater;
        double outage, addOutage = 0;
        int timer = 0;
        protected void frmSplash_Load(object sender, EventArgs e)
        {
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;
            lblDatabase_.Text = db_;
            timStart.Start();
            outage_updater = new System.Threading.Thread(Update_Outage);
            outage_updater.Start();
        }
        private void Update_Outage()
        {
            string forReader_Time = "Select * from " + lblDatabase_.Text + ".tbl_app";
            MySqlDataReader reader_time = Program.Query(forReader_Time);
            while (reader_time.Read())
            {
                var lastDate = Convert.ToDateTime(reader_time.GetString(0)).ToString("MMM dd yyyy");
                var lastTime = Convert.ToDateTime(reader_time.GetString(1)).ToString("HH:mm:ss");
                string date = lastDate + " " + lastTime;
                DateTime initial_date = Convert.ToDateTime(date);
                DateTime now_date = DateTime.Now;
                TimeSpan result = (now_date - initial_date);
                addOutage = result.TotalHours;
            }
            reader_time.Close();
            string forReader = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "'";
            MySqlDataReader reader = Program.Query(forReader);
            {
                while (reader.Read())
                {
                    string ticketnumber = reader.GetString(0);
                    outage = double.Parse(reader.GetString(13)) + addOutage;
                    outage = Math.Round(outage, 3);
                    string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set outage = '" + outage.ToString() + "' where ticketnumber like '" + ticketnumber + "'";
                    Program.Query(forUpdate).Close();
                }
            }
            reader.Close();
            string lastdate = DateTime.Now.ToString("yyyy-MM-dd"), lasttime = DateTime.Now.ToString("HH:mm:ss");
            string forUpdater = "update " + lblDatabase_.Text + ".tbl_updater" + " set lastdate = '" + lastdate + "', lasttime = '" + lasttime + "'";
            Program.Query(forUpdater).Close();
        }
        private void timStart_Tick(object sender, EventArgs e)
        {
            if (timer == 0)
            {
                lblNote.Text = "Please wait while the database is being updated";
            }
            else if (timer == 1)
            {
                lblNote.Text = "Please wait while the database is being updated.";
            }
            else if (timer == 2)
            {
                lblNote.Text = "Please wait while the database is being updated..";
            }
            else if (timer == 3)
            {
                lblNote.Text = "Please wait while the database is being updated...";
            }
            else if (timer == 4)
            {
                lblNote.Text = "Please wait while the database is being updated....";
                timer = -1;
            }
            timer++;
            if (outage_updater.IsAlive == false)
            {
                frmMain main = new frmMain();
                main.username_ = lblUsername_.Text;
                main.workgroup_ = "ADMIN";
                main.usertype_ = "admin";
                main.db_ = lblDatabase_.Text;
                action = "login success";
                process = true;
                shadow();
                main.Show();
                timStart.Enabled = false;
                Close();
            }
        }

        private void shadow()
        {
            if (process == true)
            {
                if (action == "login success")
                {
                    activity = lblUsername_.Text + " login successful.";
                }
                else if (action == "login failed")
                {
                    activity = lblUsername_.Text + " login failed. Exceeded limit.";
                }
            }
            shadowTrail();
        }
        private void shadowTrail()
        {
            string username = lblUsername_.Text;
            string workgroup = lblWorkgroup_.Text;
            string databasename = lblDatabase_.Text;
            Program.AuditTrail(activity, username, workgroup, databasename);
            process = false;
        }
    }
}