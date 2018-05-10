using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppAsync
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public double Sum { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}