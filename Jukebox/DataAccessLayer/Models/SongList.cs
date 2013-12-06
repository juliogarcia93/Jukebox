using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataAccessLayer.Conversions;
using System.IO;

namespace DataAccessLayer.Models
{
    public class SongList : List<SongModel>
    {
        SongManager SongManager = new SongManager();
        public SongList()
            : this(1, 50)
        {
        }

        private List<SongModel> GetSongList()
        {

            string songDirectory = HttpContext.Current.Server.MapPath("~/Music/");

            var songs = SongManager.GetSongList();

            TotalCount = songs.Count();

            return songs.ToList();
        }

        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public SongList(int pageNum, int pageSize)
        {
            CurrentPage = pageNum;
            PageSize = pageSize;

            var songs = GetSongList();

            this.AddRange(songs.Skip((pageNum - 1) *
                pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Uploads a song to the server and posts metadata to the database.
        /// </summary>
        /// <param name="username">The username of the user adding the song.</param>
        /// <param name="fileName">The name of the file for URL purposes.</param>
        /// <param name="file">The file from the upload form\</param>
        public void Add(string username, string fileName, HttpPostedFileBase file)
        {
            SongModel song;

            //Declaring the directory that the song will be uploaded to and performing upload.
            string MusicDirectory = HttpContext.Current.Server.MapPath("~/Music/") + fileName;
            file.SaveAs(MusicDirectory);

            //Checking to see if the song already exists in the database.
 			bool songExists = SongManager.GetSongList().Any(s => s.FilePath == fileName);    
        
            //If the song doesn't exist, create metadata and push to database.
            if (!songExists)
            {
                TagLib.File metadata = TagLib.File.Create(MusicDirectory);
                string Duration = metadata.Properties.Duration.ToString(@"mm\:ss");
                song = new SongModel(username, fileName, metadata.Tag.Title, metadata.Tag.FirstAlbumArtist, metadata.Tag.Album, metadata.Tag.Genres.FirstOrDefault(), Duration, 0);
                SongManager.UploadSong(song);
            }

            //If the song exists and the user doesn't have the association to the song, create the association.
            bool UserSongExists = SongManager.GetSongList(username).Any(s => s.FilePath == fileName);
            if (!UserSongExists)
            {
                song = SongManager.GetSongModel(fileName);
                SongManager.AddSong(song, username);
            }


           
        }

    }
}
