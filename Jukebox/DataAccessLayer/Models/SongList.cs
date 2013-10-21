﻿using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public void Add(SongModel song, HttpPostedFileBase file)
        {
            string MusicDirectory = HttpContext.Current.Server.MapPath("~/Music/");
            file.SaveAs(MusicDirectory + song.FilePath);
            SongManager.UploadSong(song);
        }
    
    }
}