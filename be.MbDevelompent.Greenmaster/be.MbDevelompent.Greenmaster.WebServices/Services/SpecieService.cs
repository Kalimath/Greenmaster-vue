using be.MbDevelompent.Greenmaster.WebServices.Database;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using Microsoft.EntityFrameworkCore;

namespace be.MbDevelompent.Greenmaster.WebServices.Services;

public class SpecieService : ISpecieService
{
    private readonly SpecieDb _specieDb;

    public SpecieService(SpecieDb specieDb)
    {
        _specieDb = specieDb ?? throw new ArgumentNullException(nameof(specieDb));
    }
    
    public async ValueTask<Specie?> Find(int id)
    {
        return await _specieDb.Species.FindAsync(id);
    }

    public async Task<List<Specie>> GetAll()
    {
        return await _specieDb.Species.ToListAsync();
    }

    public async Task Add(Specie specie)
    {
        await _specieDb.Species.AddAsync(specie);
        await _specieDb.SaveChangesAsync();
    }

    public async Task Update(Specie specie)
    {
        _specieDb.Species.Update(specie);
        await _specieDb.SaveChangesAsync();
    }

    public async Task Remove(Specie specie)
    {
        _specieDb.Species.Remove(specie);
        await _specieDb.SaveChangesAsync();
    }

    public Task<bool> ExistsWithScientificName(string scientificName)
    {
        if (string.IsNullOrWhiteSpace(scientificName))
            throw new ArgumentException(nameof(scientificName));
        
        return Task.FromResult(_specieDb.Species.Any(specie => specie.ScientificName.ToLower() == scientificName.ToLower().Trim()));
    }

    public async ValueTask<Specie?> Find(string scientificName)
    {
        return await _specieDb.GetByScientificName(scientificName);
    }
}