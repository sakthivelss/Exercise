using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseShareApp.Repository;
using ExpenseShareApp.Service;


namespace ExpenseShareApp.Test
{
    [TestClass]
    public class ExpenseTrackingTest
    {
        [TestMethod]
        public void EnterExpense()
        {
            var db = new InMemoryDB();
            var personRepository = new PersonRepository(db);
            var expenseRepository = new ExpenseRepository(db);
            var tripRepository = new TripRepository(db);

            var personService = new PersonService(personRepository);

            var expenseTracking = new ExpenseTracking(personRepository,
                tripRepository,
                expenseRepository 
                );

            var expenseService = new ExpenseService(expenseRepository);

            expenseService.CreateExpense("Lunch", "Lunch");

            var Personlist = personService.CreatePerson(new string[] { "Suresh", "Sakthivel" ,"Saravanan"});

            var trip = expenseTracking.CreateTrip("trip1", Personlist.Select(p=>p.ID));
            expenseTracking.EnterExpense(trip.TripID,1, new int[] {2,3 }, "Lunch", 100);

            var payer = Personlist.Where(p => p.ID == 1).FirstOrDefault();

            var payee = Personlist.Where(p => p.ID != 1).FirstOrDefault();
           
            Assert.AreEqual(100,payer.AmountToGet());
            Assert.AreEqual(50,payee.AmountToGive());

        }
    }
}
