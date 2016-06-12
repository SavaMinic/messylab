using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MessyLab
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void ResetPasswordForm_Shown(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            if (username == null || username == "")
            {
                txtUsername.ForeColor = Color.Red;
                return;
            }
            txtUsername.ForeColor = Color.Black;


        }
    }
}
