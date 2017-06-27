using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseShareApp.Domain;
using Repository;

namespace ExpenseShareApp.Repository
{
    public class InMemoryDB
    {
        public InMemoryDB()
        {
            this.ExpenseItems = new HashSet<ExpenseItem>();
            this.Trips = new HashSet<Trip>();
            this.TripPerson = new HashSet<TripPerson>();
            this.Person = new HashSet<Person>();

        }

        public HashSet<ExpenseItem> ExpenseItems { get; set; }

        public HashSet<Trip> Trips { get; set; }

        public HashSet<TripPerson> TripPerson { get; set; }

        public HashSet<Person> Person { get; set; }

        public void PersisDB()
        {
            return;
        }

        public void BuildTheModel()
        {
            return;
        }
    }
}
