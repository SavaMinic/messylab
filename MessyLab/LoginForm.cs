using MessyLab.Platforms;
using MessyLab.Session;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

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

        private bool showStartPage;

        #endregion

        #region Constructor

        public LoginForm(bool showStartPage = true)
        {
            InitializeComponent();
            LoadLastUsername();
            this.showStartPage = showStartPage;
        }

        #endregion

        #region Events

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (txtUsername.Text == null) txtUsername.Focus();
            else txtPassword.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            lblStatus.ForeColor = Color.Black;
            lblStatus.Text = "Syncing...";
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
                        Invoke(new ShowTexStatustCallback(ShowSuccess), new object[] { "LOGGED IN!" });
                    else
                        ShowSuccess("LOGGED IN!");
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

        private void btnReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reset = new ResetPasswordForm();
            reset.ShowDialog(this);
        }

        private void btnOffline_Click(object sender, EventArgs e)
        {
            SessionController.ClearLogin();
            // close this window, and open main form
            if (showStartPage)
            {
                MainForm.OpenStartPage();
            }
            MainForm.RefreshLoginItem();
            CloseAndDispose();
        }

        #endregion

        #region Helper methods

        private void ShowSuccess(string text)
        {
            lblStatus.ForeColor = Color.Black;
            lblStatus.Text = text;
            lblStatus.Refresh();

            SaveLastUsername();

            // close this window, and open main form
            if (showStartPage)
            {
                MainForm.OpenStartPage();
            }
            MainForm.RefreshLoginItem();
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

        #region Last username settings


        private void LoadLastUsername()
        {
            string path = Path.Combine(Platform.GetSettingsPath(), "Settings.xml");
            if (File.Exists(path))
            {
                XmlSerializer s = new XmlSerializer(typeof(SettingsData));
                TextReader r = new StreamReader(path);
                var settings = s.Deserialize(r) as SettingsData;
                r.Close();
                txtUsername.Text = settings.LastUsername;
            }
        }

        private void SaveLastUsername()
        {
            string path = Path.Combine(Platform.GetSettingsPath(), "Settings.xml");
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(SettingsData));
                TextWriter w = new StreamWriter(path);
                s.Serialize(w, new SettingsData() { LastUsername = txtUsername.Text });
                w.Close();
            }
            catch { }
        }

        #endregion
    }

    [Serializable]
    public class SettingsData
    {
        public string LastUsername;
    }
}
