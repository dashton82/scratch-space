using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<PersonEntity> GetAll();
    }
}