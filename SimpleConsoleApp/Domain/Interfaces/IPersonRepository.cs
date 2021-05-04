using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    //interface is 'blueprint' for what function of file should be 
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonEntity>> GetAll();
        Task Create(PersonEntity person);
        Task<PersonEntity> GetById(Guid id);
    }

}