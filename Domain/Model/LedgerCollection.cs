using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Domain
{
    public class LedgerCollection : List<LedgerItem>
    {

        public void Debit(ExpenseItem expense, decimal amount)
        {
            var ledgerItem = new LedgerItem() { Expense = expense, Amount = amount };
            this.Add(ledgerItem);
        }
        
        public void Credit(ExpenseItem expense, decimal amount)
        {
            var ledgerItem = new LedgerItem() { Expense = expense, Amount = (-1)*amount };
            this.Add(ledgerItem);

        }

        public decimal GetDebitBalance()
        {
            decimal balance = 0;
            this.ForEach(ledgetItem => balance += ledgetItem.Amount);
            return balance;
        }

        public decimal GetCreditBalance()
        {
            decimal balance = 0;
            this.ForEach(ledgetItem => balance += ledgetItem.Amount);
            return -1*balance;
        }

    }
}
