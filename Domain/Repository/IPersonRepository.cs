
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Domain
{
    public interface IPersonRepository
    {
        Person GetPersonById(int personId);
        IEnumerable<Person> GetPersonByIds(IEnumerable<int> personIds);

        void CreatePersons(List<Person> persons);


    }
}
            