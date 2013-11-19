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
            RoomName = "Rachet 2013";
            isPublic = false;
        }
        public RoomModel(string roomname)
        {
            RoomName = roomname;
        }
        public RoomModel(string roomname, string password)
        {
            RoomName = roomname;
            RoomPassword = password;
        }

        public string RoomPassword { get; set; }
        public string RoomName { get; set; }
        public bool isPublic { get; set; } 
        public List<SongModel> Songs { get; set; }
        public List<AccountModel> Accounts { get; set; }
        public int RoomId { get; set; }
    }
}