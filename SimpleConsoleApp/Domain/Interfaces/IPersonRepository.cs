using System.Collections.Generic;
using System.Dynamic;

namespace Domain.Interfaces
{
    //interface is 'blueprint' for what function of file should be 
    public interface IPersonRepository
    {
        IEnumerable<PersonEntity> GetAll();

    }

}