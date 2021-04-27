using System;
using System.Collections.Generic;
using Application;
using Data;
using Domain;
using Domain.Interfaces;

namespace SimpleConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var service = new PersonService(new PersonFileRepository(), new FormatService());
            var people = service.GetPeople();


            //           var personList = new List<Person>();
            //           var moreEntries = true;
            // var service1 = new PersonService(new IPersonRepository(), new FormatService());

            /*           while (moreEntries)
                    {
                          Console.WriteLine("Enter First Name");
                          var firstName = Console.ReadLine();

                          Console.WriteLine("Enter Surname");
                          var lastName = Console.ReadLine();

                          Console.WriteLine("Enter Date of Birth (dd/mm/yyyy)");
                          var dateOfBirth = DateTime.Parse(Console.ReadLine());

                          var person = new Person(firstName, lastName, dateOfBirth, greeting.GetGreeting);

                          Console.WriteLine(person.GreetingMessage);
                          Console.WriteLine(person.Age);

                          personList.Add(person);

                          Console.WriteLine("press y to add another");
                          var yEntry = Console.ReadLine().ToLower();

                          if (yEntry != "y")
                          {
                              moreEntries = false;
                          }

                      }

                      Console.WriteLine(personList.Count); */


        }
    }
}