using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
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
}