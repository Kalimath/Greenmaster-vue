using be.MbDevelompent.Greenmaster.Arboretum.Models;
using Microsoft.EntityFrameworkCore;

namespace be.MbDevelompent.Greenmaster.Arboretum.Context;

public class ArboretumContext : DbContext
{
    public ArboretumContext(DbContextOptions<ArboretumContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<Specie> Species { get; set; } = null!;
}