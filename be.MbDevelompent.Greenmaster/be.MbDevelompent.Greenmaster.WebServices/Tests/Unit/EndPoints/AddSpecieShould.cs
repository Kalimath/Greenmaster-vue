using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public class AddSpecieShould : SpecieTestBase
{
    [Fact]
    public async Task AddSpecie_CreatesSpecieInDatabase()
    {
        //Arrange
        var newSpecie = SpecieBuxusDTO;
        MockedSpecieService.Add(SpecieBuxus).Returns(Task.CompletedTask);

        //Act
        var createdResult = (Created<SpecieDTO>)await SpecieEndPointsV1.AddSpecie(newSpecie, MockedSpecieService);

        //Assert
        Assert.Equal(201, createdResult.StatusCode);
        Assert.NotNull(createdResult.Location);
        Assert.IsAssignableFrom<SpecieDTO>(createdResult.Value);

        await MockedSpecieService.Received(1).Add(Arg.Any<Specie>());
    }
     
    [Fact]
    public async Task AddSpecie_DoesNotAdd_WhenSpecieInDatabase()
    {
        //Arrange
        var newSpecie = SpecieBuxusDTO;
        MockedSpecieService.SpecieExistsWith(SpecieBuxus.Genus, SpecieBuxus.Species).Returns(true);

        //Act
        var result = (Conflict<string>) await SpecieEndPointsV1.AddSpecie(newSpecie, MockedSpecieService);

        //Assert
        Assert.Equal(StatusCodes.Status409Conflict, result.StatusCode);
        await MockedSpecieService.Received(0).Add(Arg.Any<Specie>());
    }
}