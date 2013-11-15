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

        //public IQueryable<GenreModel> GetGenreList()
        //{
        //    return _context.Genres.Select(g => new GenreModel
        //    {
        //        Id = g.Id,
        //        sName = g.sName
        //    });
        //}
        public IQueryable<SongModel> GetSongList()
        {
            return _context.Songs.Select(s => new SongModel
            {
                SongTitle = s.Title,
                Artist = s.Artist,
                Album = s.Album,
                Genre = s.Genre,
                FilePath = s.FilePath,
                Length = s.Length
            });
        }

        public IQueryable<SongModel> GetSongList(int loginId)
        {
            return _context.Songs.Where(s => s.Accounts.Any(u => u.LoginId == loginId))
                .Select(s => new SongModel
                {
                    SongTitle = s.Title,
                    Artist = s.Artist,
                    Album = s.Album,
                    Genre = s.Genre,
                    FilePath = s.FilePath,
                    Length = s.Length
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
                Account account;
                Song entity = ModelConversions.SongModelToEntity(model);
                if (_context.Accounts.Any(a => a.Username == model.Username))
                {
                    account = _context.Accounts.First(a => a.Username == model.Username);
                }
                else
                {
                    account = new Account() { Username = model.Username };
                }
                entity.Accounts.Add(account);
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
