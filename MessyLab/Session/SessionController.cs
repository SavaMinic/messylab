using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessyLab.Session
{
    public static class SessionController
    {
        #region Consts/Inner classes

        public const string SERVER_IP = "http://messylabadmin.azurewebsites.net/";

        public class LoginData
        {
            public string SessionID { get; set; }
        }

        public class ErrorData
        {
            public int Error { get; set; }
        }

        private enum ActionType
        {
            Login = 1,
            Compile,
            StartDebug,
            EndDebug,
            AddBreakpoint,
            RemoveBreakpoint,
            HitBreakpoint,
            SetWatch,
            CompilationSuccess,
            CompilationFailure,
        }

        #endregion

        #region Properties

        public static string SessionID { get; private set; }
        public static string LoggedInUsername { get; private set; }

        public static Action OnLoggedIn;

        #endregion

        #region Fields

        private static RestClient _client;
        private static RestClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new RestClient(SERVER_IP);
                    _client.AddDefaultHeader("Cache-Control", "no-cache");
                    _client.Timeout = 5000;
                }
                return _client;
            }
        }

        #endregion

        #region Methods

        public static void TryToLogin(string username, string password, Action onSuccess = null, Action onError = null, Action onTimeout = null)
        {
            var request = new RestRequest("Client/Login", Method.POST);
            request.AddParameter("user", username);
            request.AddParameter("pass", password);
            request.AddParameter("nocache", DateTime.Now.Ticks);

            SessionID = null;
            LoggedInUsername = null;

            Client.ExecuteAsync(request, response => {
                if(response.ResponseStatus == ResponseStatus.Completed)
                {
                    LoginData data = JsonConvert.DeserializeObject<LoginData>(response.Content);
                    if (data != null && data.SessionID != null)
                    {
                        SessionID = data.SessionID;
                        LoggedInUsername = username;
                        onSuccess?.Invoke();
                        OnLoggedIn?.Invoke();
                    }
                    else
                    {
                        onError?.Invoke();
                    }
                }
                else if (response.ResponseStatus == ResponseStatus.TimedOut)
                {
                    onTimeout?.Invoke();
                }
                else
                {
                    onError?.Invoke();
                }
            });
        }

        private static void PostAction(ActionType actionType, string data = null)
        {
            if (SessionID == null) return;

            var request = new RestRequest("Client/Action", Method.POST);
            request.AddParameter("sessionID", SessionID);
            request.AddParameter("type", actionType);
            request.AddParameter("data", data);
            request.AddParameter("nocache", DateTime.Now.Ticks);

            Client.ExecuteAsync(request, response => {});
        }

        #region Post helpers

        public static void PostCompilationSuccess()
        {
            PostAction(ActionType.CompilationSuccess);
        }

        public static void PostCompilationFailure(List<string> errors)
        {
            PostAction(ActionType.CompilationFailure, JObject.FromObject(new { errors = errors }).ToString());
        }

        public static void PostCompile(string code)
        {
            PostAction(ActionType.Compile, JObject.FromObject(new { code = code }).ToString());
        }

        public static void PostStartDebug()
        {
            PostAction(ActionType.StartDebug);
        }

        public static void PostEndDebug()
        {
            PostAction(ActionType.EndDebug);
        }

        #endregion

        #endregion
    }
}
