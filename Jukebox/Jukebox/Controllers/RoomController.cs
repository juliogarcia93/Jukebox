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
    /// Controller that allows Rooms to interact with the Business Logic layer
    /// </summary>
    public class RoomController : Controller
    {
        SongManager SongManager = new SongManager();

        /// <summary>
        /// Creates a New Room
        /// </summary>
        /// <returns>Create View</returns>
        public ActionResult CreateRoom()
        {
            string privacy = Request["privacy"].ToLower();
            string RoomNamePublic = Request["roomnamepublic"];
            string RoomNamePrivate = Request["roomnameprivate"];
            string Password = Request["roompassword"];
            string Genre = Request["genre"];
            string username = User.Identity.Name;

            if (privacy == "1")
            {
                RoomModel room = new RoomModel(RoomNamePublic);
                SongManager.AddRoom(room, User.Identity.Name);
                AccountModel user = SongManager.GetAccountModel(username);
                room = SongManager.GetRoomModel(RoomNamePublic);
                room.Accounts = SongManager.GetRoomAccounts(room.RoomName);
                room.Accounts.Add(user);
                
                return View("Create", room);
            }
            else
            {
                RoomModel room = new RoomModel(RoomNamePrivate, Password);
                SongManager.AddRoom(room, User.Identity.Name);
                AccountModel user = SongManager.GetAccountModel(username);
                room = SongManager.GetRoomModel(RoomNamePrivate);
                room.Accounts = SongManager.GetRoomAccounts(room.RoomName);
                room.Accounts.Add(user);
                return View("Create", room);
            }
        }

       /// <summary>
       /// Searches for a private room
       /// </summary>
       /// <returns>View of Search page or Create a room page</returns>
        public ActionResult SearchRoom()
        {
            string privacy = Request["privacy"];
            string RoomName = Request["roomname"];
            string Password = Request["password"];
            string Genre = Request["genre"];
            string username = User.Identity.Name;

            if (privacy == "1")
            {
                List<RoomModel> rooms = SongManager.GetRoomList().Where(r => r.Privacy == "public")
                    .Select(a => new RoomModel 
                    { 
                        RoomName = a.RoomName, 
                        RoomPassword = a.RoomPassword, 
                        Accounts = a.Accounts
                    }).OrderBy(r => r.RoomName).ToList();
               
                return View("SearchPage", rooms);
            }
            else
            {
                RoomModel room = SongManager.GetRoomList().Where(r => r.RoomName == RoomName && r.RoomPassword == Password).Single();
                return View("Create", room);
            }
        }

        /// <summary>
        /// Finds and returns a room based on the RoomName
        /// </summary>
        /// <param name="RoomName">RoomName for room being searched</param>
        /// <returns>Create view</returns>
        public ActionResult RoomSelect(string RoomName)
        {
            RoomModel Room = SongManager.GetRoomModel(RoomName);
            AccountModel account = SongManager.GetAccountModel(User.Identity.Name);
            SongManager.AddRoomAccount(Room, account);
            Room.Songs = SongManager.GetRoomSongsList(Room.RoomId);
            return View("Create", Room);
        }

        /// <summary>
        /// Finds all the Accounts in a room and displays them on the Accounts Partial
        /// </summary>
        /// <param name="RoomName">Name of Room with accounts list</param>
        /// <returns>PartialView for Accounts</returns>
        public ActionResult RoomAccountList(string RoomName)
        {
            List<AccountModel> accounts = SongManager.GetRoomAccounts(RoomName);
            return PartialView("_AccountsPartial", accounts);
        }

        /// <summary>
        /// Adds Songs to Room
        /// </summary>
        /// <param name="SongList">List of songs being added</param>
        /// <param name="RoomId">Id of room where songs are being added</param>
        /// <returns>Partial View of Room Playlist</returns>
        public PartialViewResult AddSongs(int[] SongList, int RoomId)
        {
            SongManager.AddSongsToRoom(SongList, RoomId);
            List<SongModel> list = SongManager.GetRoomSongsList(RoomId);
            return PartialView("_RoomPlaylistPartial", list);
        }

        /// <summary>
        /// Removes a user from a room
        /// </summary>
        /// <param name="RoomName">Name of Room that user is leaving</param>
        /// <returns>Profile of User</returns>
        public ActionResult LeaveRoom(string RoomName)
        {
            string username = User.Identity.Name;
            RoomModel room = SongManager.GetRoomModel(RoomName);
            SongManager.DeleteAccount(room, username);
            AccountModel account = SongManager.GetAccountModel(User.Identity.Name);
            return RedirectToAction("Profile", "Account", account);
        }
    }
}