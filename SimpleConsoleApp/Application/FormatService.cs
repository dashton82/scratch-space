using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Application
{
    public class FormatService
    {
        public string GetGreeting(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return "You have no name!";

            var fullName = firstName + lastName;
            if (Regex.IsMatch(fullName, "[0-9]"))
                return ("You have number in your name!!");

            if (ReverseString(fullName).Equals(fullName.ToLower(), StringComparison.CurrentCultureIgnoreCase))
                return ("Your name is a palindrome!!");

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return $"Hello {firstName}{lastName}".Trim();            

            return $"Hello {firstName} {lastName}";
        }

        private string ReverseString (string input)
        {
            var reverseInput = new StringBuilder();

            for (var i = input.Length -1; i >= 0; i-- )
                 reverseInput.Append(input[i]);

            return reverseInput.ToString();
        }
    }
}