using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Models
{
    class RoomModel
    {
        public RoomModel ()
        {
            RoomName = null;
        }
        public RoomModel(string roomname)
        {
            RoomName = roomname;
        }
        public string RoomName { get; set; }
    }
}