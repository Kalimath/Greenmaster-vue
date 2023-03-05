using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public class GetAllSpeciesWithGenusShould : SpecieTestBase
{
    [Fact]
    public async Task GetAllSpeciesWithGenus_ReturnsOkResultWithData()
    {
        // Arrange
        var buxusGenusSpecies = Species.Where(specie => specie.Genus == SpecieBuxus.Genus).ToList();
        MockedSpecieService.GetAllWithGenus(SpecieBuxus.Genus.Capitalise()).Returns(buxusGenusSpecies);

        // Act
        var result = (Ok<SpecieDTO[]>)await SpecieEndPointsV1.GetAllSpeciesWithGenus(SpecieBuxus.Genus, MockedSpecieService);

        // Assert: Check for the correct returned type
        Assert.IsType<Ok<SpecieDTO[]>>(result);
        Assert.NotNull(result.Value);
        Assert.True(buxusGenusSpecies.Count == result.Value.Length);
        Assert.True(result.Value.All(dto => dto.Genus == SpecieBuxus.Genus));
    }
     
    [Fact]
    public async Task GetAllSpeciesWithGenus_ReturnsBadRequest_WhenGenusNull()
    {
        // Act
        var result = (BadRequest<string>)await SpecieEndPointsV1.GetAllSpeciesWithGenus(null!, MockedSpecieService);

        // Assert: Check for the correct returned type
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
     
    [Fact]
    public async Task GetAllSpeciesWithGenus_ReturnsBadRequest_WhenGenusEmpty()
    {
        // Act
        var result = (BadRequest<string>)await SpecieEndPointsV1.GetAllSpeciesWithGenus(string.Empty, MockedSpecieService);

        // Assert: Check for the correct returned type
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
     
    [Fact]
    public async Task GetAllSpeciesWithGenus_ReturnsBadRequest_WhenGenusWhitespace()
    {
        // Act
        var result = (BadRequest<string>)await SpecieEndPointsV1.GetAllSpeciesWithGenus("  ", MockedSpecieService);

        // Assert: Check for the correct returned type
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}