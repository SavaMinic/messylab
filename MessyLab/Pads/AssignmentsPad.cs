﻿#region License
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
		delegate void ToogleSelectedAssignmentPanelCallback(bool isVisible);

        /// <summary>
        /// Occurs when an item is double-clicked.
        /// </summary>
        public event Action ItemDoubleClicked;

        #endregion

        #region Properites/fields

        /// <summary>
        /// Selected assignment item.
        /// </summary>
        public static Assignment SelectedAssignment { get; protected set; }

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
                SessionController.GetAssignments(RefreshAssignments);
            }
            else
            {
                lblInfo.Visible = true;
                tbtnRefresh.Enabled = false;
            }
			ToogleSelectedAssignmentPanel(false);
        }

        private void AddToMainListView(ListViewItem it)
        {
            listView.Items.Add(it);
        }

        private void ClearMainListView()
        {
            listView.Items.Clear();
        }

		private void ToogleSelectedAssignmentPanel(bool isVisible)
		{
			pnlSelectedAssignment.Visible = isVisible && SelectedAssignment != null;
			if (isVisible && SelectedAssignment != null)
			{
				lblTitle.Text = SelectedAssignment.Title;
				txtDescription.Text = SelectedAssignment.Description;
				tbtUpload.Enabled = SelectedAssignment.CanSendSolution;
				tbtOpenSolution.Enabled = SelectedAssignment.SolutionCode != null && SelectedAssignment.SolutionCode != "";
			}
		}

        private void RefreshAssignments(List<Assignment> assignments)
        {
            LoadedAssignments = assignments;
            if (listView.InvokeRequired)
                Invoke(new ClearListViewCallback(ClearMainListView));
            else
                ClearMainListView();

			var hasSelected = false;
            foreach (var assignment in assignments)
            {
				var isSelected = SelectedAssignment != null && SelectedAssignment.ID == assignment.ID;
				hasSelected = hasSelected || isSelected;
				var it = new ListViewItem(isSelected ? "✓" : string.Empty);
                it.SubItems.Add(assignment.Title);
                it.SubItems.Add(assignment.EndTime.ToString("dd.MM.yyyy HH:mm:ss"));
                it.SubItems.Add(assignment.SolutionCode != null ? "✓" : "");
                it.Tag = assignment;

                if (listView.InvokeRequired)
                    Invoke(new AddToListViewCallback(AddToMainListView), new object[] { it });
                else
                    AddToMainListView(it);
            }

			if (pnlSelectedAssignment.InvokeRequired)
				Invoke(new ToogleSelectedAssignmentPanelCallback(ToogleSelectedAssignmentPanel), new object[] { hasSelected });
			else
				ToogleSelectedAssignmentPanel(hasSelected);
        }

        protected void OnItemDoubleClicked()
		{
			if (ItemDoubleClicked != null)
			{
				ItemDoubleClicked.Invoke();
			}
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
            //UpdateItemList();
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

		private void btnUpload_Click(object sender, EventArgs e)
		{
			var code = "a = 0 %0D%0A org 8 %0D%0A MOV a, 666 %0D%0A OUT a %0D%0A STOP";
			SessionController.PostAssignmentSolution(SelectedAssignment, code, UpdateItemList);
		}

		private void tbtOpenSolution_Click(object sender, EventArgs e)
		{

		}

        #endregion
    }
}
