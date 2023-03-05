using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Database;
using be.MbDevelompent.Greenmaster.WebServices.Models;

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
                new()
                {
                    Id = 1,
                    ScientificName = "Buxus Sempervirens",
                    Name = "Boxtree",
                    Type = PlantType.Bush.ToString(),
                    Cycle = Lifecycle.Perennial.ToString()
                },
                new()
                {
                    Id = 2,
                    ScientificName = "Strelitzia Reginae",
                    Name = "Bird of paradise",
                    Type = PlantType.Bush.ToString(),
                    Cycle = Lifecycle.Perennial.ToString()
                }
            };

            _dbContext.Species.AddRange(species);
            _dbContext.SaveChanges();
        }
    }
}