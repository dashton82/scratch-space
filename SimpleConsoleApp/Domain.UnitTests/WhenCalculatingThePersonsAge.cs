using System;
using Application;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Domain.UnitTests
{
    public class WhenCalculatingThePersonsAge
    {
        [Test, AutoData]
        public void Then_If_DateOfBirth_In_Future_Then_Age_Is_Zero(string firstname, string lastName, string greeting)
        {
            //Arrange
            var mockService = new Mock<IFormatService>();
            mockService.Setup(x => x.GetGreeting(firstname, lastName)).Returns(greeting);
            var dateOfBirth = DateTime.Now.AddDays(1);
            
            //Act
            var person = new Person(firstname, lastName, dateOfBirth, mockService.Object.GetGreeting);

            //Assert
            person.Age.Should().Be(0);
            person.GreetingMessage.Should().Be(greeting);
        }
        
        [Test, AutoData]
        public void Then_If_DateOfBirth_In_Past_Then_Age_Is_Calculated_Correctly(string firstname, string lastName, string greeting)
        {
            //Arrange
            var mockService = new Mock<IFormatService>();
            mockService.Setup(x => x.GetGreeting(firstname, lastName)).Returns(greeting);

            var dateOfBirth = DateTime.Now.AddYears(-10);

            //Act
            var person = new Person(firstname, lastName, dateOfBirth, mockService.Object.GetGreeting);

            //Assert
            person.Age.Should().Be(10);
            person.GreetingMessage.Should().Be(greeting);
        }
        
        
        [Test, AutoData]
        public void Then_The_Age_Is_Correctly_Rounded_Down(string firstname, string lastName, string greeting)
        {
            //Arrange
            var mockService = new Mock<IFormatService>();
            mockService.Setup(x => x.GetGreeting(firstname, lastName)).Returns(greeting);

            var dateOfBirth = DateTime.Now.AddYears(-10).AddMonths(1);

            //Act
            var person = new Person(firstname, lastName, dateOfBirth, mockService.Object.GetGreeting);

            //Assert
            person.Age.Should().Be(9);
            person.GreetingMessage.Should().Be(greeting);
        }
    }
}