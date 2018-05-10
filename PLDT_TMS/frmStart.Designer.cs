namespace PLDT_TMS
{
    partial class frmStart
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
            this.timChecker = new System.Windows.Forms.Timer(this.components);
            this.lblSQL = new System.Windows.Forms.Label();
            this.txt1st = new System.Windows.Forms.TextBox();
            this.txt2nd = new System.Windows.Forms.TextBox();
            this.txt3rd = new System.Windows.Forms.TextBox();
            this.txt4th = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblCheck = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timChecker
            // 
            this.timChecker.Interval = 1000;
            this.timChecker.Tick += new System.EventHandler(this.timChecker_Tick);
            // 
            // lblSQL
            // 
            this.lblSQL.AutoSize = true;
            this.lblSQL.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQL.Location = new System.Drawing.Point(12, 10);
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Size = new System.Drawing.Size(249, 18);
            this.lblSQL.TabIndex = 0;
            this.lblSQL.Text = "Set MySQL Server IP Address:";
            this.lblSQL.Visible = false;
            // 
            // txt1st
            // 
            this.txt1st.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1st.Location = new System.Drawing.Point(267, 6);
            this.txt1st.MaxLength = 3;
            this.txt1st.Name = "txt1st";
            this.txt1st.Size = new System.Drawing.Size(36, 26);
            this.txt1st.TabIndex = 0;
            this.txt1st.Visible = false;
            this.txt1st.TextChanged += new System.EventHandler(this.txt1st_TextChanged);
            this.txt1st.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt1st_KeyPress);
            // 
            // txt2nd
            // 
            this.txt2nd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2nd.Location = new System.Drawing.Point(328, 6);
            this.txt2nd.MaxLength = 3;
            this.txt2nd.Name = "txt2nd";
            this.txt2nd.Size = new System.Drawing.Size(36, 26);
            this.txt2nd.TabIndex = 1;
            this.txt2nd.Visible = false;
            this.txt2nd.TextChanged += new System.EventHandler(this.txt2nd_TextChanged);
            this.txt2nd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt2nd_KeyPress);
            // 
            // txt3rd
            // 
            this.txt3rd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3rd.Location = new System.Drawing.Point(389, 6);
            this.txt3rd.MaxLength = 3;
            this.txt3rd.Name = "txt3rd";
            this.txt3rd.Size = new System.Drawing.Size(36, 26);
            this.txt3rd.TabIndex = 2;
            this.txt3rd.Visible = false;
            this.txt3rd.TextChanged += new System.EventHandler(this.txt3rd_TextChanged);
            this.txt3rd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3rd_KeyPress);
            // 
            // txt4th
            // 
            this.txt4th.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4th.Location = new System.Drawing.Point(450, 6);
            this.txt4th.MaxLength = 3;
            this.txt4th.Name = "txt4th";
            this.txt4th.Size = new System.Drawing.Size(36, 26);
            this.txt4th.TabIndex = 3;
            this.txt4th.Visible = false;
            this.txt4th.TextChanged += new System.EventHandler(this.txt4th_TextChanged);
            this.txt4th.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt4th_KeyPress);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(370, 9);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(13, 18);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = ".";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(431, 9);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(13, 18);
            this.lbl3.TabIndex = 6;
            this.lbl3.Text = ".";
            this.lbl3.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(309, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(13, 18);
            this.lbl1.TabIndex = 7;
            this.lbl1.Text = ".";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCheck.Enabled = false;
            this.btnCheck.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(502, 6);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(141, 26);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check Server";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheck.Location = new System.Drawing.Point(203, 11);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(216, 18);
            this.lblCheck.TabIndex = 8;
            this.lblCheck.Text = "Checking MySQL Server...";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(222, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(10, 10);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(651, 36);
            this.ControlBox = false;
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.lblSQL);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txt4th);
            this.Controls.Add(this.txt3rd);
            this.Controls.Add(this.txt2nd);
            this.Controls.Add(this.txt1st);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timChecker;
        private System.Windows.Forms.Label lblSQL;
        private System.Windows.Forms.TextBox txt1st;
        private System.Windows.Forms.TextBox txt2nd;
        private System.Windows.Forms.TextBox txt3rd;
        private System.Windows.Forms.TextBox txt4th;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Button btnClose;
    }
}