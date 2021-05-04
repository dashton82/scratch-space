using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public async Task<IEnumerable<PersonEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Create(PersonEntity person)
        {
            throw new NotImplementedException();
        }

        public Task<PersonEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}