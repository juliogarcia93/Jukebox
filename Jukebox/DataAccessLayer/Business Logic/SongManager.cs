using DataAccessLayer.Repositories;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLogic
{
    public class SongManager
    {
        private SongRepository SongRepository;
        public SongManager()
        {
            SongRepository = new SongRepository();
        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Song/Music stuff --------------------//
//-----------------------------------------------------------------------------------//
        public SongModel FindSong(string Songname, string Album)
        {
            return SongRepository.FindSong(Songname, Album);
        }

        public List<SongModel> GetSongList(string username)
        {
            if (SongRepository.GetAccountsList().Any(a => a.Username == username))
            {
                AccountModel account = GetAccountModel(username);
                return SongRepository.GetSongList(account.LoginId).ToList();
            }
            else
            {
                return new List<SongModel>();
            }

        }

        public IQueryable<SongModel> GetSongList()
        {
            return SongRepository.GetSongList();
        }


        public void UploadSong(SongModel model)
        {
            SongRepository.Add(model);
        }

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

        public void Delete(SongModel songmodel, string username)
        {
            AccountModel accountmodel = GetAccountModel(username);
            int userId = accountmodel.LoginId;
            SongRepository.Delete(songmodel, userId);
        }

        public void DeleteSong(SongModel model, string Username)
        {
            AccountModel account = GetAccountModel(Username);
            SongRepository.Delete(model, account.LoginId);

        }

        public void AddSong(SongModel model, string username)
        {
            SongRepository.AddSong(model, username);
        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Account stuff -----------------------//
//-----------------------------------------------------------------------------------//
        public AccountModel GetAccountModel(string username)
        {
            return SongRepository.GetAccountsList().FirstOrDefault(a => a.Username == username);
        }

        // Method that gets all the accounts in the database
        public List<AccountModel> GetAccountsList()
        {
            return SongRepository.GetAccountsList().ToList();
        }


        //Gets the account list related to the roomModel
        public List<AccountModel> GetAccountList(RoomModel room)
        {
            return SongRepository.GetAccountsList(room).ToList();
        }

        //Adds user to the list of users in site
        //Checks if the user is here first
        //Then passes and account Model
        public void AddAccount(string username)
        {
             if (!SongRepository.GetAccountsList().Any(a => a.Username == username))
            {
                AccountModel account = new AccountModel(username);
                SongRepository.AddAccount(account);
            }
        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Room stuff --------------------------//
//-----------------------------------------------------------------------------------//    

        public void AddRoom(RoomModel room, string username)
        {
            if (!SongRepository.GetRoomList().Any(a => a.RoomName == room.RoomName) && SongRepository.GetAccountsList().Any(a => a.Username == username))
            {
                AccountModel account = GetAccountModel(username);
                SongRepository.AddRoom(room, account.LoginId);
                RoomModel room1 = GetRoomModel(room.RoomName);
                room1.Accounts.Add(account);
                //AddRoomAccount(room1, account);//Adds the creater of the room to the room account list
            }

        }
        /**
            AddRoomAccount
         *  Adds Users to the existing room
        **/
        public void AddRoomAccount(RoomModel room, AccountModel account)
        {
            if (!SongRepository.GetRoomAccounts(room.RoomId).Any(a => a.Username == account.Username))
            {
                SongRepository.AddRoomAccount(room.RoomId, account.LoginId);

            }
        }

        public List<AccountModel> GetRoomAccounts(string roomName)
        {
            if (SongRepository.GetRoomList().Count() > 0)
            {
                List<AccountModel> accounts = SongRepository.GetRoomAccounts(roomName);
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

        public RoomModel GetRoomModel(string roomName)
        {
                return SongRepository.GetRoomList().First(r => r.RoomName == roomName);
        }

        public IEnumerable<RoomModel> GetRoomList()
        {
           IEnumerable<RoomModel> rooms = SongRepository.GetRoomList().AsEnumerable<RoomModel>();
           return rooms;
        }


        
    }
}
