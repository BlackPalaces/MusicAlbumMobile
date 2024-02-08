using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MusicAlbumMobile.ViewModels
{
     class MainViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateCommand { get; }
        public Command GoManager { get; }
        public MainViewModel()
        {
            NavigateCommand = new Command<string>(Navigate);

            GoManager = new Command(async () =>
            {
                System.Diagnostics.Debug.WriteLine($"มาแล้ววววววว");
                await Application.Current.MainPage.Navigation.PushAsync(new Page.MusicManager());
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Navigate(string page)
        {
            // Handle navigation based on the selected menu item
            switch (page)
            {
                case "HOME":
                    Application.Current.MainPage.Navigation.PushAsync(new Page.HomeMusic());
                    break;
                case "ARTIST":
                    // Handle navigation to artist page
                    break;
                case "ALBUMS":
                    // Handle navigation to albums page
                    break;
                case "FAVORITE":
                    // Handle navigation to favorite page
                    break;
                case "ADMINTOOLS":
                    Application.Current.MainPage.Navigation.PushAsync(new Page.Admintools());
                    break;
            }
        }


    }

}
