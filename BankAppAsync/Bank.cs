using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppAsync
{
    public class Bank
    {
        public string Name { get; set; }
        public HashSet<Client> Clients { get; set; }
        public HashSet<Account> Accounts { get; set; }

        public Bank()
        {
            Clients = new HashSet<Client>();
            Accounts = new HashSet<Account>();
        }
    }
}