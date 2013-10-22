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
            return SongRepository.GetAccountsList().Where(a => a.Username == username).Single();
        }

        public IQueryable<SongModel> GetSongList(string username)
        {
            return SongRepository.GetSongList().Where(s => s.Username == username);
        }

        public IQueryable<SongModel> GetSongList()
        {
            return SongRepository.GetSongList();
        }

        public void UploadSong(SongModel model)
        {
            SongRepository.Add(model);
        }
    }
}
