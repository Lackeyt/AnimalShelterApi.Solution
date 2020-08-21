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
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Dog>()
        .HasData(
          new Dog {DogId=1, Name="Dog1", Color="Black", Temperament="Calm", Description="testDesc"},
          new Dog {DogId=2, Name="Dog2", Color="Tan", Temperament="Anxious", Description="testDesc"},
          new Dog {DogId=3, Name="Dog3", Color="White", Temperament="Hyper", Description="testDesc"},
          new Dog {DogId=4, Name="Dog4", Color="Cream", Temperament="Energetic", Description="testDesc"},
          new Dog {DogId=5, Name="Dog5", Color="Black", Temperament="lazy", Description="testDesc"}
        );
      
      builder.Entity<Cat>()
        .HasData(
          new Cat {CatId=1, Name="Cat1", Color="Black", Temperament="Calm", Description="testDesc"},
          new Cat {CatId=2, Name="Cat2", Color="Tan", Temperament="Anxious", Description="testDesc"},
          new Cat {CatId=3, Name="Cat3", Color="White", Temperament="Hyper", Description="testDesc"},
          new Cat {CatId=4, Name="Cat4", Color="Cream", Temperament="Energetic", Description="testDesc"},
          new Cat {CatId=5, Name="Cat5", Color="Black", Temperament="lazy", Description="testDesc"}
        );
    }
    
  }
}