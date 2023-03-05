using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Services;
using be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers;
using NSubstitute;
using Xunit;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPoints;

public abstract class SpecieTestBase
{
    protected readonly ISpecieService MockedSpecieService;
    protected readonly List<Specie> Species;

    protected SpecieTestBase()
    {
        MockedSpecieService = Substitute.For<ISpecieService>();
        
        Species = new List<Specie> {
            SpecieTestData.SpecieBuxus, SpecieTestData.SpecieBuxusSinica, SpecieTestData.SpecieStrelitzia
        };
    }
    
    protected static void AssertSpecie(Specie expected, Specie actual)
    {
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Genus, actual.Genus);
        Assert.Equal(expected.Species, actual.Species);
        Assert.Equal(expected.CommonName, actual.CommonName);
        Assert.Equal(expected.Type, actual.Type);
        Assert.Equal(expected.Cycle, actual.Cycle);
    }
     
    protected static void AssertModifiedSpecieProperties(Specie expected, Specie actual)
    {
        Assert.Equal(expected.CommonName, actual.CommonName);
        Assert.Equal(expected.Cycle, actual.Cycle);
        Assert.Equal(expected.Type, actual.Type);
    }

    protected static void AssertUnchangedSpecieProperties(Specie initial, Specie updated)
    {
        Assert.Equal(initial.Id, updated.Id);
        Assert.Equal(initial.Genus, updated.Genus);
        Assert.Equal(initial.Species, updated.Species);
    }
}