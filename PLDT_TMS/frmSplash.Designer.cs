namespace PLDT_TMS
{
    partial class frmSplash
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            lblNote = new System.Windows.Forms.Label();
            lblDatabase_ = new System.Windows.Forms.Label();
            lblWorkgroup_ = new System.Windows.Forms.Label();
            lblUsername_ = new System.Windows.Forms.Label();
            timStart = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblNote
            // 
            lblNote.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNote.Location = new System.Drawing.Point(6, 9);
            lblNote.Name = "lblNote";
            lblNote.Size = new System.Drawing.Size(500, 23);
            lblNote.TabIndex = 0;
            lblNote.Text = "Please wait while the database is being updated....";
            // 
            // lblDatabase_
            // 
            lblDatabase_.AutoSize = true;
            lblDatabase_.Location = new System.Drawing.Point(209, 14);
            lblDatabase_.Name = "lblDatabase_";
            lblDatabase_.Size = new System.Drawing.Size(30, 13);
            lblDatabase_.TabIndex = 13;
            lblDatabase_.Text = "temp";
            lblDatabase_.Visible = false;
            // 
            // lblWorkgroup_
            // 
            lblWorkgroup_.AutoSize = true;
            lblWorkgroup_.Location = new System.Drawing.Point(245, 14);
            lblWorkgroup_.Name = "lblWorkgroup_";
            lblWorkgroup_.Size = new System.Drawing.Size(30, 13);
            lblWorkgroup_.TabIndex = 12;
            lblWorkgroup_.Text = "temp";
            lblWorkgroup_.Visible = false;
            // 
            // lblUsername_
            // 
            lblUsername_.AutoSize = true;
            lblUsername_.Location = new System.Drawing.Point(272, 14);
            lblUsername_.Name = "lblUsername_";
            lblUsername_.Size = new System.Drawing.Size(30, 13);
            lblUsername_.TabIndex = 11;
            lblUsername_.Text = "temp";
            lblUsername_.Visible = false;
            // 
            // timStart
            // 
            timStart.Enabled = true;
            timStart.Interval = 1000;
            timStart.Tick += new System.EventHandler(timStart_Tick);
            // 
            // frmSplash
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(502, 33);
            ControlBox = false;
            Controls.Add(lblDatabase_);
            Controls.Add(lblWorkgroup_);
            Controls.Add(lblUsername_);
            Controls.Add(lblNote);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            Name = "frmSplash";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += new System.EventHandler(frmSplash_Load);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblDatabase_;
        private System.Windows.Forms.Label lblWorkgroup_;
        private System.Windows.Forms.Label lblUsername_;
        private System.Windows.Forms.Timer timStart;
    }
}