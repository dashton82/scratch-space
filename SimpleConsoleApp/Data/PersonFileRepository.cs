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
        public string Hello(string missing_name)
        {
            throw new NotImplementedException();
        }
        private string GetSomething()
        {
            return "";
        }

        public void CreatePerson(PersonEntity person)
        {
            throw new NotImplementedException();
        }

        public PersonEntity GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        
    }

}