using ExpenseShareApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Service
{
    public class ExpenseTracking
    { 
        IPersonRepository PersonRepository;
        ITripRepository TripRepository;
        IExpenseRepository ExpenseRepository;

        public ExpenseTracking(IPersonRepository personRepository,
            ITripRepository tripRepository,
            IExpenseRepository expenseRepository)
        {
            this.PersonRepository = personRepository;
            this.TripRepository = tripRepository;
            this.ExpenseRepository = expenseRepository;
        }

        public Trip CreateTrip(string tripDescription, IEnumerable<int> PeopleIds)
        {
            var persons = this.PersonRepository.GetPersonByIds(PeopleIds);
            var trip = this.TripRepository.CreateTrip(new Trip(tripDescription, persons));
            return trip;
        }

        public void EnterExpense(int tripId, int payeeId, IEnumerable<int> paymentOnBehalfOf , string ExpenseCode, decimal amount)
        {
            var payee = this.PersonRepository.GetPersonById(payeeId);
            var persons = this.PersonRepository.GetPersonByIds(paymentOnBehalfOf);
            var expenseItem = this.ExpenseRepository.GetExpense(ExpenseCode);

            var trip = this.TripRepository.GetTripId(tripId);
            trip.EnterExpense(payee, persons, expenseItem, amount);
            this.TripRepository.UpdateTrip(trip);
        }


        public IEnumerable<Tuple<string, decimal, decimal>> GetBalance(IEnumerable<int> personIds)
        {
            var persons = this.PersonRepository.GetPersonByIds(personIds);

             return persons.Select(person => 
                        new Tuple<string, decimal, decimal>(
                        person.Name, 
                        person.AmountToGet(), 
                        person.AmountToGive()));

        }
    }
}
