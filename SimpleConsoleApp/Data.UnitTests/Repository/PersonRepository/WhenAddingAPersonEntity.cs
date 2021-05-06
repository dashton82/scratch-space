using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using Domain;
using Moq;
using NUnit.Framework;
using SFA.DAS.Courses.Data.UnitTests.DatabaseMock;
using SFA.DAS.Testing.AutoFixture;

namespace Data.UnitTests.Repository.PersonRepository
{
    public class WhenAddingAPersonEntity
    {
        [Test, MoqAutoData]
        public async Task Then_The_Person_Entity_Are_Returned_From_The_Repository(
            List<PersonEntity> persons,
            PersonEntity person,
            [Frozen]Mock<IPersonDataContext> dataContext,
            Data.Repository.PersonRepository personRepository)
        {
            //Arrange
            dataContext.Setup(x => x.PersonEntities).ReturnsDbSet(persons);

            //Act
            await personRepository.Create(person);

            //Assert
            dataContext.Verify(x=>x.SaveChanges(), Times.Once);

            //verify its been added?
            dataContext.Verify(x => x.PersonEntities.AddAsync(person, CancellationToken.None), Times.Once);
        }
    }
}