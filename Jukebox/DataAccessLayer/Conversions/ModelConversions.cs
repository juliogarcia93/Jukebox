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
            Artist artist = new Artist();
            Genre genre = new Genre();
            Album album = new Album();
            entity.sLength = !string.IsNullOrEmpty(model.Length) ? model.Length : "(Unknown Length)";
            entity.sFilePath = !string.IsNullOrEmpty(model.FilePath) ? model.FilePath : "(Unknown Filepath)";
            entity.sTitle = !string.IsNullOrEmpty(model.SongTitle) ? model.SongTitle : System.IO.Path.GetFileNameWithoutExtension(model.FilePath);
            genre.sName = !string.IsNullOrEmpty(model.Genre) ? model.Genre : "(Unknown Genre)";
            artist.sName = !string.IsNullOrEmpty(model.Artist) ? model.Artist : "(Unknown Artist)";
            album.sTitle = !string.IsNullOrEmpty(model.Album) ? model.Album : "(Unknown Album)";
            entity.Artists.Add(artist);
            entity.Genres.Add(genre);
            entity.Albums.Add(album);
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
