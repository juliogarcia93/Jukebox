using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer.Models;

namespace DataAccessLayer.Conversions
{
    public class ModelConversions
    {
        public static Song SongModelToEntity(SongModel model)
        {
            Song entity = new Song();
            entity.Length = !string.IsNullOrEmpty(model.Length) ? model.Length : "(Unknown Length)";
            entity.FilePath = !string.IsNullOrEmpty(model.FilePath) ? model.FilePath : "(Unknown Filepath)";
            entity.Title = !string.IsNullOrEmpty(model.SongTitle) ? model.SongTitle : System.IO.Path.GetFileNameWithoutExtension(model.FilePath);
            entity.Genre = !string.IsNullOrEmpty(model.Genre) ? model.Genre : "(Unknown Genre)";
            entity.Artist = !string.IsNullOrEmpty(model.Artist) ? model.Artist : "(Unknown Artist)";
            entity.Album = !string.IsNullOrEmpty(model.Album) ? model.Album : "(Unknown Album)";
            return entity;
        }

        public static Account AccountModelToEntity(AccountModel model)
        {
            Account entity = new Account();
            entity.Username = model.Username;
            //entity.Room = RoomModelToEntity(model.Room);
            return entity;
        }

        public static Room RoomModelToEntity(RoomModel model)
        {
            Room entity = new Room();
            entity.RoomName = !string.IsNullOrEmpty(model.RoomName) ? model.RoomName : "";
            entity.RoomPassword = !string.IsNullOrEmpty(model.RoomPassword) ? model.RoomPassword : "";
            return entity;
        }
    }
}
