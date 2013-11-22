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
        SongManager SongManager = new SongManager();
        public RoomModel()
        {
            RoomName = "Rachet 2013";
            Privacy = "Private";
            Accounts = new List<AccountModel>();
            Songs = new List<SongModel>();
        }
        public RoomModel(string roomname)
        {
            RoomName = roomname;
            Accounts = new List<AccountModel>();
            Songs = new List<SongModel>();
        }
        public RoomModel(string roomname, string password)
        {
            RoomName = roomname;
            RoomPassword = password;
            Accounts = new List<AccountModel>();
            Songs = new List<SongModel>();
        }

        public string RoomPassword { get; set; }
        public string RoomName { get; set; }
        public string Privacy { get; set; }
        public List<SongModel> Songs { get; set; }
        public List<AccountModel> Accounts { get; set; }
        public int RoomId { get; set; }

        public List<SongModel> GetSongs(string username)
        {
            return SongManager.GetAccountModel(username).Songs;
        }

    }
}