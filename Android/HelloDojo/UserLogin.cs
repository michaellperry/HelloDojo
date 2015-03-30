using System;
using Assisticant.Fields;

namespace HelloDojo
{

	public class UserLoginViewModel
	{
		public UserLoginViewModel()
		{
			UserLogin = new UserLogin ();
		}
		private Observable<string> _message = new Observable<string> ();

		public UserLogin UserLogin {
			get;
			set;
		}

		public string Message {
			get { return _message; }
		}

		public void Login ()
		{
			_message.Value = string.Format (
				"Welcome, {0}, your password is {1}",
				UserLogin.UserName, UserLogin.Password);
		}
	}

	public class UserLogin
	{
		private Observable<string> _userName = new Observable<string> ();
		private Observable<string> _password = new Observable<string> ();

		public string UserName {
			get { return _userName; }
			set { _userName.Value = value; }
		}

		public string Password {
			get { return _password; }
			set { _password.Value = value; }
		}
	}
}

