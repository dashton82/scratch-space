using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;
using Domain.Interfaces;
using Newtonsoft.Json;

namespace Data
{
    public class PersonFileRepository : IPersonRepository
    {
        public IEnumerable<PersonEntity> GetAll()
        {
            using (var r = new StreamReader("people.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<PersonImport>(json);
                return items.Persons.ToList();
            }
        }
    }

}