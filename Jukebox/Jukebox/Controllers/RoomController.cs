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
            SongManager.AddRoom(room, username);
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
            return View("Create", room);
        }

        public ActionResult CreatePrivate(string RoomName, string password, string username)
        {
            return View();
        }
        

        public ActionResult SearchPublic()
        {
            List<RoomModel> rooms = SongManager.GetRoomList().Where( r => r.RoomPassword == "" || r.RoomPassword == null).Select(a => new RoomModel { RoomName = a.RoomName, RoomPassword = a.RoomPassword, Accounts = a.Accounts}).ToList<RoomModel>();
           return View("SearchPage", rooms);
        }
        
        public ActionResult RoomSelect(string RoomName)
        {
            RoomModel Room = SongManager.GetRoomModel(RoomName);
            AccountModel account = SongManager.GetAccountModel(User.Identity.Name);
            SongManager.AddRoomAccount(Room, account);
            return View("Create", Room);
        }

        public ActionResult RoomAccountList(string RoomName)
        {
            List<AccountModel> accounts = SongManager.GetRoomAccounts(RoomName);
            return PartialView("_AccountsPartial", accounts);
        }

        public void AddSongs(int[] Songid, RoomModel room)
        {
            int count = Songid.Count();
            for(int x = 0; x < count; x++)
            {
                room.Songs.Add(SongManager.GetSongList().Where(s => s.SongID == Songid[x]).Single());
            }
        }
    }
}