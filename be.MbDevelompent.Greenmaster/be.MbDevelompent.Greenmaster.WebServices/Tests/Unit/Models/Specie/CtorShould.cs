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
                ScientificName = SpecieBuxus.ScientificName,
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
                ScientificName = SpecieBuxus.ScientificName,
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
                ScientificName = SpecieBuxus.ScientificName,
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
            ScientificName = SpecieBuxus.ScientificName,
            Name = SpecieBuxus.Name,
            Cycle = SpecieBuxus.Cycle,
            Type = SpecieBuxus.Type
        };
        var createdSpecie = new WebServices.Models.Specie(specieDTO);
        Assert.Equal(SpecieBuxusDTO.Genus, createdSpecie.Genus);
    }

    [Fact]
    public void SetScientificNameToDtoScientificName_WhenCalled()
    {
        var createdSpecie = new WebServices.Models.Specie(SpecieBuxusDTO);
        Assert.Equal(SpecieBuxusDTO.ScientificName, createdSpecie.ScientificName);
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