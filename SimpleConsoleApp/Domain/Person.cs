using System;

namespace Domain
{
    public class Person
    {
        public Person (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; }
        public string LastName { get;  }
        public DateTime DateOfBirth { get; set; }
        public int Age => GetAge();
        public string GreetingMessage { get; }
        public DateTime DateToday { get ; set ; }

        private int GetAge()
        {
            throw new NotImplementedException();
        }
    }
    
}