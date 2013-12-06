using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataAccessLayer.Conversions;
using Amazon;
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

            string imagesDir = HttpContext.Current.Server.MapPath("~/Music/");

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

            var images = GetSongList();

            this.AddRange(images.Skip((pageNum - 1) *
                pageSize).Take(pageSize).ToList());
        }

        public void Add(string username, string fileName, HttpPostedFileBase file)
        {
            SongModel song;
            string MusicDirectory = HttpContext.Current.Server.MapPath("~/Music/") + fileName;
            file.SaveAs(MusicDirectory);
 			bool songExists = SongManager.GetSongList().Any(s => s.FilePath == fileName);            
            if (!songExists)
            {
                //AmazonWebServices AmazonWebServices = new AmazonWebServices();
                //AmazonWebServices.Upload(file);
                //string MusicDirectory = AmazonWebServices.GetObjectUrl(fileName);
                //string MusicDirectory = "https://s3-us-west-1.amazonaws.com/jukeboxmusic/" + fileName;
                TagLib.File metadata = TagLib.File.Create(MusicDirectory);
                //var AlbumArtwork = metadata.Tag.Pictures.FirstOrDefault();
                //ImageConversion.byteArrayToImage((byte[])AlbumArtwork.Data);
                string Duration = metadata.Properties.Duration.ToString(@"mm\:ss");
                song = new SongModel(username, fileName, metadata.Tag.Title, metadata.Tag.FirstAlbumArtist, metadata.Tag.Album, metadata.Tag.Genres.FirstOrDefault(), Duration, 0);
                SongManager.UploadSong(song);
            }
            bool UserSongExists = SongManager.GetSongList(username).Any(s => s.FilePath == fileName);
            if (!UserSongExists)
            {
                song = SongManager.GetSongModel(fileName);
                SongManager.AddSong(song, username);
            }


           
        }

    }
}
