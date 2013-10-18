using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jukebox.Controllers
{
    public class MusicController : Controller
    {
        public ActionResult Upload()
        {
            return View();
        }

        //public ActionResult Save()
        //{
        //    for (int i = 0; i < Request.Files.Count; i++)
        //    {
        //        var file = Request.Files[i];

        //        string fileName = System.IO.Path.GetFileName(file.FileName);
        //        Song song = new Song(fileName, Request["songTitle"], Request["artist"], Request["album"], Request["genre"]);

        //        SongList model = new SongList();
        //        model.Add(song, file);
        //    }
        //    return RedirectToAction("Index", new { page = 1, category = Request["category"] });
        //}
    }
}