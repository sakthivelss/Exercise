
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Domain
{
    public interface IExpenseRepository
    {
        ExpenseItem GetExpense(string expenseCode);

        void CreateExpense(ExpenseItem expenseItem);

    }
}
