using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessyLab.Platforms;

namespace MessyLab.Session
{
    public static class SessionController
    {
        #region Consts/Inner classes

#if DEBUG
		public const string SERVER_IP = "http://localhost:14453/";
#else
        public const string SERVER_IP = "http://messylabadmin.azurewebsites.net/";
#endif

		public class LoginData
        {
            public string SessionID { get; set; }
        }

        public class ErrorData
        {
            public int Error { get; set; }
        }

		public class ErrorsData
		{
			public MessyLab.PicoComputer.Error[] errors;
		}

        public class AssignmentData
        {
            public int ID;
            public string Title;
            public string Description;
            public DateTime StartTime;
            public DateTime EndTime;
            public bool CanSendSolution;

            // optional
            public string SolutionCode;
            public DateTime SolutionCreated;
            public bool SolutionEvaluated;
        }

        public class GetAssignemntsData
        {
            public bool ok;
            public AssignmentData[] assignments;
        }

		public class DefaultData
		{
			public bool ok;
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
        public static bool IsLoggedIn {  get { return SessionID != null && SessionID != ""; } }

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
                        if (onSuccess != null) onSuccess.Invoke();
                        if (OnLoggedIn != null) OnLoggedIn.Invoke();
                    }
                    else
                    {
                        if (onError != null) onError.Invoke();
                    }
                }
                else if (response.ResponseStatus == ResponseStatus.TimedOut)
                {
                    if (onTimeout != null) onTimeout.Invoke();
                }
                else
                {
                    if (onError != null) onError.Invoke();
                }
            });
        }

        public static void ClearLogin()
        {
            SessionID = null;
            LoggedInUsername = "";
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

        public static void GetAssignments(Action<List<AssignmentData>> callback)
        {
            if (SessionID == null) return;

            var request = new RestRequest("Client/Assignments", Method.GET);
            request.AddParameter("sessionID", SessionID);
            request.AddParameter("nocache", DateTime.Now.Ticks);

            Client.ExecuteAsync(request, response => {
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    GetAssignemntsData data = JsonConvert.DeserializeObject<GetAssignemntsData>(response.Content);
                    if (data != null && data.ok)
                    {
                        callback(new List<AssignmentData>(data.assignments));
                    }
                }
                else
                {
                    // TODO: show some error
                }
            });
        }

		public static void PostAssignmentSolution(AssignmentData assignment, string code, Action onSuccess = null, Action<int> onError = null)
		{
			if (SessionID == null) return;

			var request = new RestRequest("Client/Assignments", Method.POST);
			request.AddParameter("sessionID", SessionID);
			request.AddParameter("assignmentID", assignment.ID);
			request.AddParameter("code", code);

			Client.ExecuteAsync(request, response =>
			{
				if (response.ResponseStatus == ResponseStatus.Completed)
				{
					var data = JsonConvert.DeserializeObject<DefaultData>(response.Content);
					if (data != null && data.ok)
					{
						onSuccess();
					}
					else
					{
						var errors = JsonConvert.DeserializeObject<ErrorsData>(response.Content);
						if (errors != null && errors.errors.Count() > 0)
							onError.Invoke(errors.errors[0].ID);
						else
							onError.Invoke(999);
					}
				}
				else
				{
					if (onError != null)
					{
						var error = JsonConvert.DeserializeObject<ErrorData>(response.Content);
						onError.Invoke(error != null ? error.Error : 999);
					}

				}
			});
		}

        public static void RequestPasswordReset(string username, Action onSuccess = null, Action<int> onError = null)
        {
            var request = new RestRequest("Client/RequestPasswordReset", Method.POST);
            request.AddParameter("username", username);
            request.AddParameter("nocache", DateTime.Now.Ticks);

            Client.ExecuteAsync(request, response => {
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    GetAssignemntsData data = JsonConvert.DeserializeObject<GetAssignemntsData>(response.Content);
                    if (data != null && data.ok)
                    {
                        if (onSuccess != null) onSuccess.Invoke();
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<ErrorData>(response.Content);
                        if (onError != null) onError.Invoke(error != null ? error.Error : 2);
                    }
                }
                else
                {
                    if (onError != null) onError.Invoke(1);
                }
            });
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

		public static void PostAddBreakpoint(BreakpointController.BreakpointDefinition breakpoint)
        {
            PostAction(ActionType.AddBreakpoint, JObject.FromObject(new { breakpoint = breakpoint.ToMemento() }).ToString());
        }

		public static void PostRemoveBreakpoint(BreakpointController.BreakpointDefinition breakpoint)
        {
            PostAction(ActionType.RemoveBreakpoint, JObject.FromObject(new { breakpoint = breakpoint.ToMemento() }).ToString());
        }

        #endregion

        #endregion
    }
}
