using Microsoft.EntityFrameworkCore;

namespace YarnCatalog.Models
{
    public class YarnDbContext : DbContext
    {
        public YarnDbContext (DbContextOptions<YarnDbContext> options)
            : base(options)
            {

            }

            public DbSet<Yarn> Yarns {get;set;} = default!;

            public DbSet<Review> Reviews {get;set;} = default!;
    }
}