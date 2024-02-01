using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAlbumMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new MainPage();
            MainPage = new NavigationPage(mainPage) {
                BarBackgroundColor = Color.FromHex("#1D2324")
            };
            NavigationPage.SetHasNavigationBar(mainPage, false);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
