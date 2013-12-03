using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class AlbumModel
    {
        public AlbumModel()
        {
            Id = null;
            sTitle = null;
        }

        public AlbumModel(int albumId, string album)
        {
            Id = albumId;
            sTitle = album;
        }
        public Nullable<int> Id { get; set; }
        public string sTitle { get; set; }
    }
}