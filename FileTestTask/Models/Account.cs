using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public double OpeningBalanceActive { get; set; }

        public double OpeningBalancePassive { get; set; }

        public double DebitTurnover {  get; set; }

        public double CreditTurnover { get; set; }

        public double ClosingBalanceActive { get; set; }

        public double ClosingBalancePassive { get; set; }

        [ForeignKey(nameof(AccountClass))]
        public int ClassId { get; set; }

        public AccountClass? Class { get; set; }

    }
}
