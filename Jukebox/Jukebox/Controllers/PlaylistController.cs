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
    /// <summary>
    /// Controller that allows the Playlist to interact with the Buisness Logic layer
    /// </summary>
    [Authorize]
    public class PlaylistController : Controller
    {
        SongManager SongManager = new SongManager();

        /// <summary>
        /// Searches for all the songs that match any part of the query
        /// </summary>
        /// <param name="query">query that user enters to search through songlist</param>
        /// <returns>PartialView of the Playlist</returns>
        public PartialViewResult Search(string username, string query)
        {
            List<SongModel> results = SongManager.Search(query, SongManager.GetSongList(username).OrderByDescending(s => s.SongID).AsQueryable()).ToList();
            return PartialView("_PlaylistPartial", results);
        }

        /// <summary>
        /// Gets a list of account associated with a room
        /// </summary>
        /// <returns>PartialView of the total list of accounts</returns>
        public PartialViewResult ListAccounts()
        {
            IdentityDbContext _context = new IdentityDbContext();
            //SongManager SongManager = new SongManager();
            List<AccountModel> list = SongManager.GetRoomAccounts(User.Identity.Name);
            return PartialView("_AccountsPartial", list);
        }


        /// <summary>
        /// Deletes a song associated with a user
        /// </summary>
        /// <param name="SongName">Name of the song being deleted</param>
        /// <param name="Album">Name of the album associated with the song being deleted</param>
        /// <returns>Profile View</returns>
        public ActionResult Delete(string SongName, string Album)
        {
            string Username = User.Identity.Name;
            SongModel song = SongManager.FindSong(SongName, Album);
            SongManager.Delete(song, Username);

            return View("Profile");
        }

        
    }
}