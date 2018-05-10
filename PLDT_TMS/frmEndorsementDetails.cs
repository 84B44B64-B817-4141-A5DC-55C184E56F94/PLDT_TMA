using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PLDT_TMS
{
    public partial class frmEndorsementDetails : Form
    {
        //IMPORTANT
        public string username_;
        public string workgroup_;
        public string db_;
        //IMPORTANT
        public frmEndorsementDetails()
        {
            InitializeComponent();
        }
        private void frmEndorsementDetails_Load(object sender, EventArgs e)
        {
            lblDatabase_.Text = db_;
            lblUsername_.Text = username_;
            lblWorkgroup_.Text = workgroup_;
            string query = "Select * from " + lblDatabase_.Text + ".tbl_endorsements" + " where ticketnumber like '" + txtTicketNumber.Text + "' and endorser like '" + txtEndorser.Text + "' and endorsee like '" + txtEndorsee.Text + "' and workgroup like '" + txtWorkgroup.Text + "' and status like '" + txtStatus.Text + "'";
            MySqlDataReader reader = Program.Query(query);
            while (reader.Read())
            {
                txtNote.Text = reader.GetString(5);
                var statusdate = Convert.ToDateTime(reader.GetString(7)).ToString("MMM dd yyyy");
                txtStatusDate.Text = statusdate;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}