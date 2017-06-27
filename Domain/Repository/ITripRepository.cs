
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Domain
{
    public interface ITripRepository
    {
        Trip GetTripId(int tripId);
        Trip CreateTrip(Trip trip);

        void UpdateTrip(Trip trip);
    }
}
