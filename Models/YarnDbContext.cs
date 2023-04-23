using Microsoft.EntityFrameworkCore;

namespace Yarn.Models
{
    public class YarnDbContext : DbContext
    {
        public YarnDbContext (DbContextOptions<YarnDbContext> options)
            : base(options)
            {

            }

            public DbSet<Yarn> Yarns {get;set;} = default!;
    }
}