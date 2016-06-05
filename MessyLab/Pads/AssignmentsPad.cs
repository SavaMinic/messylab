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

using MessyLab.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Assignment = MessyLab.Session.SessionController.AssignmentData;

namespace MessyLab
{
	/// <summary>
	/// Assignments management pad.
	/// </summary>
	public partial class AssignmentsPad : Pad
	{
        #region Delegates/events

        delegate void AddToListViewCallback(ListViewItem it);
        delegate void ClearListViewCallback();

        /// <summary>
        /// Occurs when an item is double-clicked.
        /// </summary>
        public event Action ItemDoubleClicked;

        #endregion

        #region Properites/fields

        /// <summary>
        /// Selected assignment item.
        /// </summary>
        public Assignment SelectedAssignment { get; protected set; }

        public Assignment ClickedAssignment { get; protected set; }

        private List<Assignment> LoadedAssignments;

        #endregion

        #region Constructors

        public AssignmentsPad(Project project)
            : base(project)
        {
            InitializeComponent();
            CreateMenuItem("&Assignments", MessyLab.Properties.Resources.Assignments);
            CreateToolbarItem("Assignments", MessyLab.Properties.Resources.Assignments);
            ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;

            project.Saved += UpdateItemList;
            Paint += AssignmentsPad_Paint;
        }

        public AssignmentsPad() : this(null) { }

        #endregion

        #region Methods

        /// <summary>
        /// Updates list according to the items of the current project.
        /// </summary>
        public void UpdateItemList()
        {
            if (Project == null) return;
            ClearMainListView();
            if (SessionController.IsLoggedIn)
            {
                lblInfo.Visible = false;
                tbtnRefresh.Enabled = true;
                tbtnUpload.Enabled = true;
                SessionController.GetAssignments(RefreshAssignments);
            }
            else
            {
                lblInfo.Visible = true;
                tbtnRefresh.Enabled = false;
                tbtnUpload.Enabled = false;
            }
        }

        private void AddToMainListView(ListViewItem it)
        {
            listView.Items.Add(it);
        }

        private void ClearMainListView()
        {
            listView.Items.Clear();
        }

        private void RefreshAssignments(List<Assignment> assignments)
        {
            LoadedAssignments = assignments;
            if (listView.InvokeRequired)
                Invoke(new ClearListViewCallback(ClearMainListView));
            else
                ClearMainListView();

            foreach (var assignment in assignments)
            {
                var it = new ListViewItem(ReferenceEquals(SelectedAssignment, assignment) ? "*" : string.Empty);
                it.SubItems.Add(assignment.Title);
                it.SubItems.Add(assignment.EndTime.ToString("dd.MM.yyyy HH:mm:ss"));
                it.SubItems.Add(assignment.SolutionCode != null ? "✓" : "");
                it.Tag = assignment;

                if (listView.InvokeRequired)
                    Invoke(new AddToListViewCallback(AddToMainListView), new object[] { it });
                else
                    AddToMainListView(it);
            }

            
            // TODO: enable/disable 
            //tbtnUpload.Enabled = SelectedAssignment != null;
        }

        protected void OnItemDoubleClicked()
		{
            ItemDoubleClicked?.Invoke();
        }

        protected void OpenSelected()
        {
            if (SelectedAssignment != null)
            {
                OnItemDoubleClicked();
            }
        }

        #endregion

        #region Event handlers

        private void AssignmentsPad_Paint(object sender, PaintEventArgs e)
        {
            UpdateItemList();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView.SelectedItems.Count == 1)
			{
                ClickedAssignment = listView.SelectedItems[0].Tag as Assignment;
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
			if (ClickedAssignment != null)
            {
                SelectedAssignment = ClickedAssignment;
                RefreshAssignments(LoadedAssignments);
            }
		}

		private void listView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				OpenSelected();
			}
		}

        private void tbtnRefresh_Click(object sender, EventArgs e)
        {
            UpdateItemList();
        }

        #endregion
    }
}
