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
        public Command CreateCommand { get; }
        public Command EditCommand { get; }
        public Command GoBackCommand { get; }
        public MusicAlbum MusicAlbum { get; set; }
        public Command AddsongCommand { get; }
        public Command SaveCommand { get; }


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
            MusicAlbum = new MusicAlbum();

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

            CreateCommand = new Command(async () =>
            {
                
                await Application.Current.MainPage.Navigation.PushAsync(new Page.CreateNewSong());
            });

            AddsongCommand = new Command(async () =>
            {
                var response = await apiService.AddSong(MusicAlbum);

                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("ADDSONG", "Successfully!!", "OK");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ADDSONG", "Fail!!", "OK");
                }
            });

            DeleteCommand = new Command(async () =>
            {
                bool result = await Application.Current.MainPage.DisplayAlert("Confirmation", "Are you sure you want to delete this song?", "Yes", "No");

                if (result)
                {
                    var response = await apiService.DeleteSong(selectedMusic.Id);

                    if (response)
                    {
                        await Application.Current.MainPage.DisplayAlert("DELETE", "Successfully!!", "OK");
                        GetMusicAlbum(); // รีเฟรชข้อมูลหลังจากการลบ
                        await Application.Current.MainPage.Navigation.PopModalAsync(); // กลับหน้าหลักหลังจากลบ
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("DELETE", "Fail!!", "OK");
                    }
                }
            });

            EditCommand = new Command(async () =>
            {
                var sendVar = new { selectedMusic = selectedMusic, GoBackCommand = GoBackCommand ,SaveCommand = SaveCommand};
                var editPage = new Page.EditPage
                {
                    BindingContext = sendVar
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(editPage);
            });


            SaveCommand = new Command(async () =>
            {
                System.Diagnostics.Debug.WriteLine($"จะเพิ่มแล้วนะ");
                MusicAlbum.Id = selectedMusic.Id;

                MusicAlbum.Musicname = selectedMusic.Musicname;
                MusicAlbum.Artist = selectedMusic.Artist;
                MusicAlbum.Musiclink = selectedMusic.Musiclink;
                MusicAlbum.Album = selectedMusic.Album;
                MusicAlbum.Musicpic = selectedMusic.Musicpic;
                MusicAlbum.Type = selectedMusic.Type;

                var response = await apiService.UpdateSong(MusicAlbum);

                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("UPDATE", "Success!!", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("UPDATE", "Fail!!", "OK");
                }
            });


        }

        async void GetMusicAlbum()
        {
            LoadData = await apiService.GetMusicAlbum();
        }
    }
}
