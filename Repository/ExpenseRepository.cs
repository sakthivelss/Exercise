using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseShareApp.Domain;


namespace ExpenseShareApp.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        InMemoryDB InMemoryDB;
        public ExpenseRepository(InMemoryDB db)
        {
            this.InMemoryDB = db;
        }

        public void CreateExpense(ExpenseItem expenseItem)
        {
            this.InMemoryDB.ExpenseItems.Add(expenseItem);
        }

        public ExpenseItem GetExpense(string expenseCode)
        {
            return this.InMemoryDB
                .ExpenseItems
                .Where(p => p.ExpenseCode == expenseCode)
                .FirstOrDefault();
        }
    }
}
