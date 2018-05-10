using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PLDT_TMS
{
    public partial class frmBackup : Form
    {
        //IMPORTANT
        public string db_;
        public string username_;
        public string workgroup_;
        string read;
        //IMPORTANT
        string action;
        string activity;
        public frmBackup()
        {
            InitializeComponent();
        }
        private void shadow()
        {
            if (action == "backup")
            {
                activity = lblUsername_.Text + " has performed database backup.";
            }
            else
            {
                activity = lblUsername_.Text + " has performed database restoration.";
            }
            shadowTrail();
        }
        private void shadowTrail()
        {
            string username = lblUsername_.Text;
            string workgroup = lblWorkgroup_.Text;
            string databasename = lblDatabase_.Text;
            Program.AuditTrail(activity, username, workgroup,databasename);
        }
        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (txtBackup.Text.Trim() == "")
            {
                MessageBox.Show("Select directory path.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Proceed to Database Backup?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string creationdate = DateTime.Now.ToString("yyyy-MM-dd"), creationtime = DateTime.Now.ToString("HH:mm:ss");
                    string line;
                    StreamReader life = new StreamReader("config.ini");
                    while ((line = life.ReadLine()) != null)
                    {
                        read = line;
                        line = line.Remove(4, line.Length - 4);
                        if (line == "ip_a")
                        {
                            read = read.Remove(0, 11);
                        }
                    }
                    life.Close();
                    string con = "server=" + read + ";user=root;pwd=mySQL09122016;database=" + lblDatabase_.Text + ";";
                    string backupdate = DateTime.Now.ToString("yyyyMMdd"), backuptime = DateTime.Now.ToString("hhmmss");
                    string file = txtBackup.Text + "\\" + lblDatabase_.Text + "_" + backupdate + backuptime + ".sql";
                    string name = "backup_" + backupdate + backuptime + ".sql";
                    using (MySqlConnection conn = new MySqlConnection(con))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                string forInsert = "Insert into " + lblDatabase_.Text + ".tbl_backup" + "(name,datecreated,timecreated,filepath) Values ('" + name + "','" + creationdate + "','" + creationtime + "','" + file + "')";
                                Program.Query(forInsert).Close();
                                conn.Open();
                                mb.ExportToFile(file);
                                conn.Close();
                            }
                        }
                    }
                    action = "backup";
                    MessageBox.Show("Backup successfully created.\nDate of creation: " + creationdate + " " + creationtime,"System",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    shadow();
                    txtBackup.Text = "";
                    getInfo();
                }
                else
                {
                    return;
                }
            }
        }
        private void frmBackup_Load(object sender, EventArgs e)
        {
            lblDatabase_.Text = db_;
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;
            getInfo();
            tabControl1.SelectedIndex = 0;
        }
        private void getInfo()
        {
            lsvBackup.Items.Clear();
            string forReader = "Select * from " + lblDatabase_.Text + ".tbl_backup" + " order by datecreated desc";
            MySqlDataReader reader = Program.Query(forReader);
            while (reader.Read())
            {
                ListViewItem lst = new ListViewItem(reader.GetString(0));
                var backupdate = Convert.ToDateTime(reader.GetString(1)).ToString("MMM dd yyyy");
                var backuptime = reader.GetString(2);
                lst.SubItems.Add(backupdate + " " + backuptime);
                lst.SubItems.Add(reader.GetString(3));
                lsvBackup.Items.Add(lst);
            }
            reader.Close();
        }
        private void btnCloseBackup_Click(object sender, EventArgs e)
        {
            switch (btnCloseBackup.Text)
            {
                case "Close":
                    {
                        Close();
                        break;
                    }
                case "Reset":
                    {
                        txtBackup.Text = "";
                        break;
                    }
            }
        }
        private void btnBackupBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtBackup.Text = fbd.SelectedPath;
            }
        }
        private void btnRestoreBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQL Files|*.sql";
            ofd.Title = "Select a SQL File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filelocation = ofd.InitialDirectory + ofd.FileName;
                txtRestore.Text = filelocation;
            }
        }
        private void btnCloseRestore_Click(object sender, EventArgs e)
        {
            switch (btnCloseRestore.Text)
            {
                case "Close":
                    {
                        Close();
                        break;
                    }
                case "Reset":
                    {
                        txtRestore.Text = "";
                        break;
                    }
            }
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            Program.Query("SET GLOBAL max_allowed_packet = 524288000").Close();
            if (txtRestore.Text.Trim() == "")
            {
                MessageBox.Show("Select directory path.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("This may take a while. Proceed to Database Restoration?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string restoredate = DateTime.Now.ToString("yyyy-MM-dd"), restoretime = DateTime.Now.ToString("HH:mm:ss");
                    string line;
                    StreamReader life = new StreamReader("config.ini");
                    while ((line = life.ReadLine()) != null)
                    {
                        read = line;
                        line = line.Remove(4, line.Length - 4);
                        if (line == "ip_a")
                        {
                            read = read.Remove(0, 11);
                        }
                    }
                    life.Close();
                    string con = "server=" + read + ";user=root;pwd=mySQL09122016;database=" + lblDatabase_.Text + ";";
                    string file = txtRestore.Text;
                    using (MySqlConnection connect = new MySqlConnection(con))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = connect;
                                connect.Open();
                                mb.ImportFromFile(file);
                                connect.Close();
                            }
                        }
                    }
                    action = "restore";
                    MessageBox.Show("Database restored on " + restoredate + " " + restoretime,"System",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    shadow();
                    txtRestore.Text = "";
                }
                else
                {
                    return;
                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        getInfo();
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