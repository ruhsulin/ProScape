using Microsoft.EntityFrameworkCore;
using ProScape.Domain.Entities;

namespace ProScape.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Villa> Villas { get; set; }
    public DbSet<VillaNumber> VillaNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Villa>().HasData(
          new Villa
          {
              Id = 1,
              Name = "Luxury Beachfront Villa",
              Description = "A stunning villa with direct beach access and breathtaking ocean views.",
              Price = 500.00,
              Sqft = 3500,
              Occupancy = 8,
              ImageUrl = "https://static.independent.co.uk/2024/01/09/12/FAO_83054_Villa_Mangas_Albufeira_0723_01_RGB-136-DPI-For-Web.jpg",
              CreatedDate = DateTime.UtcNow,
              UpdatedDate = DateTime.UtcNow
          },
              new Villa
              {
                  Id = 2,
                  Name = "Mountain Retreat",
                  Description = "A cozy villa nestled in the mountains, perfect for a relaxing getaway.",
                  Price = 300.00,
                  Sqft = 2500,
                  Occupancy = 6,
                  ImageUrl = "https://media.graphassets.com/kcqbCpucTbmzbM5yqelI",
                  CreatedDate = DateTime.UtcNow,
                  UpdatedDate = DateTime.UtcNow
              },
              new Villa
              {
                  Id = 3,
                  Name = "Urban Penthouse",
                  Description = "A modern penthouse villa located in the heart of the city with skyline views.",
                  Price = 700.00,
                  Sqft = 4000,
                  Occupancy = 10,
                  ImageUrl = "https://static.baranselgrup.com/nwm-248899-w1278-bavadi-villalari.png",
                  CreatedDate = DateTime.UtcNow,
                  UpdatedDate = DateTime.UtcNow
              }
     );

        modelBuilder.Entity<VillaNumber>().HasData(
            new VillaNumber
            {
                Villa_Number = 101,
                VillaId = 1,

            },
                new VillaNumber
                {
                    Villa_Number = 102,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 103,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 201,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 202,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 301,
                    VillaId = 3,
                },
                new VillaNumber
                {
                    Villa_Number = 302,
                    VillaId = 3,
                }
     );
    }
}
