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
        SongManager SongManager = new SongManager();
        public ActionResult Create(string username)
        {
            IdentityDbContext _context = new IdentityDbContext();
            //SongManager SongManager = new SongManager();
            RoomModel room = new RoomModel();
            room.Songs = SongManager.GetSongList(username).ToList();
           //List<SongModel> list = SongManager.GetSongList(username).ToList();
            return View(room);
        }

        public ActionResult Join()
        {
            return View();
        }

        public PartialViewResult Search(string query)
        {
            List<SongModel> results = SongManager.Search(query, SongManager.GetSongList()).ToList();
            return PartialView("_PlaylistPartial", results);
        }

        public ActionResult AddSongsToRoom(List<SongModel> songs, RoomModel room)
        {
            SongManager.AddSongsToList(songs, room.Songs);
            return View(room);
        }


    }
}