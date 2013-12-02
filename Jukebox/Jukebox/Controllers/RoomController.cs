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


        public ActionResult CreatePublic(RoomViewModel model)
        {
            string username = User.Identity.Name;
            RoomModel room = new RoomModel(model.RoomName);
            SongManager.AddRoom(room, User.Identity.Name);
            AccountModel user = SongManager.GetAccountModel(username);
            room = SongManager.GetRoomModel(username);
            room.Accounts = SongManager.GetRoomAccounts(room.RoomName);
            room.Accounts.Add(user);
            foreach (AccountModel account in room.Accounts)
            {
                if (account.Songs.Count() > 0)
                {
                    room.Songs.AddRange(account.Songs);
                }
            }
            if (room.Songs == null)
            {
                room.Songs = new List<SongModel>();
            }
            //if (Request.IsAjaxRequest())
            //{
            //    return Json(new { redirectToUrl = Url.View("Create", room) });
            //}
            return View("Create", room);
        }

        public ActionResult CreatePrivate(string RoomName, string password, string username)
        {
            return View();
        }
        

        public ActionResult SearchPublic()
        {
            List<RoomModel> rooms = SongManager.GetRoomList().Where( r => r.RoomPassword == "" || r.RoomPassword == null).Select(a => new RoomModel { RoomName = a.RoomName, RoomPassword = a.RoomPassword, Accounts = a.Accounts}).ToList<RoomModel>();
            foreach (RoomModel room in rooms)
            {
                room.Songs = SongManager.GetRoomSongsList(room.RoomId);
            }
           return View("SearchPage", rooms);
        }
        
        public ActionResult RoomSelect(string RoomName)
        {
            RoomModel Room = SongManager.GetRoomModel(RoomName);
            AccountModel account = SongManager.GetAccountModel(User.Identity.Name);
            SongManager.AddRoomAccount(Room, account);
            Room.Songs = SongManager.GetRoomSongsList(Room.RoomId);
            return View("Create", Room);
        }

        public ActionResult RoomAccountList(string RoomName)
        {
            List<AccountModel> accounts = SongManager.GetRoomAccounts(RoomName);
            return PartialView("_AccountsPartial", accounts);
        }

        public PartialViewResult AddSongs(int[] SongList, int RoomId)
        {
            SongManager.AddSongsToRoom(SongList, RoomId);
            List<SongModel> list = SongManager.GetRoomSongsList(RoomId);
            return PartialView("_RoomPlaylistPartial", list);
        }
    }
}