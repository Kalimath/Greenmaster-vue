using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Models;

namespace be.MbDevelompent.Greenmaster.WebServices.Services;

public interface ISpecieService
{
    ValueTask<Specie?> Find(int id);
    Task<List<Specie>> GetAll();
    Task<List<Specie>> GetAllWithGenus(string genus);
    Task<List<Specie>> GetAllWithType(PlantType plantType);
    Task Add(Specie specie);
    Task Update(Specie specie);
    Task Remove(Specie specie);
    Task<bool> SpecieExistsWith(string genus, string species);
    ValueTask<Specie?> Find(string scientificName);

    
}