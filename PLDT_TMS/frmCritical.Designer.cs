namespace PLDT_TMS
{
    partial class frmCritical
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCritical));
            this.lsvData = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewTicketDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label28 = new System.Windows.Forms.Label();
            this.txtTotalRow = new System.Windows.Forms.TextBox();
            this.btnLess = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtShowRow = new System.Windows.Forms.TextBox();
            this.lblDatabase_ = new System.Windows.Forms.Label();
            this.lblWorkgroup_ = new System.Windows.Forms.Label();
            this.lblUsername_ = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvData
            // 
            this.lsvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lsvData.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvData.FullRowSelect = true;
            this.lsvData.GridLines = true;
            this.lsvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvData.Location = new System.Drawing.Point(12, 12);
            this.lsvData.MultiSelect = false;
            this.lsvData.Name = "lsvData";
            this.lsvData.Size = new System.Drawing.Size(526, 453);
            this.lsvData.TabIndex = 0;
            this.lsvData.UseCompatibleStateImageBehavior = false;
            this.lsvData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ticket #";
            this.columnHeader6.Width = 132;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date Reported";
            this.columnHeader7.Width = 183;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Outage";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Workgroup";
            this.columnHeader9.Width = 147;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTicketDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // viewTicketDetailsToolStripMenuItem
            // 
            this.viewTicketDetailsToolStripMenuItem.Name = "viewTicketDetailsToolStripMenuItem";
            this.viewTicketDetailsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.viewTicketDetailsToolStripMenuItem.Text = "View Ticket Details";
            this.viewTicketDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewTicketDetailsToolStripMenuItem_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Maroon;
            this.label28.Location = new System.Drawing.Point(436, 475);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 15);
            this.label28.TabIndex = 58;
            this.label28.Text = "Total";
            // 
            // txtTotalRow
            // 
            this.txtTotalRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRow.Location = new System.Drawing.Point(482, 471);
            this.txtTotalRow.MaxLength = 5;
            this.txtTotalRow.Name = "txtTotalRow";
            this.txtTotalRow.ReadOnly = true;
            this.txtTotalRow.Size = new System.Drawing.Size(57, 23);
            this.txtTotalRow.TabIndex = 57;
            // 
            // btnLess
            // 
            this.btnLess.Enabled = false;
            this.btnLess.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLess.Location = new System.Drawing.Point(240, 470);
            this.btnLess.Name = "btnLess";
            this.btnLess.Size = new System.Drawing.Size(23, 23);
            this.btnLess.TabIndex = 56;
            this.btnLess.Text = "<";
            this.btnLess.UseVisualStyleBackColor = true;
            this.btnLess.Click += new System.EventHandler(this.btnLess_Click);
            // 
            // btnMore
            // 
            this.btnMore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.Location = new System.Drawing.Point(412, 471);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(23, 23);
            this.btnMore.TabIndex = 55;
            this.btnMore.Text = ">";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(332, 474);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(11, 15);
            this.label29.TabIndex = 54;
            this.label29.Text = "-";
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRow.Location = new System.Drawing.Point(349, 471);
            this.txtRow.MaxLength = 5;
            this.txtRow.Name = "txtRow";
            this.txtRow.ReadOnly = true;
            this.txtRow.Size = new System.Drawing.Size(57, 23);
            this.txtRow.TabIndex = 53;
            // 
            // txtShowRow
            // 
            this.txtShowRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShowRow.Location = new System.Drawing.Point(269, 471);
            this.txtShowRow.MaxLength = 5;
            this.txtShowRow.Name = "txtShowRow";
            this.txtShowRow.ReadOnly = true;
            this.txtShowRow.Size = new System.Drawing.Size(57, 23);
            this.txtShowRow.TabIndex = 52;
            this.txtShowRow.Text = "0";
            this.txtShowRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDatabase_
            // 
            this.lblDatabase_.AutoSize = true;
            this.lblDatabase_.Location = new System.Drawing.Point(457, -4);
            this.lblDatabase_.Name = "lblDatabase_";
            this.lblDatabase_.Size = new System.Drawing.Size(30, 13);
            this.lblDatabase_.TabIndex = 61;
            this.lblDatabase_.Text = "temp";
            this.lblDatabase_.Visible = false;
            // 
            // lblWorkgroup_
            // 
            this.lblWorkgroup_.AutoSize = true;
            this.lblWorkgroup_.Location = new System.Drawing.Point(493, -4);
            this.lblWorkgroup_.Name = "lblWorkgroup_";
            this.lblWorkgroup_.Size = new System.Drawing.Size(30, 13);
            this.lblWorkgroup_.TabIndex = 60;
            this.lblWorkgroup_.Text = "temp";
            this.lblWorkgroup_.Visible = false;
            // 
            // lblUsername_
            // 
            this.lblUsername_.AutoSize = true;
            this.lblUsername_.Location = new System.Drawing.Point(520, -4);
            this.lblUsername_.Name = "lblUsername_";
            this.lblUsername_.Size = new System.Drawing.Size(30, 13);
            this.lblUsername_.TabIndex = 59;
            this.lblUsername_.Text = "temp";
            this.lblUsername_.Visible = false;
            // 
            // frmCritical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 505);
            this.Controls.Add(this.lblDatabase_);
            this.Controls.Add(this.lblWorkgroup_);
            this.Controls.Add(this.lblUsername_);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.txtTotalRow);
            this.Controls.Add(this.btnLess);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.txtShowRow);
            this.Controls.Add(this.lsvData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCritical";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Critically-aged Tickets";
            this.Load += new System.EventHandler(this.frmCritical_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewTicketDetailsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtTotalRow;
        private System.Windows.Forms.Button btnLess;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.TextBox txtShowRow;
        private System.Windows.Forms.Label lblDatabase_;
        private System.Windows.Forms.Label lblWorkgroup_;
        private System.Windows.Forms.Label lblUsername_;
    }
}