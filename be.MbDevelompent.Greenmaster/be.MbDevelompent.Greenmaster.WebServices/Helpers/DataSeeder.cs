using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Database;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using static be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers.SpecieTestData;

namespace be.MbDevelompent.Greenmaster.WebServices.Helpers;

public class DataSeeder
{
    private readonly SpecieDb _dbContext;

    public DataSeeder(SpecieDb dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (!_dbContext.Species.Any())
        {
            var species = new List<Specie>()
            {
                SpecieBuxus,
                SpecieStrelitzia
            };

            _dbContext.Species.AddRange(species);
            _dbContext.SaveChanges();
        }
    }
}