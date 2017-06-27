using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExpenseShareApp.Service;
using ExpenseShareApp.Repository;

namespace ExpenseShareApp.Test
{
    [TestClass]
    public class ExpenseServiceTest
    {
        [TestMethod]
        public void CreateExpense()
        {
            var db = new InMemoryDB();
            var expenseRepository = new ExpenseRepository(db);

            var expense = new ExpenseService(expenseRepository);
            expense.CreateExpense("BreakFast", "Break Fast");

            var expenseItem = db.ExpenseItems.FirstOrDefault();

            Assert.AreEqual("BreakFast", expenseItem.ExpenseCode);

        }
    }
}
