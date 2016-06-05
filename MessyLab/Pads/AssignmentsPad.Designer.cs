namespace MessyLab
{
	partial class AssignmentsPad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignmentsPad));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tbtnUpload = new System.Windows.Forms.ToolStripButton();
            this.listView = new System.Windows.Forms.ListView();
            this.Selected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.canSendSolution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblInfo = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnRefresh,
            this.tbtnUpload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip";
            // 
            // tbtnRefresh
            // 
            this.tbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRefresh.Image")));
            this.tbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnRefresh.Name = "tbtnRefresh";
            this.tbtnRefresh.Size = new System.Drawing.Size(66, 22);
            this.tbtnRefresh.Text = "Refresh";
            this.tbtnRefresh.Click += new System.EventHandler(this.tbtnRefresh_Click);
            // 
            // tbtnUpload
            // 
            this.tbtnUpload.Image = ((System.Drawing.Image)(resources.GetObject("tbtnUpload.Image")));
            this.tbtnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnUpload.Name = "tbtnUpload";
            this.tbtnUpload.Size = new System.Drawing.Size(171, 22);
            this.tbtnUpload.Text = "Upload solution to selected";
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Selected,
            this.Title,
            this.EndTime,
            this.canSendSolution});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(284, 460);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // Selected
            // 
            this.Selected.Text = "Selected";
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 61;
            // 
            // EndTime
            // 
            this.EndTime.Text = "End time";
            this.EndTime.Width = 120;
            // 
            // canSendSolution
            // 
            this.canSendSolution.Text = "Solved";
            this.canSendSolution.Width = 50;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.setAsMainToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(152, 48);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // setAsMainToolStripMenuItem
            // 
            this.setAsMainToolStripMenuItem.Name = "setAsMainToolStripMenuItem";
            this.setAsMainToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.setAsMainToolStripMenuItem.Text = "Set as Selected";
            this.setAsMainToolStripMenuItem.Click += new System.EventHandler(this.setAsMainToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.SystemColors.Window;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(24, 113);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(223, 93);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Click on Project > Login, to get assignments.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.Visible = false;
            // 
            // AssignmentsPad
            // 
            this.AutoHidePortion = 300D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 485);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssignmentsPad";
            this.TabText = "Assignments";
            this.Text = "Assignments";
            this.Load += new System.EventHandler(this.AssignmentsPad_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader Selected;
		private System.Windows.Forms.ColumnHeader Title;
		private System.Windows.Forms.ToolStripButton tbtnUpload;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setAsMainToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tbtnRefresh;
        private System.Windows.Forms.ColumnHeader EndTime;
        private System.Windows.Forms.ColumnHeader canSendSolution;
        private System.Windows.Forms.Label lblInfo;
    }
}
