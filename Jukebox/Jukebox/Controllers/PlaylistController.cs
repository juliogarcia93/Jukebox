using DataAccessLayer.BusinessLogic;
using DataAccessLayer.Models;
using Jukebox.Models;
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
        public ActionResult Create(string username)
        {
            IdentityDbContext _context = new IdentityDbContext();
            SongManager SongManager = new SongManager();
            List<SongModel> list = SongManager.GetSongList().ToList();
            return View(list);
        }

        public ActionResult Join()
        {
            return View();
        }

    }
}