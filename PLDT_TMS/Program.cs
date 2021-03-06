﻿using System;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace PLDT_TMS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Only one instance of this program can be run at a time.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var main_form = new frmStart();
                main_form.Show();
                Application.Run();
            }
        }
        private static string appGuid = "06008605-2986-4a48-a804-ba5c826d897d";
        static bool DBAccessible = true;
        static string read;
        public static MySqlConnection Connect()
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
            string ConnectionString = "datasource=" + read + ";port=3306;username=root;password=mySQL09122016;";
            MySqlConnection Connection = new MySqlConnection(ConnectionString);
            Connection.Close();
            try
            {
                Connection.Open();
                if (DBAccessible == false && Connection.State == ConnectionState.Open)
                {
                    DBAccessible = true;
                    MessageBox.Show("Database access re-gained.", "MySQL - Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (DBAccessible == true && Connection.State != ConnectionState.Open)
                {
                    DBAccessible = false;
                    MessageBox.Show("Database connect attempt failed.", "MySQL - Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
            return Connection;
        }
        public static MySqlDataReader Query(string Text)
        {
            try
            {
                MySqlConnection Connection = Connect();
                MySqlCommand Command = new MySqlCommand(Text, Connection);
                Command.Prepare();
                MySqlDataReader Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);
                return Reader;
            }
            catch (MySqlException msex)
            {
                MessageBox.Show(msex.Message);
                return null;
            }
        }
        public static void AuditTrail(string activity, string username, string workgroup, string databasename)
        {
            string actdate = DateTime.Now.ToString("yyyy-MM-dd"), acttime = DateTime.Now.ToString("HH:mm:ss");
            string forAudit = "insert into " + databasename + ".tbl_audit" + " (username, workgroup, actdate, acttime, activity) values ('" + username + "', '" + workgroup + "', '" + actdate + "', '" + acttime + "', '" + activity + "');";
            Query(forAudit).Close();
        }
        internal static void AuditTrail()
        {
            throw new NotImplementedException();
        }
    }
}
/*string cmdko = "update tblusers  set Username='" + txtUsername.Text + "', Userpassword='" + txtPassword.Text + "', Userlevel='" + cboUserlevel.Text + "' where Username = '" + getusername + "'";
            Clipboard.SetText(cmdko);*/
