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
            //Starts the links to the dbsets to call and go through them
        }

//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Song/Music stuff --------------------//
//-----------------------------------------------------------------------------------//
        public IQueryable<SongModel> GetSongList()
        {
            return _context.Songs.Select(s => new SongModel
            {
                SongID = s.Id,
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
                    SongID = s.Id,
                    SongTitle = s.Title,
                    Artist = s.Artist,
                    Album = s.Album,
                    Genre = s.Genre,
                    FilePath = s.FilePath,
                    Length = s.Length
                });
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

        public void Delete(SongModel model, int loginID)
        {
            Account account = GetAccount(loginID);
            account.Songs.Remove(GetSong(model.SongID));
            _context.SaveChanges();

        }

        public Song GetSong(int songID)
        {
            return _context.Songs.Where(s => s.Id == songID).Single();
        }

        public SongModel FindSong(string name, string album)
        {
            return _context.Songs.Where(s => s.Title == name && s.Album == album)
                .Select(a => new SongModel
                {
                    SongID = a.Id,
                    SongTitle = a.Title,
                    Artist = a.Artist,
                    Album = a.Album,
                    Genre = a.Genre,
                    FilePath = a.FilePath,
                    Length = a.Length
                }).Single();

        }

        //Add song method for associating a current database song with a username
        public void AddSong(SongModel model, string username)
        {
            Account account = _context.Accounts.Where(s => s.Username == username).Single();
            Song song = _context.Songs.Where(s => s.Title == model.SongTitle && s.Length == model.Length).Single();
            //Song song = ModelConversions.SongModelToEntity(model);
            account.Songs.Add(song);
            song.Accounts.Add(account);
            _context.SaveChanges();
        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Account stuff -----------------------//
//-----------------------------------------------------------------------------------//
        public IQueryable<AccountModel> GetAccountsList()
        {
            return _context.Accounts.Select(a => new AccountModel
            {
                LoginId = a.LoginId,
                Username = a.Username
            });
        }

        public Boolean AccountExists(string username)
        {
            return _context.Accounts.Any(a => a.Username == username);
        }

        //Returns an account list of the room to display on the playlist
        public IQueryable<AccountModel> GetAccountsList(RoomModel room)
        {
            int roomId = GetRoomId(room);
            return _context.Accounts.Where(a => a.RoomId == roomId)
               .Select(a => new AccountModel
               {
                   LoginId = a.LoginId,
                   Username = a.Username
               });
        }

        public void AddAccount(string username)
        {
            Account account = ModelConversions.AccountModelToEntity(new AccountModel(_context.Accounts.Count() + 1, username));
            _context.Accounts.Add(account);
            _context.SaveChanges();

        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Room stuff --------------------------//
//-----------------------------------------------------------------------------------// 

        
        public int GetRoomId(RoomModel room)
        {
            return room.RoomId;
        }
        private Account GetAccount(int loginId)
        {
            return _context.Accounts.Where(a => a.LoginId == loginId).Single();
        }
              
                     
    }
}
