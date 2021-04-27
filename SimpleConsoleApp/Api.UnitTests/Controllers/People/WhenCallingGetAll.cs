using System.Collections.Generic;
using System.Net;
using Api.Controllers;
using AutoFixture.NUnit3;
using Domain;
using Domain.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SFA.DAS.Testing.AutoFixture;

namespace Api.UnitTests.Controllers.People
{
    public class WhenCallingGetAll
    {
        [Test, MoqAutoData]
        public void Then_Ok_Is_Returned(
            List<Person> returnData,
            [Frozen] Mock<IPersonService> service,
            [Greedy] PeopleController controller)
        {
            //Arrange
            service.Setup(x => x.GetPeople()).Returns(returnData);
            
            //Act
            var actual = controller.GetAll() as ObjectResult;
            
            //Assert
            actual.Should().NotBeNull();
            actual.StatusCode.Should().Be((int) HttpStatusCode.OK);
        }
    }
}