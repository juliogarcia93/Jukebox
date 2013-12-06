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
    /// <summary>
    /// Controller that allows music to interact with the Playlist Partials
    /// </summary>
    public class MusicController : Controller
    {

        SongManager SongManager = new SongManager();
        /// <summary>
        /// Saves a list of Songs to a user's profile
        /// </summary>
        /// <returns>Profilepage of current user</returns>
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

        /// <summary>
        /// Opens partial view that allows user to select songs to add to the room
        /// </summary>
        /// <param name="Username">User adding songs</param>
        /// <returns>PartialView of Add songs to room Partial</returns>
        public ActionResult UserSongs(string Username)
        {
            List<SongModel> songs = SongManager.GetSongList(Username);
            return PartialView("_AddToRoomPartial", songs);
        }

        /// <summary>
        /// Updates the Music player when an event occurs (i.e. pause, play, next)
        /// </summary>
        /// <param name="RoomId">Id of room where event has occured in player</param>
        /// <returns>Partial View of Music Player</returns>
        public PartialViewResult UpdatePlayer(int RoomId)
        {
            List<SongModel> songs = SongManager.GetRoomSongsList(RoomId);
            return PartialView("_MusicPlayerPartial", songs);
        }

        /// <summary>
        /// Update the Music Player on the Profile page when an event occurs
        /// </summary>
        /// <param name="Username">Username of user on profile page</param>
        /// <returns>Partial view of Music Player</returns>
        public PartialViewResult UpdateUserPlayer(string Username)
        {
            List<SongModel> songs = SongManager.GetSongList(Username);
            return PartialView("_MusicPlayerPartial", songs);
        }

        /// <summary>
        /// Increments likes when user likes a song on the playlist
        /// </summary>
        /// <param name="SongName">Songname of song that is liked</param>
        /// <param name="Album">Album associated with the song that was liked</param>
        /// <param name="RoomId">Id of the room where the song is</param>
        /// <returns>Partial View of the Songlist on the Room</returns>
        public PartialViewResult Like(string SongName, string Album, int RoomId)
        {
            SongModel song = SongManager.FindSong(SongName, Album);
            SongManager.IncrementLike(song); 
            List<SongModel> list = SongManager.GetRoomSongsList(RoomId);
            return PartialView("_RoomPlaylistPartial", list);

        }

    }
}