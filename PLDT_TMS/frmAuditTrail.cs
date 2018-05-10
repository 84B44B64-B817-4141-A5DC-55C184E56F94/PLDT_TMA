using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace PLDT_TMS
{
    public partial class frmAuditTrail : Form
    {
        //IMPORTANT
        public string db_;
        public string username_;
        //IMPORTANT
        string count;
        int tablecount = 50;
        int tableshow = 0;
        int limiter = 0;
        string read;
        Thread excelExport;
        public frmAuditTrail()
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
                btnLess.BackColor= SystemColors.WindowFrame; ;
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
        private void frmAuditTrail_Load(object sender, EventArgs e)
        {
            lblDatabase_.Text = db_;
            lblUsername_.Text = username_;
            getInfo();
            cboSearchType.SelectedIndex = 0;
            dtpSearch.Value = DateTime.Now;
        }
        private void getInfo()
        {
            switch (cboSearchType.SelectedIndex)
            {
                case 1:
                    {
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_audit" + " where username like '" + txtSearch.Text + "%" + "' order by username limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                            while (reader.Read())
                            {
                                ListViewItem lst = new ListViewItem(reader.GetString(0));
                                lst.SubItems.Add(reader.GetString(1));
                                var actdate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                lst.SubItems.Add(actdate);
                                lst.SubItems.Add(reader.GetString(3));
                                lst.SubItems.Add(reader.GetString(4));
                                lsvData.Items.Add(lst);
                            }
                            reader.Close();
                        if (lsvData.Items.Count == 0)
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
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_audit" + " where workgroup like '" + txtSearch.Text + "%" + "' order by workgroup limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                            while (reader.Read())
                            {
                                ListViewItem lst = new ListViewItem(reader.GetString(0));
                                lst.SubItems.Add(reader.GetString(1));
                                var actdate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                lst.SubItems.Add(actdate);
                                lst.SubItems.Add(reader.GetString(3));
                                lst.SubItems.Add(reader.GetString(4));
                                lsvData.Items.Add(lst);
                            }
                            reader.Close();
                            if (lsvData.Items.Count == 0)
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
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_audit" + " where actdate like '" + date + "' order by acttime limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                            while (reader.Read())
                            {
                                ListViewItem lst = new ListViewItem(reader.GetString(0));
                                lst.SubItems.Add(reader.GetString(1));
                                var actdate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                lst.SubItems.Add(actdate);
                                lst.SubItems.Add(reader.GetString(3));
                                lst.SubItems.Add(reader.GetString(4));
                                lsvData.Items.Add(lst);
                            }
                            reader.Close();
                            if (lsvData.Items.Count == 0)
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
                        MySqlCommand query_ = new MySqlCommand("SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_audit" + "", conn);
                        conn.Open();
                        count = query_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow.Text = count;
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_audit" + " limit " + tableshow + "," + tablecount;
                        lsvData.Items.Clear();
                        MySqlDataReader reader = Program.Query(query);
                        while (reader.Read())
                            {
                                ListViewItem lst = new ListViewItem(reader.GetString(0));
                                lst.SubItems.Add(reader.GetString(1));
                                var actdate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                lst.SubItems.Add(actdate);
                                lst.SubItems.Add(reader.GetString(3));
                                lst.SubItems.Add(reader.GetString(4));
                                lsvData.Items.Add(lst);
                            }
                        reader.Close();
                        if (lsvData.Items.Count == 0)
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
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This may take a while. Proceed?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Data export will now start. Feel free to continue on your work while the report is being created.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                excelExport = new Thread(toExcel);
                excelExport.Start();
            }
        }
        private void toExcel()
        {
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=mySQL09122016");
            conn.Open();
            sql = "SELECT * FROM " + lblDatabase_.Text + ".tbl_audit" + "";
            MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 1, j + 1] = data;
                }
            }
            string auditdate = DateTime.Now.ToString("yyyyMMddHHmmss");
            xlWorkBook.SaveAs("audittrail_" + auditdate + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            conn.Close();
            MessageBox.Show("Excel file created at My Documents","System",MessageBoxButtons.OK,MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("explorer.exe","::{450d8fba-ad25-11d0-98a8-0800361b1103}");
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
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
        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSearchType.SelectedIndex)
            {
                case 1:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 2:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                case 3:
                    {
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = SystemColors.Control;
                        txtSearch.Visible = false;
                        dtpSearch.Visible = true;
                        btnSearch.Enabled = true;
                        btnSearch.BackColor = SystemColors.Control;
                        txtSearch.Select(0, txtSearch.MaxLength);
                        break;
                    }
                default:
                    {
                        txtSearch.Enabled = false;
                        txtSearch.BackColor = SystemColors.WindowFrame;
                        txtSearch.Visible = true;
                        dtpSearch.Visible = false;
                        btnSearch.Enabled = false;
                        btnSearch.BackColor = SystemColors.WindowFrame;
                        txtSearch.Text = "";
                        getInfo();
                        lblCount.Text = "";
                        btnMore.Enabled = true;
                        btnMore.BackColor = SystemColors.Control;
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
                                    string ConnectionString = "datasource=" + read + ";port=3306;username=root;password=mySQL09122016;";
                                    MySqlConnection conn = new MySqlConnection("datasource= " + read + ";port=3306;username=root;password=mySQL09122016");
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_audit" + " where username like '" + txtSearch.Text + "%" + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    resetCounter();
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_audit" + " where username like '" + txtSearch.Text + "%" + "' order by username limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        var actdate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                        lst.SubItems.Add(actdate);
                                        lst.SubItems.Add(reader.GetString(3));
                                        lst.SubItems.Add(reader.GetString(4));
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
                                    string ConnectionString = "datasource=" + read + ";port=3306;username=root;password=mySQL09122016;";
                                    MySqlConnection conn = new MySqlConnection("datasource= " + read + ";port=3306;username=root;password=mySQL09122016");
                                    string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_audit" + " where workgroup like '" + txtSearch.Text + "%" + "'";
                                    MySqlCommand query_ = new MySqlCommand(que, conn);
                                    conn.Open();
                                    count = query_.ExecuteScalar().ToString();
                                    conn.Close();
                                    txtTotalRow.Text = count;
                                    string query = "Select * from " + lblDatabase_.Text + ".tbl_audit" + " where workgroup like '" + txtSearch.Text + "%" + "' order by workgroup limit " + tableshow + "," + tablecount;
                                    MySqlDataReader reader = Program.Query(query);
                                    lsvData.Items.Clear();
                                    while (reader.Read())
                                    {
                                        ListViewItem lst = new ListViewItem(reader.GetString(0));
                                        lst.SubItems.Add(reader.GetString(1));
                                        var actdate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                                        lst.SubItems.Add(actdate);
                                        lst.SubItems.Add(reader.GetString(3));
                                        lst.SubItems.Add(reader.GetString(4));
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
                        string ConnectionString = "datasource=" + read + ";port=3306;username=root;password=mySQL09122016;";
                        MySqlConnection conn = new MySqlConnection("datasource= " + read + ";port=3306;username=root;password=mySQL09122016");
                        var date = Convert.ToDateTime(dtpSearch.Value).ToString("yyyy-MM-dd");
                        string que = "SELECT count(*) FROM " + lblDatabase_.Text + ".tbl_audit" + " where actdate like '" + date + "'";
                        MySqlCommand query_ = new MySqlCommand(que, conn);
                        conn.Open();
                        count = query_.ExecuteScalar().ToString();
                        conn.Close();
                        txtTotalRow.Text = count;
                        resetCounter();
                        string query = "Select * from " + lblDatabase_.Text + ".tbl_audit" + " where actdate like '" + date + "' order by acttime limit " + tableshow + "," + tablecount;
                        MySqlDataReader reader = Program.Query(query);
                        lsvData.Items.Clear();
                        while (reader.Read())
                        {
                            ListViewItem lst = new ListViewItem(reader.GetString(0));
                            lst.SubItems.Add(reader.GetString(1));
                            var actdate = Convert.ToDateTime(reader.GetString(2)).ToString("MMM dd yyyy");
                            lst.SubItems.Add(actdate);
                            lst.SubItems.Add(reader.GetString(3));
                            lst.SubItems.Add(reader.GetString(4));
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
                        break;
                    }
            }
        }
    }
}