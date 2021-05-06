using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPersonDataContext _personDataContext;

        public PersonRepository (IPersonDataContext personDataContext)
        {
            _personDataContext = personDataContext;
        }
        
        public async Task<IEnumerable<PersonEntity>> GetAll()
        {
            var people =  await _personDataContext.PersonEntities.ToListAsync();
            
            return people;
        }

        
        // gets input 'person' from elsewhere and then adds it to the database.
        public async Task Create(PersonEntity person)
        {
             await _personDataContext.PersonEntities.AddAsync(person);
            _personDataContext.SaveChanges();
        }

        // gets input 'id' from elsewhere and findsthe person that matches 
        public async Task<PersonEntity> GetById(Guid id)
        {
            var person = await _personDataContext.PersonEntities.FindAsync(id);
            return person;
        }
    }
}