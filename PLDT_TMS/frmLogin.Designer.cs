namespace PLDT_TMS
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboWorkgroup = new System.Windows.Forms.ComboBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.timDelay = new System.Windows.Forms.Timer(this.components);
            this.lblRecover = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.grbMain = new System.Windows.Forms.GroupBox();
            this.grbDatabase = new System.Windows.Forms.GroupBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grbMain.SuspendLayout();
            this.grbDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnEnter.Enabled = false;
            this.btnEnter.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(10, 327);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 6;
            this.btnEnter.Text = "Log in";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(104, 327);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(128, 13);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(167, 26);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.WordWrap = false;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(128, 45);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "USERNAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "PASSWORD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "WORKGROUP";
            // 
            // cboWorkgroup
            // 
            this.cboWorkgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWorkgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWorkgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkgroup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWorkgroup.Location = new System.Drawing.Point(128, 100);
            this.cboWorkgroup.Name = "cboWorkgroup";
            this.cboWorkgroup.Size = new System.Drawing.Size(165, 26);
            this.cboWorkgroup.TabIndex = 5;
            this.cboWorkgroup.SelectedIndexChanged += new System.EventHandler(this.cboWorkgroup_SelectedIndexChanged);
            this.cboWorkgroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboWorkgroup_KeyPress);
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.BackColor = System.Drawing.Color.Transparent;
            this.chkAdmin.ForeColor = System.Drawing.Color.Maroon;
            this.chkAdmin.Location = new System.Drawing.Point(128, 77);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(61, 17);
            this.chkAdmin.TabIndex = 4;
            this.chkAdmin.Text = "Admin?";
            this.chkAdmin.UseVisualStyleBackColor = false;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // timDelay
            // 
            this.timDelay.Enabled = true;
            this.timDelay.Interval = 1000;
            this.timDelay.Tick += new System.EventHandler(this.timDelay_Tick);
            // 
            // lblRecover
            // 
            this.lblRecover.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lblRecover.AutoSize = true;
            this.lblRecover.BackColor = System.Drawing.Color.LightGray;
            this.lblRecover.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecover.Location = new System.Drawing.Point(197, 333);
            this.lblRecover.Name = "lblRecover";
            this.lblRecover.Size = new System.Drawing.Size(108, 12);
            this.lblRecover.TabIndex = 8;
            this.lblRecover.TabStop = true;
            this.lblRecover.Text = "Recover Account?";
            this.lblRecover.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblRecover.Click += new System.EventHandler(this.lblRecover_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "DATABASE";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.Location = new System.Drawing.Point(117, 13);
            this.txtDatabase.MaxLength = 7;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(95, 26);
            this.txtDatabase.TabIndex = 0;
            this.txtDatabase.WordWrap = false;
            this.txtDatabase.TextChanged += new System.EventHandler(this.txtDatabase_TextChanged);
            this.txtDatabase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatabase_KeyPress);
            // 
            // grbMain
            // 
            this.grbMain.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.grbMain.Controls.Add(this.label1);
            this.grbMain.Controls.Add(this.txtUsername);
            this.grbMain.Controls.Add(this.txtPassword);
            this.grbMain.Controls.Add(this.label2);
            this.grbMain.Controls.Add(this.chkAdmin);
            this.grbMain.Controls.Add(this.label3);
            this.grbMain.Controls.Add(this.cboWorkgroup);
            this.grbMain.Enabled = false;
            this.grbMain.Location = new System.Drawing.Point(10, 179);
            this.grbMain.Name = "grbMain";
            this.grbMain.Size = new System.Drawing.Size(312, 138);
            this.grbMain.TabIndex = 13;
            this.grbMain.TabStop = false;
            // 
            // grbDatabase
            // 
            this.grbDatabase.BackColor = System.Drawing.Color.LightGray;
            this.grbDatabase.Controls.Add(this.btnVerify);
            this.grbDatabase.Controls.Add(this.label4);
            this.grbDatabase.Controls.Add(this.txtDatabase);
            this.grbDatabase.Location = new System.Drawing.Point(10, 126);
            this.grbDatabase.Name = "grbDatabase";
            this.grbDatabase.Size = new System.Drawing.Size(312, 47);
            this.grbDatabase.TabIndex = 14;
            this.grbDatabase.TabStop = false;
            // 
            // btnVerify
            // 
            this.btnVerify.Enabled = false;
            this.btnVerify.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.Location = new System.Drawing.Point(218, 15);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(10, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 107);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.grbDatabase);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.grbMain);
            this.groupBox1.Controls.Add(this.btnEnter);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.lblRecover);
            this.groupBox1.Location = new System.Drawing.Point(24, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 358);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(334, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "v. 1.2.0";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnVerify;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(383, 394);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.grbMain.ResumeLayout(false);
            this.grbMain.PerformLayout();
            this.grbDatabase.ResumeLayout(false);
            this.grbDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAdmin;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.ComboBox cboWorkgroup;
        private System.Windows.Forms.Timer timDelay;
        private System.Windows.Forms.LinkLabel lblRecover;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grbMain;
        private System.Windows.Forms.GroupBox grbDatabase;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
    }
}

