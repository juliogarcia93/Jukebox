using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult Join()
        {
            return View();
        }

    }
}