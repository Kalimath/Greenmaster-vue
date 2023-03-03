using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPointTests;

public class SpecieTests
{
     [Fact]
     public async Task GetAllSpecies_ReturnsOkResult()
     {
         // Arrange
         var db = new MockedSpecieDb().CreateDbContext();

         // Act
         var result = await SpecieEndPointsV1.GetAllSpecies(db);

         // Assert: Check for the correct returned type
         Assert.IsType<Ok<SpecieDTO[]>>(result);
     }
     
     [Fact]
     public async Task GetSpecieReturnsNotFoundIfNotExists()
     {
         // Arrange
         var mockedSpecieService = Substitute.For<ISpecieService>();

         mockedSpecieService.Find(Arg.Any<int>()).Returns((Specie?)null);

         // Act
         var notFoundResult = (NotFound)await SpecieEndPointsV1.GetSpecieWithId(1, mockedSpecieService);

         //Assert
         Assert.Equal(404, notFoundResult.StatusCode);
     }
}

public interface ISpecieService
{
    ValueTask<Specie?> Find(int any);
}