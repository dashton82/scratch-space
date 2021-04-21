using System;
using Application;


namespace Domain
{
    public class Person
    {
        private readonly Func<string, string, string> _getGreeting;

        public Person (string firstName, string lastName, DateTime dateOfBirth, Func<string, string, string> getGreeting)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            _getGreeting = getGreeting;
        }

        public string FirstName { get; }
        public string LastName { get;  }
        public DateTime DateOfBirth { get; set; }
        public int Age => GetAge();
        public string GreetingMessage => _getGreeting(FirstName, LastName);

        public DateTime DateToday { get; set; } = DateTime.UtcNow;


        private int GetAge()
        {
            var age = DateToday.Year - DateOfBirth.Year;
            if (DateOfBirth > DateToday)
            {
                return 0;
            }
          
            if (DateOfBirth.DayOfYear > DateToday.DayOfYear)
            {
                age--;
                return age;
            } 

            return age;
        }
    }
    
}