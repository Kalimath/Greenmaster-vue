using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public class GetAllSpeciesWithTypeShould : SpecieTestBase
{
    [Fact]
    public async Task GetAllSpeciesWithType_ReturnsOkResultWithData()
    {
        
        // Arrange
        const PlantType bushType = PlantType.Bush;
        var bushes = Species.Where(specie => specie.Type == bushType).ToList();
        MockedSpecieService.GetAllWithType(bushType).Returns(bushes);

        // Act
        var result = (Ok<SpecieDTO[]>)await SpecieEndPointsV1.GetAllSpeciesWithType(bushType.ToString(), MockedSpecieService);

        // Assert: Check for the correct returned type
        Assert.IsType<Ok<SpecieDTO[]>>(result);
        Assert.NotNull(result.Value);
        Assert.True(bushes.Count == result.Value.Length);
        Assert.True(result.Value.All(dto => dto.Type == bushType.ToString()));
    }
     
    [Fact]
    public async Task GetAllSpeciesWithType_ReturnsBadRequest_WhenTypeInvalid()
    {
        // Act
        var result = (BadRequest<string>)await SpecieEndPointsV1.GetAllSpeciesWithType("invalidType", MockedSpecieService);

        // Assert: Check for the correct returned type
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}