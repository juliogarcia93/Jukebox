using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//This is the class that will hold all of the accounts in the database
namespace DataAccessLayer.Models
{
    public class AccountLists : List<AccountModel>
    {
        SongManager SongManager = new SongManager();
        public AccountLists()
            : this(0)
        {
        }

        private List<AccountModel> GetAccountsList()
        {
            var accounts = SongManager.GetAccountsList();

            TotalAccounts = accounts.Count();

            return accounts.ToList();

        }
        public int TotalAccounts { get; set; }

        public AccountLists(int AccountAmount)
        {
            TotalAccounts = AccountAmount;
        }
    }
}
