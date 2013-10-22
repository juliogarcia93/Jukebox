using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult Save()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                string fileName = System.IO.Path.GetFileName(file.FileName);
                SongList model = new SongList(1,50);
                model.Add(fileName, file);
            }
            return RedirectToAction("Profile", "Account", new { username = User.Identity.Name });
        }
    }
}