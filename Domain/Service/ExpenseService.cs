using ExpenseShareApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Service
{
    public class ExpenseService
    {
        IExpenseRepository ExpenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            this.ExpenseRepository = expenseRepository;
        }
        public void CreateExpense(string expenseCode, string expenseDescription)
        {
            var expenseItem = new ExpenseItem() { ExpenseCode = expenseCode, ExpenseDesccription = expenseDescription };

            this.ExpenseRepository.CreateExpense(expenseItem);

        }
    }
}
