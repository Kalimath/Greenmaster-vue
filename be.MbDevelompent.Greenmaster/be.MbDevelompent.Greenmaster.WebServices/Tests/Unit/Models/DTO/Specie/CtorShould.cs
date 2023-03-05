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
                ScientificName = SpecieBuxus.ScientificName,
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
                ScientificName = SpecieBuxus.ScientificName,
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
                ScientificName = SpecieBuxus.ScientificName,
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
    public void SetScientificNameToDtoScientificName_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.ScientificName, createdSpecie.ScientificName);
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