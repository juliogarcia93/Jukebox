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
    public class SongRepository
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
        public IQueryable<SongModel> GetSongList()
        {
            return _context.Songs.Select(s => new SongModel
            {
                SongTitle = s.sTitle,
                Artist = s.Artist.sName,
                Album = s.Album.sTitle,
                Genre = s.Genre.sName,
                FilePath = s.sFilePath
            });
        }

        public IQueryable<SongModel> GetSongList(int loginId)
        {
            return _context.Songs.Where(s => s.Users.Any(u => u.LoginId == loginId))
                .Select(s => new SongModel
                {
                    SongTitle = s.sTitle,
                    Artist = s.Artist.sName,
                    Album = s.Album.sTitle,
                    Genre = s.Genre.sName,
                    FilePath = s.sFilePath
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

        private Account GetAccount(int loginId)
        {
            return _context.Accounts.Where(a => a.LoginId == loginId).Single();
        }

        public void Add(SongModel model)
        {
            try
            {
                Song entity = ModelConversions.SongModelToEntity(model);
                _context.Artists.Add(entity.Artist);
                _context.Genres.Add(entity.Genre);
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

    }
}
