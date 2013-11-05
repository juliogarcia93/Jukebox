using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer.Conversions;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DataAccessLayer.Repositories
{
    public class SongRepository : IDisposable
    {
        private MusicContainer _context { get; set; }

        public SongRepository()
        {
            _context = new MusicContainer();
        }

        public IQueryable<GenreModel> GetGenreList()
        {
            return _context.Genres.Select(g => new GenreModel
            {
                Id = g.Id,
                sName = g.sName
            });
        }

        public IQueryable<AlbumModel> GetAlbumList()
        {
            return _context.Albums.Select(a => new AlbumModel
                {
                    sTitle = a.sTitle
                });
        }
        public IQueryable<SongModel> GetSongList()
        {
            return _context.Songs.Select(s => new SongModel
            {
                SongTitle = s.sTitle,
                Artist = s.Artists.FirstOrDefault().sName,
                Album = s.Albums.FirstOrDefault().sTitle,
                Genre = s.Genres.FirstOrDefault().sName,
                FilePath = s.sFilePath,
                Length = s.sLength
            });
        }

        public IQueryable<SongModel> GetSongList(int loginId)
        {
            return _context.Songs.Where(s => s.Accounts.Any(u => u.LoginId == loginId))
                .Select(s => new SongModel
                {
                    SongTitle = s.sTitle,
                    Artist = s.Artists.FirstOrDefault().sName,
                    Album = s.Albums.FirstOrDefault().sTitle,
                    Genre = s.Genres.FirstOrDefault().sName,
                    FilePath = s.sFilePath,
                    Username = s.Accounts.Where(a => a.LoginId == loginId).First().Username
                });
        }

        public IQueryable<ArtistModel> GetArtistList()
        {
            return _context.Artists.Select(a => new ArtistModel
            {
                Id = a.Id,
                sName = a.sName
            });
        }

        public IQueryable<AccountModel> GetAccountsList()
        {
            return _context.Accounts.Select(a => new AccountModel
                {
                    LoginId = a.LoginId,
                    Username = a.Username
                });
        }

        public Account GetAccount(int loginId)
        {
            return _context.Accounts.Where(a => a.LoginId == loginId).Single();
        }

        public Account GetAccount(string username)
        {
            return _context.Accounts.Where(a => a.Username == username).Single();
        }

        public Artist GetArtist(string artist)
        {
            return _context.Artists.Where(a => a.sName == artist).Single();
        }

        public Genre GetGenre(string genre)
        {
            return _context.Genres.Where(g => g.sName == genre).Single();
        }

        public Album GetAlbum(string album)
        {
            return _context.Albums.Where(a => a.sTitle == album).Single();
        }

        public void Add(SongModel model)
        {
            try
            {
                Song entity = ModelConversions.SongModelToEntity(model);
                _context.Songs.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
