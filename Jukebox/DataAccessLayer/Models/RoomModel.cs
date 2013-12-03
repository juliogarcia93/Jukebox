using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Models
{
    public class RoomModel
    {
        public RoomModel ()
        {
            RoomName = null;
            RoomPassword = null;
            Songs = new List<SongModel>();
            Accounts = new List<AccountModel>();
            Privacy = "public";
        }
        public RoomModel(string roomname)
        {
            RoomName = roomname;
            RoomPassword = null;
            Songs = new List<SongModel>();
            Accounts = new List<AccountModel>();
            Privacy = "public";
        }
        public RoomModel(string roomname, string password)
        {
            RoomName = roomname;
            RoomPassword = password;
            Songs = new List<SongModel>();
            Accounts = new List<AccountModel>();
            Privacy = "private";
        }

        public RoomModel(string roomname, string password, List<SongModel> songs, List<AccountModel> accounts)
        {
            RoomName = roomname;
            RoomPassword = password;
            Songs = songs;
            Accounts = accounts;
            Privacy = "private";
        }

        public string RoomPassword { get; set; }
        public string RoomName { get; set; }
        public List<SongModel> Songs { get; set; }
        public List<AccountModel> Accounts { get; set; }
        public int RoomId { get; set; }
        public string Privacy { get; set; }
    }
}