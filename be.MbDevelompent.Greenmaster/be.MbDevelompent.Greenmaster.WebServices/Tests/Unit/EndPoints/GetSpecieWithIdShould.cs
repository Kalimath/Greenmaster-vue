using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public class GetSpecieWithIdShould : SpecieTestBase
{
    [Fact]
    public async Task GetSpecieWithId_ReturnsNotFoundIfNotExists()
    {
        // Arrange
        MockedSpecieService.Find(Arg.Any<int>()).Returns((Specie?)null);

        // Act
        var notFoundResult = (NotFound)await SpecieEndPointsV1.GetSpecieWithId(1, MockedSpecieService);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task GetSpecieWithId_ReturnsSpecieFromDatabase()
    {
        // Arrange
        MockedSpecieService.Find(1)
            .Returns(SpecieBuxus);

        // Act
        var okResult = (Ok<SpecieDTO>)await SpecieEndPointsV1.GetSpecieWithId(1, MockedSpecieService);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundSpecie = Assert.IsAssignableFrom<SpecieDTO>(okResult.Value);
        Assert.Equal(1, foundSpecie.Id);
    }
}