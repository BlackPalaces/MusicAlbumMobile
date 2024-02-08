using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAlbumMobile.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicPlayPage : ContentPage
    {
        public MusicPlayPage()
        {
            InitializeComponent();

            this.Appearing += MusicPlayPage_Appearing;
        }
        private void MusicPlayPage_Appearing(object sender, EventArgs e)
        {
            string url = _url.Text; 
            if (!string.IsNullOrEmpty(url))
            {
                System.Diagnostics.Debug.WriteLine($"มาหาเว็บแล้ว");

                var match = Regex.Match(url, @"(?:\?|&)v=([^&]+)");

                if (match.Success)
                {
                    string videoId = match.Groups[1].Value;

            
                    string embedUrl = $"https://www.youtube.com/embed/{videoId}";

                    webView.Source = new UrlWebViewSource { Url = embedUrl };
                    Myurl.Text =  embedUrl;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"ไม่พบ video ID ใน URL");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"ไปก่อนนะ");
            }

       
            this.Appearing -= MusicPlayPage_Appearing;
        }
    }
}