using System.Collections.Generic;
using Data;
using Domain;
using Domain.Interfaces;

namespace Application
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IFormatService _formatService;

        public PersonService (IPersonRepository personRepository, IFormatService formatService)
        {
            _personRepository = personRepository;
            _formatService = formatService;
        }
        public IEnumerable<Person> GetPeople()
        {
            var entites = _personRepository.GetAll();

            var listPerson = new List<Person>();
            foreach (var personEntity in entites)
            {
                var person = new Person(personEntity.FirstName, personEntity.LastName, personEntity.DateOfBirth, _formatService.GetGreeting);
                listPerson.Add(person);
            }

            return listPerson;
        }
    }
}