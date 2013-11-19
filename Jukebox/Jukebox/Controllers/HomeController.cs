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
    public class HomeController : Controller
    {
        SongManager SongManager = new SongManager();
        public ActionResult Index()
        {
            return View();
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