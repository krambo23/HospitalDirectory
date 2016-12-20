using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HospitalDirectory
{
	public partial class MainView : ContentPage
	{
		private MainViewModel _viewModel;
		public MainView()
		{
			InitializeComponent();
			_viewModel = new MainViewModel();
			BindingContext = _viewModel;
		}
	}
}
