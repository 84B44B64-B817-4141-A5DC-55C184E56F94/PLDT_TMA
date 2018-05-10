namespace PLDT_TMS
{
    partial class frmRecoverAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecoverAccount));
            this.label1 = new System.Windows.Forms.Label();
            this.grbUsername = new System.Windows.Forms.GroupBox();
            this.cboWorkgroup = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVerifyAccount = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grbPassword = new System.Windows.Forms.GroupBox();
            this.cboData = new System.Windows.Forms.ComboBox();
            this.btnRecover = new System.Windows.Forms.Button();
            this.txtRecoveryKey = new System.Windows.Forms.TextBox();
            this.txtVerifyPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grbDatabase = new System.Windows.Forms.GroupBox();
            this.btnVerifyDatabase = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRecoverAccount = new System.Windows.Forms.TabPage();
            this.tabReset = new System.Windows.Forms.TabPage();
            this.grbDatabaseReset = new System.Windows.Forms.GroupBox();
            this.btnVerifyReset = new System.Windows.Forms.Button();
            this.txtDatabaseReset = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grbAccountReset = new System.Windows.Forms.GroupBox();
            this.txtPasswordReset = new System.Windows.Forms.TextBox();
            this.txtUsernameReset = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnResetProgram = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.grbUsername.SuspendLayout();
            this.grbPassword.SuspendLayout();
            this.grbDatabase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRecoverAccount.SuspendLayout();
            this.tabReset.SuspendLayout();
            this.grbDatabaseReset.SuspendLayout();
            this.grbAccountReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // grbUsername
            // 
            this.grbUsername.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.grbUsername.Controls.Add(this.cboWorkgroup);
            this.grbUsername.Controls.Add(this.txtUsername);
            this.grbUsername.Controls.Add(this.label5);
            this.grbUsername.Controls.Add(this.btnVerifyAccount);
            this.grbUsername.Controls.Add(this.label1);
            this.grbUsername.Enabled = false;
            this.grbUsername.Location = new System.Drawing.Point(6, 88);
            this.grbUsername.Name = "grbUsername";
            this.grbUsername.Size = new System.Drawing.Size(334, 105);
            this.grbUsername.TabIndex = 1;
            this.grbUsername.TabStop = false;
            // 
            // cboWorkgroup
            // 
            this.cboWorkgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWorkgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWorkgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkgroup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWorkgroup.FormattingEnabled = true;
            this.cboWorkgroup.Location = new System.Drawing.Point(131, 43);
            this.cboWorkgroup.Name = "cboWorkgroup";
            this.cboWorkgroup.Size = new System.Drawing.Size(186, 23);
            this.cboWorkgroup.TabIndex = 3;
            this.cboWorkgroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboWorkgroup_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(131, 14);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(129, 23);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Workgroup";
            // 
            // btnVerifyAccount
            // 
            this.btnVerifyAccount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifyAccount.Location = new System.Drawing.Point(131, 72);
            this.btnVerifyAccount.Name = "btnVerifyAccount";
            this.btnVerifyAccount.Size = new System.Drawing.Size(186, 23);
            this.btnVerifyAccount.TabIndex = 4;
            this.btnVerifyAccount.Text = "Verify Account";
            this.btnVerifyAccount.UseVisualStyleBackColor = true;
            this.btnVerifyAccount.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Verify Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Password";
            // 
            // grbPassword
            // 
            this.grbPassword.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.grbPassword.Controls.Add(this.cboData);
            this.grbPassword.Controls.Add(this.btnRecover);
            this.grbPassword.Controls.Add(this.txtRecoveryKey);
            this.grbPassword.Controls.Add(this.txtVerifyPassword);
            this.grbPassword.Controls.Add(this.txtNewPassword);
            this.grbPassword.Controls.Add(this.label4);
            this.grbPassword.Controls.Add(this.label3);
            this.grbPassword.Controls.Add(this.label2);
            this.grbPassword.Enabled = false;
            this.grbPassword.Location = new System.Drawing.Point(6, 199);
            this.grbPassword.Name = "grbPassword";
            this.grbPassword.Size = new System.Drawing.Size(334, 141);
            this.grbPassword.TabIndex = 5;
            this.grbPassword.TabStop = false;
            // 
            // cboData
            // 
            this.cboData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboData.FormattingEnabled = true;
            this.cboData.Location = new System.Drawing.Point(6, 114);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(121, 21);
            this.cboData.TabIndex = 10;
            this.cboData.Visible = false;
            // 
            // btnRecover
            // 
            this.btnRecover.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecover.Location = new System.Drawing.Point(131, 100);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(186, 23);
            this.btnRecover.TabIndex = 8;
            this.btnRecover.Text = "Recover Account";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // txtRecoveryKey
            // 
            this.txtRecoveryKey.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecoveryKey.Location = new System.Drawing.Point(131, 71);
            this.txtRecoveryKey.MaxLength = 8;
            this.txtRecoveryKey.Name = "txtRecoveryKey";
            this.txtRecoveryKey.Size = new System.Drawing.Size(186, 23);
            this.txtRecoveryKey.TabIndex = 7;
            this.txtRecoveryKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecoveryKey_KeyPress);
            // 
            // txtVerifyPassword
            // 
            this.txtVerifyPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerifyPassword.Location = new System.Drawing.Point(131, 42);
            this.txtVerifyPassword.MaxLength = 20;
            this.txtVerifyPassword.Name = "txtVerifyPassword";
            this.txtVerifyPassword.PasswordChar = '*';
            this.txtVerifyPassword.Size = new System.Drawing.Size(186, 23);
            this.txtVerifyPassword.TabIndex = 6;
            this.txtVerifyPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVerifyPassword_KeyPress);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Location = new System.Drawing.Point(131, 13);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(186, 23);
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPassword_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Recovery Key";
            // 
            // grbDatabase
            // 
            this.grbDatabase.BackColor = System.Drawing.Color.LightGray;
            this.grbDatabase.Controls.Add(this.btnVerifyDatabase);
            this.grbDatabase.Controls.Add(this.txtDatabase);
            this.grbDatabase.Controls.Add(this.label6);
            this.grbDatabase.Location = new System.Drawing.Point(6, 6);
            this.grbDatabase.Name = "grbDatabase";
            this.grbDatabase.Size = new System.Drawing.Size(334, 76);
            this.grbDatabase.TabIndex = 6;
            this.grbDatabase.TabStop = false;
            // 
            // btnVerifyDatabase
            // 
            this.btnVerifyDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVerifyDatabase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifyDatabase.Location = new System.Drawing.Point(131, 42);
            this.btnVerifyDatabase.Name = "btnVerifyDatabase";
            this.btnVerifyDatabase.Size = new System.Drawing.Size(186, 23);
            this.btnVerifyDatabase.TabIndex = 1;
            this.btnVerifyDatabase.Text = "Verify Database";
            this.btnVerifyDatabase.UseVisualStyleBackColor = true;
            this.btnVerifyDatabase.Click += new System.EventHandler(this.btnVerifyDatabase_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.Location = new System.Drawing.Point(131, 13);
            this.txtDatabase.MaxLength = 7;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(129, 23);
            this.txtDatabase.TabIndex = 0;
            this.txtDatabase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatabase_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Database";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRecoverAccount);
            this.tabControl1.Controls.Add(this.tabReset);
            this.tabControl1.Location = new System.Drawing.Point(12, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(363, 380);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabRecoverAccount
            // 
            this.tabRecoverAccount.BackColor = System.Drawing.Color.LightGray;
            this.tabRecoverAccount.Controls.Add(this.grbDatabase);
            this.tabRecoverAccount.Controls.Add(this.grbUsername);
            this.tabRecoverAccount.Controls.Add(this.grbPassword);
            this.tabRecoverAccount.Location = new System.Drawing.Point(4, 22);
            this.tabRecoverAccount.Name = "tabRecoverAccount";
            this.tabRecoverAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecoverAccount.Size = new System.Drawing.Size(355, 354);
            this.tabRecoverAccount.TabIndex = 0;
            this.tabRecoverAccount.Text = "Recover Account";
            // 
            // tabReset
            // 
            this.tabReset.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabReset.Controls.Add(this.grbDatabaseReset);
            this.tabReset.Controls.Add(this.grbAccountReset);
            this.tabReset.Location = new System.Drawing.Point(4, 22);
            this.tabReset.Name = "tabReset";
            this.tabReset.Padding = new System.Windows.Forms.Padding(3);
            this.tabReset.Size = new System.Drawing.Size(355, 354);
            this.tabReset.TabIndex = 1;
            this.tabReset.Text = "Reset Program";
            // 
            // grbDatabaseReset
            // 
            this.grbDatabaseReset.Controls.Add(this.btnVerifyReset);
            this.grbDatabaseReset.Controls.Add(this.txtDatabaseReset);
            this.grbDatabaseReset.Controls.Add(this.label7);
            this.grbDatabaseReset.Location = new System.Drawing.Point(6, 6);
            this.grbDatabaseReset.Name = "grbDatabaseReset";
            this.grbDatabaseReset.Size = new System.Drawing.Size(334, 76);
            this.grbDatabaseReset.TabIndex = 8;
            this.grbDatabaseReset.TabStop = false;
            // 
            // btnVerifyReset
            // 
            this.btnVerifyReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVerifyReset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifyReset.Location = new System.Drawing.Point(131, 42);
            this.btnVerifyReset.Name = "btnVerifyReset";
            this.btnVerifyReset.Size = new System.Drawing.Size(186, 23);
            this.btnVerifyReset.TabIndex = 1;
            this.btnVerifyReset.Text = "Verify Database";
            this.btnVerifyReset.UseVisualStyleBackColor = true;
            this.btnVerifyReset.Click += new System.EventHandler(this.btnVerifyReset_Click);
            // 
            // txtDatabaseReset
            // 
            this.txtDatabaseReset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabaseReset.Location = new System.Drawing.Point(131, 13);
            this.txtDatabaseReset.MaxLength = 7;
            this.txtDatabaseReset.Name = "txtDatabaseReset";
            this.txtDatabaseReset.Size = new System.Drawing.Size(129, 23);
            this.txtDatabaseReset.TabIndex = 0;
            this.txtDatabaseReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatabaseReset_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Database";
            // 
            // grbAccountReset
            // 
            this.grbAccountReset.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.grbAccountReset.Controls.Add(this.txtPasswordReset);
            this.grbAccountReset.Controls.Add(this.txtUsernameReset);
            this.grbAccountReset.Controls.Add(this.label8);
            this.grbAccountReset.Controls.Add(this.btnResetProgram);
            this.grbAccountReset.Controls.Add(this.label9);
            this.grbAccountReset.Enabled = false;
            this.grbAccountReset.Location = new System.Drawing.Point(6, 88);
            this.grbAccountReset.Name = "grbAccountReset";
            this.grbAccountReset.Size = new System.Drawing.Size(334, 105);
            this.grbAccountReset.TabIndex = 7;
            this.grbAccountReset.TabStop = false;
            // 
            // txtPasswordReset
            // 
            this.txtPasswordReset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordReset.Location = new System.Drawing.Point(131, 43);
            this.txtPasswordReset.MaxLength = 20;
            this.txtPasswordReset.Name = "txtPasswordReset";
            this.txtPasswordReset.PasswordChar = '*';
            this.txtPasswordReset.Size = new System.Drawing.Size(129, 23);
            this.txtPasswordReset.TabIndex = 3;
            this.txtPasswordReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPasswordReset_KeyPress);
            // 
            // txtUsernameReset
            // 
            this.txtUsernameReset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameReset.Location = new System.Drawing.Point(131, 14);
            this.txtUsernameReset.MaxLength = 20;
            this.txtUsernameReset.Name = "txtUsernameReset";
            this.txtUsernameReset.Size = new System.Drawing.Size(129, 23);
            this.txtUsernameReset.TabIndex = 2;
            this.txtUsernameReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsernameReset_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Password";
            // 
            // btnResetProgram
            // 
            this.btnResetProgram.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetProgram.Location = new System.Drawing.Point(131, 72);
            this.btnResetProgram.Name = "btnResetProgram";
            this.btnResetProgram.Size = new System.Drawing.Size(186, 23);
            this.btnResetProgram.TabIndex = 4;
            this.btnResetProgram.Text = "Reset Program";
            this.btnResetProgram.UseVisualStyleBackColor = true;
            this.btnResetProgram.Click += new System.EventHandler(this.btnResetProgram_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Username";
            // 
            // frmRecoverAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(389, 398);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecoverAccount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recover Account";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRecoverAccount_Load);
            this.grbUsername.ResumeLayout(false);
            this.grbUsername.PerformLayout();
            this.grbPassword.ResumeLayout(false);
            this.grbPassword.PerformLayout();
            this.grbDatabase.ResumeLayout(false);
            this.grbDatabase.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabRecoverAccount.ResumeLayout(false);
            this.tabReset.ResumeLayout(false);
            this.grbDatabaseReset.ResumeLayout(false);
            this.grbDatabaseReset.PerformLayout();
            this.grbAccountReset.ResumeLayout(false);
            this.grbAccountReset.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbUsername;
        private System.Windows.Forms.ComboBox cboWorkgroup;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVerifyAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbPassword;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.TextBox txtRecoveryKey;
        private System.Windows.Forms.TextBox txtVerifyPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbDatabase;
        private System.Windows.Forms.Button btnVerifyDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReset;
        private System.Windows.Forms.GroupBox grbDatabaseReset;
        private System.Windows.Forms.Button btnVerifyReset;
        private System.Windows.Forms.TextBox txtDatabaseReset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grbAccountReset;
        private System.Windows.Forms.TextBox txtPasswordReset;
        private System.Windows.Forms.TextBox txtUsernameReset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnResetProgram;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabRecoverAccount;
    }
}