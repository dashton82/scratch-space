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

        public Task Create(PersonEntity person)
        {

            //_personDataContext.SaveChanges();
            throw new NotImplementedException();
        }

        public async Task<PersonEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}