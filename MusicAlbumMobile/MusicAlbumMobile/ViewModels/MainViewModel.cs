using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicAlbumMobile.ViewModels
{
     class MainViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateCommand { get; }

        public MainViewModel()
        {
            NavigateCommand = new Command<string>(Navigate);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void Navigate(string page)
        {
            // Handle navigation based on the selected menu item
            switch (page)
            {
                case "Item1":
                    // Navigate to Item 1
                    break;
                case "Item2":
                    // Navigate to Item 2
                    break;
                    // Add more cases for additional menu items as needed
            }
        }

        // Implement INotifyPropertyChanged interface as needed
    }

}
