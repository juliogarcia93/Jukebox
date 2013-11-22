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
    public class RoomController : Controller
    {
        SongManager SongManager = new SongManager();
        public ActionResult CreatePublic(string RoomName, string username)
        {
            IdentityDbContext _context = new IdentityDbContext();
            RoomModel room = new RoomModel(username);
            SongManager.CreateARoom(room, username);
            return View("Create", room);
        }

        public ActionResult CreatePrivate(string RoomName, string password, string username)
        {
            return View();
        }


        public ActionResult Join()
        {
            return View();
        }

    }
}