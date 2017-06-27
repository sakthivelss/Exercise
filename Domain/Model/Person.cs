using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Domain
{
    public class Person
    {
        public Person()
        {
            this.LedgerItems = new LedgerCollection();

        }
        LedgerCollection LedgerItems { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }
   

        public void Debit(ExpenseItem expenseItem, decimal amount)
        {
            this.LedgerItems.Debit(expenseItem, amount);
        }

        public void Credit(ExpenseItem expenseItem, decimal amount)
        {
            this.LedgerItems.Credit(expenseItem, amount);
        }
        public decimal AmountToGive()
        {
            
            return this.LedgerItems.GetCreditBalance();
        }

        public decimal AmountToGet()
        {
            return this.LedgerItems.GetDebitBalance();
        }
    }
}
