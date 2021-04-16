using System;

namespace Application
{
    public class FormatService
    {
        public string GetGreeting(string firstName, string lastName)
        {
            string fullName = firstName + lastName;
            string reverseName = string.Empty;
            for (int i = fullName.Length -1; i >= 0; i-- )
            {
                reverseName += fullName[i].ToString();

                 if (reverseName.ToLower() == fullName.ToLower())
                     return ("Your name is a palindrome!!");
            }

            foreach (char c in firstName + lastName)
            {
                if (Char.IsDigit(c))
                {
                    return ("You have number in your name!!");
                }
            }

            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName))
            {
                if (String.IsNullOrEmpty(firstName) && String.IsNullOrEmpty(lastName))
                    return "You have no name!";

                else return ($"Hello {firstName.Trim()}{lastName.Trim()}");
            }
 
            else return ($"Hello {firstName} {lastName}");
        }
    }
}