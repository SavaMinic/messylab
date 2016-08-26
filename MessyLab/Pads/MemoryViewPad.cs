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
using MessyLab.Platforms.Pico;
using MessyLab.Debugger.Target.Pico;
using MessyLab.PicoComputer;

namespace MessyLab
{
	/// <summary>
	/// Memory view pad
	/// </summary>
	public partial class MemoryViewPad : Pad
	{
		#region Constructors

		public MemoryViewPad(Project project)
            : base(project)
        {
			InitializeComponent();
			CreateMenuItem("&Memory", MessyLab.Properties.Resources.Memory);
			CreateToolbarItem("Memory", MessyLab.Properties.Resources.Memory);
			ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
		}

		public MemoryViewPad() : this(null) { }

		#endregion

		#region Methods

		public void Refresh()
		{
			var picoPlatform = Project.Platform as PicoPlatform;
			if (picoPlatform == null) return;
			var picoTarget = picoPlatform.DebuggerController.Debugger.Target as PicoTarget;
			if (picoTarget == null) return;

			try
			{
				dgvMemory.Rows.Clear();
				var memory = picoTarget.VirtualMachine.Data;
				var startAdress = ushort.Parse(txtStartAdress.Text);
				for (ushort i = startAdress; i < startAdress + 16 && i < Data.Size; i++)
				{
					ushort data = memory.DirectMemoryRead(i);
					dgvMemory.Rows.Add(
						string.Format("{0} (0x{0:X4})", i, i),
						string.Format("0x{0:X2}", (byte)data), // lower byte
						string.Format("0x{0:X2}", (byte)(data >> 8)) // higher byte
					);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Event handlers

		private void tbtnRefresh_Click(object sender, EventArgs e)
		{
			Refresh();
		}

		#endregion
	}
}
