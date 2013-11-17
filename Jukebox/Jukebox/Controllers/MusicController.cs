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
         

        public ActionResult Save()
        {

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                string fileName = System.IO.Path.GetFileName(file.FileName);
                bool isMP3 = System.IO.Path.GetExtension(file.FileName) == ".mp3" ? true : false;
                if (isMP3)
                {
                    SongList model = new SongList(1, 100);
                    model.Add(User.Identity.Name, fileName, file);
                }
            }
            return RedirectToAction("Profile", "Account", new { username = User.Identity.Name });
        }


    }
}