using System;
using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTests
{
    public class WhenCalculatingThePersonsAge
    {
        [Test, AutoData]
        public void Then_If_DateOfBirth_In_Future_Then_Age_Is_Zero(Person person)
        {
            person.DateOfBirth = DateTime.Now.AddDays(1);
            person.DateToday = DateTime.UtcNow;

            person.Age.Should().Be(0);
        }
        
        [Test, AutoData]
        public void Then_If_DateOfBirth_In_Past_Then_Age_Is_Calculated_Correctly(Person person)
        {
            person.DateToday = DateTime.UtcNow;
            person.DateOfBirth = DateTime.Now.AddYears(-10);

            person.Age.Should().Be(10);
        }
        
        
        [Test, AutoData]
        public void Then_The_Age_Is_Correctly_Rounded_Down(Person person)
        {
            person.DateToday = DateTime.UtcNow;
            person.DateOfBirth = DateTime.Now.AddYears(-10).AddMonths(-1);

            person.Age.Should().Be(9);
        }
    }
}