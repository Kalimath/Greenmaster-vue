using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public class UpdateSpecieShould : SpecieTestBase
{
    [Fact]
    public async Task UpdateSpecie_UpdatesSpecieInDatabase()
    {
        //Arrange
        var existingSpecie = SpecieBuxus;

        var updatedSpecie = new Specie()
        {
            Id = 1,
            Genus = SpecieBuxus.Genus,
            Species = SpecieBuxusSinica.Species,
            CommonName = SpecieBuxus.CommonName,
            Type = PlantType.Tree.ToString(),
            Cycle = Lifecycle.Biennial.ToString()
        };
        MockedSpecieService.Find(SpecieBuxus.Id).Returns(SpecieBuxus);
        MockedSpecieService.Update(updatedSpecie).Returns(Task.CompletedTask);

        //Act
        var updatedResult = (Ok<Specie>)await SpecieEndPointsV1.UpdateSpecie(existingSpecie.Id, new SpecieDTO(updatedSpecie), MockedSpecieService);

        //Assert
        Assert.Equal(StatusCodes.Status200OK, updatedResult.StatusCode);
        Assert.NotNull(updatedResult.Value);
         
        AssertUnchangedSpecieProperties(SpecieBuxus, updatedResult.Value);
        AssertModifiedSpecieProperties(updatedSpecie, updatedResult.Value);

        await MockedSpecieService.Received(1).Update(Arg.Any<Specie>());
    }

    [Fact]
    public async Task UpdateSpecie_ReturnsNotFound_WhenSpecieNull()
    {
        //Arrange
        var updatedSpecie = new Specie()
        {
            Id = 1,
            Genus = SpecieBuxus.Genus,
            Species = SpecieBuxusSinica.Species,
            CommonName = "Boxwood",
            Type = PlantType.Tree.ToString(),
            Cycle = Lifecycle.Biennial.ToString()
        };
        MockedSpecieService.Find(SpecieBuxus.Id).Returns((Specie?)null);

        //Act
        var updatedResult = (NotFound)await SpecieEndPointsV1.UpdateSpecie(SpecieBuxus.Id, new SpecieDTO(updatedSpecie), MockedSpecieService);

        //Assert
        Assert.Equal(StatusCodes.Status404NotFound, updatedResult.StatusCode);

        await MockedSpecieService.Received(1).Find(SpecieBuxus.Id);
        await MockedSpecieService.Received(0).Update(Arg.Any<Specie>());
    }  
     
    [Fact]
    public async Task UpdateSpecie_ReturnsConflict_WhenScientificNameExistsElsewhere()
    {
        //Arrange
        var updatedSpecie = new Specie()
        {
            Id = 1,
            Genus = SpecieBuxus.Genus,
            Species = SpecieBuxus.Species,
            CommonName = "Boxwood",
            Type = PlantType.Tree.ToString(),
            Cycle = Lifecycle.Biennial.ToString()
        };
        var similarSpecie = new Specie()
        {
            Id = 2,
            Genus = SpecieBuxus.Genus,
            Species = SpecieBuxus.Species,
            CommonName = "Boxwood",
            Type = PlantType.Tree.ToString(),
            Cycle = Lifecycle.Biennial.ToString()
        };
        MockedSpecieService.Find(updatedSpecie.Id).Returns(SpecieBuxus);
        MockedSpecieService.Find(updatedSpecie.ScientificName).Returns(similarSpecie);

        //Act
        var updatedResult = (Conflict<string>)await SpecieEndPointsV1.UpdateSpecie(SpecieBuxus.Id, new SpecieDTO(updatedSpecie), MockedSpecieService);

        //Assert
        Assert.Equal(StatusCodes.Status409Conflict, updatedResult.StatusCode);
        
        await MockedSpecieService.Received(1).Find(updatedSpecie.ScientificName);
        await MockedSpecieService.Received(0).Update(Arg.Any<Specie>());
    }
}