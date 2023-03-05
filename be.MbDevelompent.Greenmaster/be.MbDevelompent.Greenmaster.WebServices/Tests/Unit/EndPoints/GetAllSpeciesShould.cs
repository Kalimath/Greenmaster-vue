using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public class GetAllSpeciesShould : SpecieTestBase
{
    [Fact]
    public async Task ReturnOkResult()
    {
        // Arrange
        MockedSpecieService.GetAll().Returns(Species);

        // Act
        var result = await SpecieEndPointsV1.GetAllSpecies(MockedSpecieService);

        // Assert: Check for the correct returned type
        Assert.IsType<Ok<SpecieDTO[]>>(result);
    }
     
    [Fact]
    public async Task ReturnSpeciesFromDatabase()
    {
        // Arrange
        MockedSpecieService.GetAll().Returns(Species);

        // Act
        var okResult = (Ok<SpecieDTO[]>)await SpecieEndPointsV1.GetAllSpecies(MockedSpecieService);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundSpecies = Assert.IsAssignableFrom<SpecieDTO[]>(okResult.Value);

        Assert.NotEmpty(foundSpecies);
        Assert.Equal(Species.Count, foundSpecies.Length);
    }
}