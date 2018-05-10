namespace PLDT_TMS
{
    partial class frmEndorseTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEndorseTickets));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboWorkgroup = new System.Windows.Forms.ComboBox();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboEndorsee = new System.Windows.Forms.ComboBox();
            this.radPerson = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radShift = new System.Windows.Forms.RadioButton();
            this.dtpEndorsedDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFromWorkgroup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTicketNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndorser = new System.Windows.Forms.TextBox();
            this.lblWorkgroup_ = new System.Windows.Forms.Label();
            this.lblUsername_ = new System.Windows.Forms.Label();
            this.lblDatabase_ = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 406);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOK);
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Location = new System.Drawing.Point(432, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 111);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(35, 17);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(98, 37);
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(35, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 37);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAdmin);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cboWorkgroup);
            this.groupBox3.Controls.Add(this.txtNote);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboEndorsee);
            this.groupBox3.Controls.Add(this.radPerson);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.radShift);
            this.groupBox3.Controls.Add(this.dtpEndorsedDate);
            this.groupBox3.Location = new System.Drawing.Point(6, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(591, 254);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(358, 74);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(74, 19);
            this.chkAdmin.TabIndex = 38;
            this.chkAdmin.Text = "Admin?";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(28, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 37;
            this.label6.Text = "Endorsee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Endorsement Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Endorsed to";
            // 
            // cboWorkgroup
            // 
            this.cboWorkgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkgroup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWorkgroup.FormattingEnabled = true;
            this.cboWorkgroup.Location = new System.Drawing.Point(154, 70);
            this.cboWorkgroup.Name = "cboWorkgroup";
            this.cboWorkgroup.Size = new System.Drawing.Size(195, 23);
            this.cboWorkgroup.TabIndex = 36;
            this.cboWorkgroup.SelectedIndexChanged += new System.EventHandler(this.cboWorkgroup_SelectedIndexChanged);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(154, 157);
            this.txtNote.MaxLength = 200;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(380, 80);
            this.txtNote.TabIndex = 10;
            this.txtNote.Text = "";
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(6, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Endorsement Details";
            // 
            // cboEndorsee
            // 
            this.cboEndorsee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndorsee.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEndorsee.FormattingEnabled = true;
            this.cboEndorsee.Location = new System.Drawing.Point(154, 124);
            this.cboEndorsee.Name = "cboEndorsee";
            this.cboEndorsee.Size = new System.Drawing.Size(298, 23);
            this.cboEndorsee.TabIndex = 27;
            this.cboEndorsee.SelectedIndexChanged += new System.EventHandler(this.cboEndorsee_SelectedIndexChanged);
            // 
            // radPerson
            // 
            this.radPerson.AutoSize = true;
            this.radPerson.Location = new System.Drawing.Point(278, 99);
            this.radPerson.Name = "radPerson";
            this.radPerson.Size = new System.Drawing.Size(71, 19);
            this.radPerson.TabIndex = 31;
            this.radPerson.TabStop = true;
            this.radPerson.Text = "Person";
            this.radPerson.UseVisualStyleBackColor = true;
            this.radPerson.CheckedChanged += new System.EventHandler(this.radPerson_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(28, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 35;
            this.label2.Text = "Workgroup";
            // 
            // radShift
            // 
            this.radShift.AutoSize = true;
            this.radShift.Checked = true;
            this.radShift.Location = new System.Drawing.Point(154, 99);
            this.radShift.Name = "radShift";
            this.radShift.Size = new System.Drawing.Size(55, 19);
            this.radShift.TabIndex = 32;
            this.radShift.TabStop = true;
            this.radShift.Text = "Shift";
            this.radShift.UseVisualStyleBackColor = true;
            this.radShift.CheckedChanged += new System.EventHandler(this.radShift_CheckedChanged);
            // 
            // dtpEndorsedDate
            // 
            this.dtpEndorsedDate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndorsedDate.Location = new System.Drawing.Point(154, 13);
            this.dtpEndorsedDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpEndorsedDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpEndorsedDate.Name = "dtpEndorsedDate";
            this.dtpEndorsedDate.Size = new System.Drawing.Size(251, 23);
            this.dtpEndorsedDate.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFromWorkgroup);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTicketNumber);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtEndorser);
            this.groupBox2.Location = new System.Drawing.Point(6, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 111);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // txtFromWorkgroup
            // 
            this.txtFromWorkgroup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromWorkgroup.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtFromWorkgroup.Location = new System.Drawing.Point(154, 75);
            this.txtFromWorkgroup.MaxLength = 8;
            this.txtFromWorkgroup.Name = "txtFromWorkgroup";
            this.txtFromWorkgroup.ReadOnly = true;
            this.txtFromWorkgroup.Size = new System.Drawing.Size(251, 23);
            this.txtFromWorkgroup.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(15, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ticket Number";
            // 
            // txtTicketNumber
            // 
            this.txtTicketNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTicketNumber.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTicketNumber.Location = new System.Drawing.Point(154, 17);
            this.txtTicketNumber.MaxLength = 8;
            this.txtTicketNumber.Name = "txtTicketNumber";
            this.txtTicketNumber.ReadOnly = true;
            this.txtTicketNumber.Size = new System.Drawing.Size(130, 23);
            this.txtTicketNumber.TabIndex = 3;
            this.txtTicketNumber.TextChanged += new System.EventHandler(this.txtTicketNumber_TextChanged);
            this.txtTicketNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTicketNumber_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(15, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Endorser";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(15, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Workgroup";
            // 
            // txtEndorser
            // 
            this.txtEndorser.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndorser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtEndorser.Location = new System.Drawing.Point(154, 46);
            this.txtEndorser.MaxLength = 8;
            this.txtEndorser.Name = "txtEndorser";
            this.txtEndorser.ReadOnly = true;
            this.txtEndorser.Size = new System.Drawing.Size(251, 23);
            this.txtEndorser.TabIndex = 28;
            // 
            // lblWorkgroup_
            // 
            this.lblWorkgroup_.AutoSize = true;
            this.lblWorkgroup_.Location = new System.Drawing.Point(520, -4);
            this.lblWorkgroup_.Name = "lblWorkgroup_";
            this.lblWorkgroup_.Size = new System.Drawing.Size(35, 13);
            this.lblWorkgroup_.TabIndex = 6;
            this.lblWorkgroup_.Text = "label1";
            this.lblWorkgroup_.Visible = false;
            // 
            // lblUsername_
            // 
            this.lblUsername_.AutoSize = true;
            this.lblUsername_.Location = new System.Drawing.Point(479, -4);
            this.lblUsername_.Name = "lblUsername_";
            this.lblUsername_.Size = new System.Drawing.Size(35, 13);
            this.lblUsername_.TabIndex = 7;
            this.lblUsername_.Text = "label2";
            this.lblUsername_.Visible = false;
            // 
            // lblDatabase_
            // 
            this.lblDatabase_.AutoSize = true;
            this.lblDatabase_.Location = new System.Drawing.Point(432, -4);
            this.lblDatabase_.Name = "lblDatabase_";
            this.lblDatabase_.Size = new System.Drawing.Size(41, 13);
            this.lblDatabase_.TabIndex = 8;
            this.lblDatabase_.Text = "label11";
            this.lblDatabase_.Visible = false;
            // 
            // frmEndorseTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(630, 430);
            this.Controls.Add(this.lblDatabase_);
            this.Controls.Add(this.lblUsername_);
            this.Controls.Add(this.lblWorkgroup_);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEndorseTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Endorse Ticket";
            this.Load += new System.EventHandler(this.fmrEndorseTickets_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblWorkgroup_;
        private System.Windows.Forms.Label lblUsername_;
        private System.Windows.Forms.Label lblDatabase_;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtEndorser;
        private System.Windows.Forms.ComboBox cboEndorsee;
        private System.Windows.Forms.DateTimePicker dtpEndorsedDate;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTicketNumber;
        private System.Windows.Forms.RadioButton radShift;
        private System.Windows.Forms.RadioButton radPerson;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFromWorkgroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboWorkgroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAdmin;
    }
}