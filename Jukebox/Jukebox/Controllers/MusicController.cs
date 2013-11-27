using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Jukebox.Models;
using DataAccessLayer.Models;
using Entities;
using DataAccessLayer.BusinessLogic;

namespace Jukebox.Controllers
{
    public class MusicController : Controller
    {

        SongManager SongManager = new SongManager();
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

        public ActionResult UserSongs(string Username)
        {
            List<SongModel> songs = SongManager.GetSongList(Username);
            return PartialView("_AddToRoomPartial", songs);
        }

    }
}