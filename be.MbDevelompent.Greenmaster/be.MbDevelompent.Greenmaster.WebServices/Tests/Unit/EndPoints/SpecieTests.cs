using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using be.MbDevelompent.Greenmaster.WebServices.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

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
        
        _species = new List<Specie> {
            SpecieBuxus, SpecieBuxusSinica, SpecieStrelitzia
        };
    }

    [Fact]
     public async Task GetAllSpecies_ReturnsOkResult()
     {
         // Arrange
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
     }
     
     [Fact]
     public async Task GetAllSpeciesWithGenus_ReturnsOkResultWithData()
     {
         // Arrange
         var buxusGenusSpecies = _species.Where(specie => specie.Genus == SpecieBuxus.Genus).ToList();
         _mockedSpecieService.GetAllWithGenus(SpecieBuxus.Genus.Capitalise()).Returns(buxusGenusSpecies);

         // Act
         var result = (Ok<SpecieDTO[]>)await SpecieEndPointsV1.GetAllSpeciesWithGenus(SpecieBuxus.Genus, _mockedSpecieService);

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
         var result = (BadRequest<string>)await SpecieEndPointsV1.GetAllSpeciesWithGenus(null!, _mockedSpecieService);

         // Assert: Check for the correct returned type
         Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
     }
     
     [Fact]
     public async Task GetAllSpeciesWithGenus_ReturnsBadRequest_WhenGenusEmpty()
     {
         // Act
         var result = (BadRequest<string>)await SpecieEndPointsV1.GetAllSpeciesWithGenus(string.Empty, _mockedSpecieService);

         // Assert: Check for the correct returned type
         Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
     }
     
     [Fact]
     public async Task GetAllSpeciesWithGenus_ReturnsBadRequest_WhenGenusWhitespace()
     {
         // Act
         var result = (BadRequest<string>)await SpecieEndPointsV1.GetAllSpeciesWithGenus("  ", _mockedSpecieService);

         // Assert: Check for the correct returned type
         Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
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
             .Returns(SpecieBuxus);

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
         _mockedSpecieService.Find(SpecieBuxus.ScientificName.TrimAndLower())
             .Returns(SpecieBuxus);

         // Act
         var okResult = (Ok<SpecieDTO>)await SpecieEndPointsV1.GetSpecieByScientificName(SpecieBuxus.ScientificName, _mockedSpecieService);

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
         var notFoundResult = (NotFound)await SpecieEndPointsV1.GetSpecieByScientificName(SpecieStrelitzia.ScientificName, _mockedSpecieService);

         //Assert
         Assert.Equal(404, notFoundResult.StatusCode);
     }
     
     [Fact]
     public async Task AddSpecie_CreatesSpecieInDatabase()
     {
         //Arrange
         var newSpecie = SpecieBuxusDTO;
         _mockedSpecieService.Add(SpecieBuxus).Returns(Task.CompletedTask);

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
         var newSpecie = SpecieBuxusDTO;
         _mockedSpecieService.SpecieExistsWith(SpecieBuxus.Genus, SpecieBuxus.Species).Returns(true);

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
         var existingSpecie = SpecieBuxus;

         var updatedSpecie = new Specie()
         {
             Id = 1,
             Genus = SpecieBuxus.Genus,
             Species = SpecieBuxusSinica.Species,
             Name = SpecieBuxus.Name,
             Type = PlantType.Tree.ToString(),
             Cycle = Lifecycle.Biennial.ToString()
         };
         _mockedSpecieService.Find(SpecieBuxus.Id).Returns(SpecieBuxus);
         _mockedSpecieService.Update(updatedSpecie).Returns(Task.CompletedTask);

         //Act
         var updatedResult = (Ok<Specie>)await SpecieEndPointsV1.UpdateSpecie(existingSpecie.Id, new SpecieDTO(updatedSpecie), _mockedSpecieService);

         //Assert
         Assert.Equal(StatusCodes.Status200OK, updatedResult.StatusCode);
         Assert.NotNull(updatedResult.Value);
         
         AssertUnchangedSpecieProperties(SpecieBuxus, updatedResult.Value);
         AssertModifiedSpecieProperties(updatedSpecie, updatedResult.Value);

         await _mockedSpecieService.Received(1).Update(Arg.Any<Specie>());
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
             Name = "Boxwood",
             Type = PlantType.Tree.ToString(),
             Cycle = Lifecycle.Biennial.ToString()
         };
         _mockedSpecieService.Find(SpecieBuxus.Id).Returns((Specie?)null);

         //Act
         var updatedResult = (NotFound)await SpecieEndPointsV1.UpdateSpecie(SpecieBuxus.Id, new SpecieDTO(updatedSpecie), _mockedSpecieService);

         //Assert
         Assert.Equal(StatusCodes.Status404NotFound, updatedResult.StatusCode);

         await _mockedSpecieService.Received(1).Find(SpecieBuxus.Id);
         await _mockedSpecieService.Received(0).Update(Arg.Any<Specie>());
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
             Name = "Boxwood",
             Type = PlantType.Tree.ToString(),
             Cycle = Lifecycle.Biennial.ToString()
         };
         var similarSpecie = new Specie()
         {
             Id = 2,
             Genus = SpecieBuxus.Genus,
             Species = SpecieBuxus.Species,
             Name = "Boxwood",
             Type = PlantType.Tree.ToString(),
             Cycle = Lifecycle.Biennial.ToString()
         };
         _mockedSpecieService.Find(updatedSpecie.Id).Returns(SpecieBuxus);
         _mockedSpecieService.Find(updatedSpecie.ScientificName).Returns(similarSpecie);

         //Act
         var updatedResult = (Conflict<string>)await SpecieEndPointsV1.UpdateSpecie(SpecieBuxus.Id, new SpecieDTO(updatedSpecie), _mockedSpecieService);

         //Assert
         Assert.Equal(StatusCodes.Status409Conflict, updatedResult.StatusCode);
        
         await _mockedSpecieService.Received(1).Find(updatedSpecie.ScientificName);
         await _mockedSpecieService.Received(0).Update(Arg.Any<Specie>());
     }
     
     [Fact]
     public async Task DeleteTodoDeletesTodoInDatabase()
     {
         //Arrange
         _mockedSpecieService.Find(SpecieBuxus.Id).Returns(SpecieBuxus);
         _mockedSpecieService.Remove(SpecieBuxus).Returns(Task.CompletedTask);

         //Act
         var noContentResult = (NoContent)await SpecieEndPointsV1.DeleteSpecie(SpecieBuxus.Id, _mockedSpecieService);

         //Assert
         Assert.Equal(204, noContentResult.StatusCode);

         await _mockedSpecieService.Received(1).Remove(Arg.Any<Specie>());
     }

     private void AssertSpecie(Specie expected, Specie actual)
     {
         Assert.Equal(expected.Id, actual.Id);
         Assert.Equal(expected.Genus, actual.Genus);
         Assert.Equal(expected.Species, actual.Species);
         Assert.Equal(expected.Name, actual.Name);
         Assert.Equal(expected.Type, actual.Type);
         Assert.Equal(expected.Cycle, actual.Cycle);
     }
     
     private static void AssertModifiedSpecieProperties(Specie expected, Specie actual)
     {
         Assert.Equal(expected.Name, actual.Name);
         Assert.Equal(expected.Cycle, actual.Cycle);
         Assert.Equal(expected.Type, actual.Type);
     }

     private void AssertUnchangedSpecieProperties(Specie initial, Specie updated)
     {
         Assert.Equal(initial.Id, updated.Id);
         Assert.Equal(initial.Genus, updated.Genus);
         Assert.Equal(initial.Species, updated.Species);
     }
}