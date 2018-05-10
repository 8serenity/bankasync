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
        public static bool IsAccountValid(string iin, string checkedPassword)
        {
            var chechedHash = checkedPassword.GetHashCode().ToString();
            return Bank.Clients.Where(c => c.IIN == iin).Any(c => c.PasswordHash == chechedHash);
        }
        static ATMService()
        {
            Bank = new BankDB();
        }

        public static IEnumerable<Account> GetClientAccount(Client client)
        {
            return Bank.Accounts.Where(a => a.ClientId == client.Id);
        }

        public static bool Deposit(Account account, double sum)
        {
            var updatingAccount = Bank.Accounts.SingleOrDefault(a => a.Id == account.Id);
            if (updatingAccount == null)
            {
                return false;
            }
            else
            {
                updatingAccount.Balance += sum;
                Bank.SaveChanges();
                return true;
            }
        }

        public static bool Withdraw(Account account, double sum)
        {
            var updatingAccount = Bank.Accounts.SingleOrDefault(a => a.Id == account.Id);
            if (updatingAccount == null || updatingAccount.Balance < sum)
            {
                return false;
            }
            else
            {
                updatingAccount.Balance -= sum;
                Bank.SaveChanges();
                return true;
            }
        }

    }
}
