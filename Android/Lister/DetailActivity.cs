
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Assisticant.Binding;

namespace Lister
{
	[Activity (Label = "DetailActivity")]			
	public class DetailActivity : Activity
	{
		private PersonDetailViewModel _viewModel = ViewModelLocator.Instance.Detail;
		private BindingManager _bindings = new BindingManager ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.Detail);

			_bindings.BindText(FindViewById<EditText>(Resource.Id.editName),()=> _viewModel.Name, n=>_viewModel.Name = n);
			_bindings.BindCommand (FindViewById<Button> (Resource.Id.buttonOk), () =>
				{
					_viewModel.Save ();
					StartActivity(typeof(MainActivity));
				});
			_bindings.BindCommand (FindViewById<Button> (Resource.Id.buttonCancel), () => 
				{
					_viewModel.Discard ();
					StartActivity(typeof(MainActivity));
				});

		}
	}
}

