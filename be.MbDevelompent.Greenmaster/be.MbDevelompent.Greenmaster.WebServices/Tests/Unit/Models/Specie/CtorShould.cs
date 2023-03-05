using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.Models.Specie;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenSpecieDtoNull()
    {
        Assert.Throws<ArgumentNullException>((() => new WebServices.Models.Specie(null!)));
    }

    [Fact]
    public void SetIdToDtoId_WhenCalled()
    {
        var createdSpecie = new WebServices.Models.Specie(SpecieBuxusDTO);
        Assert.Equal(SpecieBuxusDTO.Id, createdSpecie.Id);
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoGenusNull()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specieDTO = new SpecieDTO()
            {
                ScientificName = SpecieBuxus.GetScientificName(),
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new WebServices.Models.Specie(specieDTO);
        }));
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoGenusEmpty()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specieDTO = new SpecieDTO()
            {
                Genus = string.Empty,
                ScientificName = SpecieBuxus.GetScientificName(),
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new WebServices.Models.Specie(specieDTO);
        }));
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoGenusWhitespace()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specieDTO = new SpecieDTO()
            {
                Genus = "  ",
                ScientificName = SpecieBuxus.GetScientificName(),
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new WebServices.Models.Specie(specieDTO);
        }));
    }

    [Fact]
    public void SetGenusToDtoGenus_WhenCalled()
    {
        var createdSpecie = new WebServices.Models.Specie(SpecieBuxusDTO);
        Assert.Equal(SpecieBuxusDTO.Genus, createdSpecie.Genus);
    }
    
    [Fact]
    public void CapitaliseSetGenus_WhenCalled()
    {
        var specieDTO = new SpecieDTO()
        {
            Genus = SpecieBuxus.Genus.ToLower(),
            Species = SpecieBuxus.Species,
            ScientificName = SpecieBuxus.GetScientificName(),
            Name = SpecieBuxus.Name,
            Cycle = SpecieBuxus.Cycle,
            Type = SpecieBuxus.Type
        };
        var createdSpecie = new WebServices.Models.Specie(specieDTO);
        Assert.Equal(SpecieBuxusDTO.Genus, createdSpecie.Genus);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoSpeciesNull()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specieDTO = new SpecieDTO()
            {
                Genus = SpecieBuxus.Genus,
                Species = null!,
                ScientificName = SpecieBuxus.GetScientificName(),
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new WebServices.Models.Specie(specieDTO);
        }));
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoSpeciesEmpty()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specieDTO = new SpecieDTO()
            {
                Genus = SpecieBuxus.Genus,
                Species = string.Empty,
                ScientificName = SpecieBuxus.GetScientificName(),
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new WebServices.Models.Specie(specieDTO);
        }));
    }

    [Fact]
    public void ThrowArgumentException_WhenSpecieDtoSpeciesWhitespace()
    {
        Assert.Throws<ArgumentException>((() =>
        {
            var specieDTO = new SpecieDTO()
            {
                Genus = SpecieBuxus.Genus,
                Species = "  ",
                ScientificName = SpecieBuxus.GetScientificName(),
                Name = SpecieBuxus.Name,
                Cycle = SpecieBuxus.Cycle,
                Type = SpecieBuxus.Type
            };
            return new WebServices.Models.Specie(specieDTO);
        }));
    }

    [Fact]
    public void SetSpeciesToDtoSpecies_WhenCalled()
    {
        var createdSpecie = new WebServices.Models.Specie(SpecieBuxusDTO);
        Assert.Equal(SpecieBuxusDTO.Species, createdSpecie.Species);
    }
    
    [Fact]
    public void CapitaliseSetSpecies_WhenCalled()
    {
        var specieDTO = new SpecieDTO()
        {
            Genus = SpecieBuxus.Genus,
            Species = SpecieBuxus.Species.ToLower(),
            ScientificName = SpecieBuxus.GetScientificName(),
            Name = SpecieBuxus.Name,
            Cycle = SpecieBuxus.Cycle,
            Type = SpecieBuxus.Type
        };
        var createdSpecie = new WebServices.Models.Specie(specieDTO);
        Assert.Equal(SpecieBuxusDTO.Species, createdSpecie.Species);
    }

    [Fact]
    public void SetScientificName_WhenCalled()
    {
        var createdSpecie = new WebServices.Models.Specie(SpecieBuxusDTO);
        Assert.Equal($"{SpecieBuxus.Genus} {SpecieBuxus.Species}", createdSpecie.GetScientificName());
    }

    [Fact]
    public void SetNameToDtoName_WhenCalled()
    {
        var createdSpecie = new WebServices.Models.Specie(SpecieBuxusDTO);
        Assert.Equal(SpecieBuxusDTO.Name, createdSpecie.Name);
    }
    
    [Fact]
    public void SetTypeToDtoType_WhenCalled()
    {
        var createdSpecie = new WebServices.Models.Specie(SpecieBuxusDTO);
        Assert.Equal(SpecieBuxusDTO.Type, createdSpecie.Type);
    }
    
    [Fact]
    public void SetCycleToDtoCycle_WhenCalled()
    {
        var createdSpecie = new WebServices.Models.Specie(SpecieBuxusDTO);
        Assert.Equal(SpecieBuxusDTO.Cycle, createdSpecie.Cycle);
    }
}