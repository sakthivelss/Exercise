using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseShareApp.Repository;
using ExpenseShareApp.Service;

namespace ExpenseShareApp.Test
{
    [TestClass]
    public class PersonServiceTest
    {
        [TestMethod]
        public void CreatePerson()
        {
            var db = new InMemoryDB();
            var personRepository = new PersonRepository(db);

            var personService = new PersonService(personRepository);
            personService.CreatePerson(new string[] { "Suresh", "Sakthivel" });

            var person = db.Person.FirstOrDefault();

            Assert.AreEqual(1, person.ID);
            Assert.AreEqual("Suresh", person.Name);

            person = db.Person.ElementAt(1);
            Assert.AreEqual(2, person.ID);
            Assert.AreEqual("Sakthivel", person.Name);

        }


    }
}