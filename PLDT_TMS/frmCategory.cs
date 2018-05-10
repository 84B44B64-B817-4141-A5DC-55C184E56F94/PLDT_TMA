using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PLDT_TMS
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }
        //IMPORTANT
        public string username_;
        public string workgroup_;
        public string db_;
        string read;
        //IMPORTANT
        string prevEntry;
        private void getInfo()
        {
            switch (tabMain.SelectedIndex)
            {
                case 0:
                    {
                        lsvData_Workgroup.Items.Clear();
                        lsvOnList_Workgroup.Items.Clear();
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
                        string forReader_verify = "Select count(workgroup) from " + lblDatabase_.Text + ".tbl_category";
                        MySqlCommand reader_verify = new MySqlCommand(forReader_verify, conn);
                        conn.Open();
                        if (reader_verify.ExecuteScalar().ToString() != "0")
                        {
                            lsvData_Workgroup.Enabled = true;
                            string forReader_data = "Select workgroup from " + lblDatabase_.Text + ".tbl_category" + " order by workgroup";
                            MySqlDataReader reader_data = Program.Query(forReader_data);
                            while (reader_data.Read())
                            {
                                ListViewItem lst = new ListViewItem("");
                                if (!reader_data.IsDBNull(0))
                                {
                                    lst.SubItems.Add(reader_data.GetString(0));
                                    lsvData_Workgroup.Items.Add(lst);
                                }
                            }
                            reader_data.Close();
                            string purge = "DELETE FROM " + lblDatabase_.Text + ".tbl_category" + " WHERE workgroup IS NULL";
                            Program.Query(purge).Close();
                        }
                        else
                        {
                            lsvData_Workgroup.Enabled = false;
                        }
                        conn.Close();
                        string forReader_Onlist = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " order by workgroup";
                        MySqlDataReader reader_onlist = Program.Query(forReader_Onlist);
                        while (reader_onlist.Read())
                        {
                            ListViewItem lst = new ListViewItem("");
                            if (!reader_onlist.IsDBNull(0))
                            {
                                lst.SubItems.Add(reader_onlist.GetString(0));
                                lsvOnList_Workgroup.Items.Add(lst);
                            }
                        }
                        reader_onlist.Close();
                        break;
                    }
                case 1:
                    {
                        lsvData_ServiceType.Items.Clear();
                        lsvOnList_ServiceType.Items.Clear();
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
                        string forReader_verify = "Select count(" + servicemedium_servicetype + "servicetype" + ") from " + lblDatabase_.Text + ".tbl_category";
                        MySqlCommand reader_verify = new MySqlCommand(forReader_verify, conn);
                        conn.Open();
                        if (reader_verify.ExecuteScalar().ToString() != "0")
                        {
                            lsvData_ServiceType.Enabled = true;
                            string forReader_data = "Select " + servicemedium_servicetype + "servicetype" + " from " + lblDatabase_.Text + ".tbl_category" + " order by " + servicemedium_servicetype + "servicetype";
                            MySqlDataReader reader_data = Program.Query(forReader_data);
                            while (reader_data.Read())
                            {
                                ListViewItem lst = new ListViewItem("");
                                if (!reader_data.IsDBNull(0))
                                {
                                    lst.SubItems.Add(reader_data.GetString(0));
                                    lsvData_ServiceType.Items.Add(lst);
                                }
                            }
                            reader_data.Close();
                        }
                        else
                        {
                            lsvData_ServiceType.Enabled = false;
                        }
                        conn.Close();

                        string forReader_Onlist = "Select * from " + lblDatabase_.Text + ".tbl_" + servicemedium_servicetype + "servicetype" + " order by servicetype";
                        MySqlDataReader reader_onlist = Program.Query(forReader_Onlist);
                        while (reader_onlist.Read())
                        {
                            ListViewItem lst = new ListViewItem("");
                            if (!reader_onlist.IsDBNull(0))
                            {
                                lst.SubItems.Add(reader_onlist.GetString(0));
                                lsvOnList_ServiceType.Items.Add(lst);
                            }
                        }
                        reader_onlist.Close();
                        break;
                    }
                case 2:
                    {
                        lsvData_FaultType.Items.Clear();
                        lsvOnList_FaultType.Items.Clear();
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
                        string forReader_verify = "Select count(" + servicemedium_faulttype + "faulttype" + ") from " + lblDatabase_.Text + ".tbl_category";
                        MySqlCommand reader_verify = new MySqlCommand(forReader_verify, conn);
                        conn.Open();
                        if (reader_verify.ExecuteScalar().ToString() != "0")
                        {
                            lsvData_FaultType.Enabled = true;
                            string forReader_data = "Select " + servicemedium_faulttype + "faulttype" + " from " + lblDatabase_.Text + ".tbl_category" + " order by " + servicemedium_faulttype + "faulttype";
                            MySqlDataReader reader_data = Program.Query(forReader_data);
                            while (reader_data.Read())
                            {
                                ListViewItem lst = new ListViewItem("");
                                if (!reader_data.IsDBNull(0))
                                {
                                    lst.SubItems.Add(reader_data.GetString(0));
                                    lsvData_FaultType.Items.Add(lst);
                                }
                            }
                            reader_data.Close();
                        }
                        else
                        {
                            lsvData_FaultType.Enabled = false;
                        }
                        conn.Close();

                        string forReader_Onlist = "Select * from " + lblDatabase_.Text + ".tbl_" + servicemedium_faulttype + "faulttype" + " order by faulttype";
                        MySqlDataReader reader_onlist = Program.Query(forReader_Onlist);
                        while (reader_onlist.Read())
                        {
                            ListViewItem lst = new ListViewItem("");
                            if (!reader_onlist.IsDBNull(0))
                            {
                                lst.SubItems.Add(reader_onlist.GetString(0));
                                lsvOnList_FaultType.Items.Add(lst);
                            }
                        }
                        reader_onlist.Close();
                        break;
                    }
                case 3:
                    {
                        lsvData_Remarks.Items.Clear();
                        lsvOnList_Remarks.Items.Clear();
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
                        string forReader_verify = "Select count(remarks) from " + lblDatabase_.Text + ".tbl_category";
                        MySqlCommand reader_verify = new MySqlCommand(forReader_verify, conn);
                        conn.Open();
                        if (reader_verify.ExecuteScalar().ToString() != "0")
                        {
                            lsvData_Remarks.Enabled = true;
                            string forReader_data = "Select remarks from " + lblDatabase_.Text + ".tbl_category" + " order by remarks";
                            MySqlDataReader reader_data = Program.Query(forReader_data);
                            while (reader_data.Read())
                            {
                                ListViewItem lst = new ListViewItem("");
                                if (!reader_data.IsDBNull(0))
                                {
                                    lst.SubItems.Add(reader_data.GetString(0));
                                    lsvData_Remarks.Items.Add(lst);
                                }
                            }
                            reader_data.Close();
                        }
                        else
                        {
                            lsvData_Remarks.Enabled = false;
                        }
                        conn.Close();
                        string forReader_Onlist = "Select * from " + lblDatabase_.Text + ".tbl_remarks" + " order by remarks";
                        MySqlDataReader reader_onlist = Program.Query(forReader_Onlist);
                        while (reader_onlist.Read())
                        {
                            ListViewItem lst = new ListViewItem("");
                            if (!reader_onlist.IsDBNull(0))
                            {
                                lst.SubItems.Add(reader_onlist.GetString(0));
                                lsvOnList_Remarks.Items.Add(lst);
                            }
                        }
                        reader_onlist.Close();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            lblDatabase_.Text = db_;
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;

            getInfo();
        }
        string servicemedium_faulttype = "wired";
        private void radWired_FaultType_CheckedChanged(object sender, EventArgs e)
        {
            if (radWired_FaultType.Checked == true)
            {
                radWireless_FaultType.Checked = false;
                servicemedium_faulttype = "wired";
                getInfo();
                btnAdd_FaultType.Enabled = false;
                btnRemove_FaultType.Enabled = false;
                btnNew_FaultType.Enabled = true;
                btnEdit_FaultType.Enabled = false;
                txtEntry_FaultType.Text = "";
                if (lsvData_FaultType.Items.Count != 0)
                {
                    lsvData_FaultType.Items[0].Selected = false;
                }
                btnClose_FaultType.Text = "Close";
                if (lsvOnList_FaultType.Items.Count != 0)
                {
                    lsvOnList_FaultType.Items[0].Selected = false;
                }
            }
        }
        private void radWireless_FaultType_CheckedChanged(object sender, EventArgs e)
        {
            if (radWireless_FaultType.Checked == true)
            {
                radWired_FaultType.Checked = false;
                servicemedium_faulttype = "wireless";
                getInfo();
                btnAdd_FaultType.Enabled = false;
                btnRemove_FaultType.Enabled = false;
                btnNew_FaultType.Enabled = true;
                btnEdit_FaultType.Enabled = false;
                txtEntry_FaultType.Text = "";
                if (lsvData_FaultType.Items.Count != 0)
                {
                    lsvData_FaultType.Items[0].Selected = false;
                }
                btnClose_FaultType.Text = "Close";
                if (lsvOnList_FaultType.Items.Count != 0)
                {
                    lsvOnList_FaultType.Items[0].Selected = false;
                }
            }
        }
        string servicemedium_servicetype = "wired";
        private void radWireless_ServiceType_CheckedChanged(object sender, EventArgs e)
        {
            if (radWireless_ServiceType.Checked == true)
            {
                radWired_ServiceType.Checked = false;
                servicemedium_servicetype = "wireless";
                getInfo();
                btnAdd_ServiceType.Enabled = false;
                btnRemove_ServiceType.Enabled = false;
                btnNew_ServiceType.Enabled = true;
                btnEdit_ServiceType.Enabled = false;
                txtEntry_ServiceType.Text = "";
                if (lsvData_ServiceType.Items.Count != 0)
                {
                    lsvData_ServiceType.Items[0].Selected = false;
                }
                btnClose_ServiceType.Text = "Close";
                if (lsvOnList_ServiceType.Items.Count != 0)
                {
                    lsvOnList_ServiceType.Items[0].Selected = false;
                }
            }
        }
        private void radWired_ServiceType_CheckedChanged(object sender, EventArgs e)
        {
            if (radWired_ServiceType.Checked == true)
            {
                radWireless_ServiceType.Checked = false;
                servicemedium_servicetype = "wired";
                getInfo();
                btnAdd_ServiceType.Enabled = false;
                btnRemove_ServiceType.Enabled = false;
                btnNew_ServiceType.Enabled = true;
                btnEdit_ServiceType.Enabled = false;
                txtEntry_ServiceType.Text = "";
                if (lsvData_ServiceType.Items.Count != 0)
                {
                    lsvData_ServiceType.Items[0].Selected = false;
                }
                btnClose_ServiceType.Text = "Close";
                if (lsvOnList_ServiceType.Items.Count != 0)
                {
                    lsvOnList_ServiceType.Items[0].Selected = false;
                }
            }
        }
        private void clearForms()
        {
            switch (tabMain.SelectedIndex)
            {
                case 0:
                    {
                        switch (btnClose_Workgroup.Text)
                        {
                            case "Close":
                                {
                                    Close();
                                    break;
                                }
                            case "Reset":
                                {
                                    btnAdd_Workgroup.Enabled = false;
                                    btnRemove_Workgroup.Enabled = false;
                                    btnNew_Workgroup.Enabled = true;
                                    btnEdit_Workgroup.Enabled = false;
                                    txtEntry_Workgroup.Text = "";
                                    txtEntry_Workgroup.Enabled = false;
                                    if (lsvData_Workgroup.Items.Count != 0)
                                    {
                                        lsvData_Workgroup.Items[0].Selected = false;
                                    }
                                    btnClose_Workgroup.Text = "Close";
                                    if (lsvOnList_Workgroup.Items.Count != 0)
                                    {
                                        lsvOnList_Workgroup.Items[0].Selected = false;
                                    }
                                    btnNew_Workgroup.Text = "Add";
                                    btnEdit_Workgroup.Text = "Edit";
                                    grbMain_Workgroup.Enabled = true;
                                    tabServiceType.Enabled = true;
                                    tabFaultType.Enabled = true;
                                    tabRemarks.Enabled = true;
                                    tabWorkgroup.Enabled = true;
                                    break;
                                }
                        }
                        break;
                    }
                case 1:
                    {
                        switch (btnClose_ServiceType.Text)
                        {
                            case "Close":
                                {
                                    Close();
                                    break;
                                }
                            case "Reset":
                                {
                                    btnAdd_ServiceType.Enabled = false;
                                    btnRemove_ServiceType.Enabled = false;
                                    btnNew_ServiceType.Enabled = true;
                                    btnEdit_ServiceType.Enabled = false;
                                    txtEntry_ServiceType.Text = "";
                                    txtEntry_ServiceType.Enabled = false;
                                    if (lsvData_ServiceType.Items.Count != 0)
                                    {
                                        lsvData_ServiceType.Items[0].Selected = false;
                                    }
                                    btnClose_ServiceType.Text = "Close";
                                    if (lsvOnList_ServiceType.Items.Count != 0)
                                    {
                                        lsvOnList_ServiceType.Items[0].Selected = false;
                                    }
                                    btnNew_ServiceType.Text = "Add";
                                    btnEdit_ServiceType.Text = "Edit";
                                    grbMain_ServiceType.Enabled = true;
                                    grbServiceMedium_ServiceType.Enabled = true;
                                    tabServiceType.Enabled = true;
                                    tabFaultType.Enabled = true;
                                    tabRemarks.Enabled = true;
                                    tabWorkgroup.Enabled = true;
                                    break;
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        switch (btnClose_FaultType.Text)
                        {
                            case "Close":
                                {
                                    Close();
                                    break;
                                }
                            case "Reset":
                                {
                                    btnAdd_FaultType.Enabled = false;
                                    btnRemove_FaultType.Enabled = false;
                                    btnNew_FaultType.Enabled = true;
                                    btnEdit_FaultType.Enabled = false;
                                    txtEntry_FaultType.Text = "";
                                    txtEntry_FaultType.Enabled = false;
                                    if (lsvData_FaultType.Items.Count != 0)
                                    {
                                        lsvData_FaultType.Items[0].Selected = false;
                                    }
                                    btnClose_FaultType.Text = "Close";
                                    if (lsvOnList_FaultType.Items.Count != 0)
                                    {
                                        lsvOnList_FaultType.Items[0].Selected = false;
                                    }
                                    btnNew_FaultType.Text = "Add";
                                    btnEdit_FaultType.Text = "Edit";
                                    grbMain_FaultType.Enabled = true;
                                    grbServiceMedium_FaultType.Enabled = true;
                                    tabServiceType.Enabled = true;
                                    tabFaultType.Enabled = true;
                                    tabRemarks.Enabled = true;
                                    tabWorkgroup.Enabled = true;
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        switch (btnClose_Remarks.Text)
                        {
                            case "Close":
                                {
                                    Close();
                                    break;
                                }
                            case "Reset":
                                {
                                    btnAdd_Remarks.Enabled = false;
                                    btnRemove_Remarks.Enabled = false;
                                    btnNew_Remarks.Enabled = true;
                                    btnEdit_Remarks.Enabled = false;
                                    txtEntry_Remarks.Text = "";
                                    txtEntry_Remarks.Enabled = false;
                                    if (lsvData_Remarks.Items.Count != 0)
                                    {
                                        lsvData_Remarks.Items[0].Selected = false;
                                    }
                                    btnClose_Remarks.Text = "Close";
                                    if (lsvOnList_Remarks.Items.Count != 0)
                                    {
                                        lsvOnList_Remarks.Items[0].Selected = false;
                                    }
                                    btnNew_Remarks.Text = "Add";
                                    btnEdit_Remarks.Text = "Edit";
                                    grbMain_Remarks.Enabled = true;
                                    tabServiceType.Enabled = true;
                                    tabFaultType.Enabled = true;
                                    tabServiceType.Enabled = true;
                                    tabWorkgroup.Enabled = true;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        private void lsvData_Workgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvData_Workgroup.SelectedItems.Count != 0)
            {
                btnAdd_Workgroup.Enabled = true;
                btnRemove_Workgroup.Enabled = false;
                btnNew_Workgroup.Enabled = false;
                btnEdit_Workgroup.Enabled = true;
                btnClose_Workgroup.Text = "Reset";
                ListViewItem item = lsvData_Workgroup.SelectedItems[0];
                txtEntry_Workgroup.Text = item.SubItems[1].Text;
                if (lsvOnList_Workgroup.Items.Count != 0)
                {
                    lsvOnList_Workgroup.Items[0].Selected = false;
                }
            }
            else
            {
                btnAdd_Workgroup.Enabled = false;
                btnRemove_Workgroup.Enabled = false;
                btnNew_Workgroup.Enabled = true;
                btnEdit_Workgroup.Enabled = false;
                btnClose_Workgroup.Text = "Close";
                txtEntry_Workgroup.Text = "";
                if (lsvOnList_Workgroup.Items.Count != 0)
                {
                    lsvOnList_Workgroup.Items[0].Selected = false;
                }
            }
        }
        private void lsvOnList_Workgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvOnList_Workgroup.SelectedItems.Count != 0)
            {
                btnAdd_Workgroup.Enabled = false;
                btnRemove_Workgroup.Enabled = true;
                btnNew_Workgroup.Enabled = false;
                btnEdit_Workgroup.Enabled = false;
                btnClose_Workgroup.Text = "Reset";
                txtEntry_Workgroup.Text = "";
                if (lsvData_Workgroup.Items.Count != 0)
                {
                    lsvData_Workgroup.Items[0].Selected = false;
                }
            }
            else
            {
                btnAdd_Workgroup.Enabled = false;
                btnRemove_Workgroup.Enabled = false;
                btnNew_Workgroup.Enabled = true;
                btnEdit_Workgroup.Enabled = false;
                btnClose_Workgroup.Text = "Close";
                txtEntry_Workgroup.Text = "";
                if (lsvData_Workgroup.Items.Count != 0)
                {
                    lsvData_Workgroup.Items[0].Selected = false;
                }
            }
        }
        private void lsvData_ServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvData_ServiceType.SelectedItems.Count != 0)
            {
                btnAdd_ServiceType.Enabled = true;
                btnRemove_ServiceType.Enabled = false;
                btnNew_ServiceType.Enabled = false;
                btnEdit_ServiceType.Enabled = true;
                btnClose_ServiceType.Text = "Reset";
                ListViewItem item = lsvData_ServiceType.SelectedItems[0];
                txtEntry_ServiceType.Text = item.SubItems[1].Text;
                if (lsvOnList_ServiceType.Items.Count != 0)
                {
                    lsvOnList_ServiceType.Items[0].Selected = false;
                }
            }
            else
            {
                btnAdd_ServiceType.Enabled = false;
                btnRemove_ServiceType.Enabled = false;
                btnNew_ServiceType.Enabled = true;
                btnEdit_ServiceType.Enabled = false;
                btnClose_ServiceType.Text = "Close";
                txtEntry_ServiceType.Text = "";
                if (lsvOnList_ServiceType.Items.Count != 0)
                {
                    lsvOnList_ServiceType.Items[0].Selected = false;
                }
            }
        }
        private void lsvOnList_ServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvOnList_ServiceType.SelectedItems.Count != 0)
            {
                btnAdd_ServiceType.Enabled = false;
                btnRemove_ServiceType.Enabled = true;
                btnNew_ServiceType.Enabled = false;
                btnEdit_ServiceType.Enabled = false;
                btnClose_ServiceType.Text = "Reset";
                txtEntry_ServiceType.Text = "";
                if (lsvData_ServiceType.Items.Count != 0)
                {
                    lsvData_ServiceType.Items[0].Selected = false;
                }
            }
            else
            {
                btnAdd_ServiceType.Enabled = false;
                btnRemove_ServiceType.Enabled = false;
                btnNew_ServiceType.Enabled = true;
                btnEdit_ServiceType.Enabled = false;
                btnClose_ServiceType.Text = "Close";
                txtEntry_ServiceType.Text = "";
                if (lsvData_ServiceType.Items.Count != 0)
                {
                    lsvData_ServiceType.Items[0].Selected = false;
                }
            }
        }
        private void lsvData_FaultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvData_FaultType.SelectedItems.Count != 0)
            {
                btnAdd_FaultType.Enabled = true;
                btnRemove_FaultType.Enabled = false;
                btnNew_FaultType.Enabled = false;
                btnEdit_FaultType.Enabled = true;
                btnClose_FaultType.Text = "Reset";
                ListViewItem item = lsvData_FaultType.SelectedItems[0];
                txtEntry_FaultType.Text = item.SubItems[1].Text;
                if (lsvOnList_FaultType.Items.Count != 0)
                {
                    lsvOnList_FaultType.Items[0].Selected = false;
                }
            }
            else
            {
                btnAdd_FaultType.Enabled = false;
                btnRemove_FaultType.Enabled = false;
                btnNew_FaultType.Enabled = true;
                btnEdit_FaultType.Enabled = false;
                btnClose_FaultType.Text = "Close";
                txtEntry_FaultType.Text = "";
                if (lsvOnList_FaultType.Items.Count != 0)
                {
                    lsvOnList_FaultType.Items[0].Selected = false;
                }
            }
        }
        private void lsvOnList_FaultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvOnList_FaultType.SelectedItems.Count != 0)
            {
                btnAdd_FaultType.Enabled = false;
                btnRemove_FaultType.Enabled = true;
                btnNew_FaultType.Enabled = false;
                btnEdit_FaultType.Enabled = false;
                btnClose_FaultType.Text = "Reset";
                txtEntry_FaultType.Text = "";
                if (lsvData_FaultType.Items.Count != 0)
                {
                    lsvData_FaultType.Items[0].Selected = false;
                }
            }
            else
            {
                btnAdd_FaultType.Enabled = false;
                btnRemove_FaultType.Enabled = false;
                btnNew_FaultType.Enabled = true;
                btnEdit_FaultType.Enabled = false;
                btnClose_FaultType.Text = "Close";
                txtEntry_FaultType.Text = "";
                if (lsvData_FaultType.Items.Count != 0)
                {
                    lsvData_FaultType.Items[0].Selected = false;
                }
            }
        }
        private void lsvData_Remarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvData_Remarks.SelectedItems.Count != 0)
            {
                btnAdd_Remarks.Enabled = true;
                btnRemove_Remarks.Enabled = false;
                btnNew_Remarks.Enabled = false;
                btnEdit_Remarks.Enabled = true;
                btnClose_Remarks.Text = "Reset";
                ListViewItem item = lsvData_Remarks.SelectedItems[0];
                txtEntry_Remarks.Text = item.SubItems[1].Text;
                if (lsvOnList_Remarks.Items.Count != 0)
                {
                    lsvOnList_Remarks.Items[0].Selected = false;
                }
            }
            else
            {
                btnAdd_Remarks.Enabled = false;
                btnRemove_Remarks.Enabled = false;
                btnNew_Remarks.Enabled = true;
                btnEdit_Remarks.Enabled = false;
                btnClose_Remarks.Text = "Close";
                txtEntry_Remarks.Text = "";
                if (lsvOnList_Remarks.Items.Count != 0)
                {
                    lsvOnList_Remarks.Items[0].Selected = false;
                }
            }
        }
        private void lsvOnList_Remarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvOnList_Remarks.SelectedItems.Count != 0)
            {
                btnAdd_Remarks.Enabled = false;
                btnRemove_Remarks.Enabled = true;
                btnNew_Remarks.Enabled = false;
                btnEdit_Remarks.Enabled = false;
                btnClose_Remarks.Text = "Reset";
                txtEntry_Remarks.Text = "";
                if (lsvData_Remarks.Items.Count != 0)
                {
                    lsvData_Remarks.Items[0].Selected = false;
                }
            }
            else
            {
                btnAdd_Remarks.Enabled = false;
                btnRemove_Remarks.Enabled = false;
                btnNew_Remarks.Enabled = true;
                btnEdit_Remarks.Enabled = false;
                btnClose_Remarks.Text = "Close";
                txtEntry_Remarks.Text = "";
                if (lsvData_Remarks.Items.Count != 0)
                {
                    lsvData_Remarks.Items[0].Selected = false;
                }
            }
        }
        private void txtEntry_Workgroup_Leave(object sender, EventArgs e)
        {
            txtEntry_Workgroup.Text = txtEntry_Workgroup.Text.ToUpper();
        }
        private void txtEntry_ServiceType_Leave(object sender, EventArgs e)
        {
            txtEntry_ServiceType.Text = txtEntry_ServiceType.Text.ToUpper();
        }
        private void txtEntry_FaultType_Leave(object sender, EventArgs e)
        {
            txtEntry_FaultType.Text = txtEntry_FaultType.Text.ToUpper();
        }
        private void txtEntry_Remarks_Leave(object sender, EventArgs e)
        {
            txtEntry_Remarks.Text = txtEntry_Remarks.Text.ToUpper();
        }
        private void btnClose_Workgroup_Click(object sender, EventArgs e)
        {
            clearForms();
        }
        private void btnClose_ServiceType_Click(object sender, EventArgs e)
        {
            clearForms();
        }
        private void btnClose_FaultType_Click(object sender, EventArgs e)
        {
            clearForms();
        }
        private void btnClose_Remarks_Click(object sender, EventArgs e)
        {
            clearForms();
        }
        string activity;
        string action;
        string activetab;
        string entryname;
        private void shadow()
        {
            switch (action)
            {
                case "add":
                    {
                        activity = activetab + " [" + entryname + "] has been added.";
                        break;
                    }
                case "edit":
                    {
                        activity = activetab + " [" + prevEntry + "] has been changed to [" + entryname + "].";
                        break;
                    }
                case "activate":
                    {
                        activity = activetab + " [" + entryname + "] has been added to Currently Activated.";
                        break;
                    }
                case "deactivate":
                    {
                        activity = activetab + " [" + entryname + "] has been added to Currently Activated.";
                        break;
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
        }
        private void btnEdit_Workgroup_Click(object sender, EventArgs e)
        {
            switch (btnEdit_Workgroup.Text)
            {
                case "Edit":
                    {
                        btnEdit_Workgroup.Text = "Update";
                        txtEntry_Workgroup.Enabled = true;
                        btnClose_Workgroup.Text = "Reset";
                        grbMain_Workgroup.Enabled = false;
                        prevEntry = txtEntry_Workgroup.Text;
                        tabServiceType.Enabled = false;
                        tabFaultType.Enabled = false;
                        tabRemarks.Enabled = false;
                        txtEntry_Workgroup.Select(0, txtEntry_Workgroup.MaxLength);
                        txtEntry_Workgroup.Focus();
                        break;
                    }
                case "Update":
                    {
                        if (prevEntry != txtEntry_Workgroup.Text)
                        {
                            if (txtEntry_Workgroup.Text.Trim() != "")
                            {
                                string forReader = "Select workgroup from " + lblDatabase_.Text + ".tbl_category" + " where workgroup like '" + txtEntry_Workgroup.Text + "'";
                                MySqlDataReader reader = Program.Query(forReader);
                                if (reader.Read() == false)
                                {
                                    if (MessageBox.Show("Entry: " + prevEntry + " >>> " + txtEntry_Workgroup.Text + "\n\n\nEdit entry?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        string forUpdate = "update " + lblDatabase_.Text + ".tbl_category" + " set workgroup = '" + txtEntry_Workgroup.Text + "' where workgroup = '" + prevEntry + "'";
                                        Program.Query(forUpdate).Close();
                                        MessageBox.Show("Entry is successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        activetab = "Workgroup";
                                        action = "edit";
                                        entryname = txtEntry_Workgroup.Text;
                                        shadow();
                                        clearForms();
                                        getInfo();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entry is existing.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEntry_Workgroup.Select(0, txtEntry_Workgroup.MaxLength);
                                    txtEntry_Workgroup.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Entry is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEntry_Workgroup.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No change has beeen done.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }
        private void btnEdit_ServiceType_Click(object sender, EventArgs e)
        {
            switch (btnEdit_ServiceType.Text)
            {
                case "Edit":
                    {
                        btnEdit_ServiceType.Text = "Update";
                        txtEntry_ServiceType.Enabled = true;
                        btnClose_ServiceType.Text = "Reset";
                        grbMain_ServiceType.Enabled = false;
                        grbServiceMedium_ServiceType.Enabled = false;
                        prevEntry = txtEntry_ServiceType.Text;
                        tabWorkgroup.Enabled = false;
                        tabFaultType.Enabled = false;
                        tabRemarks.Enabled = false;
                        txtEntry_ServiceType.Select(0, txtEntry_ServiceType.MaxLength);
                        txtEntry_ServiceType.Focus();
                        break;
                    }
                case "Update":
                    {
                        if (prevEntry != txtEntry_ServiceType.Text)
                        {
                            if (txtEntry_ServiceType.Text.Trim() != "")
                            {
                                string forReader = "Select " + servicemedium_servicetype + "servicetype" + " from " + lblDatabase_.Text + ".tbl_category" + " where " + servicemedium_servicetype + "servicetype" + " like '" + txtEntry_ServiceType.Text + "'";
                                MySqlDataReader reader = Program.Query(forReader);
                                if (reader.Read() == false)
                                {
                                    if (MessageBox.Show("Entry: " + prevEntry + " >>> " + txtEntry_ServiceType.Text + "\n\n\nEdit entry?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        string forUpdate = "update " + lblDatabase_.Text + ".tbl_category" + " set " + servicemedium_servicetype + "servicetype" + " = '" + txtEntry_ServiceType.Text + "' where " + servicemedium_servicetype + "servicetype" + " = '" + prevEntry + "'";
                                        Program.Query(forUpdate).Close();
                                        MessageBox.Show("Entry is successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        activetab = "Service Type";
                                        action = "edit";
                                        entryname = txtEntry_ServiceType.Text;
                                        shadow();
                                        clearForms();
                                        getInfo();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entry is existing.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEntry_ServiceType.Select(0, txtEntry_ServiceType.MaxLength);
                                    txtEntry_ServiceType.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Entry is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEntry_ServiceType.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No change has beeen done.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }
        private void btnEdit_FaultType_Click(object sender, EventArgs e)
        {
            switch (btnEdit_FaultType.Text)
            {
                case "Edit":
                    {
                        btnEdit_FaultType.Text = "Update";
                        txtEntry_FaultType.Enabled = true;
                        btnClose_FaultType.Text = "Reset";
                        grbMain_FaultType.Enabled = false;
                        grbServiceMedium_FaultType.Enabled = false;
                        prevEntry = txtEntry_FaultType.Text;
                        tabServiceType.Enabled = false;
                        tabWorkgroup.Enabled = false;
                        tabRemarks.Enabled = false;
                        txtEntry_FaultType.Select(0, txtEntry_FaultType.MaxLength);
                        txtEntry_FaultType.Focus();
                        break;
                    }
                case "Update":
                    {
                        if (prevEntry != txtEntry_FaultType.Text)
                        {
                            if (txtEntry_FaultType.Text.Trim() != "")
                            {
                                string forReader = "Select " + servicemedium_faulttype + "faulttype" + " from " + lblDatabase_.Text + ".tbl_category" + " where " + servicemedium_faulttype + "faulttype" + " like '" + txtEntry_FaultType.Text + "'";
                                MySqlDataReader reader = Program.Query(forReader);
                                if (reader.Read() == false)
                                {
                                    if (MessageBox.Show("Entry: " + prevEntry + " >>> " + txtEntry_FaultType.Text + "\n\n\nEdit entry?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        string forUpdate = "update " + lblDatabase_.Text + ".tbl_category" + " set " + servicemedium_faulttype + "faulttype" + " = '" + txtEntry_FaultType.Text + "' where " + servicemedium_faulttype + "faulttype" + " = '" + prevEntry + "'";
                                        Program.Query(forUpdate).Close();
                                        MessageBox.Show("Entry is successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        activetab = "Fault Type";
                                        action = "edit";
                                        entryname = txtEntry_FaultType.Text;
                                        shadow();
                                        clearForms();
                                        getInfo();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entry is existing.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEntry_FaultType.Select(0, txtEntry_FaultType.MaxLength);
                                    txtEntry_FaultType.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Entry is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEntry_FaultType.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No change has beeen done.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }
        private void btnEdit_Remarks_Click(object sender, EventArgs e)
        {
            switch (btnEdit_Remarks.Text)
            {
                case "Edit":
                    {
                        btnEdit_Remarks.Text = "Update";
                        txtEntry_Remarks.Enabled = true;
                        btnClose_Remarks.Text = "Reset";
                        grbMain_Remarks.Enabled = false;
                        prevEntry = txtEntry_Remarks.Text;
                        tabServiceType.Enabled = false;
                        tabFaultType.Enabled = false;
                        tabWorkgroup.Enabled = false;
                        txtEntry_Remarks.Select(0, txtEntry_Remarks.MaxLength);
                        txtEntry_Remarks.Focus();
                        break;
                    }
                case "Update":
                    {
                        if (prevEntry != txtEntry_Remarks.Text)
                        {
                            if (txtEntry_Remarks.Text.Trim() != "")
                            {
                                string forReader = "Select remarks from " + lblDatabase_.Text + ".tbl_category" + " where remarks like '" + txtEntry_Remarks.Text + "'";
                                MySqlDataReader reader = Program.Query(forReader);
                                if (reader.Read() == false)
                                {
                                    if (MessageBox.Show("Entry: " + prevEntry + " >>> " + txtEntry_Remarks.Text + "\n\n\nEdit entry?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        string forUpdate = "update " + lblDatabase_.Text + ".tbl_category" + " set remarks = '" + txtEntry_Remarks.Text + "' where remarks = '" + prevEntry + "'";
                                        Program.Query(forUpdate).Close();
                                        MessageBox.Show("Entry is successfully updated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        activetab = "Remarks";
                                        action = "edit";
                                        entryname = txtEntry_Remarks.Text;
                                        shadow();
                                        clearForms();
                                        getInfo();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entry is existing.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEntry_Remarks.Select(0, txtEntry_Remarks.MaxLength);
                                    txtEntry_Remarks.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Entry is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEntry_Remarks.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No change has beeen done.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }
        private void tabMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !e.TabPage.Enabled;
        }
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            getInfo();
        }
        private void btnNew_Workgroup_Click(object sender, EventArgs e)
        {
            switch (btnNew_Workgroup.Text)
            {
                case "Add":
                    {
                        txtEntry_Workgroup.Enabled = true;
                        btnClose_Workgroup.Text = "Reset";
                        btnNew_Workgroup.Text = "Save";
                        grbMain_Workgroup.Enabled = false;
                        tabServiceType.Enabled = false;
                        tabFaultType.Enabled = false;
                        tabRemarks.Enabled = false;
                        txtEntry_Workgroup.Focus();
                        break;
                    }
                case "Save":
                    {
                        if (txtEntry_Workgroup.Text.Trim() != "")
                        {
                            if (txtEntry_Workgroup.Text != "OPEN")
                            {
                                string forVerify = "Select workgroup from " + lblDatabase_.Text + ".tbl_category" + " where workgroup like '" + txtEntry_Workgroup.Text + "'";
                                MySqlDataReader reader_verify = Program.Query(forVerify);
                                if (!reader_verify.Read())
                                {
                                    if (MessageBox.Show("Entry: " + txtEntry_Workgroup.Text + "\n\n\nAdd entry?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        string forInsert = "insert into " + lblDatabase_.Text + ".tbl_category" + " (workgroup) values ('" + txtEntry_Workgroup.Text + "')";
                                        Program.Query(forInsert).Close();
                                        MessageBox.Show("Entry is successfully added.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        activetab = "Workgroup";
                                        action = "add";
                                        entryname = txtEntry_Workgroup.Text;
                                        shadow();
                                        clearForms();
                                        getInfo();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entry is existing.", "System.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEntry_Workgroup.Select(0, txtEntry_Workgroup.MaxLength);
                                    txtEntry_Workgroup.Focus();
                                }
                                reader_verify.Close();
                            }
                            else
                            {
                                MessageBox.Show("Entry is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEntry_Workgroup.Select(0, txtEntry_Workgroup.MaxLength);
                                txtEntry_Workgroup.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Entry is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEntry_Workgroup.Focus();
                        }
                        break;
                    }
            }
        }
        private void btnNew_ServiceType_Click(object sender, EventArgs e)
        {
            switch (btnNew_ServiceType.Text)
            {
                case "Add":
                    {
                        txtEntry_ServiceType.Enabled = true;
                        btnClose_ServiceType.Text = "Reset";
                        btnNew_ServiceType.Text = "Save";
                        grbMain_ServiceType.Enabled = false;
                        grbServiceMedium_ServiceType.Enabled = false;
                        tabWorkgroup.Enabled = false;
                        tabFaultType.Enabled = false;
                        tabRemarks.Enabled = false;
                        txtEntry_ServiceType.Focus();
                        break;
                    }
                case "Save":
                    {
                        if (txtEntry_ServiceType.Text.Trim() != "")
                        {
                            if (txtEntry_ServiceType.Text != "OPEN")
                            {
                                string forVerify = "Select " + servicemedium_servicetype + "servicetype" + " from " + lblDatabase_.Text + ".tbl_category" + " where " + servicemedium_servicetype + "servicetype" + " like '" + txtEntry_ServiceType.Text + "'";
                                MySqlDataReader reader_verify = Program.Query(forVerify);
                                if (!reader_verify.Read())
                                {
                                    if (MessageBox.Show("Entry: " + txtEntry_ServiceType.Text + "\n\n\nAdd entry?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        string forInsert = "insert into " + lblDatabase_.Text + ".tbl_category" + " (" + servicemedium_servicetype + "servicetype" + ") values ('" + txtEntry_ServiceType.Text + "')";
                                        Program.Query(forInsert).Close();
                                        MessageBox.Show("Entry is successfully added.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        activetab = "Service Type";
                                        action = "add";
                                        entryname = txtEntry_ServiceType.Text;
                                        shadow();
                                        clearForms();
                                        getInfo();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entry is existing.", "System.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEntry_ServiceType.Select(0, txtEntry_ServiceType.MaxLength);
                                    txtEntry_ServiceType.Focus();
                                }
                                reader_verify.Close();
                            }
                            else
                            {
                                MessageBox.Show("Entry is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEntry_ServiceType.Select(0, txtEntry_ServiceType.MaxLength);
                                txtEntry_ServiceType.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Entry is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEntry_ServiceType.Focus();
                        }
                        break;
                    }
            }
        }
        private void btnNew_FaultType_Click(object sender, EventArgs e)
        {
            switch (btnNew_FaultType.Text)
            {
                case "Add":
                    {
                        txtEntry_FaultType.Enabled = true;
                        btnClose_FaultType.Text = "Reset";
                        btnNew_FaultType.Text = "Save";
                        grbMain_FaultType.Enabled = false;
                        grbServiceMedium_FaultType.Enabled = false;
                        tabWorkgroup.Enabled = false;
                        tabServiceType.Enabled = false;
                        tabRemarks.Enabled = false;
                        txtEntry_FaultType.Focus();
                        break;
                    }
                case "Save":
                    {
                        if (txtEntry_FaultType.Text.Trim() != "")
                        {
                            if (txtEntry_FaultType.Text != "OPEN")
                            {
                                string forVerify = "Select " + servicemedium_faulttype + "faulttype" + " from " + lblDatabase_.Text + ".tbl_category" + " where " + servicemedium_faulttype + "FaultType" + " like '" + txtEntry_FaultType.Text + "'";
                                MySqlDataReader reader_verify = Program.Query(forVerify);
                                if (!reader_verify.Read())
                                {
                                    if (MessageBox.Show("Entry: " + txtEntry_FaultType.Text + "\n\n\nAdd entry?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        string forInsert = "insert into " + lblDatabase_.Text + ".tbl_category" + " (" + servicemedium_faulttype + "faulttype" + ") values ('" + txtEntry_FaultType.Text + "')";
                                        Program.Query(forInsert).Close();
                                        MessageBox.Show("Entry is successfully added.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        activetab = "Fault Type";
                                        action = "add";
                                        entryname = txtEntry_FaultType.Text;
                                        shadow();
                                        clearForms();
                                        getInfo();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entry is existing.", "System.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEntry_FaultType.Select(0, txtEntry_FaultType.MaxLength);
                                    txtEntry_FaultType.Focus();
                                }
                                reader_verify.Close();
                            }
                            else
                            {
                                MessageBox.Show("Entry is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEntry_FaultType.Select(0, txtEntry_FaultType.MaxLength);
                                txtEntry_FaultType.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Entry is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEntry_FaultType.Focus();
                        }
                        break;
                    }
            }
        }
        private void btnNew_Remarks_Click(object sender, EventArgs e)
        {
            switch (btnNew_Remarks.Text)
            {
                case "Add":
                    {
                        txtEntry_Remarks.Enabled = true;
                        btnClose_Remarks.Text = "Reset";
                        btnNew_Remarks.Text = "Save";
                        grbMain_Remarks.Enabled = false;
                        tabServiceType.Enabled = false;
                        tabFaultType.Enabled = false;
                        tabWorkgroup.Enabled = false;
                        txtEntry_Remarks.Focus();
                        break;
                    }
                case "Save":
                    {
                        if (txtEntry_Remarks.Text.Trim() != "")
                        {
                            if (txtEntry_Remarks.Text != "OPEN")
                            {
                                string forVerify = "Select remarks from " + lblDatabase_.Text + ".tbl_category" + " where remarks like '" + txtEntry_Remarks.Text + "'";
                                MySqlDataReader reader_verify = Program.Query(forVerify);
                                if (!reader_verify.Read())
                                {
                                    if (MessageBox.Show("Entry: " + txtEntry_Remarks.Text + "\n\n\nAdd entry?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        string forInsert = "insert into " + lblDatabase_.Text + ".tbl_category" + " (remarks) values ('" + txtEntry_Remarks.Text + "')";
                                        Program.Query(forInsert).Close();
                                        MessageBox.Show("Entry is successfully added.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        activetab = "Remarks";
                                        action = "add";
                                        entryname = txtEntry_Remarks.Text;
                                        shadow();
                                        clearForms();
                                        getInfo();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entry is existing.", "System.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEntry_Remarks.Select(0, txtEntry_Remarks.MaxLength);
                                    txtEntry_Remarks.Focus();
                                }
                                reader_verify.Close();
                            }
                            else
                            {
                                MessageBox.Show("Entry is invalid.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEntry_Remarks.Select(0, txtEntry_Remarks.MaxLength);
                                txtEntry_Remarks.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Entry is empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEntry_Remarks.Focus();
                        }
                        break;
                    }
            }
        }
        private void btnAdd_Workgroup_Click(object sender, EventArgs e)
        {
            ListViewItem item = lsvData_Workgroup.SelectedItems[0];
            lblEntry_Workgroup.Text = item.SubItems[1].Text;
            string forReader_verify = "Select * from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + lblEntry_Workgroup.Text + "'";
            MySqlDataReader reader_verify = Program.Query(forReader_verify);
            if (!reader_verify.Read())
            {
                string forInsert = "insert into " + lblDatabase_.Text + ".tbl_workgroup" + " (workgroup) values ('" + lblEntry_Workgroup.Text + "')";
                Program.Query(forInsert).Close();
                string forUpdate = "update " + lblDatabase_.Text + ".tbl_category" + " set workgroup = null where workgroup = '" + lblEntry_Workgroup.Text + "'";
                Program.Query(forUpdate).Close();
                clearForms();
                getInfo();
                entryname = lblEntry_Workgroup.Text;
                action = "activate";
                shadow();
                lblEntry_Workgroup.Text = "";
            }
            else
            {
                MessageBox.Show("Action failed.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_FaultType_Click(object sender, EventArgs e)
        {
            ListViewItem item = lsvData_FaultType.SelectedItems[0];
            lblEntry_FaultType.Text = item.SubItems[1].Text;
            string forReader_verify = "Select * from " + lblDatabase_.Text + ".tbl_" + servicemedium_faulttype + "faulttype" + " where faulttype like '" + lblEntry_FaultType.Text + "'";
            MySqlDataReader reader_verify = Program.Query(forReader_verify);
            if (!reader_verify.Read())
            {
                string forInsert = "insert into " + lblDatabase_.Text + ".tbl_" + servicemedium_faulttype + "faulttype" + " (faulttype) values ('" + lblEntry_FaultType.Text + "')";
                Program.Query(forInsert).Close();
                string forUpdate = "update " + lblDatabase_.Text + ".tbl_category" + " set " + servicemedium_faulttype + "faulttype" + " = null where " + servicemedium_faulttype + "faulttype" + " = '" + lblEntry_FaultType.Text + "'";
                Program.Query(forUpdate).Close();
                clearForms();
                getInfo();
                entryname = lblEntry_FaultType.Text;
                action = "activate";
                shadow();
                lblEntry_FaultType.Text = "";
            }
            else
            {
                MessageBox.Show("Action failed.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_ServiceType_Click(object sender, EventArgs e)
        {
            ListViewItem item = lsvData_ServiceType.SelectedItems[0];
            lblEntry_ServiceType.Text = item.SubItems[1].Text;
            string forReader_verify = "Select * from " + lblDatabase_.Text + ".tbl_" + servicemedium_servicetype + "servicetype" + " where servicetype like '" + lblEntry_ServiceType.Text + "'";
            MySqlDataReader reader_verify = Program.Query(forReader_verify);
            if (!reader_verify.Read())
            {
                string forInsert = "insert into " + lblDatabase_.Text + ".tbl_" + servicemedium_servicetype + "servicetype" + " (servicetype) values ('" + lblEntry_ServiceType.Text + "')";
                Program.Query(forInsert).Close();
                string forUpdate = "update " + lblDatabase_.Text + ".tbl_category" + " set " + servicemedium_servicetype + "servicetype" + " = null where " + servicemedium_servicetype + "servicetype" + " = '" + lblEntry_ServiceType.Text + "'";
                Program.Query(forUpdate).Close();
                clearForms();
                getInfo();
                entryname = lblEntry_ServiceType.Text;
                action = "activate";
                shadow();
                lblEntry_ServiceType.Text = "";
            }
            else
            {
                MessageBox.Show("Action failed.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Remarks_Click(object sender, EventArgs e)
        {
            ListViewItem item = lsvData_Remarks.SelectedItems[0];
            lblEntry_Remarks.Text = item.SubItems[1].Text;
            string forReader_verify = "Select * from " + lblDatabase_.Text + ".tbl_remarks" + " where remarks like '" + lblEntry_Remarks.Text + "'";
            MySqlDataReader reader_verify = Program.Query(forReader_verify);
            if (!reader_verify.Read())
            {
                string forInsert = "insert into " + lblDatabase_.Text + ".tbl_remarks" + " (remarks) values ('" + lblEntry_Remarks.Text + "')";
                Program.Query(forInsert).Close();
                string forUpdate = "update " + lblDatabase_.Text + ".tbl_category" + " set remarks = null where remarks = '" + lblEntry_Remarks.Text + "'";
                Program.Query(forUpdate).Close();
                clearForms();
                getInfo();
                entryname = lblEntry_Remarks.Text;
                action = "activate";
                shadow();
                lblEntry_Remarks.Text = "";
            }
            else
            {
                MessageBox.Show("Action failed.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemove_Remarks_Click(object sender, EventArgs e)
        {
            ListViewItem item = lsvOnList_Remarks.SelectedItems[0];
            lblEntry_Remarks.Text = item.SubItems[1].Text;
            if (lblEntry_Remarks.Text == "CLOSED" || lblEntry_Remarks.Text == "OTHERS" || lblEntry_Remarks.Text == "PARKED")
            {
                MessageBox.Show("Entry cannot be deactivated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string forReader_verify = "Select remarks from " + lblDatabase_.Text + ".tbl_category" + " where remarks like '" + lblEntry_Remarks.Text + "'";
                MySqlDataReader reader_verify = Program.Query(forReader_verify);
                if (!reader_verify.Read())
                {
                    string forInsert = "insert into " + lblDatabase_.Text + ".tbl_category" + " (remarks) values ('" + lblEntry_Remarks.Text + "')";
                    Program.Query(forInsert).Close();
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_remarks" + " from " + lblDatabase_.Text + ".tbl_remarks" + " where remarks like '" + lblEntry_Remarks.Text + "'";
                    Program.Query(forDelete).Close();
                    clearForms();
                    getInfo();
                    entryname = lblEntry_Remarks.Text;
                    action = "deactivate";
                    shadow();
                    lblEntry_Remarks.Text = "";
                }
                else
                {
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_remarks" + " from " + lblDatabase_.Text + ".tbl_remarks" + " where remarks like '" + lblEntry_Remarks.Text + "'";
                    Program.Query(forDelete).Close();
                    clearForms();
                    getInfo();
                    entryname = lblEntry_Remarks.Text;
                    action = "deactivate";
                    shadow();
                    lblEntry_Workgroup.Text = "";
                }
            }
        }
        private void btnRemove_FaultType_Click(object sender, EventArgs e)
        {
            if (lsvOnList_FaultType.Items.Count == 1)
            {
                MessageBox.Show("Entry list cannot be empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ListViewItem item = lsvOnList_FaultType.SelectedItems[0];
                lblEntry_FaultType.Text = item.SubItems[1].Text;
                string forReader_verify = "Select " + servicemedium_faulttype + "faulttype" + " from " + lblDatabase_.Text + ".tbl_category" + " where " + servicemedium_faulttype + "faulttype" + " like '" + lblEntry_FaultType.Text + "'";
                MySqlDataReader reader_verify = Program.Query(forReader_verify);
                if (!reader_verify.Read())
                {
                    string forInsert = "insert into " + lblDatabase_.Text + ".tbl_category" + " (" + servicemedium_faulttype + "faulttype" + ") values ('" + lblEntry_FaultType.Text + "')";
                    Program.Query(forInsert).Close();
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_" + servicemedium_faulttype + "faulttype" + " from " + lblDatabase_.Text + ".tbl_" + servicemedium_faulttype + "faulttype" + " where faulttype like '" + lblEntry_FaultType.Text + "'";
                    Program.Query(forDelete).Close();
                    clearForms();
                    getInfo();
                    entryname = lblEntry_FaultType.Text;
                    action = "deactivate";
                    shadow();
                    lblEntry_FaultType.Text = "";
                }
                else
                {
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_" + servicemedium_faulttype + "faulttype" + " from " + lblDatabase_.Text + ".tbl_" + servicemedium_faulttype + "faulttype" + " where faulttype like '" + lblEntry_FaultType.Text + "'";
                    Program.Query(forDelete).Close();
                    clearForms();
                    getInfo();
                    entryname = lblEntry_FaultType.Text;
                    action = "deactivate";
                    shadow();
                    lblEntry_FaultType.Text = "";
                }
            }
        }
        private void btnRemove_ServiceType_Click(object sender, EventArgs e)
        {
            if (lsvOnList_ServiceType.Items.Count == 1)
            {
                MessageBox.Show("Entry list cannot be empty.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ListViewItem item = lsvOnList_ServiceType.SelectedItems[0];
                lblEntry_ServiceType.Text = item.SubItems[1].Text;
                string forReader_verify = "Select " + servicemedium_servicetype + "servicetype" + " from " + lblDatabase_.Text + ".tbl_category" + " where " + servicemedium_servicetype + "servicetype" + " like '" + lblEntry_ServiceType.Text + "'";
                MySqlDataReader reader_verify = Program.Query(forReader_verify);
                if (!reader_verify.Read())
                {
                    string forInsert = "insert into " + lblDatabase_.Text + ".tbl_category" + " (" + servicemedium_servicetype + "servicetype" + ") values ('" + lblEntry_ServiceType.Text + "')";
                    Program.Query(forInsert).Close();
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_" + servicemedium_servicetype + "servicetype" + " from " + lblDatabase_.Text + ".tbl_" + servicemedium_servicetype + "servicetype" + " where servicetype like '" + lblEntry_ServiceType.Text + "'";
                    Program.Query(forDelete).Close();
                    clearForms();
                    getInfo();
                    entryname = lblEntry_ServiceType.Text;
                    action = "deactivate";
                    shadow();
                    lblEntry_ServiceType.Text = "";
                }
                else
                {
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_" + servicemedium_servicetype + "servicetype" + " from " + lblDatabase_.Text + ".tbl_" + servicemedium_servicetype + "servicetype" + " where servicetype like '" + lblEntry_ServiceType.Text + "'";
                    Program.Query(forDelete).Close();
                    clearForms();
                    getInfo();
                    entryname = lblEntry_ServiceType.Text;
                    action = "deactivate";
                    shadow();
                    lblEntry_ServiceType.Text = "";
                }
            }
        }
        private void btnRemove_Workgroup_Click(object sender, EventArgs e)
        {
            if (lsvOnList_Workgroup.Items.Count == 1)
            {
                MessageBox.Show("Entry list cannot be empty", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ListViewItem item = lsvOnList_Workgroup.SelectedItems[0];
                lblEntry_Workgroup.Text = item.SubItems[1].Text;

                string forReader_verify = "Select workgroup from " + lblDatabase_.Text + ".tbl_category" + " where workgroup like '" + lblEntry_Workgroup.Text + "'";
                MySqlDataReader reader_verify = Program.Query(forReader_verify);
                if (!reader_verify.Read())
                {
                    string forInsert = "insert into " + lblDatabase_.Text + ".tbl_category" + " (workgroup) values ('" + lblEntry_Workgroup.Text + "')";
                    Program.Query(forInsert).Close();
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_workgroup" + " from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + lblEntry_Workgroup.Text + "'";
                    Program.Query(forDelete).Close();
                    clearForms();
                    getInfo();
                    entryname = lblEntry_Workgroup.Text;
                    action = "deactivate";
                    shadow();
                    lblEntry_Workgroup.Text = "";
                }
                else
                {
                    string forDelete = "delete " + lblDatabase_.Text + ".tbl_workgroup" + " from " + lblDatabase_.Text + ".tbl_workgroup" + " where workgroup like '" + lblEntry_Workgroup.Text + "'";
                    Program.Query(forDelete).Close();
                    clearForms();
                    getInfo();
                    entryname = lblEntry_Workgroup.Text;
                    action = "deactivate";
                    shadow();
                    lblEntry_Workgroup.Text = "";
                }
            }
        }
    }
}