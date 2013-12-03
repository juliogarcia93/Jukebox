﻿using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            string MusicDirectory = HttpContext.Current.Server.MapPath("~/Music/") + fileName;
            //string MusicDirectory = Path.GetFileName(file.FileName);
            TagLib.File metadata = TagLib.File.Create(MusicDirectory);
            string Duration = metadata.Properties.Duration.ToString(@"mm\:ss");
            SongModel song = new SongModel(username, fileName, metadata.Tag.Title, metadata.Tag.FirstAlbumArtist, metadata.Tag.Album, metadata.Tag.Genres.FirstOrDefault(), Duration, 0);
            bool songExists = SongManager.GetSongList().Any(s => s.SongTitle == song.SongTitle && s.Length == song.Length);
            if (!songExists)
            {
                AmazonWebServices AmazonWebServices = new AmazonWebServices();
                AmazonWebServices.Upload(file);
                SongManager.UploadSong(song);
            }
            bool UserSongExists = SongManager.GetSongList(username).Any(s => s.SongTitle == song.SongTitle && s.Length == song.Length);
            if (!UserSongExists)
            {
                SongManager.AddSong(song, username);
            }

           
        }

    }
}
