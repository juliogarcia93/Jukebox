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
                AccountModel account = GetAccountModel(username);
                SongRepository.AddAccount(account);
            }
        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Room stuff --------------------------//
//-----------------------------------------------------------------------------------//    

        public void AddRoom(RoomModel room, string username)
        {
            if (!SongRepository.RoomExists(room) && SongRepository.GetAccountsList().Any(a => a.Username == username))
            {
                AccountModel account = GetAccountModel(username);
                SongRepository.AddRoom(room, account.LoginId);
            }

        }

        public List<AccountModel> GetRoomAccounts(string roomName)
        {
            if (SongRepository.GetRoomList().Count() > 0)
            {
                RoomModel room = GetRoomModel(roomName);
                if (room.Accounts == null)
                {
                    return new List<AccountModel>();
                }
                return room.Accounts;
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


        
    }
}
