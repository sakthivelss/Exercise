
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseShareApp.Domain;

namespace ExpenseShareApp.Repository 
{
    public class PersonRepository : IPersonRepository
    {
        InMemoryDB InMemoryDB;
        public PersonRepository(InMemoryDB db)
        {
            this.InMemoryDB = db;
        }

        public void CreatePersons(List<Person> persons)
        {
            var idIndex = this.InMemoryDB.Person.Count();

            foreach (var person in persons)
            {
                idIndex++;
                person.ID = idIndex;
                this.InMemoryDB.Person.Add(person);
            }
        }

        public Person GetPersonById(int personId)
        {
        
            return this.InMemoryDB
                .Person
                .Where(p => p.ID == personId)
                .FirstOrDefault();
        }

        public IEnumerable<Person> GetPersonByIds(IEnumerable<int> personIds)
        {
            return this.InMemoryDB
                .Person
                .Where(p => personIds.Contains(p.ID));
        }
    }
}
            