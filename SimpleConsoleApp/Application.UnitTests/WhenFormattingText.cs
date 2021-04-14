using NUnit.Framework;

namespace Application.UnitTests
{
    public class WhenFormattingText
    {
        private FormatService _service;

        [SetUp]
        public void Setup()
        {
            _service = new FormatService();
        }

        [TestCase("Barry", "Smith", "Hello Barry Smith")]
        [TestCase("", "Smith", "Hello Smith")]
        [TestCase("Barry", "", "Hello Barry")]
        [TestCase("", "", "You have no name!")]
        [TestCase("a23", "smith", "You have number in your name!!")]
        [TestCase("Barry", "5", "You have number in your name!!")]
        [TestCase("Anna", "", "You name is a palindrome!!")]
        [TestCase("", "Madam", "You name is a palindrome!!")]
        public void Then_When_Calling_GetGreeting_Then_The_Expected_ResponseIs_Returned(string firstName, string lastName, string expected)
        {
            var actual = _service.GetGreeting(firstName, lastName);
            
            Assert.AreEqual(expected, actual);
        }
    }
}