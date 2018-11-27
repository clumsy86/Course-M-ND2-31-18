using Lab4.DataAccess.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DataAccess.Context
{
    public class ContextFactory : IContextFactory
    {
        public IContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
            optionsBuilder.UseSqlServer("Filename=./Twitter.db");
            return new EFContext(optionsBuilder.Options);
        }
    }

}
