using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace SimpleConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var personList = new List<Person>();

            bool moreEntries = true;

            do
            {
                Console.WriteLine("Enter First Name");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter Surname");
                String lastName = Console.ReadLine();

                Console.WriteLine("Enter Date of Birth (dd/mm/yyyy)");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                
                var person = new Person(firstName, lastName, dateOfBirth);

                Console.WriteLine(person.GreetingMessage);
                Console.WriteLine(person.Age);

                personList.Add(person);

                Console.WriteLine("press y to add another");
                string yEntry = Console.ReadLine().ToLower();

                if (yEntry != "y") moreEntries = false;


            } while (moreEntries);

            Console.WriteLine(personList.Count);


        }
    }
}