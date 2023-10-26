using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CretaceousApi.Models
{
  public class CretaceousApiContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Animal> Animals { get; set; }

    public CretaceousApiContext(DbContextOptions<CretaceousApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Matilda", Species = "Woolly Mammoth", Age = 7 },
          new Animal { AnimalId = 2, Name = "Rexie", Species = "Dinosaur", Age = 10 },
          new Animal { AnimalId = 3, Name = "Matilda", Species = "Dinosaur", Age = 2 },
          new Animal { AnimalId = 4, Name = "Pip", Species = "Shark", Age = 4 },
          new Animal { AnimalId = 5, Name = "Bartholomew", Species = "Dinosaur", Age = 22 }
        );

      var hasher = new PasswordHasher<IdentityUser>();
      builder.Entity<ApplicationUser>()
        .HasData(
          new ApplicationUser { Id = "sda", UserName = "Joey", PasswordHash = hasher.HashPassword(null, "test"), Email = "joey@test.com", NormalizedEmail = "JOEY@TEST.COM" },
          new ApplicationUser { Id = "abc", UserName = "Richard", PasswordHash = hasher.HashPassword(null, "test"), Email = "richard@test.com", NormalizedEmail = "RICHARD@TEST.COM" },
          new ApplicationUser { Id = "frg", UserName = "Onur", PasswordHash = hasher.HashPassword(null, "test"), Email = "onur@test.com", NormalizedEmail = "ONUR@TEST.COM" }
        );

      base.OnModelCreating(builder);
    }
  }
}