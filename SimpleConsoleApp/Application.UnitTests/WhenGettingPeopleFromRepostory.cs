using System.Collections.Generic;
using System.Linq;
using AutoFixture.NUnit3;
using Data;
using Domain;
using Domain.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

//Using FluentAssertions makes testing easier

namespace Application.UnitTests
{
    public class WhenGettingPeopleFromRepository
    {
// Test creates own values for PersonEntity and Greeting and then checks that when converted to Person list values match original. 
        [Test, AutoData]
        public void Then_The_List_Of_PersonEntities_Is_Mapped_To_The_Person_Domain(List<PersonEntity> personEntities, string greeting)
        {
            //Arrange
            // Can only mock interfaces 
            var mockRepo = new Mock<IPersonRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(personEntities);
            var mockGreetingService = new Mock<IFormatService>();
            mockGreetingService.Setup(x => x.GetGreeting(It.IsAny<string>(), It.IsAny<string>())).Returns(greeting);
            var service = new PersonService(mockRepo.Object, mockGreetingService.Object);

            //Act
            var actual = service.GetPeople().ToList();

            //Assert
            Assert.IsNotNull(actual);
            actual.Should().BeEquivalentTo(personEntities, options=>options.Excluding(c=>c.Id));
            actual.ToList().TrueForAll(c => c.GreetingMessage.Equals(greeting));
        }

        [Test]
        public void Then_If_The_List_Of_PersonEntities_Is_Null_Then_Null_Returned()
        {
            //Arrange
            var mockRepo = new Mock<IPersonRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync((IEnumerable<PersonEntity>)null);// return null when we call the repository GetAll method
            var mockGreetingService = new Mock<IFormatService>();
            var service = new PersonService(mockRepo.Object, mockGreetingService.Object);

            //Act
            var actual = service.GetPeople();

            //Assert
            Assert.IsNull(actual);
        }
    }
}