using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace HospitalDirectory
{
	public class MainViewModel : INotifyPropertyChanged
	{
		// Input Hospital Name
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

		// Input Hospital Location
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

		// Hospital List
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

		// Instantiate
		public MainViewModel()
		{
			HospitalList = new ObservableCollection<Hospital>();
		}

		// Adds to Hospital List
		public void Run()
		{
			Hospital H = new Hospital
			{
				HName = InputHName,
				HLocation = InputHLocation
			};

			HospitalList.Add(H);
		}

		// Bind with 'Add Entry' Button
		public ICommand AddHospital
		{
			get
			{
				return new Command(Run);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string PropertyInput)
		{
			if (PropertyInput != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(PropertyInput));
			}
		}
	}
}
