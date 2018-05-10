namespace PLDT_TMS
{
    partial class frmEndorsements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEndorsements));
            this.lsvData = new System.Windows.Forms.ListView();
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTicketDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsername_ = new System.Windows.Forms.Label();
            this.lblWorkgroup_ = new System.Windows.Forms.Label();
            this.lblDatabase_ = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtTotalRow = new System.Windows.Forms.TextBox();
            this.btnLess = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtShowRow = new System.Windows.Forms.TextBox();
            this.dtpSearch = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvData
            // 
            this.lsvData.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lsvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader23,
            this.columnHeader20,
            this.columnHeader24,
            this.columnHeader1,
            this.columnHeader2});
            this.lsvData.ContextMenuStrip = this.ctmMain;
            this.lsvData.FullRowSelect = true;
            this.lsvData.GridLines = true;
            this.lsvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvData.Location = new System.Drawing.Point(12, 47);
            this.lsvData.MultiSelect = false;
            this.lsvData.Name = "lsvData";
            this.lsvData.Size = new System.Drawing.Size(915, 421);
            this.lsvData.TabIndex = 50;
            this.lsvData.UseCompatibleStateImageBehavior = false;
            this.lsvData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Ticket #";
            this.columnHeader19.Width = 106;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Endorsed by";
            this.columnHeader23.Width = 214;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Endorsed to";
            this.columnHeader20.Width = 184;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Endorsed on";
            this.columnHeader24.Width = 108;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Workgroup";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 79;
            // 
            // ctmMain
            // 
            this.ctmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDetailsToolStripMenuItem,
            this.viewTicketDetailsToolStripMenuItem});
            this.ctmMain.Name = "ctmMain";
            this.ctmMain.Size = new System.Drawing.Size(210, 48);
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.viewDetailsToolStripMenuItem.Text = "View endorsement details";
            this.viewDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewDetailsToolStripMenuItem_Click);
            // 
            // viewTicketDetailsToolStripMenuItem
            // 
            this.viewTicketDetailsToolStripMenuItem.Name = "viewTicketDetailsToolStripMenuItem";
            this.viewTicketDetailsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.viewTicketDetailsToolStripMenuItem.Text = "View ticket details";
            this.viewTicketDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewTicketDetailsToolStripMenuItem_Click);
            // 
            // lblUsername_
            // 
            this.lblUsername_.AutoSize = true;
            this.lblUsername_.Location = new System.Drawing.Point(896, -3);
            this.lblUsername_.Name = "lblUsername_";
            this.lblUsername_.Size = new System.Drawing.Size(35, 13);
            this.lblUsername_.TabIndex = 51;
            this.lblUsername_.Text = "label1";
            this.lblUsername_.Visible = false;
            // 
            // lblWorkgroup_
            // 
            this.lblWorkgroup_.AutoSize = true;
            this.lblWorkgroup_.Location = new System.Drawing.Point(859, -3);
            this.lblWorkgroup_.Name = "lblWorkgroup_";
            this.lblWorkgroup_.Size = new System.Drawing.Size(35, 13);
            this.lblWorkgroup_.TabIndex = 52;
            this.lblWorkgroup_.Text = "label2";
            this.lblWorkgroup_.Visible = false;
            // 
            // lblDatabase_
            // 
            this.lblDatabase_.AutoSize = true;
            this.lblDatabase_.Location = new System.Drawing.Point(836, -3);
            this.lblDatabase_.Name = "lblDatabase_";
            this.lblDatabase_.Size = new System.Drawing.Size(35, 13);
            this.lblDatabase_.TabIndex = 53;
            this.lblDatabase_.Text = "label3";
            this.lblDatabase_.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Maroon;
            this.label28.Location = new System.Drawing.Point(824, 478);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 15);
            this.label28.TabIndex = 65;
            this.label28.Text = "Total";
            // 
            // txtTotalRow
            // 
            this.txtTotalRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRow.Location = new System.Drawing.Point(870, 474);
            this.txtTotalRow.MaxLength = 5;
            this.txtTotalRow.Name = "txtTotalRow";
            this.txtTotalRow.ReadOnly = true;
            this.txtTotalRow.Size = new System.Drawing.Size(57, 23);
            this.txtTotalRow.TabIndex = 64;
            // 
            // btnLess
            // 
            this.btnLess.Enabled = false;
            this.btnLess.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLess.Location = new System.Drawing.Point(628, 473);
            this.btnLess.Name = "btnLess";
            this.btnLess.Size = new System.Drawing.Size(23, 23);
            this.btnLess.TabIndex = 63;
            this.btnLess.Text = "<";
            this.btnLess.UseVisualStyleBackColor = true;
            this.btnLess.Click += new System.EventHandler(this.btnLess_Click);
            // 
            // btnMore
            // 
            this.btnMore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.Location = new System.Drawing.Point(800, 474);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(23, 23);
            this.btnMore.TabIndex = 62;
            this.btnMore.Text = ">";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(720, 477);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(11, 15);
            this.label29.TabIndex = 61;
            this.label29.Text = "-";
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRow.Location = new System.Drawing.Point(737, 474);
            this.txtRow.MaxLength = 5;
            this.txtRow.Name = "txtRow";
            this.txtRow.ReadOnly = true;
            this.txtRow.Size = new System.Drawing.Size(57, 23);
            this.txtRow.TabIndex = 60;
            // 
            // txtShowRow
            // 
            this.txtShowRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShowRow.Location = new System.Drawing.Point(657, 474);
            this.txtShowRow.MaxLength = 5;
            this.txtShowRow.Name = "txtShowRow";
            this.txtShowRow.ReadOnly = true;
            this.txtShowRow.Size = new System.Drawing.Size(57, 23);
            this.txtShowRow.TabIndex = 59;
            this.txtShowRow.Text = "0";
            this.txtShowRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpSearch
            // 
            this.dtpSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearch.Location = new System.Drawing.Point(682, 18);
            this.dtpSearch.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpSearch.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpSearch.Name = "dtpSearch";
            this.dtpSearch.Size = new System.Drawing.Size(203, 23);
            this.dtpSearch.TabIndex = 69;
            this.dtpSearch.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(596, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 68;
            this.label2.Text = "Search for:";
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
            "Endorsed by",
            "Endorsed to",
            "Endorsed on",
            "Workgroup"});
            this.cboSearchType.Location = new System.Drawing.Point(369, 17);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(206, 23);
            this.cboSearchType.TabIndex = 66;
            this.cboSearchType.SelectedIndexChanged += new System.EventHandler(this.cboSearchType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(287, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 67;
            this.label1.Text = "Search by:";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(681, 17);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(204, 23);
            this.txtSearch.TabIndex = 71;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(12, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(253, 23);
            this.lblCount.TabIndex = 73;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(892, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 23);
            this.btnSearch.TabIndex = 70;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmEndorsements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(938, 508);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSearchType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.txtTotalRow);
            this.Controls.Add(this.btnLess);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.txtShowRow);
            this.Controls.Add(this.lblDatabase_);
            this.Controls.Add(this.lblWorkgroup_);
            this.Controls.Add(this.lblUsername_);
            this.Controls.Add(this.lsvData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEndorsements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Endorsements";
            this.Load += new System.EventHandler(this.frmEndorsements_Load);
            this.ctmMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvData;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Label lblUsername_;
        private System.Windows.Forms.Label lblWorkgroup_;
        private System.Windows.Forms.Label lblDatabase_;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtTotalRow;
        private System.Windows.Forms.Button btnLess;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.TextBox txtShowRow;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip ctmMain;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem viewTicketDetailsToolStripMenuItem;
    }
}