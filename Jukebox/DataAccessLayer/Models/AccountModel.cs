using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class AccountModel
    {
        public AccountModel()
        {
            LoginId = null;
            Username = null;
        }

        public Nullable<int> LoginId { get; set; }
        public string Username { get; set; }
    }
}
