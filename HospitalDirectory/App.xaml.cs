using Xamarin.Forms;

namespace HospitalDirectory
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent(); // Parses App.xaml
			MainPage = new MainView(); // Launches MainView.xaml
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
