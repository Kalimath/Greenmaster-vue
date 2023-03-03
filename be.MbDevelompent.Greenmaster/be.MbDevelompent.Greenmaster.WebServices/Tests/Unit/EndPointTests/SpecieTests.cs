using System.Diagnostics;
using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using be.MbDevelompent.Greenmaster.WebServices.Services;
using be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPointTests;

public class SpecieTests
{
    private readonly ISpecieService _mockedSpecieService;
    private readonly List<Specie> _species;
    private readonly Specie _specieBuxus;
    private readonly Specie _specieStrelitzia;

    public SpecieTests()
    {
        _mockedSpecieService = Substitute.For<ISpecieService>();
        _specieBuxus = new Specie
        {
            Id = 1,
            ScientificName = "Buxus Sempervirens",
            Name = "Boxtree",
            Type = PlantType.Bush.ToString(),
            Cycle = Lifecycle.Perennial.ToString()
        };
        _specieStrelitzia = new Specie
        {
            Id = 1,
            ScientificName = "Strelitzia Reginae",
            Name = "Bird of paradise",
            Type = PlantType.Bush.ToString(),
            Cycle = Lifecycle.Perennial.ToString()
        };
        
        _species = new List<Specie> {
            _specieBuxus,_specieStrelitzia
        };
    }

    [Fact]
     public async Task GetAllSpecies_ReturnsOkResult()
     {
         // Arrange
         var db = new MockedSpecieDb().CreateDbContext();
         _mockedSpecieService.GetAll().Returns(_species);

         // Act
         var result = await SpecieEndPointsV1.GetAllSpecies(_mockedSpecieService);

         // Assert: Check for the correct returned type
         Assert.IsType<Ok<SpecieDTO[]>>(result);
     }
     
     [Fact]
     public async Task GetSpecieReturnsNotFoundIfNotExists()
     {
         // Arrange
         _mockedSpecieService.Find(Arg.Any<int>()).Returns((Specie?)null);

         // Act
         var notFoundResult = (NotFound)await SpecieEndPointsV1.GetSpecieWithId(1, _mockedSpecieService);

         //Assert
         Assert.Equal(404, notFoundResult.StatusCode);
     }
     
     [Fact]
     public async Task GetAllReturnsSpeciesFromDatabase()
     {
         // Arrange
         _mockedSpecieService.GetAll().Returns(_species);

         // Act
         var okResult = (Ok<SpecieDTO[]>)await SpecieEndPointsV1.GetAllSpecies(_mockedSpecieService);

         //Assert
         Assert.Equal(200, okResult.StatusCode);
         var foundSpecies = Assert.IsAssignableFrom<SpecieDTO[]>(okResult.Value);

         Assert.NotEmpty(foundSpecies);
         Assert.Equal(_species.Count, foundSpecies.Length);
         Assert.Collection(foundSpecies, specie1 =>
         {
             Assert.Equal(_specieBuxus.Id, specie1.Id);
             Assert.Equal(_specieBuxus.ScientificName, specie1.ScientificName);
             Assert.Equal(_specieBuxus.Name, specie1.Name);
             Assert.Equal(_specieBuxus.Type, specie1.Type);
             Assert.Equal(_specieBuxus.Cycle, specie1.Cycle);
         }, specie2 =>
         {
             Assert.Equal(_specieStrelitzia.Id, specie2.Id);
             Assert.Equal(_specieStrelitzia.ScientificName, specie2.ScientificName);
             Assert.Equal(_specieStrelitzia.Name, specie2.Name);
             Assert.Equal(_specieStrelitzia.Type, specie2.Type);
             Assert.Equal(_specieStrelitzia.Cycle, specie2.Cycle);
         });
     }
}