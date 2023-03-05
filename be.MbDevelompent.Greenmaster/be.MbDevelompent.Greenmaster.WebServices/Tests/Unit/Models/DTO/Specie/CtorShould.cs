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
    public void SetGenusToDtoGenus_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.Genus, createdSpecie.Genus);
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
        Assert.Equal(SpecieBuxus.ScientificName, createdSpecie.ScientificName);
    }

    [Fact]
    public void SetNameToDtoName_WhenCalled()
    {
        var createdSpecie = new SpecieDTO(SpecieBuxus);
        Assert.Equal(SpecieBuxus.CommonName, createdSpecie.CommonName);
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