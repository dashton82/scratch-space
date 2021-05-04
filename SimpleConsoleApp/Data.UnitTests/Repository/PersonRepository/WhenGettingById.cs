using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SFA.DAS.Courses.Data.UnitTests.DatabaseMock;
using SFA.DAS.Testing.AutoFixture;

namespace Data.UnitTests.Repository.PersonRepository
{
    public class WhenGettingById
    {
        [Test, MoqAutoData]
        public async Task Then_The_Person_Entity_Are_Returned_From_The_Repository(
            List<PersonEntity> persons,
            PersonEntity person,
            [Frozen]Mock<IPersonDataContext> dataContext,
            Data.Repository.PersonRepository personRepository)
        {
            //Arrange
            persons.Add(person);
            dataContext.Setup(x => x.PersonEntities).ReturnsDbSet(persons);
            dataContext.Setup(x => x.PersonEntities.FindAsync(It.Is<Guid>(c=>c.Equals(person.Id)))).ReturnsAsync(person);

            //Act
            var actual = await personRepository.GetById(person.Id);

            //Assert
            actual.Should().BeEquivalentTo(person);

        }
    }
}