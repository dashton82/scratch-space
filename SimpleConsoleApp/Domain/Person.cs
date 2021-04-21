using System;
using Application;


namespace Domain
{
    public class Person
    {
        public Person (string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; }
        public string LastName { get;  }
        public DateTime DateOfBirth { get; set; }
        public int Age => GetAge();
        public string GreetingMessage 
        {
            get
            {
                FormatService greeting = new FormatService();
                return greeting.GetGreeting(FirstName, LastName);
            } 
        
        }

        public DateTime DateToday { get; set; } = DateTime.UtcNow;


        private int GetAge()
        {
            var age = DateToday.Year - DateOfBirth.Year;
            if (DateOfBirth > DateToday) return 0;
          
            if (DateOfBirth.DayOfYear > DateToday.DayOfYear)
            {
                age--;
                return age;
            } 

            return age;
        }
    }
    
}