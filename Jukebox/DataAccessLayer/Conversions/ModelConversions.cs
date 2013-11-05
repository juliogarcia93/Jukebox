using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.Conversions
{
    public class ModelConversions
    {
        public static Song SongModelToEntity(SongModel model)
        {
            using (var _context = new SongRepository())
            {
                bool artistExists = _context.GetArtistList().Any(a => a.sName == model.Artist);
                bool genreExists = _context.GetGenreList().Any(g => g.sName == model.Genre);
                bool albumExists = _context.GetAlbumList().Any(a => a.sTitle == model.Album);
                bool accountExists = _context.GetAccountsList().Any(a => a.Username == model.Username);

                Song entity = new Song();
                Artist artist;
                Genre genre;
                Album album;
                Account account;

                //Song
                entity.sLength = !string.IsNullOrEmpty(model.Length) ? model.Length : "(Unknown Length)";
                entity.sFilePath = !string.IsNullOrEmpty(model.FilePath) ? model.FilePath : "(Unknown Filepath)";
                entity.sTitle = !string.IsNullOrEmpty(model.SongTitle) ? model.SongTitle : System.IO.Path.GetFileNameWithoutExtension(model.FilePath);

                //Artist
                if (artistExists)
                {
                    artist = _context.GetArtist(model.Artist);
                }
                else
                {
                    artist = new Artist();
                    artist.sName = !string.IsNullOrEmpty(model.Artist) ? model.Artist : "(Unknown Artist)";
                }

                //Genre
                if (genreExists)
                {
                    genre = _context.GetGenre(model.Genre);
                }
                else
                {
                    genre = new Genre();
                    genre.sName = !string.IsNullOrEmpty(model.Genre) ? model.Genre : "(Unknown Genre)";
                }

                //Album
                if (albumExists)
                {
                    album = _context.GetAlbum(model.Album);
                }
                else
                {
                    album = new Album();
                    album.sTitle = !string.IsNullOrEmpty(model.Album) ? model.Album : "(Unknown Album)";

                }

                //Account
                if (accountExists)
                {
                    account = _context.GetAccount(model.Username);
                }
                else
                {
                    account = new Account();
                    account.Username = !string.IsNullOrEmpty(model.Username) ? model.Username : "(Unknown User)";
                }

                //Add associations to the Song
                entity.Artists.Add(artist);
                entity.Genres.Add(genre);
                entity.Albums.Add(album);
                entity.Accounts.Add(account);
                return entity;
            }
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
