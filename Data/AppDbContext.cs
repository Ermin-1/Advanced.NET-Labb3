using Advanced.NET_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.NET_Labb3.Data
{
    public class AppDbContext : DbContext
    {

        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definiera många-till-många-relationen mellan Person och Interest
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Interests)
                .WithMany(i => i.Persons)
                .UsingEntity<Dictionary<string, object>>(
                    "PersonInterest",  // Namn på join-tabellen
                    j => j.HasOne<Interest>()  // Navigation från join-tabell till Interest
                          .WithMany()
                          .HasForeignKey("InterestId")  // Främmande nyckel i join-tabellen som refererar till Interest
                          .OnDelete(DeleteBehavior.Cascade),  // Hantera borttagning
                    j => j.HasOne<Person>()  // Navigation från join-tabell till Person
                          .WithMany()
                          .HasForeignKey("PersonId")  // Främmande nyckel i join-tabellen som refererar till Person
                          .OnDelete(DeleteBehavior.Cascade)  // Hantera borttagning
                )
                .HasKey("PersonId", "InterestId");  // Sätt primärnycklarna för join-tabellen


            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, FirstName = "Ermin", LastName = "Husic", PhoneNumber = 072222 },
                new Person { PersonId = 2, FirstName = "Oskar", LastName = "Johansson", PhoneNumber = 07222322 },
                new Person { PersonId = 3, FirstName = "Jonathan", LastName = "Bengtsson", PhoneNumber = 07245645 }

            );

            modelBuilder.Entity<Interest>().HasData(

                new Interest { InterestId = 1, Description = "Programmering" },
                new Interest { InterestId = 2, Description = "Cykla" },
                new Interest { InterestId = 3, Description = "Surfa" }

            );

            modelBuilder.Entity<Link>().HasData(
                new Link { LinkId = 1, Url = "https://example.com/programmering", InterestId = 1 },
                new Link { LinkId = 2, Url = "https://example.com/cykla", InterestId = 2 },
                new Link { LinkId = 3, Url = "https://example.com/surfa", InterestId = 3 }
            );

        }


    }
}
