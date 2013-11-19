using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ArtistModel
    {
        public ArtistModel()
        {
            Id = null;
            sName = null;
        }

        public ArtistModel(int artistId, string artist)
        {
            Id = artistId;
            sName = artist;
        }
        public Nullable<int> Id { get; set; }
        public string sName { get; set; }

    }
}