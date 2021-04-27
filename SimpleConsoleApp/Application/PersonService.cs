using System.Collections.Generic;
using Domain;
using Domain.Interfaces;

namespace Application
{
    //converts list personEntity to listPerson so will be used with FormatServices and Program.cs.  
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
            var entities = _personRepository.GetAll();

            var listPerson = new List<Person>();

            if (entities == null)
            {
                return null;
            }
            
            foreach (var personEntity in entities)
            {
                var person = new Person(personEntity.FirstName, personEntity.LastName, personEntity.DateOfBirth, _formatService.GetGreeting);
                listPerson.Add(person);
            } 
            
            return listPerson;

        }
    }
}