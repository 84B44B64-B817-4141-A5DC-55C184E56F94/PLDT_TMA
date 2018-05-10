namespace PLDT_TMS
{
    partial class frmNewTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewTicket));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radWireless = new System.Windows.Forms.RadioButton();
            this.radWired = new System.Windows.Forms.RadioButton();
            this.grbDetails = new System.Windows.Forms.GroupBox();
            this.txtTicketNumber = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFaultType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboWorkgroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPLNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateReported = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboServiceType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUsername_ = new System.Windows.Forms.Label();
            this.lblWorkgroup_ = new System.Windows.Forms.Label();
            this.lblDatabase_ = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Service Type";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.radWireless);
            this.groupBox1.Controls.Add(this.radWired);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 82);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // radWireless
            // 
            this.radWireless.AutoSize = true;
            this.radWireless.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWireless.ForeColor = System.Drawing.Color.Black;
            this.radWireless.Location = new System.Drawing.Point(256, 46);
            this.radWireless.Name = "radWireless";
            this.radWireless.Size = new System.Drawing.Size(81, 19);
            this.radWireless.TabIndex = 1;
            this.radWireless.Text = "Wireless";
            this.radWireless.UseVisualStyleBackColor = true;
            this.radWireless.CheckedChanged += new System.EventHandler(this.radWireless_CheckedChanged);
            // 
            // radWired
            // 
            this.radWired.AutoSize = true;
            this.radWired.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWired.ForeColor = System.Drawing.Color.Black;
            this.radWired.Location = new System.Drawing.Point(111, 46);
            this.radWired.Name = "radWired";
            this.radWired.Size = new System.Drawing.Size(63, 19);
            this.radWired.TabIndex = 0;
            this.radWired.Text = "Wired";
            this.radWired.UseVisualStyleBackColor = true;
            this.radWired.CheckedChanged += new System.EventHandler(this.radWired_CheckedChanged);
            // 
            // grbDetails
            // 
            this.grbDetails.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.grbDetails.Controls.Add(this.txtTicketNumber);
            this.grbDetails.Controls.Add(this.txtDescription);
            this.grbDetails.Controls.Add(this.label7);
            this.grbDetails.Controls.Add(this.cboFaultType);
            this.grbDetails.Controls.Add(this.label6);
            this.grbDetails.Controls.Add(this.cboWorkgroup);
            this.grbDetails.Controls.Add(this.label5);
            this.grbDetails.Controls.Add(this.txtPLNumber);
            this.grbDetails.Controls.Add(this.label4);
            this.grbDetails.Controls.Add(this.dtpDateReported);
            this.grbDetails.Controls.Add(this.label3);
            this.grbDetails.Controls.Add(this.label9);
            this.grbDetails.Controls.Add(this.cboServiceType);
            this.grbDetails.Controls.Add(this.label2);
            this.grbDetails.Enabled = false;
            this.grbDetails.Location = new System.Drawing.Point(12, 100);
            this.grbDetails.Name = "grbDetails";
            this.grbDetails.Size = new System.Drawing.Size(422, 308);
            this.grbDetails.TabIndex = 9;
            this.grbDetails.TabStop = false;
            // 
            // txtTicketNumber
            // 
            this.txtTicketNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTicketNumber.Location = new System.Drawing.Point(148, 45);
            this.txtTicketNumber.MaxLength = 8;
            this.txtTicketNumber.Name = "txtTicketNumber";
            this.txtTicketNumber.Size = new System.Drawing.Size(130, 23);
            this.txtTicketNumber.TabIndex = 3;
            this.txtTicketNumber.TextChanged += new System.EventHandler(this.txtTicketNumber_TextChanged);
            this.txtTicketNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTicketNumber_KeyDown);
            this.txtTicketNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTicketNumber_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(148, 192);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(259, 96);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "";
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(6, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Description";
            // 
            // cboFaultType
            // 
            this.cboFaultType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFaultType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFaultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaultType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFaultType.FormattingEnabled = true;
            this.cboFaultType.Items.AddRange(new object[] {
            "CRT ClLOUD WIRED",
            "CRT CLOUD",
            "CRT Fixed",
            "DSLE-SMP",
            "MAJ_INC",
            "PRT",
            "SVC_RQST WIRED"});
            this.cboFaultType.Location = new System.Drawing.Point(148, 162);
            this.cboFaultType.Name = "cboFaultType";
            this.cboFaultType.Size = new System.Drawing.Size(259, 23);
            this.cboFaultType.Sorted = true;
            this.cboFaultType.TabIndex = 7;
            this.cboFaultType.TextChanged += new System.EventHandler(this.cboFaultType_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(7, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fault Type";
            // 
            // cboWorkgroup
            // 
            this.cboWorkgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWorkgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWorkgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkgroup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWorkgroup.FormattingEnabled = true;
            this.cboWorkgroup.Location = new System.Drawing.Point(148, 133);
            this.cboWorkgroup.Name = "cboWorkgroup";
            this.cboWorkgroup.Size = new System.Drawing.Size(259, 23);
            this.cboWorkgroup.Sorted = true;
            this.cboWorkgroup.TabIndex = 6;
            this.cboWorkgroup.TextChanged += new System.EventHandler(this.cboWorkgroup_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(7, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Workgroup";
            // 
            // txtPLNumber
            // 
            this.txtPLNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPLNumber.Location = new System.Drawing.Point(148, 104);
            this.txtPLNumber.MaxLength = 30;
            this.txtPLNumber.Name = "txtPLNumber";
            this.txtPLNumber.Size = new System.Drawing.Size(259, 23);
            this.txtPLNumber.TabIndex = 5;
            this.txtPLNumber.TextChanged += new System.EventHandler(this.txtPLNumber_TextChanged);
            this.txtPLNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPLNumber_KeyDown);
            this.txtPLNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPLNumber_KeyPress);
            this.txtPLNumber.Leave += new System.EventHandler(this.txtPLNumber_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "PL Number";
            // 
            // dtpDateReported
            // 
            this.dtpDateReported.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateReported.Location = new System.Drawing.Point(148, 75);
            this.dtpDateReported.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpDateReported.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDateReported.Name = "dtpDateReported";
            this.dtpDateReported.Size = new System.Drawing.Size(259, 23);
            this.dtpDateReported.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date Reported";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(7, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Ticket Number";
            // 
            // cboServiceType
            // 
            this.cboServiceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboServiceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServiceType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServiceType.FormattingEnabled = true;
            this.cboServiceType.Items.AddRange(new object[] {
            "ADSL",
            "BRAINS DOMESTIC",
            "BRAINS IPVPN LL",
            "CLOUD SAAS",
            "CLOUD VIDEO MONITORING",
            "DID",
            "DIGINET",
            "FEXLINE",
            "I-GATE",
            "I-GATE LITE",
            "ISDN",
            "METRO E-LAN",
            "METRO E-WAN",
            "METRO ELINE",
            "PLDT WATCHER-WIRED",
            "SHOPS.WORK DSL",
            "SIP TRUNKS"});
            this.cboServiceType.Location = new System.Drawing.Point(148, 16);
            this.cboServiceType.Name = "cboServiceType";
            this.cboServiceType.Size = new System.Drawing.Size(189, 23);
            this.cboServiceType.Sorted = true;
            this.cboServiceType.TabIndex = 2;
            this.cboServiceType.TextChanged += new System.EventHandler(this.cboServiceType_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(123, 414);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 40);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(274, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 40);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUsername_
            // 
            this.lblUsername_.AutoSize = true;
            this.lblUsername_.Location = new System.Drawing.Point(393, -4);
            this.lblUsername_.Name = "lblUsername_";
            this.lblUsername_.Size = new System.Drawing.Size(30, 13);
            this.lblUsername_.TabIndex = 16;
            this.lblUsername_.Text = "temp";
            this.lblUsername_.Visible = false;
            // 
            // lblWorkgroup_
            // 
            this.lblWorkgroup_.AutoSize = true;
            this.lblWorkgroup_.Location = new System.Drawing.Point(357, -4);
            this.lblWorkgroup_.Name = "lblWorkgroup_";
            this.lblWorkgroup_.Size = new System.Drawing.Size(30, 13);
            this.lblWorkgroup_.TabIndex = 17;
            this.lblWorkgroup_.Text = "temp";
            this.lblWorkgroup_.Visible = false;
            // 
            // lblDatabase_
            // 
            this.lblDatabase_.AutoSize = true;
            this.lblDatabase_.Location = new System.Drawing.Point(321, -4);
            this.lblDatabase_.Name = "lblDatabase_";
            this.lblDatabase_.Size = new System.Drawing.Size(30, 13);
            this.lblDatabase_.TabIndex = 18;
            this.lblDatabase_.Text = "temp";
            this.lblDatabase_.Visible = false;
            // 
            // frmNewTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(455, 465);
            this.Controls.Add(this.lblDatabase_);
            this.Controls.Add(this.lblWorkgroup_);
            this.Controls.Add(this.lblUsername_);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grbDetails);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Ticket";
            this.Load += new System.EventHandler(this.frmNewTicket_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbDetails.ResumeLayout(false);
            this.grbDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radWireless;
        private System.Windows.Forms.RadioButton radWired;
        private System.Windows.Forms.GroupBox grbDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboServiceType;
        private System.Windows.Forms.DateTimePicker dtpDateReported;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWorkgroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPLNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFaultType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTicketNumber;
        private System.Windows.Forms.Label lblUsername_;
        private System.Windows.Forms.Label lblWorkgroup_;
        private System.Windows.Forms.Label lblDatabase_;
    }
}