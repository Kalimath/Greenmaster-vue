using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

// ReSharper disable MethodTooLong

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public class DeleteSpecieShould : SpecieTestBase
{
    [Fact]
     public async Task DeleteSpecieInDatabase()
     {
         //Arrange
         MockedSpecieService.Find(SpecieBuxus.Id).Returns(SpecieBuxus);
         MockedSpecieService.Remove(SpecieBuxus).Returns(Task.CompletedTask);

         //Act
         var noContentResult = (NoContent)await SpecieEndPointsV1.DeleteSpecie(SpecieBuxus.Id, MockedSpecieService);

         //Assert
         Assert.Equal(204, noContentResult.StatusCode);

         await MockedSpecieService.Received(1).Remove(Arg.Any<Specie>());
     }

}