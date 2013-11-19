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
            List<SongModel> list = SongManager.GetSongList().ToList();
            return View(list);
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

        public ActionResult Delete(string SongName, string Album)
        {
            string Username = @User.Identity.Name;
            SongModel song = SongManager.FindSong(SongName, Album);
            SongManager.Delete(song, Username);

            return View("Profile");
        }
        //Function that will return the list of accounts to the view

        public PartialViewResult ListAccounts()
        {

            List<AccountModel> list = SongManager.GetAccountsList();
            return PartialView("_AccountsPartial", list);
        }
    }
}