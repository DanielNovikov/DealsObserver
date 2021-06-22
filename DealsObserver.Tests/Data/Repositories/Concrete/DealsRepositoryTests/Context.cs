using DealsObserver.Data;
using Microsoft.EntityFrameworkCore;

namespace DealsObserver.Tests.Data.Repositories.Concrete.DealsRepositoryTests
{
    public class Context
    {
        protected DealsContext DealsContext;

        protected void CreateContext()
        {
            var options = new DbContextOptionsBuilder<DealsContext>()
                .UseInMemoryDatabase(databaseName: "DealsDatabase")
                .Options;

            DealsContext = new DealsContext(options);
        }
    }
}
