using MessyLab.Session;
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
        delegate void InvokeCallback();

        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseAndDispose();
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
                MessageBox.Show("Enter your username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            btnReset.Text = "Sending...";
            btnReset.Enabled = false;
            SessionController.RequestPasswordReset(username, () =>
            {
                if (InvokeRequired)
                    Invoke(new InvokeCallback(CloseAndDispose));
                else
                    CloseAndDispose();
                MessageBox.Show("Check your email for password reset link.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            },  err =>
            {
                if (btnReset.InvokeRequired)
                    Invoke(new InvokeCallback(EnableResetButton));
                else
                    EnableResetButton();
                var error = "Undefined error!";
                switch(err)
                {
                    case 1: error = "Server timeout!"; break;
                    case -1: error = "Empty username!"; break;
                    case -2: error = "No such username!"; break;
                    case -3: error = "You already have requested passwod reset in last 24h!\nCheck your @student.etf.rs email."; break;
                }
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void EnableResetButton()
        {
            btnReset.Enabled = true;
            btnReset.Text = "Send reset request";
        }

        private void CloseAndDispose()
        {
            Close();
            Dispose();
        }
    }
}
