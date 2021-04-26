using System.Collections.Generic;
using System.Dynamic;

namespace Domain.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<PersonEntity> GetAll();

    }

}