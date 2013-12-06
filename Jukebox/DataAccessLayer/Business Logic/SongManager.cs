using DataAccessLayer.Repositories;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLogic
{
    /// <summary>
    /// Buisness logic layer that allows users a medium for communication with the database. 
    /// </summary>
    public class SongManager
    {
        private SongRepository SongRepository;
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SongManager()
        {
            SongRepository = new SongRepository();
        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Song/Music stuff --------------------//
//-----------------------------------------------------------------------------------//

        /// <summary>
        /// Finds the SongModel you are looking for
        /// </summary>
        /// <param name="Songname">The name of the song you are looking for</param>
        /// <param name="Album">The name of the album associated with the song you are looking for</param>
        /// <returns>SongModel</returns>
        public SongModel FindSong(string Songname, string Album)
        {
            return SongRepository.FindSong(Songname, Album);
        }

        /// <summary>
        /// Gets a list of songs from a user's account
        /// </summary>
        /// <param name="username">Username whose songlist you are looking for</param>
        /// <returns>List of SongModels</returns>
        public IQueryable<SongModel> GetSongList(string username)
        {
            if (SongRepository.GetAccountsList().Any(a => a.Username == username))
            {
                AccountModel account = GetAccountModel(username);
                return SongRepository.GetSongList(account.LoginId);
            }
            return null;
        }

        /// <summary>
        /// Gets the entire songlist in the database
        /// </summary>
        /// <returns>IQueryable of SongModels</SongModel></returns>
        public IQueryable<SongModel> GetSongList()
        {
            return SongRepository.GetSongList();
        }

        /// <summary>
        /// Adds a song to the database
        /// </summary>
        /// <param name="model">SongModel of song you are adding</param>
        public void UploadSong(SongModel model)
        {
            SongRepository.Add(model);
        }

        /// <summary>
        /// Returns a list of all the songs that match any part of the query
        /// </summary>
        /// <param name="query">query that user enters to search through songlist</param>
        /// <param name="originalList">Original list of songs that user is searching through</param>
        /// <returns>IQueryable of SongModels</returns>
        public IQueryable<SongModel> Search(string query, IQueryable<SongModel> originalList)
        {
            if (string.IsNullOrEmpty(query))
            {
                return originalList;
            }
            return originalList.Where(s => s.SongTitle.Contains(query)
                ||
                s.Artist.Contains(query)
                ||
                s.Album.Contains(query)
                ||
                s.Genre.Contains(query)
                ).OrderBy(s => s.SongTitle);
        }

        /// <summary>
        /// Deletes a song from database
        /// </summary>
        /// <param name="songmodel">Song to be deleted</param>
        /// <param name="username">Username who is deleting the song</param>
        public void Delete(SongModel songmodel, string username)
        {
            AccountModel accountmodel = GetAccountModel(username);
            int userId = accountmodel.LoginId;
            SongRepository.Delete(songmodel, userId);
        }

        /// <summary>
        /// Adds a new song to the database
        /// </summary>
        /// <param name="model">Song that is being added</param>
        /// <param name="username">User that is adding the song</param>
        public void AddSong(SongModel model, string username)
        {
            SongRepository.AddSong(model, username);
        }

        /// <summary>
        /// Increment Like count when user like's a song
        /// </summary>
        /// <param name="song">Song that is being liked</param>
        public void IncrementLike(SongModel song)
        {
            int songId = song.SongID;
            //song.IncrementLikes();
            SongRepository.IncrementLike(songId);
        }

//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Account stuff -----------------------//
//-----------------------------------------------------------------------------------//

        /// <summary>
        /// Returns an Account Model associated with a username
        /// </summary>
        /// <param name="username">Username for user being passed in</param>
        /// <returns>AcocuntModel for username</returns>
        public AccountModel GetAccountModel(string username)
        {
            return SongRepository.GetAccountsList().Where(a => a.Username == username).Single();
        }

        /// <summary>
        /// Method that gets all the accounts in the database
        /// </summary>
        /// <returns>List of SongModels</returns>
        public List<AccountModel> GetAccountsList()
        {
            return SongRepository.GetAccountsList().ToList();
        }


        /// <summary>
        /// Gets the account list related to the roomModel
        /// </summary>
        /// <param name="room">RoomModel for room being passed in</param>
        /// <returns>List of AccountModel</returns>
        public List<AccountModel> GetAccountList(RoomModel room)
        {
            return SongRepository.GetAccountsList(room).ToList();
        }

        /// <summary>
        /// Adds user to the list of users in site
        /// </summary>
        /// <param name="username">Checks if the user is here first</param>
        public void AddAccount(string username)
        {
             if (!SongRepository.GetAccountsList().Any(a => a.Username == username))
            {
                AccountModel account = new AccountModel() { Username = username };
                SongRepository.AddAccount(account);
            }
        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Room stuff --------------------------//
//-----------------------------------------------------------------------------------//    


        /// <summary>
        /// Gets the song list of the room
        /// </summary>
        /// <param name="roomid">Id of Room with list of Songs</param>
        /// <returns>List of SongModels in Room</returns>
        public List<SongModel> GetRoomSongsList(int roomid)
        {
            if (SongRepository.GetRoomList().Any(r => r.RoomId == roomid))
            {
                List<SongModel> list = SongRepository.GetRoomSongsList(roomid).ToList();
                return list;
            }
            else
            {
                return new List<SongModel>();
            }
        }

        /// <summary>
        /// Adds a new room to the database
        /// </summary>
        /// <param name="room">RoomModel of room being created</param>
        /// <param name="username">Username of user creating the room</param>
        public void AddRoom(RoomModel room, string username)
        {
            if (SongRepository.IsRoomListEmpty())
            {
                AccountModel account = GetAccountModel(username);
                SongRepository.AddRoom(room, account.LoginId);

            }
            else if (!SongRepository.GetRoomList().Any(a => a.RoomName == room.RoomName) && SongRepository.GetAccountsList().Any(a => a.Username == username))
            {
                AccountModel account = GetAccountModel(username);
                SongRepository.AddRoom(room, account.LoginId);
            }
       }

        /// <summary>
        /// Adds Users to the existing room
        /// </summary>
        /// <param name="room">Room that user is being added to</param>
        /// <param name="account">AccountModel of user being added to room</param>
        public void AddRoomAccount(RoomModel room, AccountModel account)
        {
            if (!SongRepository.GetRoomAccounts(room.RoomId).Any(a => a.Username == account.Username))
            {
                SongRepository.AddRoomAccount(room.RoomId, account.LoginId);

            }
        }

        /// <summary>
        /// Returns a List of Accounts in a Room
        /// </summary>
        /// <param name="roomName">Name of Room that Accountlist is in</param>
        /// <returns>List of AccountModels in Room</returns>
        public List<AccountModel> GetRoomAccounts(string roomName)
        {
            if (SongRepository.GetRoomList().Count() > 0)
            {
                RoomModel room = GetRoomModel(roomName);
                List<AccountModel> accounts = SongRepository.GetRoomAccounts(room.RoomId);
                if (accounts == null)
                {
                    return new List<AccountModel>();
                }
                return accounts;
            }
            else
            {
                return new List<AccountModel>();
            }

        }

        /// <summary>
        /// Adds Songs to an existing Room
        /// </summary>
        /// <param name="songList">List of Songs being added to room</param>
        /// <param name="roomId">Id of Room that songs are begin added to</param>
        public void AddSongsToRoom(int[] songList, int roomId)
        {
            if (songList.Count() <= 0)
            {
                return;
            }
            if (SongRepository.GetRoomList().Any(a => a.RoomId == roomId) == false)
            {
                return;
            }

            SongRepository.AddSongsToRoom(songList, roomId);
        }

        /// <summary>
        /// Gets a RoomModel associated with a roomname
        /// </summary>
        /// <param name="roomName">Name of Room</param>
        /// <returns>RoomModel for roomname</returns>
        public RoomModel GetRoomModel(string roomName)
        {
            return SongRepository.GetRoomList().Where(r => r.RoomName == roomName).Single();
        }

        /// <summary>
        /// Gets a List of all the Rooms in the database
        /// </summary>
        /// <returns>IEnumerable of RoomModels</returns>
        public IEnumerable<RoomModel> GetRoomList()
        {
           IEnumerable<RoomModel> rooms = SongRepository.GetRoomList().AsEnumerable<RoomModel>();
           return rooms;
        }

        /// <summary>
        /// Method for leaving a room. This will remove the user from the room and set the users room information to null
        /// </summary>
        /// <param name="room">Room that user is being deleted from</param>
        /// <param name="username">Username of user that is being deleted from room</param>
        public void DeleteAccount(RoomModel room, string username)
        {
            int roomid = room.RoomId;
            AccountModel account = GetAccountModel(username);
            SongRepository.DeleteAccount(roomid, account.LoginId);
        }

        /// <summary>
        /// Gets a song for the given filename.
        /// </summary>
        /// <param name="fileName">The filename of the uploaded song desired.</param>
        /// <returns>SongModel for matching filename.</returns>
        public SongModel GetSongModel(string fileName)
        {
            SongModel song = SongRepository.GetSongList().FirstOrDefault(s => s.FilePath == fileName);
            return song;
        }

        /// <summary>
        /// Edit song metadata and push to database
        /// </summary>
        /// <param name="song">SongModel with updated information.</param>
        public void EditSong(SongModel song)
        {
            SongRepository.EditSong(song);
        }
    }
}
