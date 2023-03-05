using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.Models.DTO.Specie;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenSpecieNull()
    {
        Assert.Throws<ArgumentNullException>((() => new SpecieDTO(null!)));
    }

    [Fact]
    public void SetIdToDtoId_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxusDTO.Id, createdSpecie.Id);
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoGenusNull()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specie = new WebServices.Models.Specie()
            {
                Species = SpecieBuxus.Species,
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new SpecieDTO(specie);
        }));
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoGenusEmpty()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specie = new WebServices.Models.Specie()
            {
                Genus = string.Empty,
                Species = SpecieBuxus.Species,
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new SpecieDTO(specie);
        }));
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoGenusWhitespace()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specie = new WebServices.Models.Specie()
            {
                Genus = "  ",
                Species = SpecieBuxus.Species,
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new SpecieDTO(specie);
        }));
    }

    [Fact]
    public void SetGenusToDtoGenus_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.Genus, createdSpecie.Genus);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoSpeciesNull()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specie = new WebServices.Models.Specie()
            {
                Genus = SpecieBuxus.Genus,
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new SpecieDTO(specie);
        }));
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoSpeciesEmpty()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specie = new WebServices.Models.Specie()
            {
                Genus = SpecieBuxus.Genus,
                Species = string.Empty,
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new SpecieDTO(specie);
        }));
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoSpeciesWhitespace()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specie = new WebServices.Models.Specie()
            {
                Genus = SpecieBuxus.Genus,
                Species = "  ",
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new SpecieDTO(specie);
        }));
    }

    [Fact]
    public void SetSpeciesToDtoSpecies_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.Species, createdSpecie.Species);
    }

    [Fact]
    public void SetScientificNameToDtoScientificName_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.GetScientificName(), createdSpecie.ScientificName);
    }

    [Fact]
    public void SetNameToDtoName_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.Name, createdSpecie.Name);
    }
    
    [Fact]
    public void SetTypeToDtoType_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.Type, createdSpecie.Type);
    }
    
    [Fact]
    public void SetCycleToDtoCycle_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.Cycle, createdSpecie.Cycle);
    }
}