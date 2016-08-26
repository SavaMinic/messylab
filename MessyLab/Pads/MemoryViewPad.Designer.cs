namespace MessyLab
{
	partial class MemoryViewPad
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryViewPad));
			this.dgvMemory = new System.Windows.Forms.DataGridView();
			this.Adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FirstByte = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SecondByte = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.txtStartAdress = new System.Windows.Forms.ToolStripTextBox();
			this.tbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.iMemoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dgvMemory)).BeginInit();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.iMemoryBindingSource)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvMemory
			// 
			this.dgvMemory.AllowUserToAddRows = false;
			this.dgvMemory.AllowUserToDeleteRows = false;
			this.dgvMemory.AllowUserToResizeColumns = false;
			this.dgvMemory.AllowUserToResizeRows = false;
			this.dgvMemory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvMemory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dgvMemory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMemory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Adress,
            this.FirstByte,
            this.SecondByte});
			this.dgvMemory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMemory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dgvMemory.Location = new System.Drawing.Point(0, 0);
			this.dgvMemory.Margin = new System.Windows.Forms.Padding(5, 50, 5, 5);
			this.dgvMemory.Name = "dgvMemory";
			this.dgvMemory.ReadOnly = true;
			this.dgvMemory.RowHeadersWidth = 20;
			this.dgvMemory.Size = new System.Drawing.Size(284, 336);
			this.dgvMemory.TabIndex = 1;
			// 
			// Adress
			// 
			this.Adress.HeaderText = "Adress";
			this.Adress.Name = "Adress";
			this.Adress.ReadOnly = true;
			// 
			// FirstByte
			// 
			this.FirstByte.HeaderText = "Lower byte";
			this.FirstByte.Name = "FirstByte";
			this.FirstByte.ReadOnly = true;
			this.FirstByte.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.FirstByte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.FirstByte.ToolTipText = "First byte of data";
			// 
			// SecondByte
			// 
			this.SecondByte.HeaderText = "Higher byte";
			this.SecondByte.Name = "SecondByte";
			this.SecondByte.ReadOnly = true;
			this.SecondByte.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.SecondByte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.SecondByte.ToolTipText = "Second byte of data";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtStartAdress,
            this.tbtnRefresh});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(284, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
			this.toolStripLabel1.Text = "Adress:";
			// 
			// txtStartAdress
			// 
			this.txtStartAdress.AutoSize = false;
			this.txtStartAdress.Name = "txtStartAdress";
			this.txtStartAdress.Size = new System.Drawing.Size(50, 25);
			this.txtStartAdress.Text = "0";
			this.txtStartAdress.ToolTipText = "Enter start adress";
			// 
			// tbtnRefresh
			// 
			this.tbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRefresh.Image")));
			this.tbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnRefresh.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.tbtnRefresh.Name = "tbtnRefresh";
			this.tbtnRefresh.Size = new System.Drawing.Size(82, 25);
			this.tbtnRefresh.Text = "Show data";
			this.tbtnRefresh.Click += new System.EventHandler(this.tbtnRefresh_Click);
			// 
			// iMemoryBindingSource
			// 
			this.iMemoryBindingSource.DataSource = typeof(MessyLab.Debugger.Target.IMemory);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgvMemory);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(284, 336);
			this.panel1.TabIndex = 2;
			// 
			// MemoryViewPad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(284, 361);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MemoryViewPad";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.TabText = "Memory";
			this.Text = "Memory view";
			((System.ComponentModel.ISupportInitialize)(this.dgvMemory)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.iMemoryBindingSource)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvMemory;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tbtnRefresh;
		private System.Windows.Forms.BindingSource iMemoryBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn Adress;
		private System.Windows.Forms.DataGridViewTextBoxColumn FirstByte;
		private System.Windows.Forms.DataGridViewTextBoxColumn SecondByte;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox txtStartAdress;
		private System.Windows.Forms.Panel panel1;
	}
}