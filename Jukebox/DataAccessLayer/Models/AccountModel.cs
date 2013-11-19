using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class AccountModel
    {
        public AccountModel()
        {
            Username = null;
        }

        public AccountModel(int id, string username)
        {
            LoginId = id;
            Username = username;

        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public Nullable<int> RoomId { get; set; }
        public List<SongModel> Songs { get; set; }
        public List<PlaylistModel> Playlists { get; set; }
    }
}
