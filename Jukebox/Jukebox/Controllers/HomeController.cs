
using DataAccessLayer.BusinessLogic;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jukebox.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SongRepository _context = new SongRepository();
            List<SongModel> TopSongs = _context.GetTopSongs(6).ToList();
            return View(TopSongs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "A little about Jukebox";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacts";

            return View();
        }

        public ActionResult Playlist()
        {
            return View();
        }
      
    }
}