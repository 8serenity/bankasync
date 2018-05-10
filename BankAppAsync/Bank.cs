using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppAsync
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Client> Clients { get; set; }

        public Bank()
        {
            Clients = new HashSet<Client>();
        }
    }
}