using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SongModel
    {
        public SongModel ()
        {
            Username = null;
            FilePath = null;
            SongTitle = null;
            Artist = null;
            Album = null;
            Genre = null;
            Length = null;
            
        }
        public SongModel(string username, string filePath, string songTitle, string artist, string album, string genre, string length)
        {
            Username = username;
            FilePath = filePath;
            SongTitle = songTitle;
            Artist = artist;
            Album = album;
            Genre = genre;
            Length = length;
        }
        public int SongID { get; set;}
        public string FilePath;
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string Length { get; set; }

        public string Username { get; set; }

    }
}
