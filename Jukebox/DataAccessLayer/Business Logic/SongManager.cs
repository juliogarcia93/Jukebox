﻿using DataAccessLayer.Repositories;
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
        public void AddAccount(string username)
        {
            Boolean exist = SongRepository.AccountExists(username);
            if (!exist)
            {
                SongRepository.AddAccount(username);
            }
        }
//-----------------------------------------------------------------------------------//
//-------------------------------The Things for Room stuff --------------------------//
//-----------------------------------------------------------------------------------//    

        public void AddAccount(AccountModel model, string roomname)
        {
            SongRepository.AddAccountToRoom(model, roomname);
        }

        public void AddRoom(string roomname, string username)
        {
            SongRepository.AddRoom(roomname);
            //RoomModel room = SongRepository.GetRoom(roomname);
           
        }

        public int GetRoomId()
        {
            return SongRepository.GetRoomId();
        }

        public void CreateARoom(RoomModel room, string username)
        {
            if (!SongRepository.RoomExists(room))
            {
                SongRepository.CreateARoom(room, username);
            }

        }

        public List<AccountModel> RoomAccounts(string username)
        {
            return SongRepository.RoomAccounts(username);
        }


        public List<SongModel> AddSongsToList(List<SongModel> newSongs, List<SongModel> list)
        {
            foreach (SongModel song in list)
            {
                SongRepository.AddSongToList(song, list);
            }
            return list;
        }

        public RoomModel GetRoom(string roomname)
        {
            return SongRepository.GetRoom(roomname);
        }










    }
}
