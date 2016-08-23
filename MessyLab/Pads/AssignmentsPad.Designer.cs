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
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.setAsMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlSelectedAssignment = new System.Windows.Forms.Panel();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.tstAssignmentStrip = new System.Windows.Forms.ToolStrip();
			this.tbtUpload = new System.Windows.Forms.ToolStripButton();
			this.tbtOpenSolution = new System.Windows.Forms.ToolStripButton();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.lblInfo = new System.Windows.Forms.Label();
			this.listView = new System.Windows.Forms.ListView();
			this.Selected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.EndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.canSendSolution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tstMainStrip = new System.Windows.Forms.ToolStrip();
			this.tbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.contextMenuStrip.SuspendLayout();
			this.pnlSelectedAssignment.SuspendLayout();
			this.tstAssignmentStrip.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.tstMainStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsMainToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
			// 
			// setAsMainToolStripMenuItem
			// 
			this.setAsMainToolStripMenuItem.Name = "setAsMainToolStripMenuItem";
			this.setAsMainToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.setAsMainToolStripMenuItem.Text = "Set as Selected";
			this.setAsMainToolStripMenuItem.Click += new System.EventHandler(this.setAsMainToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
			// 
			// pnlSelectedAssignment
			// 
			this.pnlSelectedAssignment.Controls.Add(this.txtDescription);
			this.pnlSelectedAssignment.Controls.Add(this.tstAssignmentStrip);
			this.pnlSelectedAssignment.Controls.Add(this.lblTitle);
			this.pnlSelectedAssignment.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlSelectedAssignment.Location = new System.Drawing.Point(0, 229);
			this.pnlSelectedAssignment.Name = "pnlSelectedAssignment";
			this.pnlSelectedAssignment.Size = new System.Drawing.Size(267, 276);
			this.pnlSelectedAssignment.TabIndex = 3;
			// 
			// txtDescription
			// 
			this.txtDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtDescription.Location = new System.Drawing.Point(0, 58);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(267, 218);
			this.txtDescription.TabIndex = 5;
			this.txtDescription.Text = "testing description of assignment";
			// 
			// tstAssignmentStrip
			// 
			this.tstAssignmentStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtUpload,
            this.tbtOpenSolution});
			this.tstAssignmentStrip.Location = new System.Drawing.Point(0, 27);
			this.tstAssignmentStrip.Name = "tstAssignmentStrip";
			this.tstAssignmentStrip.Size = new System.Drawing.Size(267, 25);
			this.tstAssignmentStrip.TabIndex = 4;
			this.tstAssignmentStrip.Text = "tstAssignmentStrip";
			// 
			// tbtUpload
			// 
			this.tbtUpload.Image = ((System.Drawing.Image)(resources.GetObject("tbtUpload.Image")));
			this.tbtUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtUpload.Name = "tbtUpload";
			this.tbtUpload.Size = new System.Drawing.Size(111, 22);
			this.tbtUpload.Text = "Upload solution";
			this.tbtUpload.ToolTipText = "Upload your main project file as solution";
			this.tbtUpload.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// tbtOpenSolution
			// 
			this.tbtOpenSolution.Image = global::MessyLab.Properties.Resources.ProjectExplorer;
			this.tbtOpenSolution.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtOpenSolution.Name = "tbtOpenSolution";
			this.tbtOpenSolution.Size = new System.Drawing.Size(129, 22);
			this.tbtOpenSolution.Text = "View your solution";
			this.tbtOpenSolution.ToolTipText = "View your uploaded solution";
			this.tbtOpenSolution.Click += new System.EventHandler(this.tbtOpenSolution_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(267, 27);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "Test name";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.lblInfo);
			this.pnlMain.Controls.Add(this.listView);
			this.pnlMain.Controls.Add(this.tstMainStrip);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(267, 205);
			this.pnlMain.TabIndex = 4;
			// 
			// lblInfo
			// 
			this.lblInfo.BackColor = System.Drawing.SystemColors.Window;
			this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInfo.Location = new System.Drawing.Point(30, 76);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(228, 80);
			this.lblInfo.TabIndex = 7;
			this.lblInfo.Text = "Click on Project > Login, to get assignments.";
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.listView.Size = new System.Drawing.Size(267, 180);
			this.listView.TabIndex = 6;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
			this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
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
			this.EndTime.Width = 100;
			// 
			// canSendSolution
			// 
			this.canSendSolution.Text = "Solved";
			this.canSendSolution.Width = 50;
			// 
			// tstMainStrip
			// 
			this.tstMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnRefresh});
			this.tstMainStrip.Location = new System.Drawing.Point(0, 0);
			this.tstMainStrip.Name = "tstMainStrip";
			this.tstMainStrip.Size = new System.Drawing.Size(267, 25);
			this.tstMainStrip.TabIndex = 5;
			this.tstMainStrip.Text = "toolStrip";
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
			// AssignmentsPad
			// 
			this.AutoHidePortion = 300D;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(284, 485);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlSelectedAssignment);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AssignmentsPad";
			this.TabText = "Assignments";
			this.Text = "Assignments";
			this.Load += new System.EventHandler(this.AssignmentsPad_Load);
			this.contextMenuStrip.ResumeLayout(false);
			this.pnlSelectedAssignment.ResumeLayout(false);
			this.pnlSelectedAssignment.PerformLayout();
			this.tstAssignmentStrip.ResumeLayout(false);
			this.tstAssignmentStrip.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.tstMainStrip.ResumeLayout(false);
			this.tstMainStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem setAsMainToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.Panel pnlSelectedAssignment;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ToolStrip tstAssignmentStrip;
		private System.Windows.Forms.ToolStripButton tbtUpload;
		private System.Windows.Forms.ToolStripButton tbtOpenSolution;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader Selected;
		private System.Windows.Forms.ColumnHeader Title;
		private System.Windows.Forms.ColumnHeader EndTime;
		private System.Windows.Forms.ColumnHeader canSendSolution;
		private System.Windows.Forms.ToolStrip tstMainStrip;
		private System.Windows.Forms.ToolStripButton tbtnRefresh;
		private System.Windows.Forms.Label lblInfo;
    }
}
