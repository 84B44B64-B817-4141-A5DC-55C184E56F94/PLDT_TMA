namespace PLDT_TMS
{
    partial class frmAdminMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminMaintenance));
            this.lsvData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbDetails = new System.Windows.Forms.GroupBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMiddleInitial = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboWorkgroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUserType = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grbPassword = new System.Windows.Forms.GroupBox();
            this.txtRecovery = new System.Windows.Forms.TextBox();
            this.chkViewRecovery = new System.Windows.Forms.CheckBox();
            this.btnRecovery = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalRow = new System.Windows.Forms.TextBox();
            this.btnLess = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtShowRow = new System.Windows.Forms.TextBox();
            this.grbSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblWorkgroup_ = new System.Windows.Forms.Label();
            this.lblDatabase_ = new System.Windows.Forms.Label();
            this.lblUsername_ = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblLogout = new System.Windows.Forms.Label();
            this.txtLogout = new System.Windows.Forms.TextBox();
            this.grbScroll = new System.Windows.Forms.GroupBox();
            this.grbDetails.SuspendLayout();
            this.grbPassword.SuspendLayout();
            this.grbSearch.SuspendLayout();
            this.grbScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvData
            // 
            this.lsvData.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lsvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lsvData.FullRowSelect = true;
            this.lsvData.GridLines = true;
            this.lsvData.Location = new System.Drawing.Point(14, 54);
            this.lsvData.MultiSelect = false;
            this.lsvData.Name = "lsvData";
            this.lsvData.Size = new System.Drawing.Size(694, 368);
            this.lsvData.TabIndex = 0;
            this.lsvData.UseCompatibleStateImageBehavior = false;
            this.lsvData.View = System.Windows.Forms.View.Details;
            this.lsvData.SelectedIndexChanged += new System.EventHandler(this.lsvData_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 76;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User Type";
            this.columnHeader2.Width = 71;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Workgroup";
            this.columnHeader3.Width = 116;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Account Holder";
            this.columnHeader5.Width = 212;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Contact Number";
            this.columnHeader6.Width = 106;
            // 
            // grbDetails
            // 
            this.grbDetails.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.grbDetails.Controls.Add(this.txtLastName);
            this.grbDetails.Controls.Add(this.txtMiddleInitial);
            this.grbDetails.Controls.Add(this.txtFirstName);
            this.grbDetails.Controls.Add(this.txtContactNumber);
            this.grbDetails.Controls.Add(this.label8);
            this.grbDetails.Controls.Add(this.label7);
            this.grbDetails.Controls.Add(this.label6);
            this.grbDetails.Controls.Add(this.label5);
            this.grbDetails.Controls.Add(this.btnClose);
            this.grbDetails.Controls.Add(this.btnEdit);
            this.grbDetails.Controls.Add(this.btnAdd);
            this.grbDetails.Controls.Add(this.cboStatus);
            this.grbDetails.Controls.Add(this.label4);
            this.grbDetails.Controls.Add(this.cboWorkgroup);
            this.grbDetails.Controls.Add(this.label3);
            this.grbDetails.Controls.Add(this.label2);
            this.grbDetails.Controls.Add(this.cboUserType);
            this.grbDetails.Controls.Add(this.txtUsername);
            this.grbDetails.Controls.Add(this.label1);
            this.grbDetails.Location = new System.Drawing.Point(712, 55);
            this.grbDetails.Name = "grbDetails";
            this.grbDetails.Size = new System.Drawing.Size(313, 292);
            this.grbDetails.TabIndex = 1;
            this.grbDetails.TabStop = false;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(124, 197);
            this.txtLastName.MaxLength = 30;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(183, 23);
            this.txtLastName.TabIndex = 6;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastName_KeyPress);
            // 
            // txtMiddleInitial
            // 
            this.txtMiddleInitial.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleInitial.Location = new System.Drawing.Point(124, 168);
            this.txtMiddleInitial.MaxLength = 5;
            this.txtMiddleInitial.Name = "txtMiddleInitial";
            this.txtMiddleInitial.ReadOnly = true;
            this.txtMiddleInitial.Size = new System.Drawing.Size(54, 23);
            this.txtMiddleInitial.TabIndex = 5;
            this.txtMiddleInitial.TextChanged += new System.EventHandler(this.txtMiddleInitial_TextChanged);
            this.txtMiddleInitial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMiddleInitial_KeyPress);
            this.txtMiddleInitial.Leave += new System.EventHandler(this.txtMiddleInitial_Leave);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(124, 137);
            this.txtFirstName.MaxLength = 30;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(183, 23);
            this.txtFirstName.TabIndex = 4;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstName_KeyPress);
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNumber.Location = new System.Drawing.Point(124, 226);
            this.txtContactNumber.MaxLength = 11;
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.ReadOnly = true;
            this.txtContactNumber.Size = new System.Drawing.Size(183, 23);
            this.txtContactNumber.TabIndex = 7;
            this.txtContactNumber.TextChanged += new System.EventHandler(this.txtContactNumber_TextChanged);
            this.txtContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContactNumber_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(6, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Contact Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(6, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Last Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(6, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Middle Initial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(6, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "First Name";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(219, 264);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(121, 264);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(23, 264);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStatus.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Enabled = false;
            this.cboStatus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "activated",
            "deactivated"});
            this.cboStatus.Location = new System.Drawing.Point(124, 106);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(183, 23);
            this.cboStatus.TabIndex = 3;
            this.cboStatus.TextChanged += new System.EventHandler(this.cboStatus_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Status";
            // 
            // cboWorkgroup
            // 
            this.cboWorkgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWorkgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWorkgroup.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cboWorkgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkgroup.Enabled = false;
            this.cboWorkgroup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWorkgroup.FormattingEnabled = true;
            this.cboWorkgroup.Location = new System.Drawing.Point(124, 77);
            this.cboWorkgroup.Name = "cboWorkgroup";
            this.cboWorkgroup.Size = new System.Drawing.Size(183, 23);
            this.cboWorkgroup.TabIndex = 2;
            this.cboWorkgroup.TextChanged += new System.EventHandler(this.cboWorkgroup_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Workgroup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "User Type";
            // 
            // cboUserType
            // 
            this.cboUserType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUserType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUserType.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserType.Enabled = false;
            this.cboUserType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUserType.FormattingEnabled = true;
            this.cboUserType.Items.AddRange(new object[] {
            "user",
            "admin"});
            this.cboUserType.Location = new System.Drawing.Point(124, 48);
            this.cboUserType.Name = "cboUserType";
            this.cboUserType.Size = new System.Drawing.Size(183, 23);
            this.cboUserType.TabIndex = 1;
            this.cboUserType.TextChanged += new System.EventHandler(this.cboUserType_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(124, 19);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(183, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Password";
            // 
            // grbPassword
            // 
            this.grbPassword.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.grbPassword.Controls.Add(this.txtRecovery);
            this.grbPassword.Controls.Add(this.chkViewRecovery);
            this.grbPassword.Controls.Add(this.btnRecovery);
            this.grbPassword.Controls.Add(this.label9);
            this.grbPassword.Enabled = false;
            this.grbPassword.Location = new System.Drawing.Point(712, 351);
            this.grbPassword.Name = "grbPassword";
            this.grbPassword.Size = new System.Drawing.Size(313, 100);
            this.grbPassword.TabIndex = 25;
            this.grbPassword.TabStop = false;
            // 
            // txtRecovery
            // 
            this.txtRecovery.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecovery.Location = new System.Drawing.Point(9, 53);
            this.txtRecovery.Name = "txtRecovery";
            this.txtRecovery.PasswordChar = '*';
            this.txtRecovery.ReadOnly = true;
            this.txtRecovery.Size = new System.Drawing.Size(183, 23);
            this.txtRecovery.TabIndex = 12;
            this.txtRecovery.Text = "00000000";
            // 
            // chkViewRecovery
            // 
            this.chkViewRecovery.AutoSize = true;
            this.chkViewRecovery.ForeColor = System.Drawing.Color.Maroon;
            this.chkViewRecovery.Location = new System.Drawing.Point(194, 56);
            this.chkViewRecovery.Name = "chkViewRecovery";
            this.chkViewRecovery.Size = new System.Drawing.Size(119, 17);
            this.chkViewRecovery.TabIndex = 13;
            this.chkViewRecovery.Text = "View Recovery Key";
            this.chkViewRecovery.UseVisualStyleBackColor = true;
            this.chkViewRecovery.CheckedChanged += new System.EventHandler(this.chkViewRecovery_CheckedChanged);
            // 
            // btnRecovery
            // 
            this.btnRecovery.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecovery.Location = new System.Drawing.Point(95, 19);
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Size = new System.Drawing.Size(212, 23);
            this.btnRecovery.TabIndex = 11;
            this.btnRecovery.Text = "Provide Recovery Key";
            this.btnRecovery.UseVisualStyleBackColor = true;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(6, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Search by:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(314, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 15);
            this.label11.TabIndex = 29;
            this.label11.Text = "Search for:";
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
            "Username",
            "Workgroup"});
            this.cboSearchType.Location = new System.Drawing.Point(102, 15);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(206, 23);
            this.cboSearchType.TabIndex = 27;
            this.cboSearchType.SelectedIndexChanged += new System.EventHandler(this.cboSearchType_SelectedIndexChanged);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(25, 15);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(253, 23);
            this.lblCount.TabIndex = 30;
            this.lblCount.Text = "Temp";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearch.Enabled = false;
            this.txtSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(399, 15);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(190, 23);
            this.txtSearch.TabIndex = 31;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(202, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 15);
            this.label12.TabIndex = 38;
            this.label12.Text = "Total";
            // 
            // txtTotalRow
            // 
            this.txtTotalRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRow.Location = new System.Drawing.Point(248, 10);
            this.txtTotalRow.MaxLength = 5;
            this.txtTotalRow.Name = "txtTotalRow";
            this.txtTotalRow.ReadOnly = true;
            this.txtTotalRow.Size = new System.Drawing.Size(57, 23);
            this.txtTotalRow.TabIndex = 37;
            // 
            // btnLess
            // 
            this.btnLess.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnLess.Enabled = false;
            this.btnLess.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLess.Location = new System.Drawing.Point(6, 10);
            this.btnLess.Name = "btnLess";
            this.btnLess.Size = new System.Drawing.Size(23, 23);
            this.btnLess.TabIndex = 36;
            this.btnLess.Text = "<";
            this.btnLess.UseVisualStyleBackColor = false;
            this.btnLess.Click += new System.EventHandler(this.btnLess_Click);
            // 
            // btnMore
            // 
            this.btnMore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.Location = new System.Drawing.Point(178, 10);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(23, 23);
            this.btnMore.TabIndex = 35;
            this.btnMore.Text = ">";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(498, 430);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 15);
            this.label13.TabIndex = 34;
            this.label13.Text = "-";
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRow.Location = new System.Drawing.Point(115, 10);
            this.txtRow.MaxLength = 5;
            this.txtRow.Name = "txtRow";
            this.txtRow.ReadOnly = true;
            this.txtRow.Size = new System.Drawing.Size(57, 23);
            this.txtRow.TabIndex = 33;
            // 
            // txtShowRow
            // 
            this.txtShowRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShowRow.Location = new System.Drawing.Point(35, 10);
            this.txtShowRow.MaxLength = 5;
            this.txtShowRow.Name = "txtShowRow";
            this.txtShowRow.ReadOnly = true;
            this.txtShowRow.Size = new System.Drawing.Size(57, 23);
            this.txtShowRow.TabIndex = 32;
            this.txtShowRow.Text = "0";
            this.txtShowRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbSearch
            // 
            this.grbSearch.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.grbSearch.Controls.Add(this.btnSearch);
            this.grbSearch.Controls.Add(this.lblWorkgroup_);
            this.grbSearch.Controls.Add(this.lblDatabase_);
            this.grbSearch.Controls.Add(this.lblUsername_);
            this.grbSearch.Controls.Add(this.label10);
            this.grbSearch.Controls.Add(this.cboSearchType);
            this.grbSearch.Controls.Add(this.label11);
            this.grbSearch.Controls.Add(this.txtSearch);
            this.grbSearch.Location = new System.Drawing.Point(14, 4);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(1012, 45);
            this.grbSearch.TabIndex = 39;
            this.grbSearch.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(595, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 23);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblWorkgroup_
            // 
            this.lblWorkgroup_.AutoSize = true;
            this.lblWorkgroup_.Location = new System.Drawing.Point(864, 0);
            this.lblWorkgroup_.Name = "lblWorkgroup_";
            this.lblWorkgroup_.Size = new System.Drawing.Size(30, 13);
            this.lblWorkgroup_.TabIndex = 40;
            this.lblWorkgroup_.Text = "temp";
            this.lblWorkgroup_.Visible = false;
            // 
            // lblDatabase_
            // 
            this.lblDatabase_.AutoSize = true;
            this.lblDatabase_.Location = new System.Drawing.Point(898, 0);
            this.lblDatabase_.Name = "lblDatabase_";
            this.lblDatabase_.Size = new System.Drawing.Size(30, 13);
            this.lblDatabase_.TabIndex = 40;
            this.lblDatabase_.Text = "temp";
            this.lblDatabase_.Visible = false;
            // 
            // lblUsername_
            // 
            this.lblUsername_.AutoSize = true;
            this.lblUsername_.Location = new System.Drawing.Point(970, 0);
            this.lblUsername_.Name = "lblUsername_";
            this.lblUsername_.Size = new System.Drawing.Size(30, 13);
            this.lblUsername_.TabIndex = 25;
            this.lblUsername_.Text = "temp";
            this.lblUsername_.Visible = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(14, 428);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(117, 23);
            this.btnLogout.TabIndex = 40;
            this.btnLogout.Text = "Force Log-out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Visible = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.Maroon;
            this.lblLogout.Location = new System.Drawing.Point(137, 432);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(119, 15);
            this.lblLogout.TabIndex = 42;
            this.lblLogout.Text = "Admin Password:";
            this.lblLogout.Visible = false;
            // 
            // txtLogout
            // 
            this.txtLogout.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogout.Location = new System.Drawing.Point(259, 428);
            this.txtLogout.MaxLength = 20;
            this.txtLogout.Name = "txtLogout";
            this.txtLogout.PasswordChar = '*';
            this.txtLogout.Size = new System.Drawing.Size(137, 23);
            this.txtLogout.TabIndex = 43;
            this.txtLogout.Visible = false;
            this.txtLogout.TextChanged += new System.EventHandler(this.txtLogout_TextChanged);
            this.txtLogout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLogout_KeyPress);
            // 
            // grbScroll
            // 
            this.grbScroll.Controls.Add(this.btnMore);
            this.grbScroll.Controls.Add(this.txtShowRow);
            this.grbScroll.Controls.Add(this.txtRow);
            this.grbScroll.Controls.Add(this.btnLess);
            this.grbScroll.Controls.Add(this.txtTotalRow);
            this.grbScroll.Controls.Add(this.label12);
            this.grbScroll.Location = new System.Drawing.Point(402, 422);
            this.grbScroll.Name = "grbScroll";
            this.grbScroll.Size = new System.Drawing.Size(311, 37);
            this.grbScroll.TabIndex = 44;
            this.grbScroll.TabStop = false;
            // 
            // frmAdminMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1037, 462);
            this.Controls.Add(this.grbScroll);
            this.Controls.Add(this.txtLogout);
            this.Controls.Add(this.lblLogout);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.grbSearch);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.grbPassword);
            this.Controls.Add(this.grbDetails);
            this.Controls.Add(this.lsvData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdminMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Maintenance (Admin Mode)";
            this.Load += new System.EventHandler(this.frmAdminMaintenance_Load);
            this.grbDetails.ResumeLayout(false);
            this.grbDetails.PerformLayout();
            this.grbPassword.ResumeLayout(false);
            this.grbPassword.PerformLayout();
            this.grbSearch.ResumeLayout(false);
            this.grbSearch.PerformLayout();
            this.grbScroll.ResumeLayout(false);
            this.grbScroll.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox grbDetails;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboWorkgroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUserType;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grbPassword;
        private System.Windows.Forms.TextBox txtRecovery;
        private System.Windows.Forms.CheckBox chkViewRecovery;
        private System.Windows.Forms.Button btnRecovery;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalRow;
        private System.Windows.Forms.Button btnLess;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.TextBox txtShowRow;
        private System.Windows.Forms.GroupBox grbSearch;
        public System.Windows.Forms.Label lblWorkgroup_;
        public System.Windows.Forms.Label lblDatabase_;
        private System.Windows.Forms.Label lblUsername_;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.TextBox txtLogout;
        private System.Windows.Forms.GroupBox grbScroll;
    }
}