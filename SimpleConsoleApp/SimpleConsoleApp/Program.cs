using System;
using Application;

namespace SimpleConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            FormatService greeting = new FormatService();

            Console.WriteLine("Enter First Name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Surname");
            String lastName = Console.ReadLine();

            Console.WriteLine (greeting.GetGreeting(firstName, lastName));

        }
    }
}