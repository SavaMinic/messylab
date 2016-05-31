using MessyLab.Session;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MessyLab
{
    public partial class LoginForm : Form
    {

        #region Static

        public static string SessionID { get; set; }

        // todo: move this to some conf file
        public const string SERVER_IP = "http://messylabadmin.azurewebsites.net/";

        #endregion

        #region Properties/Delegates

        public MainForm MainForm { get; set; }

        delegate void ShowTexStatustCallback(string text);

        #endregion

        #region Constructor

        public LoginForm()
        {
            InitializeComponent();
            lblStatus.Visible = false;
        }

        #endregion

        #region Events

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            lblStatus.ForeColor = Color.Black;
            lblStatus.Text = "Syncing...";
            lblStatus.Visible = true;
            lblStatus.Refresh();

            // check data
            bool isOk = true;
            lblUsername.ForeColor = Color.Black;
            if (txtUsername.Text == "")
            {
                isOk = false;
                lblUsername.ForeColor = Color.Red;
            }

            lblPassword.ForeColor = Color.Black;
            if (txtPassword.Text == "")
            {
                isOk = false;
                lblPassword.ForeColor = Color.Red;
            }

            if (!isOk)
            {
                ShowError("Enter credentials!");
                return;
            }

            // async login, so need to handle the callbacks
            SessionController.TryToLogin(txtUsername.Text, txtPassword.Text,
                () =>
                {
                    if (lblStatus.InvokeRequired)
                        Invoke(new ShowTexStatustCallback(ShowInfo), new object[] { "LOGGED IN!" });
                    else
                        ShowInfo("LOGGED IN!");
                },
                () =>
                {
                        if (lblStatus.InvokeRequired)
                            Invoke(new ShowTexStatustCallback(ShowError), new object[] { "Wrong credentials!" });
                        else
                            ShowError("Wrong credentials!");
                },
                () =>
                {
                    if (lblStatus.InvokeRequired)
                        Invoke(new ShowTexStatustCallback(ShowError), new object[] { "Server not responding!" });
                    else
                        ShowError("Server not responding!");
                }
            );
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseAndDispose();
            MainForm.Close();
        }

        #endregion

        #region Helper methods

        private void ShowInfo(string text)
        {
            lblStatus.ForeColor = Color.Black;
            lblStatus.Text = text;
            lblStatus.Refresh();

            // sleep for a second and close this window
            Thread.Sleep(1000);
            CloseAndDispose();
        }

        private void ShowError(string text)
        {
            btnLogin.Enabled = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = text;
            lblStatus.Refresh();
        }

        public void CloseAndDispose()
        {
            Close();
            Dispose();
        }

        #endregion
    }
}
