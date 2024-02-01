using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;
using MusicAlbumMobile.Models;
using MusicAlbumMobile.APIs;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MusicAlbumMobile.ViewModels
{
    class ManagerListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command SelectCommand { get; }
        public Command DetailCommand { get; }
        public Command DeleteCommand { get; }
        public Command EditCommand { get; }
        public Command GoBackCommand { get; }

        public ObservableCollection<MusicAlbum> LoadData
        {
            get
            {
                return mymusic;
            }
            set
            {
                mymusic = value;
                var args = new PropertyChangedEventArgs(nameof(LoadData));
                PropertyChanged?.Invoke(this, args);
            }
        }

        ObservableCollection<MusicAlbum> mymusic;
     
        public MusicAlbum selectedMusic { get; set; }
        ApiService apiService;

        public ManagerListViewModel()
        {

            LoadData = new ObservableCollection<MusicAlbum>();
            apiService = new ApiService();

            GetMusicAlbum();

            GoBackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });


            DetailCommand = new Command(async () =>
            {
                var sendVar = new { selectedMusic = selectedMusic, EditCommand = EditCommand, DeleteCommand = DeleteCommand, GoBackCommand= GoBackCommand };
                var ProdDetail = new Page.DetailPage
                {
                    BindingContext = sendVar
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(ProdDetail);
            });


        }

        async void GetMusicAlbum()
        {
            LoadData = await apiService.GetMusicAlbum();
        }
    }
}
