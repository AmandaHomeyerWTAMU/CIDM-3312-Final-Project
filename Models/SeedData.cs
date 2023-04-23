using Microsoft.EntityFrameworkCore;

namespace Yarn.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YarnDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<YarnDbContext>>()))
                {
                    //look for any yarns
                    if (context.Yarns.Any())
                    {
                        return; //DB has been seeded
                    }

                    context.Yarns.AddRange(
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        },
                        new Yarn
                        {
                            Brand = "",
                            Name = "",
                            Weight = "",
                            Yardage = ,
                            Fiber = ""
                        }
                    );
                }
        }
    }
}