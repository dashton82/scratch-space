using AutoFixture.NUnit3;
using FluentAssertions;
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
        [TestCase("Anna", "", "Your name is a palindrome!!")]
        [TestCase("", "Madam", "Your name is a palindrome!!")]
        public void Then_When_Calling_GetGreeting_Then_The_Expected_ResponseIs_Returned(string firstName, string lastName, string expected)
        {
            var actual = _service.GetGreeting(firstName, lastName);
            
            Assert.AreEqual(expected, actual);
        }

        [Test, AutoData]
        public void Then_The_Correct_Response_Is_Returned_If_You_Have_Numeric_Characters_In_FirstName_And_LastName(string firstName, string lastName)
        {
            var actual = _service.GetGreeting(firstName, lastName);

            actual.Should().Be($"You have number in your name!!");
        }
        
    }
}