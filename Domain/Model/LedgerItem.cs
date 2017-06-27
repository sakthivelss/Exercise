using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Domain
{
    public class LedgerItem
    {

        //public Person Person { get; set; }

        public ExpenseItem Expense { get; set; }

        public decimal Amount { get; set; }
        // can have negative value, 
        // Negative value - represent liability 
        // positive value - represent money that person has to give.

        public void Debit(ExpenseItem expense , decimal amount)
        {
            this.Expense = Expense;
            this.Amount = amount;       
        }

        public void Credit(ExpenseItem expense, decimal amount)
        {
            this.Expense = expense;
            this.Amount = (-1) * amount;
        }

    } 
}
