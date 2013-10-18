using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Song
    {
        public Song ()
        {
            FilePath = null;
            SongTitle = null;
            Artist = null;
            Album = null;
            Genre = null;
        }
        public Song(string filePath, string songTitle, string artist, string album, string genre)
        {
            FilePath = filePath;
            SongTitle = songTitle;
            Artist = artist;
            Album = album;
            Genre = genre;
        }
        public string FilePath;
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }

    }
}
