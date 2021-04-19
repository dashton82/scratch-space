using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Application
{
    public class FormatService
    {
        public string GetGreeting(string firstName, string lastName)
        {
            var fullName = firstName + lastName;
            var reverseName = Palindrome(fullName);
            
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return "You have no name!";

            if (Regex.IsMatch(fullName, "[0-9]"))
                return ("You have number in your name!!");

            if (reverseName.ToLower() == fullName.ToLower())
                return ("Your name is a palindrome!!");

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return $"Hello {firstName}{lastName}".Trim();            

            return ($"Hello {firstName} {lastName}");
        }

        private string Palindrome (string fullName)
        {
            StringBuilder reverseName = new StringBuilder();

            for (int i = fullName.Length -1; i >= 0; i-- )
                 reverseName.Append(fullName[i]);

            return reverseName.ToString();

        }
    }
}