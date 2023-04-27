using Microsoft.EntityFrameworkCore;

namespace YarnCatalog.Models
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
                            Brand = "Red Heart",
                            Name = "Super Saver",
                            Weight = "Medium",
                            Yardage = 364,
                            Fiber = "Acrylic"
                        },
                        new Yarn
                        {
                            Brand = "Caron",
                            Name = "Simply Soft",
                            Weight = "Medium",
                            Yardage = 315,
                            Fiber = "Acrylic"
                        },
                        new Yarn
                        {
                            Brand = "Caron",
                            Name = "Cotton Cakes",
                            Weight = "Medium",
                            Yardage = 530,
                            Fiber = "Cotton/Acrylic"
                        },
                        new Yarn
                        {
                            Brand = "Caron",
                            Name = "Cakes",
                            Weight = "Medium",
                            Yardage = 445,
                            Fiber = "Acrylic/Wool"
                        },
                        new Yarn
                        {
                            Brand = "Bernat",
                            Name = "Blanket",
                            Weight = "Super Bulky",
                            Yardage = 220,
                            Fiber = "Polyester"
                        },
                        new Yarn
                        {
                            Brand = "Bernat",
                            Name = "Satin",
                            Weight = "Medium",
                            Yardage = 200,
                            Fiber = "Acrylic"
                        },
                        new Yarn
                        {
                            Brand = "Patons",
                            Name = "Classic Wool",
                            Weight = "Medium",
                            Yardage = 194,
                            Fiber = "Wool"
                        },
                        new Yarn
                        {
                            Brand = "Patons",
                            Name = "Kroy Socks",
                            Weight = "Super Fine",
                            Yardage = 166,
                            Fiber = "Wool/Nylon"
                        },
                        new Yarn
                        {
                            Brand = "Patons",
                            Name = "Grace",
                            Weight = "Light",
                            Yardage = 136,
                            Fiber = "Cotton"
                        },
                        new Yarn
                        {
                            Brand = "Patons",
                            Name = "Shetland Chunky",
                            Weight = "Bulky",
                            Yardage = 148,
                            Fiber = "Acrylic/Wool"
                        },
                        new Yarn
                        {
                            Brand = "Lily",
                            Name = "Sugar'N Cream",
                            Weight = "Medium",
                            Yardage = 120,
                            Fiber = "Cotton"
                        },
                        new Yarn
                        {
                            Brand = "Lion Brand",
                            Name = "Sock Ease",
                            Weight = "Super Fine",
                            Yardage = 437,
                            Fiber = "Wool/Nylon"
                        },
                        new Yarn
                        {
                            Brand = "Lion Brand",
                            Name = "24/7 Cotton DK",
                            Weight = "Light",
                            Yardage = 273,
                            Fiber = "Cotton"
                        },
                        new Yarn
                        {
                            Brand = "Lion Brand",
                            Name = "Truboo",
                            Weight = "Light",
                            Yardage = 241,
                            Fiber = "Bamboo"
                        },
                        new Yarn
                        {
                            Brand = "Lion Brand",
                            Name = "LB Collection Merino Camel",
                            Weight = "Fine",
                            Yardage = 136,
                            Fiber = "Merino Wool/Camel"
                        },
                        new Yarn
                        {
                            Brand = "Lion Brand",
                            Name = "Ferris Wheel",
                            Weight = "Medium",
                            Yardage = 270,
                            Fiber = "Acrylic"
                        },
                        new Yarn
                        {
                            Brand = "Lion Brand",
                            Name = "Feels Like Butta",
                            Weight = "Medium",
                            Yardage = 218,
                            Fiber = "Polyester"
                        },
                        new Yarn
                        {
                            Brand = "Lion Brand",
                            Name = "LB Collection Superwash Merino",
                            Weight = "Light",
                            Yardage = 306,
                            Fiber = "Merino Wool"
                        },
                        new Yarn
                        {
                            Brand = "Lion Brand",
                            Name = "LB Collection Baby Alpaca",
                            Weight = "Light",
                            Yardage = 146,
                            Fiber = "Alpaca"
                        },
                        new Yarn
                        {
                            Brand = "Hobbii",
                            Name = "Rainbow",
                            Weight = "Fine",
                            Yardage = 186,
                            Fiber = "Cotton"
                        },
                        new Yarn
                        {
                            Brand = "Hobbii",
                            Name = "Dahlia",
                            Weight = "Light",
                            Yardage = 875,
                            Fiber = "Cotton"
                        },
                        new Yarn
                        {
                            Brand = "Rowan",
                            Name = "Kidsilk Haze",
                            Weight = "Super Fine",
                            Yardage = 229,
                            Fiber = "Mohair/Silk"
                        },
                        new Yarn
                        {
                            Brand = "Rowan",
                            Name = "Pure Cashmere",
                            Weight = "Light",
                            Yardage = 149,
                            Fiber = "Cashmere"
                        },
                        new Yarn
                        {
                            Brand = "Rowan",
                            Name = "Selects Chunky Cashmere",
                            Weight = "Bulky",
                            Yardage = 153,
                            Fiber = "Cashmere"
                        },
                        new Yarn
                        {
                            Brand = "MYak",
                            Name = "Baby Camel",
                            Weight = "Light",
                            Yardage = 190,
                            Fiber = "Camel"
                        },
                        new Yarn
                        {
                            Brand = "MYak",
                            Name = "Tibetan Cloud Wool",
                            Weight = "Light",
                            Yardage = 328,
                            Fiber = "Wool"
                        },
                        new Yarn
                        {
                            Brand = "MYak",
                            Name = "Baby Yak Lace",
                            Weight = "Super Fine",
                            Yardage = 370,
                            Fiber = "Yak"
                        }
                
                    );

                    context.SaveChanges();
                }
        }
    }
}