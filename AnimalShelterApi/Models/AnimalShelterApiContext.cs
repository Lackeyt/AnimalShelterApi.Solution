using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext : DbContext
  {
    public AnimalShelterApiContext(DbContextOptions <AnimalShelterApiContext> options)
    :base(options)
    {

    }
    public DbSet<Dog> Dogs {get; set;}
    public DbSet<Cat> Cats {get; set;}
  }
}