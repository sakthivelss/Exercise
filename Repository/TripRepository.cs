using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseShareApp.Domain;

namespace ExpenseShareApp.Repository
{
    public class TripRepository : ITripRepository
    {
        InMemoryDB InMemoryDB; 

        public TripRepository(InMemoryDB db)
        {
            this.InMemoryDB = db;
        }

        public Trip CreateTrip(Trip trip)
        {
            int id = InMemoryDB.Trips.Count() + 1;
            trip.TripID = id;
            InMemoryDB.Trips.Add(trip);
            return trip;
        }

        public Trip GetTripId(int tripId)
        {

            return InMemoryDB.Trips
                .Where(t => t.TripID == tripId)
                .FirstOrDefault();
        }

        public void UpdateTrip(Trip trip)
        {
            InMemoryDB.Trips.Add(trip);
        }
    }
}
