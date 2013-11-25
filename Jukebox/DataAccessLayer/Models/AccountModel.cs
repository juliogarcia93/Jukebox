using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    //-----------began to add lists to the constructors
    public class AccountModel
    {
        public AccountModel()
        {
            Username = null;
            Songs = new List<SongModel>();
            Room = new RoomModel();
            Room_Id = null;
            
        }

        public AccountModel(int id, string username)
        {
            LoginId = id;
            Username = username;
            Songs = new List<SongModel>();
            Room = new RoomModel();
            Room_Id = null;
        }


        public AccountModel(string username)
        {
            Username = username;
            Songs = new List<SongModel>();
            Room = new RoomModel();
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public RoomModel Room { get; set; }
        public List<SongModel> Songs { get; set; }
        public Nullable<int> Room_Id { get; set; }
        public List<PlaylistModel> Playlists { get; set; }
    }
}
