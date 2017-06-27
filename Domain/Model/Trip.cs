using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Domain
{
    public class Trip
    {
        public Trip()
        {
            this.PersonCollection = new List<Person>();
        }

        public Trip(string description, IEnumerable<Person> persons)
        {
            this.PersonCollection = persons.ToList();
            this.Description = description;
        }

        public int TripID { get; set; }

        public string Description { get; set; }

        List<Person> PersonCollection { get; set; }

        public void AddPerson(Person person)
        {
            this.PersonCollection.Add(person);
        }

        public void EnterExpense(Person payer,IEnumerable<Person> expenseFor, ExpenseItem expenseItem, decimal amount)
        {
            payer.Debit(expenseItem, amount); //crediting since amount is flowing from payer to expense

            var amountToBeDebited = (amount / expenseFor.Count());
            var total = 0m;

            foreach (var person in expenseFor)
            {
                total += amountToBeDebited;
                person.Credit(expenseItem, amountToBeDebited);
            }

            var diff = amount - total;
            if (diff > 0)
                expenseFor.FirstOrDefault().Debit(expenseItem, diff);

        }

    }
}
