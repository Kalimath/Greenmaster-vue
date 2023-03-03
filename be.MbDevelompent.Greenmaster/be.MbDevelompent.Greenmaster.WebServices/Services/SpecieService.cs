using be.MbDevelompent.Greenmaster.WebServices.Database;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Tests.Unit.EndPointTests;

namespace be.MbDevelompent.Greenmaster.WebServices.Services;

public class SpecieService : ISpecieService
{
    private readonly SpecieDb _specieDb;

    public SpecieService(SpecieDb specieDb)
    {
        _specieDb = specieDb;
    }
    
    public async ValueTask<Specie?> Find(int any)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Specie>> GetAll()
    {
        throw new NotImplementedException();
    }
}