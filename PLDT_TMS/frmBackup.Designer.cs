namespace PLDT_TMS
{
    partial class frmBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
            this.lblUsername_ = new System.Windows.Forms.Label();
            this.lblWorkgroup_ = new System.Windows.Forms.Label();
            this.fbdBackup = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRestoreBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRestore = new System.Windows.Forms.TextBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackupBrowse = new System.Windows.Forms.Button();
            this.btnCloseBackup = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblBackup = new System.Windows.Forms.Label();
            this.tabRestore = new System.Windows.Forms.TabPage();
            this.btnCloseRestore = new System.Windows.Forms.Button();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvBackup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lblDatabase_ = new System.Windows.Forms.Label();
            this.tabRestore.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername_
            // 
            this.lblUsername_.AutoSize = true;
            this.lblUsername_.Location = new System.Drawing.Point(33, 19);
            this.lblUsername_.Name = "lblUsername_";
            this.lblUsername_.Size = new System.Drawing.Size(35, 13);
            this.lblUsername_.TabIndex = 0;
            this.lblUsername_.Text = "label1";
            this.lblUsername_.Visible = false;
            // 
            // lblWorkgroup_
            // 
            this.lblWorkgroup_.AutoSize = true;
            this.lblWorkgroup_.Location = new System.Drawing.Point(119, 19);
            this.lblWorkgroup_.Name = "lblWorkgroup_";
            this.lblWorkgroup_.Size = new System.Drawing.Size(35, 13);
            this.lblWorkgroup_.TabIndex = 1;
            this.lblWorkgroup_.Text = "label2";
            this.lblWorkgroup_.Visible = false;
            // 
            // fbdBackup
            // 
            this.fbdBackup.RootFolder = System.Environment.SpecialFolder.CommonApplicationData;
            // 
            // btnRestoreBrowse
            // 
            this.btnRestoreBrowse.Location = new System.Drawing.Point(661, 93);
            this.btnRestoreBrowse.Name = "btnRestoreBrowse";
            this.btnRestoreBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnRestoreBrowse.TabIndex = 16;
            this.btnRestoreBrowse.Text = "Browse";
            this.btnRestoreBrowse.UseVisualStyleBackColor = true;
            this.btnRestoreBrowse.Click += new System.EventHandler(this.btnRestoreBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(158, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Restore from:";
            // 
            // txtRestore
            // 
            this.txtRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestore.Location = new System.Drawing.Point(265, 93);
            this.txtRestore.Name = "txtRestore";
            this.txtRestore.ReadOnly = true;
            this.txtRestore.Size = new System.Drawing.Size(390, 22);
            this.txtRestore.TabIndex = 15;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(298, 148);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(142, 42);
            this.btnRestore.TabIndex = 12;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackupBrowse
            // 
            this.btnBackupBrowse.Location = new System.Drawing.Point(675, 213);
            this.btnBackupBrowse.Name = "btnBackupBrowse";
            this.btnBackupBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBackupBrowse.TabIndex = 12;
            this.btnBackupBrowse.Text = "Browse";
            this.btnBackupBrowse.UseVisualStyleBackColor = true;
            this.btnBackupBrowse.Click += new System.EventHandler(this.btnBackupBrowse_Click);
            // 
            // btnCloseBackup
            // 
            this.btnCloseBackup.Location = new System.Drawing.Point(756, 121);
            this.btnCloseBackup.Name = "btnCloseBackup";
            this.btnCloseBackup.Size = new System.Drawing.Size(142, 55);
            this.btnCloseBackup.TabIndex = 11;
            this.btnCloseBackup.Text = "Close";
            this.btnCloseBackup.UseVisualStyleBackColor = true;
            this.btnCloseBackup.Click += new System.EventHandler(this.btnCloseBackup_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(756, 41);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(142, 55);
            this.btnBackup.TabIndex = 10;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // lblBackup
            // 
            this.lblBackup.AutoSize = true;
            this.lblBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackup.ForeColor = System.Drawing.Color.Maroon;
            this.lblBackup.Location = new System.Drawing.Point(10, 216);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new System.Drawing.Size(89, 16);
            this.lblBackup.TabIndex = 8;
            this.lblBackup.Text = "Backup to:: ";
            // 
            // tabRestore
            // 
            this.tabRestore.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tabRestore.Controls.Add(this.btnRestoreBrowse);
            this.tabRestore.Controls.Add(this.label1);
            this.tabRestore.Controls.Add(this.txtRestore);
            this.tabRestore.Controls.Add(this.btnCloseRestore);
            this.tabRestore.Controls.Add(this.btnRestore);
            this.tabRestore.Location = new System.Drawing.Point(4, 24);
            this.tabRestore.Name = "tabRestore";
            this.tabRestore.Padding = new System.Windows.Forms.Padding(3);
            this.tabRestore.Size = new System.Drawing.Size(904, 261);
            this.tabRestore.TabIndex = 0;
            this.tabRestore.Text = "Restore";
            // 
            // btnCloseRestore
            // 
            this.btnCloseRestore.Location = new System.Drawing.Point(446, 148);
            this.btnCloseRestore.Name = "btnCloseRestore";
            this.btnCloseRestore.Size = new System.Drawing.Size(142, 42);
            this.btnCloseRestore.TabIndex = 13;
            this.btnCloseRestore.Text = "Close";
            this.btnCloseRestore.UseVisualStyleBackColor = true;
            this.btnCloseRestore.Click += new System.EventHandler(this.btnCloseRestore_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "File Path";
            this.columnHeader4.Width = 366;
            // 
            // lsvBackup
            // 
            this.lsvBackup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.lsvBackup.FullRowSelect = true;
            this.lsvBackup.GridLines = true;
            this.lsvBackup.Location = new System.Drawing.Point(6, 6);
            this.lsvBackup.Name = "lsvBackup";
            this.lsvBackup.Size = new System.Drawing.Size(744, 198);
            this.lsvBackup.TabIndex = 2;
            this.lsvBackup.UseCompatibleStateImageBehavior = false;
            this.lsvBackup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Backup Name";
            this.columnHeader1.Width = 205;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date of Creation";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 194;
            // 
            // tabBackup
            // 
            this.tabBackup.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tabBackup.Controls.Add(this.btnBackupBrowse);
            this.tabBackup.Controls.Add(this.btnCloseBackup);
            this.tabBackup.Controls.Add(this.btnBackup);
            this.tabBackup.Controls.Add(this.lblBackup);
            this.tabBackup.Controls.Add(this.lsvBackup);
            this.tabBackup.Controls.Add(this.txtBackup);
            this.tabBackup.Location = new System.Drawing.Point(4, 24);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackup.Size = new System.Drawing.Size(904, 261);
            this.tabBackup.TabIndex = 1;
            this.tabBackup.Text = "Backup";
            // 
            // txtBackup
            // 
            this.txtBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackup.Location = new System.Drawing.Point(105, 213);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.ReadOnly = true;
            this.txtBackup.Size = new System.Drawing.Size(564, 22);
            this.txtBackup.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBackup);
            this.tabControl1.Controls.Add(this.tabRestore);
            this.tabControl1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(912, 289);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // lblDatabase_
            // 
            this.lblDatabase_.AutoSize = true;
            this.lblDatabase_.Location = new System.Drawing.Point(838, -4);
            this.lblDatabase_.Name = "lblDatabase_";
            this.lblDatabase_.Size = new System.Drawing.Size(30, 13);
            this.lblDatabase_.TabIndex = 11;
            this.lblDatabase_.Text = "temp";
            this.lblDatabase_.Visible = false;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(946, 313);
            this.Controls.Add(this.lblDatabase_);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblWorkgroup_);
            this.Controls.Add(this.lblUsername_);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup/Restore";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.tabRestore.ResumeLayout(false);
            this.tabRestore.PerformLayout();
            this.tabBackup.ResumeLayout(false);
            this.tabBackup.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblUsername_;
        public System.Windows.Forms.Label lblWorkgroup_;
        private System.Windows.Forms.FolderBrowserDialog fbdBackup;
        private System.Windows.Forms.Button btnRestoreBrowse;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtRestore;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackupBrowse;
        private System.Windows.Forms.Button btnCloseBackup;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.TabPage tabRestore;
        private System.Windows.Forms.Button btnCloseRestore;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lsvBackup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabBackup;
        public System.Windows.Forms.TextBox txtBackup;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label lblDatabase_;
    }
}