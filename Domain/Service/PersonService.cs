using ExpenseShareApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShareApp.Service
{
    public class PersonService
    {
        IPersonRepository PersonRepository;
        public PersonService(IPersonRepository personRepository)
        {
            this.PersonRepository = personRepository;
        }

        public List<Person> CreatePerson(IEnumerable<string> names)
        {
            var persons = names.Select(name => new Domain.Person() { Name = name })
                        .ToList();
            this.PersonRepository.CreatePersons(persons);
            return persons.ToList();
        }

        


    }
}
