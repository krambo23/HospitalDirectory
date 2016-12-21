using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace HospitalDirectory
{
	public class MainViewModel : INotifyPropertyChanged
	{
		// Input Hospital Name (Same as in Line 7 in /Views/MainView.xaml)
		private string _inputHName;
		public string InputHName
		{ 
			get
			{
				return _inputHName;
			}

			set
			{
				_inputHName = value;
				OnPropertyChanged("InputHName");
			}
		}

		// Input Hospital Location (Same as in Line 8 in /Views/MainView.xaml)
		private string _inputHLocation;
		public string InputHLocation
		{ 
			get
			{
				return _inputHLocation;
			}
			set
			{
				_inputHLocation = value;
				OnPropertyChanged("InputHLocation");
			}
		}

		// Instantiate
		public MainViewModel()
		{
			HospitalList = new ObservableCollection<Hospital>();
			populateList();
		}

		// Hospital List - ObservableCollection  
		// Same as in Line 30 in /Views/MainView.xaml
		private ObservableCollection<Hospital> _hospitalList;
		public ObservableCollection<Hospital> HospitalList
		{
			get
			{
				return _hospitalList;
			}

			set
			{
				_hospitalList = value;
			}
		}

		// Adds to Hospital List
		public async void Run()
		{
			Hospital H = new Hospital
			{
				Name = InputHName,
				Location = InputHLocation
			};
			await App.client.GetTable<Hospital>().InsertAsync(H);
			HospitalList.Clear();
			populateList();
			//HospitalList.Add(H);
		}

		// Bind with 'Add Entry' Button - /Views/MainView.xaml (Line 10)
		public ICommand AddHospital
		{
			get
			{
				return new Command (Run);
			}
		}

		public async void populateList()
		{
			var dblist = await App.client.GetTable<Hospital>().ToListAsync();

			foreach (var item in dblist)
			{
				Hospital newhospital = new Hospital
				{
					Location = item.Location,
					Name = item.Name
				};
				HospitalList.Add(newhospital);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string PropertyInput)
		{
			/*
			if (PropertyInput != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(PropertyInput));
			}
			*/ // Same as code below
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyInput));
		}
	}
}
