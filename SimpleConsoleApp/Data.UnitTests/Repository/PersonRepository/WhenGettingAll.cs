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
    public class WhenGettingAll
    {
        [Test, MoqAutoData]
        public async Task Then_The_Person_Entities_Are_Returned_From_The_Repository(
            List<PersonEntity> persons,
            [Frozen]Mock<IPersonDataContext> dataContext,
            Data.Repository.PersonRepository personRepository)
        {
            dataContext.Setup(x => x.PersonEntities).ReturnsDbSet(persons);

            var actual = await personRepository.GetAll();

            actual.Should().BeEquivalentTo(persons);

        }
    }
}