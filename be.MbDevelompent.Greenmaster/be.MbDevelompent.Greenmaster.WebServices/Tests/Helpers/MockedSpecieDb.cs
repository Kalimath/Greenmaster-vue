using be.MbDevelompent.Greenmaster.WebServices.Database;
using Microsoft.EntityFrameworkCore;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers;

public class MockedSpecieDb : IDbContextFactory<SpecieDb>
{
    public SpecieDb CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<SpecieDb>()
            .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
            .Options;

        return new SpecieDb(options);
    }
}