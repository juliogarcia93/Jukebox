using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class GenreModel
    {
        public GenreModel()
        {
            Id = null;
            sName = null;
        }

        public GenreModel(int genreId, string genre)
        {
            Id = genreId;
            sName = genre;
        }
        public Nullable<int> Id { get; set; }
        public string sName { get; set; }
    }
}