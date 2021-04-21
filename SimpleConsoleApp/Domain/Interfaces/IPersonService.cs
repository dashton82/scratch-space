using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPeople();
    }
}