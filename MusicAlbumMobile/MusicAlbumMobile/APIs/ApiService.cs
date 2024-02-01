using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MusicAlbumMobile.Models;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace MusicAlbumMobile.APIs
{
    class ApiService
    {
        HttpClient client;

        public ApiService()
        {
            client = new HttpClient();
        }
        public async Task<ObservableCollection<MusicAlbum>> GetMusicAlbum()
        {
            ObservableCollection<MusicAlbum> Items = null;

            try
            {
                var response = await client.GetAsync("http://10.0.2.2:49233/api/PhoneMusicAlbums");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ObservableCollection<MusicAlbum>>(content);
                    return Items;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return null;
        }
    }
}
