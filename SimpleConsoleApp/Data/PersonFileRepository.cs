using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Newtonsoft.Json;

namespace Data
{
    // Gets data from Json and converts to list 
    public class PersonFileRepository : IPersonRepository
    {
        public async Task<IEnumerable<PersonEntity>> GetAll()
        {
            using (var r = new StreamReader("people.json"))
            {
                var json = await r.ReadToEndAsync();
                var items = JsonConvert.DeserializeObject<PersonImport>(json);
                return items.Persons.ToList();
            }
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