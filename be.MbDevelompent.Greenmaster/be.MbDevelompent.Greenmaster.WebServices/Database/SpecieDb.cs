using be.MbDevelompent.Greenmaster.WebServices.Models;
using Microsoft.EntityFrameworkCore;

namespace be.MbDevelompent.Greenmaster.WebServices.Database;

public class SpecieDb : DbContext
{
    public SpecieDb(DbContextOptions<SpecieDb> options) :  base(options)
    {
        
    }

    public DbSet<Specie> Species => Set<Specie>();
}