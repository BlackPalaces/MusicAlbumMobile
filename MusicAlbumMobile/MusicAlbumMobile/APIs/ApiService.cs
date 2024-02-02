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

        public async Task<bool> AddSong(MusicAlbum Item)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Item);
                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://10.0.2.2:49233/api/PhoneMusicAlbums", sContent);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public async Task<bool> DeleteSong(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"http://10.0.2.2:49233/api/PhoneMusicAlbums/{id}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> UpdateSong(MusicAlbum updatedMusic)
        {
            try
            {

                var modifiedProperties = new
                {
                    updatedMusic.Musicname,
                    updatedMusic.Artist,
                    updatedMusic.Musiclink,
                    updatedMusic.Album,
                    updatedMusic.Musicpic,
                    updatedMusic.Type
                };
                string json = JsonConvert.SerializeObject(updatedMusic);
                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"http://10.0.2.2:49233/api/PhoneMusicAlbums/{updatedMusic.Id}", sContent);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


    }
}
