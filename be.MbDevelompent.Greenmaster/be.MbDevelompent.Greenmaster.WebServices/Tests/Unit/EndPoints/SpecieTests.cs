using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using be.MbDevelompent.Greenmaster.WebServices.Services;
using be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;

// ReSharper disable MethodTooLong

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

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
            Id = 2,
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
     public async Task GetAllSpecies_ReturnsSpeciesFromDatabase()
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
     
     [Fact]
     public async Task GetSpecieWithId_ReturnsNotFoundIfNotExists()
     {
         // Arrange
         _mockedSpecieService.Find(Arg.Any<int>()).Returns((Specie?)null);

         // Act
         var notFoundResult = (NotFound)await SpecieEndPointsV1.GetSpecieWithId(1, _mockedSpecieService);

         //Assert
         Assert.Equal(404, notFoundResult.StatusCode);
     }

     [Fact]
     public async Task GetSpecieWithId_ReturnsSpecieFromDatabase()
     {
         // Arrange
         _mockedSpecieService.Find(1)
             .Returns(_specieBuxus);

         // Act
         var okResult = (Ok<SpecieDTO>)await SpecieEndPointsV1.GetSpecieWithId(1, _mockedSpecieService);

         //Assert
         Assert.Equal(200, okResult.StatusCode);
         var foundSpecie = Assert.IsAssignableFrom<SpecieDTO>(okResult.Value);
         Assert.Equal(1, foundSpecie.Id);
     }
     
     [Fact]
     public async Task GetSpecieByScientificName_ReturnsSpecieFromDatabase()
     {
         // Arrange
         _mockedSpecieService.Find(_specieBuxus.ScientificName.TrimAndLower())
             .Returns(_specieBuxus);

         // Act
         var okResult = (Ok<SpecieDTO>)await SpecieEndPointsV1.GetSpecieByScientificName(_specieBuxus.ScientificName, _mockedSpecieService);

         //Assert
         Assert.Equal(200, okResult.StatusCode);
         var foundSpecie = Assert.IsAssignableFrom<SpecieDTO>(okResult.Value);
         Assert.Equal(1, foundSpecie.Id);
     }
     
     [Fact]
     public async Task GetSpecieByScientificName_ReturnsNotFoundIfNotExists()
     {
         // Arrange
         _mockedSpecieService.Find(Arg.Any<string>()).Returns((Specie?)null);

         // Act
         var notFoundResult = (NotFound)await SpecieEndPointsV1.GetSpecieByScientificName(_specieStrelitzia.ScientificName, _mockedSpecieService);

         //Assert
         Assert.Equal(404, notFoundResult.StatusCode);
     }
     
     [Fact]
     public async Task AddSpecie_CreatesSpecieInDatabase()
     {
         //Arrange
         var newSpecie = new SpecieDTO(_specieBuxus);
         _mockedSpecieService.Add(_specieBuxus).Returns(Task.CompletedTask);

         //Act
         var createdResult = (Created<SpecieDTO>)await SpecieEndPointsV1.AddSpecie(newSpecie, _mockedSpecieService);

         //Assert
         Assert.Equal(201, createdResult.StatusCode);
         Assert.NotNull(createdResult.Location);
         Assert.IsAssignableFrom<SpecieDTO>(createdResult.Value);

         await _mockedSpecieService.Received(1).Add(Arg.Any<Specie>());
     }
     
     [Fact]
     public async Task AddSpecie_DoesNotAdd_WhenSpecieInDatabase()
     {
         //Arrange
         var newSpecie = new SpecieDTO(_specieBuxus);
         _mockedSpecieService.ExistsWithScientificName(_specieBuxus.ScientificName).Returns(true);

         //Act
         var result = (Conflict<string>) await SpecieEndPointsV1.AddSpecie(newSpecie, _mockedSpecieService);

         //Assert
         Assert.Equal(StatusCodes.Status409Conflict, result.StatusCode);
         await _mockedSpecieService.Received(0).Add(Arg.Any<Specie>());
     }
     
     [Fact]
     public async Task UpdateSpecie_UpdatesSpecieInDatabase()
     {
         //Arrange
         var existingSpecie = _specieBuxus;

         var updatedSpecie = new Specie()
         {
             Id = 1,
             ScientificName = "Buxus 2",
             Name = "Boxwood",
             Type = PlantType.Tree.ToString(),
             Cycle = Lifecycle.Biennial.ToString()
         };
         _mockedSpecieService.Find(_specieBuxus.Id).Returns(_specieBuxus);
         _mockedSpecieService.Update(updatedSpecie).Returns(Task.CompletedTask);

         //Act
         var updatedResult = (Ok)await SpecieEndPointsV1.UpdateSpecie(existingSpecie.Id, new SpecieDTO(updatedSpecie), _mockedSpecieService);

         //Assert
         Assert.Equal(StatusCodes.Status200OK, updatedResult.StatusCode);

         await _mockedSpecieService.Received(1).Update(Arg.Any<Specie>());
     }  
     [Fact]
     public async Task UpdateSpecie_ReturnsNotFound_WhenSpecieNull()
     {
         //Arrange
         var updatedSpecie = new Specie()
         {
             Id = 1,
             ScientificName = "Buxus 2",
             Name = "Boxwood",
             Type = PlantType.Tree.ToString(),
             Cycle = Lifecycle.Biennial.ToString()
         };
         _mockedSpecieService.Find(_specieBuxus.Id).Returns((Specie?)null);

         //Act
         var updatedResult = (NotFound)await SpecieEndPointsV1.UpdateSpecie(_specieBuxus.Id, new SpecieDTO(updatedSpecie), _mockedSpecieService);

         //Assert
         Assert.Equal(StatusCodes.Status404NotFound, updatedResult.StatusCode);

         await _mockedSpecieService.Received(1).Find(_specieBuxus.Id);
         await _mockedSpecieService.Received(0).Update(Arg.Any<Specie>());
     }  
     
     [Fact]
     public async Task UpdateSpecie_ReturnsConflict_WhenScientificNameExistsElsewhere()
     {
         //Arrange
         var updatedSpecie = new Specie()
         {
             Id = 1,
             ScientificName = _specieBuxus.ScientificName,
             Name = "Boxwood",
             Type = PlantType.Tree.ToString(),
             Cycle = Lifecycle.Biennial.ToString()
         };
         var similarSpecie = new Specie()
         {
             Id = 2,
             ScientificName = _specieBuxus.ScientificName,
             Name = "Boxwood",
             Type = PlantType.Tree.ToString(),
             Cycle = Lifecycle.Biennial.ToString()
         };
         _mockedSpecieService.Find(updatedSpecie.Id).Returns(_specieBuxus);
         _mockedSpecieService.Find(updatedSpecie.ScientificName).Returns(similarSpecie);

         //Act
         var updatedResult = (Conflict<string>)await SpecieEndPointsV1.UpdateSpecie(_specieBuxus.Id, new SpecieDTO(updatedSpecie), _mockedSpecieService);

         //Assert
         Assert.Equal(StatusCodes.Status409Conflict, updatedResult.StatusCode);

         await _mockedSpecieService.Received(1).Find(updatedSpecie.ScientificName);
         await _mockedSpecieService.Received(0).Update(Arg.Any<Specie>());
     }
     
     [Fact]
     public async Task DeleteTodoDeletesTodoInDatabase()
     {
         //Arrange
         _mockedSpecieService.Find(_specieBuxus.Id).Returns(_specieBuxus);
         _mockedSpecieService.Remove(_specieBuxus).Returns(Task.CompletedTask);

         //Act
         var noContentResult = (NoContent)await SpecieEndPointsV1.DeleteSpecie(_specieBuxus.Id, _mockedSpecieService);

         //Assert
         Assert.Equal(204, noContentResult.StatusCode);

         await _mockedSpecieService.Received(1).Remove(Arg.Any<Specie>());
     }
}