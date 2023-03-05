using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public class GetSpecieByScientificNameShould : SpecieTestBase
{
    [Fact]
    public async Task GetSpecieByScientificName_ReturnsSpecieFromDatabase()
    {
        // Arrange
        MockedSpecieService.Find(SpecieBuxus.ScientificName.TrimAndLower())
            .Returns(SpecieBuxus);

        // Act
        var okResult = (Ok<SpecieDTO>)await SpecieEndPointsV1.GetSpecieByScientificName(SpecieBuxus.ScientificName, MockedSpecieService);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundSpecie = Assert.IsAssignableFrom<SpecieDTO>(okResult.Value);
        Assert.Equal(1, foundSpecie.Id);
    }
     
    [Fact]
    public async Task GetSpecieByScientificName_ReturnsNotFoundIfNotExists()
    {
        // Arrange
        MockedSpecieService.Find(Arg.Any<string>()).Returns((Specie?)null);

        // Act
        var notFoundResult = (NotFound)await SpecieEndPointsV1.GetSpecieByScientificName(SpecieStrelitzia.ScientificName, MockedSpecieService);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
    }
}