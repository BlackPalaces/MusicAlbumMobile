using System;
using System.Collections.Generic;
using System.Text;

namespace MusicAlbumMobile.Models
{
    public class MusicAlbum
    {
        public int Id { get; set; }
        public string Musicname { get; set; }
        public string Artist { get; set; }
        public string Musiclink { get; set; }
        public string Album { get; set; }
        public string Musicpic { get; set; }
        public int? Hit { get; set; }
        public string Type { get; set; }
    }
}
