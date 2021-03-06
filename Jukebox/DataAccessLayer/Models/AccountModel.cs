﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    //-----------began to add lists to the constructors
    public class AccountModel
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public RoomModel Room { get; set; }
        public List<SongModel> Songs { get; set; }
        public Nullable<int> Room_Id { get; set; }
        public List<PlaylistModel> Playlists { get; set; }
    }
}
