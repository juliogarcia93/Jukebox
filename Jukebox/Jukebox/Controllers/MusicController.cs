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
    public class MusicController : Controller
    {

        SongManager SongManager = new SongManager();
        public ActionResult Save()
        {
            int songsUploadedSucessfully = 0;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string fileExtension = System.IO.Path.GetExtension(file.FileName);
                bool isValidFormat = fileExtension == ".mp3" || fileExtension == ".m4a" ? true : false;
                if (isValidFormat)
                {
                    SongList model = new SongList(1, 100);
                    model.Add(User.Identity.Name, fileName, file);
                    ++songsUploadedSucessfully;
                }
            }
            if (songsUploadedSucessfully > 0)
            {
                if (songsUploadedSucessfully == 1)
                {
                    TempData["message"] = "You have successfully added " + songsUploadedSucessfully + " song to your profile!";
                }
                else
                {
                    TempData["message"] = "You have successfully added " + songsUploadedSucessfully + " songs to your profile!";
                }
            }
            else
            {
                TempData["error"] = "Whoops! Something went wrong. Please try uploading your music again.";
            }
            return RedirectToAction("Profile", "Account", new { username = User.Identity.Name });
        }

        public ActionResult UserSongs(string Username)
        {
            List<SongModel> songs = SongManager.GetSongList(Username).ToList();
            return PartialView("_AddToRoomPartial", songs);
        }

        public PartialViewResult UpdatePlayer(int RoomId)
        {
            List<SongModel> songs = SongManager.GetRoomSongsList(RoomId);
            return PartialView("_MusicPlayerPartial", songs);
        }

        public PartialViewResult UpdateUserPlayer(string Username)
        {
            List<SongModel> songs = SongManager.GetSongList(Username).OrderByDescending(s => s.SongID).ToList();
            return PartialView("_MusicPlayerPartial", songs);
        }

        public PartialViewResult Like(string SongName, string Album, int RoomId)
        {
            SongModel song = SongManager.FindSong(SongName, Album);
            SongManager.IncrementLike(song); 
            List<SongModel> list = SongManager.GetRoomSongsList(RoomId).OrderByDescending(s => s.Likes).ToList();
            return PartialView("_RoomPlaylistPartial", list);

        }

        public PartialViewResult Edit(string oldSong, string oldAlbum, string song, string artist, string album)
        {
            SongModel songModel = SongManager.FindSong(oldSong, oldAlbum);
            songModel.SongTitle = song;
            songModel.Artist = artist;
            songModel.Album = album;
            SongManager.EditSong(songModel);
            return null;
        }

    }
}