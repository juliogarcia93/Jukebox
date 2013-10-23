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
            entity.Artist = new Artist();
            entity.Genre = new Genre();
            entity.Album = new Album();
            entity.sLength = !string.IsNullOrEmpty(model.Length) ? model.Length : "";
            entity.sFilePath = !string.IsNullOrEmpty(model.FilePath) ? model.FilePath : "";
            entity.sTitle = !string.IsNullOrEmpty(model.SongTitle) ? model.SongTitle : "";
            entity.Genre.sName = !string.IsNullOrEmpty(model.Genre) ? model.Genre : "";
            entity.Artist.sName = !string.IsNullOrEmpty(model.Artist) ? model.Artist : "";
            entity.Album.sTitle = !string.IsNullOrEmpty(model.Album) ? model.Album : "";
            return entity;
        }

        public static Account AccountModelToEntity(AccountModel model)
        {
            Account entity = new Account();
            entity.LoginId = (int) model.LoginId;
            entity.Username = model.Username;
            return entity;
        }
    }
}
