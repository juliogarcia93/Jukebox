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
    /// <summary>
    /// Direct communication with the database. Tables include songs, artists, rooms, accounts etc.
    /// </summary>
    public class SongRepository
    {
        private MusicContainer _context { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SongRepository()
        {
            _context = new MusicContainer();
            //Starts the links to the dbsets to call and go through them
        }

        //-----------------------------------------------------------------------------------//
        //-------------------------------The Things for Song/Music stuff --------------------//
        //-----------------------------------------------------------------------------------//

        /// <summary>
        /// Gets a list of all the songs in the database
        /// </summary>
        /// <returns>IQueryable of SongModels</returns>
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
                Length = s.Length,
                Likes = s.Likes
            });
        }

        /// <summary>
        /// Gets all the songs associated with a user
        /// </summary>
        /// <param name="loginId">LoginID of user</param>
        /// <returns>IQueryable of SongModels</returns>
        public IQueryable<SongModel> GetSongList(int loginId)
        {
            return _context.Songs.Where(s => s.Accounts.Any(a => a.LoginId == loginId) == true )
                .Select(s => new SongModel
                {
                    SongID = s.Id,
                    SongTitle = s.Title,
                    Artist = s.Artist,
                    Album = s.Album,
                    Genre = s.Genre,
                    FilePath = s.FilePath,
                    Length = s.Length,
                    Likes = s.Likes
                });
        }

        /// <summary>
        /// Gets a list of top songs based on the number of likes.
        /// </summary>
        /// <param name="numberOfSongs">The size of the list desired.</param>
        /// <returns>List of SongModels</returns>
        public IQueryable<SongModel> GetTopSongs(int numberOfSongs)
        {
            return _context.Songs.OrderByDescending(s => s.Likes)
                .Take(numberOfSongs)
                .Select(s => new SongModel
                {
                    SongID = s.Id,
                    SongTitle = s.Title,
                    Artist = s.Artist,
                    Genre = s.Genre,
                    Likes = s.Likes
                });
        }

        /// <summary>
        /// Adds songs to the database
        /// </summary>
        /// <param name="model">SongModel of song being added</param>
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

        /// <summary>
        /// Deletes a song asssociated with a user
        /// </summary>
        /// <param name="model">SongModel of Song being deleted</param>
        /// <param name="loginID">LoginId of user deleting song</param>
        public void Delete(SongModel model, int loginID)
        {
            Account account = GetAccount(loginID);
            account.Songs.Remove(GetSong(model.SongID));
            _context.SaveChanges();

        }


        /// <summary>
        /// Gets a Song entity from a songID
        /// </summary>
        /// <param name="songID">Id of song</param>
        /// <returns>Song entity</returns>
        public Song GetSong(int songID)
        {
            return _context.Songs.Where(s => s.Id == songID).Single();
        }

        /// <summary>
        /// Finds a song based on name and album
        /// </summary>
        /// <param name="name">Name of song</param>
        /// <param name="album">Name of album associated with song</param>
        /// <returns>SongModel of song</returns>
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
                    Length = a.Length,
                    Likes = a.Likes
                }).Single();

        }

        /// <summary>
        /// Add song method for associating a current database song with a username
        /// </summary>
        /// <param name="model">SongModel of song being added</param>
        /// <param name="username">username of user adding song</param>
        public void AddSong(SongModel model, string username)
        {
            Account account = _context.Accounts.Where(s => s.Username == username).Single();
            Song song = _context.Songs.Where(s => s.Title == model.SongTitle && s.Length == model.Length).Single();
            //Song song = ModelConversions.SongModelToEntity(model);
            account.Songs.Add(song);
            song.Accounts.Add(account);
            _context.SaveChanges();
        }

        /// <summary>
        /// Increments the Likes for a song
        /// </summary>
        /// <param name="songId">songId of song being liked</param>
        public void IncrementLike(int songId)
        {
            Song song = _context.Songs.Where(s => s.Id == songId).Single();
            song.Likes++;
            _context.SaveChanges();
        }


        //-----------------------------------------------------------------------------------//
        //-------------------------------The Things for Account stuff -----------------------//
        //-----------------------------------------------------------------------------------//


        /// <summary>
        /// Returns an Account entity for a loginId
        /// </summary>
        /// <param name="loginId">loginId of user account</param>
        /// <returns>Account entity</returns>
        private Account GetAccount(int loginId)
        {
            return _context.Accounts.Where(a => a.LoginId == loginId).Single();
        }

        /// <summary>
        /// Gets a list of all the Accounts in the database
        /// </summary>
        /// <returns>IQueryable of AccountModels</returns>
        public IQueryable<AccountModel> GetAccountsList()
        {
            return _context.Accounts.Select(a => new AccountModel
            {
                LoginId = a.LoginId,
                Username = a.Username
            });
        }

        /// <summary>
        /// Checks to see if Account Exists
        /// </summary>
        /// <param name="username">Username of account being checked</param>
        /// <returns>Boolean of whether account was found or not</returns>
        public Boolean AccountExists(string username)
        {
            return _context.Accounts.Any(a => a.Username == username);
        }

        /// <summary>
        /// Returns an account list of the room to display on the playlist
        /// </summary>
        /// <param name="room">RoomModel of room with accountlist</param>
        /// <returns>IQueryable of AccountModels</returns>
        public IQueryable<AccountModel> GetAccountsList(RoomModel room)
        {
            return _context.Accounts.Where(a => a.Room.Id == room.RoomId)
               .Select(a => new AccountModel
               {
                   LoginId = a.LoginId,
                   Username = a.Username
               });
        }

        /// <summary>
        /// Adds new Account to database
        /// </summary>
        /// <param name="account">AccountModel of account being added</param>
        public void AddAccount(AccountModel account)
        {
            Account entity = ModelConversions.AccountModelToEntity(account);
            _context.Accounts.Add(entity);
            _context.SaveChanges();

        }
        //-----------------------------------------------------------------------------------//
        //-------------------------------The Things for Room stuff --------------------------//
        //-----------------------------------------------------------------------------------// 



        /// <summary>
        /// Returns true if the room is already in the database
        /// </summary>
        /// <param name="roomid">Id of room being checked</param>
        /// <returns>Boolean of whether room exists or not</returns>
        public Boolean RoomExists(int roomid)
        {
            return _context.Rooms.Any(s => s.Id == roomid);
        }

        /// <summary>
        /// Adds a Room to the database
        /// </summary>
        /// <param name="room">RoomModel being added</param>
        /// <param name="loginId">loginId of user creating room</param>
        public void AddRoom(RoomModel room, int loginId)
        {
            try
            {
                Room entity;
                entity = ModelConversions.RoomModelToEntity(room);
                Account account = GetAccount(loginId);
                entity.Accounts.Add(account);
                _context.Rooms.Add(entity);
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

        /// <summary>
        /// Get list of Accounts in a Room
        /// </summary>
        /// <param name="roomId">roomId of room with list of accounts</param>
        /// <returns>List of AccountModels</returns>
        public List<AccountModel> GetRoomAccounts(int roomId)
        {
            Room room = _context.Rooms.Where(r => r.Id == roomId).Single();
            var list =  _context.Accounts.Where(a => a.Room.Id == roomId).Select(u => new AccountModel
            {
                LoginId = u.LoginId,
                Username = u.Username
            }).OrderBy(u => u.Username).ToList();
            return list;
            
        }

        /// <summary>
        /// Adds Accounts to the existing Room
        /// </summary>
        /// <param name="roomId">Id of room where account is being added</param>
        /// <param name="loginid">loginId of user being added to room</param>
        public void AddRoomAccount(int roomId, int loginid)
        {
            Account account = GetAccount(loginid);
            Room room = GetRoom(roomId);
            room.Accounts.Add(account);
            _context.SaveChanges();

        }


        /// <summary>
        /// Returns the room associated the specific id
        /// </summary>
        /// <param name="roomid">RoomId of room being searched</param>
        /// <returns>Room entity</returns>
        public Room GetRoom(int roomid)
        {
            return _context.Rooms.Where(a => a.Id == roomid).Single();
        }

        /// <summary>
        /// Gets a list of all the rooms in the database
        /// </summary>
        /// <returns>IQueryable of RoomModels</returns>
        public IQueryable<RoomModel> GetRoomList()
        {
                return _context.Rooms.Select(r => new RoomModel
                {
                    RoomId = r.Id,
                    RoomName = r.RoomName,
                    RoomPassword = r.RoomPassword,
                    Privacy = r.Privacy
                });
        }

        /// <summary>
        /// Checks if there are any rooms in List
        /// </summary>
        /// <returns>Boolean that is true when there are no rooms in the database</returns>
        public Boolean IsRoomListEmpty()
        {
            return (_context.Rooms.Count() == 0);
        }


        /// <summary>
        /// Adds a list of songs to a room
        /// </summary>
        /// <param name="songList">int array of songs</param>
        /// <param name="roomId">roomId of room that songs are being added to</param>
        public void AddSongsToRoom(int[] songList, int roomId)
        {
            foreach (int songId in songList)
            {
                AddSongToRoom(songId, roomId);
            }
            int count = _context.Rooms.Where(r => r.Id == roomId).Single().Songs.Count();
        }


        /// <summary>
        /// Adds a song to the database
        /// </summary>
        /// <param name="songId">songId of song being added to room</param>
        /// <param name="roomId">roomId that song is being added to</param>
        public void AddSongToRoom(int songId, int roomId)
        {
            Song song = GetSong(songId);
            if (_context.Rooms.Where(r => r.Id == roomId).Single().Songs.Any(s => s.Id == songId))
            {
                return;
            }
            _context.Rooms.Where(r => r.Id == roomId).Single().Songs.Add(song);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets a list of all the songs in a room
        /// </summary>
        /// <param name="roomid">roomId what songlist is in</param>
        /// <returns>IEnumerable of SongModels</returns>
        public IEnumerable<SongModel> GetRoomSongsList(int roomid)
        {
            Room room = _context.Rooms.Where(r => r.Id == roomid).Single();
                return room.Songs.Select(s => new SongModel
                {
                    Artist = s.Artist,
                    Album = s.Album,
                    SongTitle = s.Title,
                    Length = s.Length,
                    FilePath = s.FilePath,
                    SongID = s.Id,
                    Genre = s.Genre,
                    Likes = s.Likes
                });
        }


        /// <summary>
        /// Removes the user from the room account list and removes the room from the users association
        /// </summary>
        /// <param name="roomId">roomId of room that has account</param>
        /// <param name="loginId">account being deleted from a room</param>
        public void DeleteAccount(int roomId, int loginId)
        {
            Account account = GetAccount(loginId);
            Room room = GetRoom(roomId);
            room.Accounts.Remove(account);
            //account.RoomId = null;
            //account.Room = null;
            _context.SaveChanges();

        }

        /// <summary>
        /// Gets the RoomModel associated with an Account
        /// </summary>
        /// <param name="loginId">loginId of Account</param>
        /// <returns>IQueryable of RoomModel</returns>
        public IQueryable<RoomModel> GetAccountRooms(int loginId)
        {
            return _context.Rooms.Where(r => r.Accounts.Any(a => a.LoginId == loginId)).Select(r => new RoomModel
            {
                RoomId = r.Id,
                RoomName = r.RoomName,
                RoomPassword = r.RoomPassword,
                Privacy = r.Privacy

            });
        }

        /// <summary>
        /// Push edited song metadata to the database.
        /// </summary>
        /// <param name="song">SongModel with updated information.</param>
        public void EditSong(SongModel song)
        {
            Song entity = GetSong(song.SongID);
            entity.Title = song.SongTitle;
            entity.Artist = song.Artist;
            entity.Album = song.Album;
            _context.SaveChanges();
        }
    }
}
