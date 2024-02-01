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

        private async void Navigate(string page)
        {
            // Handle navigation based on the selected menu item
            switch (page)
            {
                case "HOME":
                  
                    break;
                case "ARTIST":
                
                    break;

                case "ALBUMS":

                    break;
                case "FAVORITE":

                    break;
                case "ADMINTOOLS":
                    await Application.Current.MainPage.Navigation.PushAsync(new Page.Admintools());
                    break;

            }
        }

    }

}
