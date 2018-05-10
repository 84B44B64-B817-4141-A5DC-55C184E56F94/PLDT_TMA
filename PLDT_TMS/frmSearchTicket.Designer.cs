namespace PLDT_TMS
{
    partial class frmSearchTicket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchTicket));
            this.lblUsername_ = new System.Windows.Forms.Label();
            this.lblWorkgroup_ = new System.Windows.Forms.Label();
            this.lsvData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOutage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboTicketType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboFaultType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpUpdatedDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReportedDate = new System.Windows.Forms.DateTimePicker();
            this.txtOtherRemarks = new System.Windows.Forms.RichTextBox();
            this.lblOtherRemarks = new System.Windows.Forms.Label();
            this.cboRemarks = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboWorkgroup = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboServiceType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPLNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTicketNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalRow = new System.Windows.Forms.TextBox();
            this.btnLess = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtShowRow = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtpSearch = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpReported = new System.Windows.Forms.DateTimePicker();
            this.dtpUpdated = new System.Windows.Forms.DateTimePicker();
            this.lblDatabase_ = new System.Windows.Forms.Label();
            this.ctmSearchTicket = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTicketDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endorseTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.ctmSearchTicket.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername_
            // 
            this.lblUsername_.AutoSize = true;
            this.lblUsername_.Location = new System.Drawing.Point(456, 2);
            this.lblUsername_.Name = "lblUsername_";
            this.lblUsername_.Size = new System.Drawing.Size(35, 13);
            this.lblUsername_.TabIndex = 0;
            this.lblUsername_.Text = "label1";
            this.lblUsername_.Visible = false;
            // 
            // lblWorkgroup_
            // 
            this.lblWorkgroup_.AutoSize = true;
            this.lblWorkgroup_.Location = new System.Drawing.Point(497, 2);
            this.lblWorkgroup_.Name = "lblWorkgroup_";
            this.lblWorkgroup_.Size = new System.Drawing.Size(35, 13);
            this.lblWorkgroup_.TabIndex = 1;
            this.lblWorkgroup_.Text = "label2";
            this.lblWorkgroup_.Visible = false;
            // 
            // lsvData
            // 
            this.lsvData.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lsvData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvData.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lsvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader9,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader10,
            this.columnHeader6,
            this.columnHeader8});
            this.lsvData.FullRowSelect = true;
            this.lsvData.GridLines = true;
            this.lsvData.Location = new System.Drawing.Point(12, 37);
            this.lsvData.MultiSelect = false;
            this.lsvData.Name = "lsvData";
            this.lsvData.Size = new System.Drawing.Size(929, 368);
            this.lsvData.TabIndex = 2;
            this.lsvData.UseCompatibleStateImageBehavior = false;
            this.lsvData.View = System.Windows.Forms.View.Details;
            this.lsvData.SelectedIndexChanged += new System.EventHandler(this.lsvData_SelectedIndexChanged);
            this.lsvData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lsvData_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ticket #";
            this.columnHeader1.Width = 86;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PL #";
            this.columnHeader2.Width = 166;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date Reported";
            this.columnHeader3.Width = 149;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date Updated";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ticket Type";
            this.columnHeader9.Width = 74;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Service Type";
            this.columnHeader5.Width = 154;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Workgroup";
            this.columnHeader7.Width = 146;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Fault Type";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Description";
            this.columnHeader6.Width = 305;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Remarks";
            this.columnHeader8.Width = 163;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtOutage);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cboTicketType);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cboFaultType);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dtpUpdatedDate);
            this.groupBox1.Controls.Add(this.dtpReportedDate);
            this.groupBox1.Controls.Add(this.txtOtherRemarks);
            this.groupBox1.Controls.Add(this.lblOtherRemarks);
            this.groupBox1.Controls.Add(this.cboRemarks);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboWorkgroup);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboServiceType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPLNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTicketNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 431);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 226);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Maroon;
            this.label16.Location = new System.Drawing.Point(506, 164);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 15);
            this.label16.TabIndex = 27;
            this.label16.Text = "hr";
            // 
            // txtOutage
            // 
            this.txtOutage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutage.Location = new System.Drawing.Point(417, 161);
            this.txtOutage.MaxLength = 6;
            this.txtOutage.Name = "txtOutage";
            this.txtOutage.ReadOnly = true;
            this.txtOutage.Size = new System.Drawing.Size(83, 23);
            this.txtOutage.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Maroon;
            this.label15.Location = new System.Drawing.Point(342, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 15);
            this.label15.TabIndex = 25;
            this.label15.Text = "Outage";
            // 
            // cboTicketType
            // 
            this.cboTicketType.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cboTicketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTicketType.Enabled = false;
            this.cboTicketType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTicketType.FormattingEnabled = true;
            this.cboTicketType.Items.AddRange(new object[] {
            "wired",
            "wireless"});
            this.cboTicketType.Location = new System.Drawing.Point(307, 13);
            this.cboTicketType.Name = "cboTicketType";
            this.cboTicketType.Size = new System.Drawing.Size(113, 23);
            this.cboTicketType.TabIndex = 24;
            this.cboTicketType.SelectedIndexChanged += new System.EventHandler(this.cboTicketType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Maroon;
            this.label14.Location = new System.Drawing.Point(220, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "Ticket Type";
            // 
            // cboFaultType
            // 
            this.cboFaultType.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cboFaultType.Enabled = false;
            this.cboFaultType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFaultType.FormattingEnabled = true;
            this.cboFaultType.Location = new System.Drawing.Point(115, 190);
            this.cboFaultType.Name = "cboFaultType";
            this.cboFaultType.Size = new System.Drawing.Size(204, 23);
            this.cboFaultType.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(2, 193);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 15);
            this.label13.TabIndex = 21;
            this.label13.Text = "Fault Type";
            // 
            // dtpUpdatedDate
            // 
            this.dtpUpdatedDate.Enabled = false;
            this.dtpUpdatedDate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpUpdatedDate.Location = new System.Drawing.Point(115, 99);
            this.dtpUpdatedDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpUpdatedDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpUpdatedDate.Name = "dtpUpdatedDate";
            this.dtpUpdatedDate.Size = new System.Drawing.Size(251, 23);
            this.dtpUpdatedDate.TabIndex = 20;
            // 
            // dtpReportedDate
            // 
            this.dtpReportedDate.Enabled = false;
            this.dtpReportedDate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReportedDate.Location = new System.Drawing.Point(115, 73);
            this.dtpReportedDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpReportedDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpReportedDate.Name = "dtpReportedDate";
            this.dtpReportedDate.Size = new System.Drawing.Size(251, 23);
            this.dtpReportedDate.TabIndex = 5;
            // 
            // txtOtherRemarks
            // 
            this.txtOtherRemarks.Location = new System.Drawing.Point(543, 124);
            this.txtOtherRemarks.MaxLength = 200;
            this.txtOtherRemarks.Name = "txtOtherRemarks";
            this.txtOtherRemarks.ReadOnly = true;
            this.txtOtherRemarks.Size = new System.Drawing.Size(380, 80);
            this.txtOtherRemarks.TabIndex = 10;
            this.txtOtherRemarks.Text = "";
            this.txtOtherRemarks.Visible = false;
            // 
            // lblOtherRemarks
            // 
            this.lblOtherRemarks.AutoSize = true;
            this.lblOtherRemarks.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherRemarks.ForeColor = System.Drawing.Color.Maroon;
            this.lblOtherRemarks.Location = new System.Drawing.Point(436, 124);
            this.lblOtherRemarks.Name = "lblOtherRemarks";
            this.lblOtherRemarks.Size = new System.Drawing.Size(101, 15);
            this.lblOtherRemarks.TabIndex = 17;
            this.lblOtherRemarks.Text = "Other remarks";
            this.lblOtherRemarks.Visible = false;
            // 
            // cboRemarks
            // 
            this.cboRemarks.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cboRemarks.Enabled = false;
            this.cboRemarks.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRemarks.FormattingEnabled = true;
            this.cboRemarks.Location = new System.Drawing.Point(543, 95);
            this.cboRemarks.Name = "cboRemarks";
            this.cboRemarks.Size = new System.Drawing.Size(234, 23);
            this.cboRemarks.TabIndex = 9;
            this.cboRemarks.SelectedIndexChanged += new System.EventHandler(this.cboRemarks_SelectedIndexChanged);
            this.cboRemarks.TextChanged += new System.EventHandler(this.cboRemarks_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(436, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Remarks";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(543, 9);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(380, 80);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(436, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Description";
            // 
            // cboWorkgroup
            // 
            this.cboWorkgroup.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cboWorkgroup.Enabled = false;
            this.cboWorkgroup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWorkgroup.FormattingEnabled = true;
            this.cboWorkgroup.Location = new System.Drawing.Point(115, 161);
            this.cboWorkgroup.Name = "cboWorkgroup";
            this.cboWorkgroup.Size = new System.Drawing.Size(204, 23);
            this.cboWorkgroup.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(3, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Workgroup";
            // 
            // cboServiceType
            // 
            this.cboServiceType.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cboServiceType.Enabled = false;
            this.cboServiceType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServiceType.FormattingEnabled = true;
            this.cboServiceType.Location = new System.Drawing.Point(115, 132);
            this.cboServiceType.Name = "cboServiceType";
            this.cboServiceType.Size = new System.Drawing.Size(204, 23);
            this.cboServiceType.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(3, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Service Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(3, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Date Updated";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(3, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Date Reported";
            // 
            // txtPLNumber
            // 
            this.txtPLNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPLNumber.Location = new System.Drawing.Point(115, 42);
            this.txtPLNumber.MaxLength = 20;
            this.txtPLNumber.Name = "txtPLNumber";
            this.txtPLNumber.ReadOnly = true;
            this.txtPLNumber.Size = new System.Drawing.Size(251, 23);
            this.txtPLNumber.TabIndex = 4;
            this.txtPLNumber.Leave += new System.EventHandler(this.txtPLNumber_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(3, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "PL Number";
            // 
            // txtTicketNumber
            // 
            this.txtTicketNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTicketNumber.Location = new System.Drawing.Point(115, 13);
            this.txtTicketNumber.MaxLength = 8;
            this.txtTicketNumber.Name = "txtTicketNumber";
            this.txtTicketNumber.ReadOnly = true;
            this.txtTicketNumber.Size = new System.Drawing.Size(99, 23);
            this.txtTicketNumber.TabIndex = 3;
            this.txtTicketNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTicketNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ticket Number";
            // 
            // cboSearchType
            // 
            this.cboSearchType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSearchType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Items.AddRange(new object[] {
            "None",
            "Ticket Number",
            "PL Number",
            "Date Reported",
            "Service Type",
            "Workgroup",
            "Fault Type",
            "Remarks",
            "Description"});
            this.cboSearchType.Location = new System.Drawing.Point(377, 9);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(206, 23);
            this.cboSearchType.TabIndex = 0;
            this.cboSearchType.SelectedIndexChanged += new System.EventHandler(this.cboSearchType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(295, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search by:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(604, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search for:";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(12, 9);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(253, 23);
            this.lblCount.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(520, 663);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(310, 663);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 30);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit details";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(836, 415);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 15);
            this.label11.TabIndex = 30;
            this.label11.Text = "Total";
            // 
            // txtTotalRow
            // 
            this.txtTotalRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRow.Location = new System.Drawing.Point(882, 411);
            this.txtTotalRow.MaxLength = 5;
            this.txtTotalRow.Name = "txtTotalRow";
            this.txtTotalRow.ReadOnly = true;
            this.txtTotalRow.Size = new System.Drawing.Size(57, 23);
            this.txtTotalRow.TabIndex = 29;
            // 
            // btnLess
            // 
            this.btnLess.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnLess.Enabled = false;
            this.btnLess.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLess.Location = new System.Drawing.Point(640, 410);
            this.btnLess.Name = "btnLess";
            this.btnLess.Size = new System.Drawing.Size(23, 23);
            this.btnLess.TabIndex = 28;
            this.btnLess.Text = "<";
            this.btnLess.UseVisualStyleBackColor = false;
            this.btnLess.Click += new System.EventHandler(this.btnLess_Click);
            // 
            // btnMore
            // 
            this.btnMore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.Location = new System.Drawing.Point(812, 411);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(23, 23);
            this.btnMore.TabIndex = 27;
            this.btnMore.Text = ">";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(732, 414);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "-";
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRow.Location = new System.Drawing.Point(749, 411);
            this.txtRow.MaxLength = 5;
            this.txtRow.Name = "txtRow";
            this.txtRow.ReadOnly = true;
            this.txtRow.Size = new System.Drawing.Size(57, 23);
            this.txtRow.TabIndex = 25;
            // 
            // txtShowRow
            // 
            this.txtShowRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShowRow.Location = new System.Drawing.Point(669, 411);
            this.txtShowRow.MaxLength = 5;
            this.txtShowRow.Name = "txtShowRow";
            this.txtShowRow.ReadOnly = true;
            this.txtShowRow.Size = new System.Drawing.Size(57, 23);
            this.txtShowRow.TabIndex = 24;
            this.txtShowRow.Text = "0";
            this.txtShowRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearch.Enabled = false;
            this.txtSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(689, 9);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(204, 23);
            this.txtSearch.TabIndex = 31;
            // 
            // dtpSearch
            // 
            this.dtpSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearch.Location = new System.Drawing.Point(690, 9);
            this.dtpSearch.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpSearch.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpSearch.Name = "dtpSearch";
            this.dtpSearch.Size = new System.Drawing.Size(203, 23);
            this.dtpSearch.TabIndex = 21;
            this.dtpSearch.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(905, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 23);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpReported
            // 
            this.dtpReported.Location = new System.Drawing.Point(710, 663);
            this.dtpReported.Name = "dtpReported";
            this.dtpReported.Size = new System.Drawing.Size(200, 20);
            this.dtpReported.TabIndex = 33;
            this.dtpReported.Visible = false;
            // 
            // dtpUpdated
            // 
            this.dtpUpdated.Location = new System.Drawing.Point(710, 673);
            this.dtpUpdated.Name = "dtpUpdated";
            this.dtpUpdated.Size = new System.Drawing.Size(200, 20);
            this.dtpUpdated.TabIndex = 34;
            this.dtpUpdated.Visible = false;
            // 
            // lblDatabase_
            // 
            this.lblDatabase_.AutoSize = true;
            this.lblDatabase_.Location = new System.Drawing.Point(415, 2);
            this.lblDatabase_.Name = "lblDatabase_";
            this.lblDatabase_.Size = new System.Drawing.Size(35, 13);
            this.lblDatabase_.TabIndex = 35;
            this.lblDatabase_.Text = "label1";
            this.lblDatabase_.Visible = false;
            // 
            // ctmSearchTicket
            // 
            this.ctmSearchTicket.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTicketDetailsToolStripMenuItem,
            this.endorseTicketToolStripMenuItem});
            this.ctmSearchTicket.Name = "ctmSearchTicket";
            this.ctmSearchTicket.ShowImageMargin = false;
            this.ctmSearchTicket.ShowItemToolTips = false;
            this.ctmSearchTicket.Size = new System.Drawing.Size(148, 48);
            // 
            // editTicketDetailsToolStripMenuItem
            // 
            this.editTicketDetailsToolStripMenuItem.Name = "editTicketDetailsToolStripMenuItem";
            this.editTicketDetailsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editTicketDetailsToolStripMenuItem.Text = "Edit ticket details...";
            this.editTicketDetailsToolStripMenuItem.Click += new System.EventHandler(this.editTicketDetailsToolStripMenuItem_Click);
            // 
            // endorseTicketToolStripMenuItem
            // 
            this.endorseTicketToolStripMenuItem.Name = "endorseTicketToolStripMenuItem";
            this.endorseTicketToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.endorseTicketToolStripMenuItem.Text = "Endorse ticket...";
            this.endorseTicketToolStripMenuItem.Click += new System.EventHandler(this.endorseTicketToolStripMenuItem_Click);
            // 
            // cboSearch
            // 
            this.cboSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "None",
            "Ticket Number",
            "PL Number",
            "Date Reported",
            "Service Type",
            "Workgroup",
            "Fault Type",
            "Remarks",
            "Description"});
            this.cboSearch.Location = new System.Drawing.Point(689, 9);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(206, 23);
            this.cboSearch.TabIndex = 36;
            this.cboSearch.Visible = false;
            this.cboSearch.SelectedIndexChanged += new System.EventHandler(this.cboSearch_SelectedIndexChanged);
            // 
            // frmSearchTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(957, 702);
            this.Controls.Add(this.lblDatabase_);
            this.Controls.Add(this.dtpUpdated);
            this.Controls.Add(this.dtpReported);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotalRow);
            this.Controls.Add(this.btnLess);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.txtShowRow);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSearchType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsvData);
            this.Controls.Add(this.lblWorkgroup_);
            this.Controls.Add(this.lblUsername_);
            this.Controls.Add(this.dtpSearch);
            this.Controls.Add(this.cboSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSearchTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket Registry";
            this.Load += new System.EventHandler(this.frmSearchTicket_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ctmSearchTicket.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername_;
        private System.Windows.Forms.Label lblWorkgroup_;
        private System.Windows.Forms.ListView lsvData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.RichTextBox txtOtherRemarks;
        private System.Windows.Forms.Label lblOtherRemarks;
        private System.Windows.Forms.ComboBox cboRemarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboWorkgroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboServiceType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPLNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTicketNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DateTimePicker dtpUpdatedDate;
        private System.Windows.Forms.DateTimePicker dtpReportedDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalRow;
        private System.Windows.Forms.Button btnLess;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.TextBox txtShowRow;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtpSearch;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ComboBox cboFaultType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ComboBox cboTicketType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtOutage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpReported;
        private System.Windows.Forms.DateTimePicker dtpUpdated;
        private System.Windows.Forms.Label lblDatabase_;
        private System.Windows.Forms.ContextMenuStrip ctmSearchTicket;
        private System.Windows.Forms.ToolStripMenuItem editTicketDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endorseTicketToolStripMenuItem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboSearch;
    }
}