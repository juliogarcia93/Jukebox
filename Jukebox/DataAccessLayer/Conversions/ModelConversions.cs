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
            entity.Genre = new Genre();
            entity.Album = new Album();
            entity.Artist = new Artist();
            entity.sTitle = model.SongTitle;
            entity.sLength = model.Length;
            entity.sFilePath = model.FilePath;
            entity.Genre.sName = model.Genre;
            entity.Artist.sName = model.Artist;
            entity.Album.sTitle = model.Album;
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
