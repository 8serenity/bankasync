using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppAsync
{
    public class Client
    {
        public int Id { get; set; }
        public string IIN { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual HashSet<Account> Accounts { get; set; }
        public Client()
        {
            Accounts = new HashSet<Account>();
        }
    }
}
