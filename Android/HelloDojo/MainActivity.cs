using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Assisticant.Binding;

namespace HelloDojo
{
	[Activity (Label = "HelloDojo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private UserLoginViewModel _userLoginViewModel = new UserLoginViewModel ();
		private BindingManager _bindings = new BindingManager ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			_bindings.Initialize (this);

			SetContentView (Resource.Layout.Main);

			_bindings.BindText (FindViewById<EditText> (Resource.Id.userName), () => _userLoginViewModel.UserLogin.UserName, x => _userLoginViewModel.UserLogin.UserName = x);
			_bindings.BindText (FindViewById<EditText> (Resource.Id.password), () => _userLoginViewModel.UserLogin.Password, x => _userLoginViewModel.UserLogin.Password = x);
			_bindings.BindCommand (FindViewById<Button> (Resource.Id.myButton), _userLoginViewModel.Login,
				()=>(!string.IsNullOrWhiteSpace(_userLoginViewModel.UserLogin.UserName) && !string.IsNullOrWhiteSpace(_userLoginViewModel.UserLogin.Password)));
			_bindings.BindText (FindViewById<TextView> (Resource.Id.welcome), () => _userLoginViewModel.Message);
		}

		protected override void OnDestroy ()
		{
			_bindings.Unbind ();
			base.OnDestroy ();
		}
	}
}


