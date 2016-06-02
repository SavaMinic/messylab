#region License
/*
 * Copyright 2010 Miloš Anđelković
 *    
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MessyLab
{
	/// <summary>
	/// Assignments management pad.
	/// </summary>
	public partial class AssignmentsPad : Pad
	{
		public AssignmentsPad(Project project)
			: base(project)
		{
			InitializeComponent();
			CreateMenuItem("&Assignments", MessyLab.Properties.Resources.Assignments);
			CreateToolbarItem("Assignments", MessyLab.Properties.Resources.Assignments);
			ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;

			project.Saved += UpdateItemList;
		}
		public AssignmentsPad() : this(null) { }

		/// <summary>
		/// Updates list according to the items of the current project.
		/// </summary>
		public void UpdateItemList()
		{
			listView.Items.Clear();
			if (Project == null) return;
			foreach (var item in Project.Items)
			{
				var it = new ListViewItem(ReferenceEquals(Project.MainItem, item) ? "*" : string.Empty);
				it.SubItems.Add(item.Filename);
				it.Tag = item;
				listView.Items.Add(it);
			}
		}

		/// <summary>
		/// Selected project item.
		/// </summary>
		public ProjectItem SelectedItem { get; protected set; }
        
		/// <summary>
		/// Occurs when an item is double-clicked.
		/// </summary>
		public event Action ItemDoubleClicked;
        
		protected void OnItemDoubleClicked()
		{
            ItemDoubleClicked?.Invoke();
        }

		private void listView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView.SelectedItems.Count == 1)
			{
				SelectedItem = listView.SelectedItems[0].Tag as ProjectItem;
			}
		}

		protected void OpenSelected()
		{
			if (SelectedItem != null)
			{
				OnItemDoubleClicked();
			}
		}

		private void listView_DoubleClick(object sender, EventArgs e)
		{
			OpenSelected();
		}

		private void AssignmentsPad_Load(object sender, EventArgs e)
		{
			UpdateItemList();
		}

		private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			if (listView.SelectedItems.Count != 1) e.Cancel = true;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenSelected();
		}

		private void setAsMainToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				Project.MainItem = SelectedItem;
				Project.Save();
			}
		}

		private void listView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				OpenSelected();
			}
		}

	}
}
