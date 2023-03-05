using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using Xunit;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.Models.Specie;

public class CycleShould
{
    [Fact]
    public void Set_WhenGivenIsLowercase()
    {
        var specie = new WebServices.Models.Specie(SpecieBuxusDTO)
        {
            Cycle = Lifecycle.Perennial.ToString().TrimAndLower()
        };
        Assert.Equal(SpecieBuxusDTO.Cycle, specie.Cycle);
    }
}