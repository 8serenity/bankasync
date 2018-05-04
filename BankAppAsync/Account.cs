using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppAsync
{
    public class Account
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Bank")]
        public int BankId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Bank Bank { get; set; }
    }
}
