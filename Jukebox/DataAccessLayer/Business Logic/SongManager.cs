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
        
        public AccountModel GetAccountModel(string username)
        {
            return SongRepository.GetAccountsList().FirstOrDefault(a => a.Username == username);
        }


        //Gets the account list related to the roomModel
        public List<AccountModel> GetAccountList(RoomModel room)
        {
            return SongRepository.GetAccountsList(room).ToList();
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
    }
}
