using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jukebox.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        public ActionResult Create()
        {
           /// RoomModal room = new RoomModal( Request.RequestType.ToString() );
           /// return RedirectToAction("Create", "Playlist", new { username = User.Identity.Name });
            return View();
        }

        public ActionResult Join()
        {
            return View();
        }

    }
}