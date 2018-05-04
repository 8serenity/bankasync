using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppAsync
{
    class ATMService
    {
        public static BankDB Bank { get; private set; }
        static bool IsAccountValid(string iin, string checkedPassword)
        {
            return Bank.Clients.Where(c => c.IIN == iin).Any(c => c.PasswordHash == checkedPassword.GetHashCode().ToString());
        }

        static IEnumerable<Account> GetClientAccount(Client client)
        {
            return Bank.Accounts.Where(a => a.Client == client);
        }

        static void Deposit(Account account, double sum)
        {
            
            account.Balance += sum;
            
        }
    }
}
