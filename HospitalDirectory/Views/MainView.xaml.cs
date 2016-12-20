using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HospitalDirectory
{
	public partial class MainView : ContentPage
	{
		private MainViewModel _mainViewModel;
		public MainView()
		{
			InitializeComponent(); // Parses XAML
			_mainViewModel = new MainViewModel();
			BindingContext = _mainViewModel;
		}
	}
}
