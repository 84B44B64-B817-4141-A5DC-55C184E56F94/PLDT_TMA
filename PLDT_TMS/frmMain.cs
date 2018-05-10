using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.IO;

namespace PLDT_TMS
{
    public partial class frmMain : Form
    {
        //IMPORTANT
        public string usertype_;
        public string username_;
        public string workgroup_;
        public string db_;
        string read;
        //IMPORTANT
        bool noClose = false;
        double addOutage;
        string balloontype;
        string count_daily;
        int tablecount_daily = 50;
        int tableshow_daily = 0;
        int limiter_daily = 0;
        string count_weekly;
        int tablecount_weekly = 50;
        int tableshow_weekly = 0;
        int limiter_weekly = 0;
        string count_monthly;
        int tablecount_monthly = 50;
        int tableshow_monthly = 0;
        int limiter_monthly = 0;
        int tablecount_endorsement = 50;
        int tableshow_endorsement = 0;
        int limiter_endorsement = 0;
        int count_endorsement = 0;
        int usercount = 0;
        int enablelog = 0;
        int disabler_Daily, disabler_Weekly, disabler_Monthly = 0;
        int rowDaily;
        int rowWeekly_1, rowWeekly_2, rowWeekly_3, rowWeekly_4, rowWeekly_5, rowWeekly_6, rowWeekly_7 = 0;
        int rowMonthly_1, rowMonthly_2, rowMonthly_3, rowMonthly_4, rowMonthly_5, rowMonthly_6, rowMonthly_7 = 0;
        System.Threading.Thread outage_updater;
        string updater;
        bool isUpdating, stillUpdating, updateraccount,forced;
        int messageoffset = 0;
        int update_timer = 300;
        public frmMain()
        {
            InitializeComponent();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void addNewTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmNewTicket)
                {
                    f.Focus();
                    return;
                }
            }
            frmNewTicket newticket = new frmNewTicket();
            newticket.username_ = lblUsername_.Text;
            newticket.workgroup_ = lblWorkgroup_.Text;
            newticket.db_ = lblDatabase_.Text;
            newticket.Show();
        }
        private void searchTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmSearchTicket)
                {
                    f.Focus();
                    return;
                }
            }
            frmSearchTicket searchticket = new frmSearchTicket();
            searchticket.username_ = lblUsername_.Text;
            searchticket.workgroup_ = lblWorkgroup_.Text;
            searchticket.db_ = lblDatabase_.Text;
            searchticket.doubleclicked_ = false;
            searchticket.Show();
        }
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmUserMaintenance)
                {
                    f.Focus();
                    return;
                }
            }
            frmUserMaintenance user = new frmUserMaintenance();
            user.txtUsername.Text = lblUsername_.Text;
            user.txtWorkgroup.Text = lblWorkgroup_.Text;
            user.db_ = lblDatabase_.Text;
            user.ShowDialog();
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmAdminMaintenance)
                {
                    f.Focus();
                    return;
                }
            }
            frmAdminMaintenance admin = new frmAdminMaintenance();
            admin.username_ = lblUsername_.Text;
            admin.workgroup_ = workgroup_;
            admin.db_ = lblDatabase_.Text;
            admin.ShowDialog();
        }
        private void auditTrailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmAuditTrail)
                {
                    f.Focus();
                    return;
                }
            }
            frmAuditTrail audit = new frmAuditTrail();
            audit.username_ = lblUsername_.Text;
            audit.db_ = lblDatabase_.Text;
            audit.ShowDialog();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmAbout)
                {
                    f.Focus();
                    return;
                }
            }
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            balloontype = "welcome";
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;
            lblDatabase_.Text = db_;
            Text = "Ticket Monitor [Logged user: " + username_ + ":" + workgroup_ + "]";
            count_endorsement = 0;
            string forReader_Count = "Select * from " + lblDatabase_.Text + ".tbl_usercount";
            MySqlDataReader reader_count = Program.Query(forReader_Count);
            while (reader_count.Read())
            {
                usercount = int.Parse(reader_count.GetString(0));
                usercount = usercount + 1;
                string forUpdate_Count = "update " + lblDatabase_.Text + ".tbl_usercount" + " set usercount = '" + usercount + "'";
                Program.Query(forUpdate_Count).Close();
            }
            reader_count.Close();
            getInfo();
            string forReader_username = "Select * from " + lblDatabase_.Text + ".tbl_users" + " where username collate latin1_general_cs like '" + lblUsername_.Text + "'";
            MySqlDataReader reader_username = Program.Query(forReader_username);
            while (reader_username.Read())
            {
                lblUsername_Full.Text = reader_username.GetString(5) + ", " + reader_username.GetString(4) + " " + reader_username.GetString(6) + ".";
            }
            reader_username.Close();
            string forReader_endorse = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsee collate latin1_general_cs like '" + lblUsername_Full.Text + "'";
            MySqlDataReader reader_endorse = Program.Query(forReader_endorse);
            while (reader_endorse.Read())
            {
                count_endorsement++;
            }
            reader_endorse.Close();
            string forReader_updater = "Select * from " + lblDatabase_.Text + ".tbl_updater";
            MySqlDataReader reader_updater = Program.Query(forReader_updater);
            while (reader_updater.Read())
            {
                var updatedate = Convert.ToDateTime(reader_updater.GetString(0)).ToString("MMM dd yyyy");
                var updatetime = Convert.ToDateTime(reader_updater.GetString(1)).ToString("HH:mm:ss");
                string date = updatedate + " " + updatetime;
                lblLastUpdate.Text = date;
            }
            reader_updater.Close();
            string forReader_checker = "Select * from " + lblDatabase_.Text + ".tbl_current " + " limit " + "1";
            MySqlDataReader reader_checker = Program.Query(forReader_checker);
            while (reader_checker.Read())
            {
                updater = reader_checker.GetString(0);
            }
            if (updater == username_)
            {
                updateraccount = true;
            }
            reader_checker.Close();
            switch (usertype_)
            {
                case "admin":
                    {
                        tsmAdmin.Enabled = true;
                        tsmAuditTrail.Enabled = true;
                        tsmDatabase.Enabled = true;
                        tsmCategoryManager.Enabled = true;
                        tsmUsers.Enabled = false;
                        btnEnableLog.Visible = true;
                        if (updateraccount == true)
                        {
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            btnUpdate.Visible = false;
                        }
                            break;
                    }
                case "user":
                    {
                        tsmAdmin.Enabled = false;
                        tsmAuditTrail.Enabled = false;
                        tsmDatabase.Enabled = false;
                        tsmCategoryManager.Enabled = false;
                        tsmUsers.Enabled = true;
                        btnEnableLog.Visible = false;
                        btnUpdate.Visible = false;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Login error.");
                        break;
                    }
            }
            if (count_endorsement != 0)
            {
                if (count_endorsement == 1)
                {
                    notMain.BalloonTipText = "Welcome [ " + lblUsername_.Text + " ].\nYou have " + count_endorsement.ToString() + " pending endorsement.";
                    notMain.ShowBalloonTip(60000);
                }
                else
                {
                    notMain.BalloonTipText = "Welcome [ " + lblUsername_.Text + " ].\nYou have " + count_endorsement.ToString() + " pending endorsements.";
                    notMain.ShowBalloonTip(60000);
                }
            }
            else
            {
                notMain.BalloonTipText = "Welcome [ " + lblUsername_.Text + " ].";
                notMain.ShowBalloonTip(60000);
            }
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (updateraccount == true)
            {
                string closingdate = DateTime.Now.ToString("yyyy-MM-dd"), closingtime = DateTime.Now.ToString("HH:mm:ss");
                string forUpdate = "update " + lblDatabase_.Text + ".tbl_app" + " set closingdate = '" + closingdate + "', closingtime = '" + closingtime + "'";
                Program.Query(forUpdate).Close();
            }
            string forReader_Count = "Select * from " + lblDatabase_.Text + ".tbl_usercount";
            MySqlDataReader reader_count = Program.Query(forReader_Count);
            while (reader_count.Read())
            {
                usercount = int.Parse(reader_count.GetString(0));
                usercount = usercount - 1;
                string forUpdate_Count = "update " + lblDatabase_.Text + ".tbl_usercount" + " set usercount = '" + usercount + "'";
                Program.Query(forUpdate_Count).Close();
                if (usercount < 1)
                {
                    string forEnableUpdate = "update " + lblDatabase_.Text + ".tbl_app" + " set enablelog = '" + 0 + "'";
                    Program.Query(forEnableUpdate).Close();
                    string forDelete = "truncate table " + lblDatabase_.Text + ".tbl_current";
                    Program.Query(forDelete).Close();
                }
                else
                {
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_current" + " from " + lblDatabase_.Text + ".tbl_current" + " where username collate latin1_general_cs like '" + username_ + "'";
                    Program.Query(forDelete).Close();
                }
            }
            reader_count.Close();
            Application.Exit();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (forced != true)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }

                if (MessageBox.Show("Exit application?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    formChecker();
                    if (noClose == true)
                    {
                        if (MessageBox.Show("There are still unclosed forms. Exit application?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        private void formChecker()
        {
            bool _frmNewTicket = false;
            bool _frmSearchTicket = false;
            bool _frmCurrentShift = false;
            bool _frmClosedTickets = false;
            bool _frmOpenTickets = false;
            bool _frmCarryOver = false;
            bool _frmUserMaintainance = false;
            bool _frmAdminMaintenance = false;
            bool _frmAuditTrail = false;
            bool _frmBackup = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmNewTicket)
                {
                    _frmNewTicket = true;
                }
                if (f is frmSearchTicket)
                {
                    _frmSearchTicket = true;
                }
                if (f is frmBackup)
                {
                    _frmBackup = true;
                }
                if (f is frmUserMaintenance)
                {
                    _frmUserMaintainance = true;
                }
                if (f is frmAdminMaintenance)
                {
                    _frmAdminMaintenance = true;
                }
                if (f is frmAuditTrail)
                {
                    _frmAuditTrail = true;
                }
                if (_frmBackup == true || _frmAdminMaintenance == true || _frmAuditTrail == true || _frmCarryOver == true || _frmClosedTickets == true || _frmCurrentShift == true || _frmNewTicket == true || _frmOpenTickets == true || _frmSearchTicket == true || _frmUserMaintainance == true)
                {
                    noClose = true;
                }
                else
                {
                    noClose = false;
                }
            }
        }
        int colorswitch = 0;
        private void timClock_Tick(object sender, EventArgs e)
        {
            if (isUpdating == true)
            {
                getInfo();
                proUpdate.Style = ProgressBarStyle.Blocks;
                string forReader_updater = "Select * from " + lblDatabase_.Text + ".tbl_updater";
                MySqlDataReader reader_updater = Program.Query(forReader_updater);
                while (reader_updater.Read())
                {
                    var updatedate = Convert.ToDateTime(reader_updater.GetString(0)).ToString("MMM dd yyyy");
                    var updatetime = Convert.ToDateTime(reader_updater.GetString(1)).ToString("HH:mm:ss");
                    string date = updatedate + " " + updatetime;
                    lblLastUpdate.Text = date;
                }
                reader_updater.Close();
                lblUpdate.Visible = true;
                string count_outage;
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
                string forOutageChecker = "Select count(*) from " + lblDatabase_.Text + ".tbl_tickets" + " where outage >= '" + 16 + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "'";
                MySqlCommand queryOutage = new MySqlCommand(forOutageChecker, conn);
                conn.Open();
                count_outage = queryOutage.ExecuteScalar().ToString();
                conn.Close();
                if (int.Parse(count_outage) != 0)
                {
                    balloontype = "critical";
                    notMain.BalloonTipText = "There are " + count_outage + " critically-aged tickets. Click here to view them.";
                    notMain.ShowBalloonTip(60000);
                }
                isUpdating = false;
                btnUpdate.Enabled = true;
            }
            string clockdate = DateTime.Now.ToString("MMM dd yyyy");
            string clocktime = DateTime.Now.ToLongTimeString();
            lblClock.Text = clockdate + " - " + clocktime;
            switch (colorswitch)
            {
                case 0:
                    {
                        if (txtDaily_Less4.Text != "0")
                        {
                            ovaDaily1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaDaily1.Enabled = false;
                            ovaDaily1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More4.Text != "0")
                        {
                            ovaDaily2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaDaily2.Enabled = false;
                            ovaDaily2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More8.Text != "0")
                        {
                            ovaDaily3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaDaily3.Enabled = false;
                            ovaDaily3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More12.Text != "0")
                        {
                            ovaDaily4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaDaily4.Enabled = false;
                            ovaDaily4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More16.Text != "0")
                        {
                            ovaDaily5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaDaily5.Enabled = false;
                            ovaDaily5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More24.Text != "0")
                        {
                            ovaDaily6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaDaily6.Enabled = false;
                            ovaDaily6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More48.Text != "0")
                        {
                            ovaDaily7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaDaily7.Enabled = false;
                            ovaDaily7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_Less4.Text != "0")
                        {
                            ovalShape1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovalShape1.Enabled = false;
                            ovalShape1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More4.Text != "0")
                        {
                            ovalShape2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovalShape2.Enabled = false;
                            ovalShape2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More8.Text != "0")
                        {
                            ovalShape3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovalShape3.Enabled = false;
                            ovalShape3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More12.Text != "0")
                        {
                            ovalShape4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovalShape4.Enabled = false;
                            ovalShape4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More16.Text != "0")
                        {
                            ovalShape5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovalShape5.Enabled = false;
                            ovalShape5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More24.Text != "0")
                        {
                            ovalShape6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovalShape6.Enabled = false;
                            ovalShape6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More48.Text != "0")
                        {
                            ovalShape7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovalShape7.Enabled = false;
                            ovalShape7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_Less4.Text != "0")
                        {
                            ovaMonthly1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaMonthly2.Enabled = false;
                            ovaMonthly1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More4.Text != "0")
                        {
                            ovaMonthly2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaMonthly2.Enabled = false;
                            ovaMonthly2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More8.Text != "0")
                        {
                            ovaMonthly3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaMonthly3.Enabled = false;
                            ovaMonthly3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More12.Text != "0")
                        {
                            ovaMonthly4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaMonthly4.Enabled = false;
                            ovaMonthly4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More16.Text != "0")
                        {
                            ovaMonthly5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaMonthly5.Enabled = false;
                            ovaMonthly5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More24.Text != "0")
                        {
                            ovaMonthly6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaMonthly6.Enabled = false;
                            ovaMonthly6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More48.Text != "0")
                        {
                            ovaMonthly7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
                        }
                        else
                        {
                            ovaMonthly7.Enabled = false;
                            ovaMonthly7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        colorswitch = 1;
                        break;
                    }
                case 1:
                    {
                        if (txtDaily_Less4.Text != "0")
                        {
                            ovaDaily1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More4.Text != "0")
                        {
                            ovaDaily2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More8.Text != "0")
                        {
                            ovaDaily3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More12.Text != "0")
                        {
                            ovaDaily4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More16.Text != "0")
                        {
                            ovaDaily5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More24.Text != "0")
                        {
                            ovaDaily6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtDaily_More48.Text != "0")
                        {
                            ovaDaily7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_Less4.Text != "0")
                        {
                            ovalShape1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More4.Text != "0")
                        {
                            ovalShape2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More8.Text != "0")
                        {
                            ovalShape3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More12.Text != "0")
                        {
                            ovalShape4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More16.Text != "0")
                        {
                            ovalShape5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More24.Text != "0")
                        {
                            ovalShape6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtWeekly_More48.Text != "0")
                        {
                            ovalShape7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_Less4.Text != "0")
                        {
                            ovaMonthly1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More4.Text != "0")
                        {
                            ovaMonthly2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More8.Text != "0")
                        {
                            ovaMonthly3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More12.Text != "0")
                        {
                            ovaMonthly4.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More16.Text != "0")
                        {
                            ovaMonthly5.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More24.Text != "0")
                        {
                            ovaMonthly6.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        if (txtMonthly_More48.Text != "0")
                        {
                            ovaMonthly7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None;
                        }
                        colorswitch = 0;
                        break;
                    }
            }
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmBackup)
                {
                    f.Focus();
                    return;
                }
            }
            frmBackup backup = new frmBackup();
            backup.db_ = lblDatabase_.Text;
            backup.workgroup_ = lblWorkgroup_.Text;
            backup.username_ = lblUsername_.Text;
            backup.ShowDialog();
        }
        private void getInfo()
        {
            switch (tabMain.SelectedIndex)
            {
                case 0: //DAILY
                    {
                        int less4tickets = 0;
                        int more4tickets = 0;
                        int more8tickets = 0;
                        int more12tickets = 0;
                        int more16tickets = 0;
                        int more24tickets = 0;
                        int more48tickets = 0;
                        string today = DateTime.Now.ToString("yyyy-MM-dd");
                        string forReading_aging = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + today + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "'";
                        MySqlDataReader reader_aging = Program.Query(forReading_aging);
                        while (reader_aging.Read())
                        {
                            var reporteddate = Convert.ToDateTime(reader_aging.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = Convert.ToDateTime(reader_aging.GetString(8)).ToString("HH:mm:ss");
                            string date = reporteddate + " " + reportedtime;
                            DateTime report_date = Convert.ToDateTime(date);
                            DateTime update_date = DateTime.Now;
                            TimeSpan result = (update_date - report_date);
                            double outage = double.Parse(reader_aging.GetString(13));
                            if (outage < 4)
                            {
                                less4tickets++;
                            }
                            else if (outage < 8 && outage >= 4)
                            {
                                more4tickets++;
                            }
                            else if (outage < 12 && outage >= 8)
                            {
                                more8tickets++;
                            }
                            else if (outage < 16 && outage >= 12)
                            {
                                more12tickets++;
                            }
                            else if (outage < 24 && outage >= 16)
                            {
                                more16tickets++;
                            }
                            else if (outage < 48 && outage >= 24)
                            {
                                more24tickets++;
                            }
                            else if (outage >= 48)
                            {
                                more48tickets++;
                            }
                        }
                        reader_aging.Close();
                        txtDaily_Less4.Text = less4tickets.ToString();
                        txtDaily_More4.Text = more4tickets.ToString();
                        txtDaily_More8.Text = more8tickets.ToString();
                        txtDaily_More12.Text = more12tickets.ToString();
                        txtDaily_More16.Text = more16tickets.ToString();
                        txtDaily_More24.Text = more24tickets.ToString();
                        txtDaily_More48.Text = more48tickets.ToString();
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
                        string forQuerydaily = "Select count(*) from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + today + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "'";
                        MySqlCommand querydaily_ = new MySqlCommand(forQuerydaily, conn);
                        conn.Open();
                        count_daily = querydaily_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow_Daily.Text = count_daily;
                        if (int.Parse(count_daily) <= 50)
                        {
                            btnDaily_More.Enabled = false;
                        }
                        else
                        {
                            btnDaily_More.Enabled = true;
                        }
                        txtDaily_Open.Text = count_daily;

                        string query_daily = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + today + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "' limit " + tableshow_daily + "," + tablecount_daily;
                        lsvDaily.Items.Clear();
                        MySqlDataReader reader_daily = Program.Query(query_daily);
                        while (reader_daily.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader_daily.GetString(0));
                            lst.SubItems.Add(reader_daily.GetString(11));
                            var reporteddate = Convert.ToDateTime(reader_daily.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = Convert.ToDateTime(reader_daily.GetString(8)).ToString("HH:mm:ss");
                            string date = reporteddate + " " + reportedtime;
                            lst.SubItems.Add(date);
                            double outage = double.Parse(reader_daily.GetString(13));
                            var updateddate = Convert.ToDateTime(reader_daily.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = Convert.ToDateTime(reader_daily.GetString(10)).ToString("HH:mm:ss");
                            string update = updateddate + " " + updatedtime;
                            lst.SubItems.Add(update);
                            lst.SubItems.Add((Math.Round(outage, 3)).ToString());
                            lst.SubItems.Add(reader_daily.GetString(2));
                            lsvDaily.Items.Add(lst);
                        }
                        reader_daily.Close();
                        foreach (ListViewItem lst in lsvDaily.Items)
                        {
                            double outage = double.Parse(lst.SubItems[4].Text);

                            if (outage < 4)
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4)
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8)
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12)
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
                        txtRow_Daily.Text = (tableshow_daily + lsvDaily.Items.Count).ToString();
                        break;
                    }
                case 1: //WEEKLY
                    {
                        int totaltickets = 0;
                        int less4tickets = 0;
                        int more4tickets = 0;
                        int more8tickets = 0;
                        int more12tickets = 0;
                        int more16tickets = 0;
                        int more24tickets = 0;
                        int more48tickets = 0;
                        string month = DateTime.Now.ToString("yyyy-MM");
                        string forQuery = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + month + "%" + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "'";
                        MySqlDataReader reader_aging = Program.Query(forQuery);
                        while (reader_aging.Read())
                        {
                            var initialdate = Convert.ToDateTime(reader_aging.GetString(7)).ToString("MMM-dd-yyyy");
                            DateTime convertdate;
                            convertdate = DateTime.Parse(initialdate);
                            int date1 = GetIso8601WeekOfYear(DateTime.Today);
                            int date2 = GetIso8601WeekOfYear(convertdate);

                            if (date1 == date2)
                            {
                                totaltickets++;
                                double outage = double.Parse(reader_aging.GetString(13));
                                if (outage < 4)
                                {
                                    less4tickets++;
                                }
                                else if (outage < 8 && outage >= 4)
                                {
                                    more4tickets++;
                                }
                                else if (outage < 12 && outage >= 8)
                                {
                                    more8tickets++;
                                }
                                else if (outage < 16 && outage >= 12)
                                {
                                    more12tickets++;
                                }
                                else if (outage < 24 && outage >= 16)
                                {
                                    more16tickets++;
                                }
                                else if (outage < 48 && outage >= 24)
                                {
                                    more24tickets++;
                                }
                                else if (outage >= 48)
                                {
                                    more48tickets++;
                                }
                            }
                        }
                        reader_aging.Close();
                        txtWeekly_Open.Text = totaltickets.ToString();
                        txtTotalRow_Weekly.Text = totaltickets.ToString();
                        count_weekly = txtTotalRow_Weekly.Text;
                        if (int.Parse(count_weekly) <= 50)
                        {
                            btnWeekly_More.Enabled = false;
                        }
                        else
                        {
                            btnWeekly_More.Enabled = true;
                        }
                        txtWeekly_Less4.Text = less4tickets.ToString();
                        txtWeekly_More4.Text = more4tickets.ToString();
                        txtWeekly_More8.Text = more8tickets.ToString();
                        txtWeekly_More12.Text = more12tickets.ToString();
                        txtWeekly_More16.Text = more16tickets.ToString();
                        txtWeekly_More24.Text = more24tickets.ToString();
                        txtWeekly_More48.Text = more48tickets.ToString();
                        string forReader_weekly = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + month + "%" + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "' limit " + tableshow_weekly + "," + tablecount_weekly;
                        MySqlDataReader reader_weekly = Program.Query(forReader_weekly);
                        lsvWeekly.Items.Clear();
                        while (reader_weekly.Read())
                        {
                            var initialdate = Convert.ToDateTime(reader_weekly.GetString(7)).ToString("MMM-dd-yyyy");
                            DateTime convertdate;
                            convertdate = DateTime.Parse(initialdate);
                            int date1 = GetIso8601WeekOfYear(DateTime.Today);
                            int date2 = GetIso8601WeekOfYear(convertdate);
                            if (date1 == date2)
                            {
                                totaltickets++;
                                ListViewItem lst = new ListViewItem(reader_weekly.GetString(0));
                                lst.SubItems.Add(reader_weekly.GetString(11));
                                var reporteddate = Convert.ToDateTime(reader_weekly.GetString(7)).ToString("MMM dd yyyy");
                                var reportedtime = Convert.ToDateTime(reader_weekly.GetString(8)).ToString("HH:mm:ss");
                                string date = reporteddate + " " + reportedtime;
                                lst.SubItems.Add(date);
                                double outage = double.Parse(reader_weekly.GetString(13));

                                var updateddate = Convert.ToDateTime(reader_weekly.GetString(9)).ToString("MMM dd yyyy");
                                var updatedtime = Convert.ToDateTime(reader_weekly.GetString(10)).ToString("HH:mm:ss");
                                string update = updateddate + " " + updatedtime;
                                lst.SubItems.Add(update);
                                lst.SubItems.Add((Math.Round(outage, 3)).ToString());
                                lst.SubItems.Add(reader_weekly.GetString(2));
                                lsvWeekly.Items.Add(lst);
                            }
                        }
                        reader_weekly.Close();
                        foreach (ListViewItem lst in lsvWeekly.Items)
                        {
                            double outage = double.Parse(lst.SubItems[4].Text);

                            if (outage < 4 )
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4)
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8)
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12)
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
                        txtRow_Weekly.Text = (tableshow_weekly + lsvWeekly.Items.Count).ToString();
                        break;
                    }
                case 2: //MONTHLY
                    {
                        int less4tickets = 0;
                        int more4tickets = 0;
                        int more8tickets = 0;
                        int more12tickets = 0;
                        int more16tickets = 0;
                        int more24tickets = 0;
                        int more48tickets = 0;
                        string month = DateTime.Now.ToString("yyyy-MM");
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
                        string forQuerymonthly = "Select count(*) from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + month + "%" + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "'";
                        MySqlCommand querymonthly_ = new MySqlCommand(forQuerymonthly, conn);
                        conn.Open();
                        count_monthly = querymonthly_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow_Monthly.Text = count_monthly;
                        if (int.Parse(count_monthly) <= 50)
                        {
                            btnMonthly_More.Enabled = false;
                        }
                        else
                        {
                            btnMonthly_More.Enabled = true;
                        }
                        txtMonthly_Open.Text = count_monthly;

                        string count_aging = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + month + "%" + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "'";
                        MySqlDataReader reader_aging = Program.Query(count_aging);
                        while (reader_aging.Read())
                        {
                            double outage = double.Parse(reader_aging.GetString(13));
                            if (outage < 4)
                            {
                                less4tickets++;
                            }
                            else if (outage < 8 && outage >= 4)
                            {
                                more4tickets++;
                            }
                            else if (outage < 12 && outage >= 8)
                            {
                                more8tickets++;
                            }
                            else if (outage < 16 && outage >= 12)
                            {
                                more12tickets++;
                            }
                            else if (outage < 24 && outage >= 16)
                            {
                                more16tickets++;
                            }
                            else if (outage < 48 && outage >= 24)
                            {
                                more24tickets++;
                            }
                            else if (outage >= 48)
                            {
                                more48tickets++;
                            }
                        }
                        reader_aging.Close();
                        string query_month = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where reporteddate like '" + month + "%" + "' and remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "' limit " + tableshow_monthly + "," + tablecount_monthly;
                        lsvMonthly.Items.Clear();
                        MySqlDataReader reader_month = Program.Query(query_month);
                        while (reader_month.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader_month.GetString(0));
                            lst.SubItems.Add(reader_month.GetString(11));
                            var reporteddate = Convert.ToDateTime(reader_month.GetString(7)).ToString("MMM dd yyyy");
                            var reportedtime = Convert.ToDateTime(reader_month.GetString(8)).ToString("HH:mm:ss");
                            string date = reporteddate + " " + reportedtime;
                            lst.SubItems.Add(date);
                            double outage = double.Parse(reader_month.GetString(13));
                            var updateddate = Convert.ToDateTime(reader_month.GetString(9)).ToString("MMM dd yyyy");
                            var updatedtime = reader_month.GetString(10);
                            string update = updateddate + " " + updatedtime;
                            lst.SubItems.Add(update);
                            lst.SubItems.Add((Math.Round(outage, 3)).ToString());
                            lst.SubItems.Add(reader_month.GetString(2));
                            lsvMonthly.Items.Add(lst);
                        }
                        reader_month.Close();
                        txtMonthly_Less4.Text = less4tickets.ToString();
                        txtMonthly_More4.Text = more4tickets.ToString();
                        txtMonthly_More8.Text = more8tickets.ToString();
                        txtMonthly_More12.Text = more12tickets.ToString();
                        txtMonthly_More16.Text = more16tickets.ToString();
                        txtMonthly_More24.Text = more24tickets.ToString();
                        txtMonthly_More48.Text = more48tickets.ToString();
                        foreach (ListViewItem lst in lsvMonthly.Items)
                        {
                            double outage = double.Parse(lst.SubItems[4].Text);
                            if (outage < 4)
                            {
                                lst.BackColor = Color.Thistle;
                            }
                            else if (outage < 8 && outage >= 4)
                            {
                                lst.BackColor = Color.LimeGreen;
                            }
                            else if (outage < 12 && outage >= 8)
                            {
                                lst.BackColor = Color.GreenYellow;
                            }
                            else if (outage < 16 && outage >= 12)
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
                        txtRow_Monthly.Text = (tableshow_monthly + lsvMonthly.Items.Count).ToString();
                        break;
                    }
                case 3: //ENDORSEMENTS
                    {
                        txtNotes.Text = "";
                        lsvEndorsements.Items.Clear();
                        if (radPerson.Checked == true)
                        {
                            string query_person = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsee like '" + lblUsername_Full.Text + "' and status not like '" + "Noted" + "' order by endorsedate limit " + tableshow_endorsement + "," + tablecount_endorsement;
                            MySqlDataReader reader_person = Program.Query(query_person);
                            while (reader_person.Read())
                            {
                                ListViewItem lst = new ListViewItem(reader_person.GetString(0));
                                lst.SubItems.Add(reader_person.GetString(1));
                                lst.SubItems.Add(reader_person.GetString(3));
                                var endorseddate = Convert.ToDateTime(reader_person.GetString(2)).ToString("MMM dd yyyy HH:mm:ss");
                                lst.SubItems.Add(endorseddate);
                                lsvEndorsements.Items.Add(lst);
                            }
                            reader_person.Close();
                        }
                        else if (radShift.Checked == true)
                        {
                            switch (cboChoice.SelectedIndex)
                            {
                                case -1:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        string query_shift = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where endorsee like '" + cboChoice.Text + "'  and status not like '" + "Noted" + "' order by endorsedate limit " + tableshow_endorsement + "," + tablecount_endorsement;
                                        MySqlDataReader reader_shift = Program.Query(query_shift);
                                        while (reader_shift.Read())
                                        {
                                            ListViewItem lst = new ListViewItem(reader_shift.GetString(0));
                                            lst.SubItems.Add(reader_shift.GetString(1));
                                            lst.SubItems.Add(reader_shift.GetString(3));
                                            var endorseddate = Convert.ToDateTime(reader_shift.GetString(2)).ToString("MMM dd yyyy HH:mm:ss");
                                            lst.SubItems.Add(endorseddate);
                                            lsvEndorsements.Items.Add(lst);
                                        }
                                        reader_shift.Close();
                                        break;
                                    }
                            }
                        }
                        else if (radWorkgroup.Checked == true)
                        {
                            switch (cboChoice.SelectedIndex)
                            {
                                case -1:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        string query_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where workgroup like '" + cboChoice.Text + "'  and status not like '" + "Noted" + "' order by endorsedate limit " + tableshow_endorsement + "," + tablecount_endorsement;
                                        MySqlDataReader reader_workgroup = Program.Query(query_workgroup);
                                        while (reader_workgroup.Read())
                                        {
                                            ListViewItem lst = new ListViewItem(reader_workgroup.GetString(0));
                                            lst.SubItems.Add(reader_workgroup.GetString(1));
                                            lst.SubItems.Add(reader_workgroup.GetString(3));
                                            var endorseddate = Convert.ToDateTime(reader_workgroup.GetString(2)).ToString("MMM dd yyyy HH:mm:ss");
                                            lst.SubItems.Add(endorseddate);
                                            lsvEndorsements.Items.Add(lst);
                                        }
                                        reader_workgroup.Close();
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        bool formIsOpen;
        private void tsmCategories_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmCategory)
                {
                    f.Focus();
                    return;
                }
            }
            frmCategory category = new frmCategory();
            category.username_ = lblUsername_.Text;
            category.workgroup_ = lblWorkgroup_.Text;
            category.db_ = lblDatabase_.Text;
            category.ShowDialog();
        }
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        private void btnDaily_Less_Click(object sender, EventArgs e)
        {
            int counter = 50;
            while (counter != 0)
            {
                counter--;
                tableshow_daily--;
                limiter_daily--;
                if (limiter_daily == 0)
                {
                    btnDaily_Less.Enabled = false;
                    counter = 0;
                }
            }
            getInfo();
            btnDaily_More.Enabled = true;
            txtShowRow_Daily.Text = tableshow_daily.ToString();
            txtRow_Daily.Text = (tableshow_daily + lsvDaily.Items.Count).ToString();
        }
        private void btnDaily_More_Click(object sender, EventArgs e)
        {
            disabler_Daily = (tableshow_daily + lsvDaily.Items.Count + 50);
            if (disabler_Daily >= int.Parse(count_daily))
            {
                btnDaily_More.Enabled = false;
            }
            int counter = 0;
            while (counter != 50)
            {
                counter++;
                tableshow_daily++;
                limiter_daily++;
                if (limiter_daily == int.Parse(count_daily))
                {
                    btnDaily_More.Enabled = false;
                    counter = 50;
                }
            }
            getInfo();
            if (limiter_daily == int.Parse(count_daily))
            {
                MessageBox.Show("End of records.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDaily_More.Enabled = false;
                counter = 50;
            }
            btnDaily_Less.Enabled = true;
            txtShowRow_Daily.Text = tableshow_daily.ToString();
            if (limiter_daily == int.Parse(count_daily))
            {
                txtRow_Daily.Text = lsvDaily.Items.Count.ToString();
            }
            else
            {
                txtRow_Daily.Text = (tableshow_daily + lsvDaily.Items.Count).ToString();
            }
        }
        private void btnMonthly_More_Click(object sender, EventArgs e)
        {
            disabler_Monthly = (tableshow_monthly + lsvMonthly.Items.Count + 50);
            if (disabler_Monthly >= int.Parse(count_monthly))
            {
                btnMonthly_More.Enabled = false;
            }
            int counter = 0;
            while (counter != 50)
            {
                counter++;
                tableshow_monthly++;
                limiter_monthly++;
                if (limiter_monthly == int.Parse(count_monthly))
                {
                    btnMonthly_More.Enabled = false;
                    counter = 50;
                }
            }
            getInfo();
            if (limiter_monthly == int.Parse(count_monthly))
            {
                MessageBox.Show("End of records.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMonthly_More.Enabled = false;
                counter = 50;
            }
            btnMonthly_Less.Enabled = true;
            txtShowRow_Monthly.Text = tableshow_monthly.ToString();
            if (limiter_monthly == int.Parse(count_monthly))
            {
                txtRow_Monthly.Text = lsvMonthly.Items.Count.ToString();
            }
            else
            {
                txtRow_Monthly.Text = (tableshow_monthly + lsvMonthly.Items.Count).ToString();
            }
        }
        private void btnMonthly_Less_Click(object sender, EventArgs e)
        {
            int counter = 50;
            while (counter != 0)
            {
                counter--;
                tableshow_monthly--;
                limiter_monthly--;
                if (limiter_monthly == 0)
                {
                    btnMonthly_Less.Enabled = false;
                    counter = 0;
                }
            }
            getInfo();
            btnMonthly_More.Enabled = true;
            txtShowRow_Monthly.Text = tableshow_monthly.ToString();
            txtRow_Monthly.Text = (tableshow_monthly + lsvMonthly.Items.Count).ToString();
        }
        private void btnWeekly_More_Click(object sender, EventArgs e)
        {
            disabler_Weekly = (tableshow_weekly + lsvWeekly.Items.Count + 50);
            if (disabler_Weekly >= int.Parse(count_weekly))
            {
                btnWeekly_More.Enabled = false;
            }
            int counter = 0;
            while (counter != 50)
            {
                counter++;
                tableshow_weekly++;
                limiter_weekly++;
                if (limiter_weekly == int.Parse(count_weekly))
                {
                    btnWeekly_More.Enabled = false;
                    counter = 50;
                }
            }
            getInfo();
            if (limiter_weekly == int.Parse(count_weekly))
            {
                MessageBox.Show("End of records.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnWeekly_More.Enabled = false;
                counter = 50;
            }
            btnWeekly_Less.Enabled = true;
            txtShowRow_Weekly.Text = tableshow_weekly.ToString();
            if (limiter_weekly == int.Parse(count_weekly))
            {
                txtRow_Weekly.Text = lsvWeekly.Items.Count.ToString();
            }
            else
            {
                txtRow_Weekly.Text = (tableshow_weekly + lsvWeekly.Items.Count).ToString();
            }
        }
        private void btnWeekly_Less_Click(object sender, EventArgs e)
        {
            int counter = 50;
            while (counter != 0)
            {
                counter--;
                tableshow_weekly--;
                limiter_weekly--;
                if (limiter_weekly == 0)
                {
                    btnWeekly_Less.Enabled = false;
                    counter = 0;
                }
            }
            getInfo();
            btnWeekly_More.Enabled = true;
            txtShowRow_Weekly.Text = tableshow_weekly.ToString();
            txtRow_Weekly.Text = (tableshow_weekly + lsvWeekly.Items.Count).ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "D:\\Users\\Jayson Hernandez\\Desktop\\test.wav";
            player.Play();
        }
        private void lsvDaily_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lsvDaily.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ctmMain.Show(Cursor.Position);
                }
            }
        }
        private void seeTicketDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ticketnumber;
            switch (tabMain.SelectedIndex)
            {
                case 0:
                    {
                        if (lsvDaily.SelectedItems.Count == 0)
                        {
                            return;
                        }
                        else
                        {
                            ListViewItem item = lsvDaily.SelectedItems[0];
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
                        break;
                    }
                case 1:
                    {
                        if (lsvWeekly.SelectedItems.Count == 0)
                        {
                            return;
                        }
                        else
                        {
                            ListViewItem item = lsvWeekly.SelectedItems[0];
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
                        break;
                    }
                case 2:
                    {
                        if (lsvMonthly.SelectedItems.Count == 0)
                        {
                            return;
                        }
                        else
                        {
                            ListViewItem item = lsvMonthly.SelectedItems[0];
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
                        break;
                    }
                case 3:
                    {
                        if (lsvEndorsements.SelectedItems.Count == 0)
                        {
                            return;
                        }
                        else
                        {
                            ListViewItem item = lsvEndorsements.SelectedItems[0];
                            ticketnumber = item.SubItems[0].Text;
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
                        break;
                    }
            }
        }
        private void lsvWeekly_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lsvWeekly.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ctmMain.Show(Cursor.Position);
                }
            }
        }
        private void lsvMonthly_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lsvMonthly.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ctmMain.Show(Cursor.Position);
                }
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
            if (lsvEndorsements.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                ListViewItem item = lsvEndorsements.SelectedItems[0];
                tickets.txtTicketNumber.Text = item.SubItems[0].Text;
            }
            tickets.Show();
        }
        private void radShift_CheckedChanged(object sender, EventArgs e)
        {
            if (radShift.Checked == true)
            {
                lsvEndorsements.Items.Clear();
                radWorkgroup.Checked = false;
                radPerson.Checked = false;
                grbChoice.Text = "Shift";
                grbChoice.Visible = true;
                cboChoice.Items.Clear();
                cboChoice.Items.Add("Morning Shift");
                cboChoice.Items.Add("Evening Shift");
                cboChoice.Items.Add("Graveyard Shift");
            }
        }

        private void radWorkgroup_CheckedChanged(object sender, EventArgs e)
        {
            if (radWorkgroup.Checked == true)
            {
                lsvEndorsements.Items.Clear();
                radShift.Checked = false;
                radPerson.Checked = false;
                grbChoice.Text = "Workgroup";
                grbChoice.Visible = true;
                cboChoice.Items.Clear();
                string forReader_workgroup = "Select * from " + lblDatabase_.Text + ".tbl_workgroup";
                MySqlDataReader reader_workgroup = Program.Query(forReader_workgroup);
                while (reader_workgroup.Read())
                {
                    cboChoice.Items.Add(reader_workgroup.GetString(0));
                }
                reader_workgroup.Close();
            }
        }
        private void radPerson_CheckedChanged(object sender, EventArgs e)
        {
            lsvEndorsements.Items.Clear();
            getInfo();
            if (radPerson.Checked == true)
            {
                radWorkgroup.Checked = false;
                radShift.Checked = false;
                grbChoice.Visible = false;
            }
        }
        private void showCriticallyAgedTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmCritical)
                {
                    return;
                }
            }

            frmCritical crit = new frmCritical();
            crit.db_ = lblDatabase_.Text;
            crit.workgroup_ = lblWorkgroup_.Text;
            crit.username_ = lblUsername_.Text;
            crit.Show();
        }
        string onUpdate;

        private void tsmIEPort_Click(object sender, EventArgs e)
        {

        }

        private void timUpdater_Tick(object sender, EventArgs e)
        {
            string forReader_checker = "Select * from " + lblDatabase_.Text + ".tbl_current " + " limit " + "1";
            MySqlDataReader reader_checker = Program.Query(forReader_checker);
            while (reader_checker.Read())
            {
                updater = reader_checker.GetString(0);
            }
            if (updater == username_)
            {
                updateraccount = true;
                btnUpdate.Visible = true;
            }
            reader_checker.Close();
            if (updateraccount != true)
            {
                string forProgressBar = "Select * from " + lblDatabase_.Text + ".tbl_updater ";
                MySqlDataReader progress = Program.Query(forProgressBar);
                while (progress.Read())
                {
                    onUpdate = progress.GetString(2);
                }
                progress.Close();
                if (onUpdate == "1")
                {
                    proUpdate.Style = ProgressBarStyle.Marquee;
                    lblLastUpdate.Text = "Updating outage...";
                }
                else
                {
                    string forReader_updater = "Select * from " + lblDatabase_.Text + ".tbl_updater";
                    MySqlDataReader reader_updater = Program.Query(forReader_updater);
                    while (reader_updater.Read())
                    {
                        var updatedate = Convert.ToDateTime(reader_updater.GetString(0)).ToString("MMM dd yyyy");
                        var updatetime = Convert.ToDateTime(reader_updater.GetString(1)).ToString("HH:mm:ss");
                        string date = updatedate + " " + updatetime;
                        lblLastUpdate.Text = date;
                    }
                    reader_updater.Close();
                    proUpdate.Style = ProgressBarStyle.Blocks;
                }
            }
            string forCurrent = "Select * from " + lblDatabase_.Text + ".tbl_current" + " where username collate latin1_general_cs like '" + username_ + "'";
            MySqlDataReader autologout = Program.Query(forCurrent);
            if (!autologout.Read())
            {
                if (messageoffset == 0)
                {
                    messageoffset = -1;
                    MessageBox.Show("Your account has been logged-out by the Administrators.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    forced = true;
                    tsmExit.PerformClick();
                }
                else
                {
                    messageoffset = -1;
                }
            }
            autologout.Close();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            getInfo();
        }

        private void restoreProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (WindowState == FormWindowState.Minimized)
                {
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update_timer = 0;
        }
        private void Update_Outage()
        {
            stillUpdating = true;
            string forReader_checker = "Select * from " + lblDatabase_.Text + ".tbl_current " + " limit " + "1";
            MySqlDataReader reader_checker = Program.Query(forReader_checker);
            while (reader_checker.Read())
            {
                updater = reader_checker.GetString(0);
            }
            reader_checker.Close();
            if (updater == username_)
            {
                updateraccount = true;
                string forReader_LastUpdate = "Select * from " + lblDatabase_.Text + ".tbl_updater ";
                MySqlDataReader reader_last = Program.Query(forReader_LastUpdate);
                while (reader_last.Read())
                {
                    var lastDate = Convert.ToDateTime(reader_last.GetString(0)).ToString("MMM dd yyyy");
                    var lastTime = Convert.ToDateTime(reader_last.GetString(1)).ToString("HH:mm:ss");
                    string date = lastDate + " " + lastTime;
                    DateTime initial_date = Convert.ToDateTime(date);
                    DateTime now_date = DateTime.Now;
                    TimeSpan result = (now_date - initial_date);
                    addOutage = result.TotalHours;
                }
                double outage = 0;
                string forReader = "Select * from " + lblDatabase_.Text + ".tbl_tickets" + " where remarks not like '" + "CLOSED" + "' and remarks not like '" + "PARKED" + "'";
                MySqlDataReader reader = Program.Query(forReader);
                while (reader.Read())
                {
                    string ticketnumber = reader.GetString(0);
                    outage = double.Parse(reader.GetString(13)) + addOutage;
                    outage = Math.Round(outage, 3);
                    string forUpdate = "update " + lblDatabase_.Text + ".tbl_tickets" + " set outage = '" + outage.ToString() + "' where ticketnumber like '" + ticketnumber + "'";
                    Program.Query(forUpdate).Close();
                }
                reader.Close();
                string lastdate = DateTime.Now.ToString("yyyy-MM-dd"), lasttime = DateTime.Now.ToString("HH:mm:ss");
                string forUpdater = "update " + lblDatabase_.Text + ".tbl_updater" + " set lastdate = '" + lastdate + "', lasttime = '" + lasttime + "', isUpdating = '" + "0" + "'";
                Program.Query(forUpdater).Close();
                isUpdating = true;
                stillUpdating = false;
                update_timer = 300;
            }
        }
        private void timOutage_Tick(object sender, EventArgs e)
        {
            if (update_timer > 0)
            {
                update_timer--;
                if (updateraccount == true && usertype_ == "admin")
                {
                    btnUpdate.Visible = true;
                }
                else if (updateraccount == false && usertype_ == "admin")
                {
                    btnUpdate.Visible = false;
                }
                    return;
            }
            update_timer = 0;
            if (stillUpdating != true)
            {
                lblLastUpdate.Text = "Updating outage...";
                string forUpdate = "update " + lblDatabase_.Text + ".tbl_updater" + " set isUpdating = '" + "1" + "'";
                Program.Query(forUpdate).Close();
                outage_updater = new System.Threading.Thread(Update_Outage);
                outage_updater.Start();
                proUpdate.Style = ProgressBarStyle.Marquee;
                btnUpdate.Enabled = false;
            }
        }
        private void cboChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radShift.Checked == true)
            {
                lsvEndorsements.Items.Clear();
                getInfo();
            }
            else if (radWorkgroup.Checked == true)
            {
                lsvEndorsements.Items.Clear();
                getInfo();
            }
        }
        private void lsvEndorsements_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lsvEndorsements.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ctmMain.Show(Cursor.Position);
                }
            }
        }
        private void endorsementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmEndorsements)
                {
                    f.Focus();
                    return;
                }
            }
            frmEndorsements endorsement = new frmEndorsements();
            endorsement.db_ = lblDatabase_.Text;
            endorsement.workgroup_ = lblWorkgroup_.Text;
            endorsement.username_ = lblUsername_.Text;
            endorsement.Show();
        }
        private void lsvEndorsements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvEndorsements.SelectedItems.Count == 0)
            {
                txtNotes.Text = "";
                return;
            }
            else
            {
                ListViewItem item = lsvEndorsements.SelectedItems[0];
                string ticketnumber = item.SubItems[0].Text;
                string forReader_notes = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where ticketnumber like '" + ticketnumber + "'";
                MySqlDataReader reader_notes = Program.Query(forReader_notes);
                while (reader_notes.Read())
                {
                    txtNotes.Text = "";
                    txtNotes.Text = reader_notes.GetString(5);
                }
                reader_notes.Close();
            }
        }
        private void btnEnableLog_Click(object sender, EventArgs e)
        {
            if (btnEnableLog.Text == "Enable Log-in")
            {
                if (MessageBox.Show("Enable log-in?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string forReader = "Select enablelog from " + lblDatabase_.Text + ".tbl_app";
                    MySqlDataReader reader = Program.Query(forReader);
                    while (reader.Read())
                    {
                        string forUpdate = "update " + lblDatabase_.Text + ".tbl_app" + " set enablelog = '" + 1 + "'";
                        Program.Query(forUpdate).Close();
                    }
                    reader.Close();
                    btnEnableLog.Text = "Disable Log-in";
                    MessageBox.Show("Log-in enabled.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("This will prevent log-ins in the future.\nCurrently logged users are not affected.\n\nDisable Log-in?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string forReader = "Select enablelog from " + lblDatabase_.Text + ".tbl_app";
                    MySqlDataReader reader = Program.Query(forReader);
                    while (reader.Read())
                    {
                        string forUpdate = "update " + lblDatabase_.Text + ".tbl_app" + " set enablelog = '" + 0 + "'";
                        Program.Query(forUpdate).Close();
                    }
                    reader.Close();
                    btnEnableLog.Text = "Enable Log-in";
                    MessageBox.Show("Log-in disabled.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
        }
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void notMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
                Activate();
            }
        }
        private void notMain_BalloonTipClicked(object sender, EventArgs e)
        {
            switch (balloontype)
            {
                case "welcome":
                    {
                        if (count_endorsement != 0)
                        {
                            if (WindowState == FormWindowState.Minimized)
                            {
                                WindowState = FormWindowState.Normal;
                            }
                            Activate();
                            tabMain.SelectedTab = tabEndorsements;
                        }
                        break;
                    }
                case "critical":
                    {
                        foreach (Form f in Application.OpenForms)
                        {
                            if (f is frmCritical)
                            {
                                return;
                            }
                        }
                        frmCritical crit = new frmCritical();
                        crit.db_ = lblDatabase_.Text;
                        crit.workgroup_ = lblWorkgroup_.Text;
                        crit.username_ = lblUsername_.Text;
                        crit.Show();
                        break;
                    }
                case "default":
                    {
                        break;
                    }
            }
        }
        private void notMain_BalloonTipClosed(object sender, EventArgs e)
        {
            balloontype = "default";
        }
        protected override void WndProc(ref Message m)
        {
            FormWindowState org = WindowState;
            base.WndProc(ref m);
            if (WindowState != org)
                OnFormWindowStateChanged(EventArgs.Empty);
        }
        protected virtual void OnFormWindowStateChanged(EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
            else
            {
                ShowInTaskbar = true;
            }
        }
    }
}