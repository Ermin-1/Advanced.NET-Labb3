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
        public DbSet<JoinTable> JoinTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, FirstName = "Ermin", LastName = "Husic", PhoneNumber = 072222 },
                new Person { PersonId = 2, FirstName = "Oskar", LastName = "Johansson", PhoneNumber = 07222322 },
                new Person { PersonId = 3, FirstName = "Jonathan", LastName = "Bengtsson", PhoneNumber = 07245645 }

            );

            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 1, InterestTitle = "Programmering", InterestDescription = "Sitta och göra sidoprpjekt" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 2, InterestTitle = "Cykla", InterestDescription = "Cykla mountainbike" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 3, InterestTitle = "Surfa", InterestDescription = "Kitesurfa nere i viken" });



            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 1, Url = "https://example.com/programmering", PersonInterestId = 1 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 2, Url = "https://example.com/cykla", PersonInterestId = 2 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 3, Url = "https://example.com/surfa", PersonInterestId = 3 });



            modelBuilder.Entity<JoinTable>().HasData(new JoinTable{ PersonInterestId = 1,PersonId = 1, InterestId = 1});
            modelBuilder.Entity<JoinTable>().HasData(new JoinTable{PersonInterestId = 2,PersonId = 2,InterestId = 2,});
            modelBuilder.Entity<JoinTable>().HasData(new JoinTable{PersonInterestId = 3,PersonId = 3,InterestId = 3,});
        }


    }
}
