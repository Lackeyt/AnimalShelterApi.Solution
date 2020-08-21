using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Dog
  {
    public int DogId {get;set;}
    
    [StringLength(20)]
    [Required]
    public string Name {get;set;}
    [Required]
    [StringLength(20)]
    public string Color {get;set;}
    [Required]
    [StringLength(20)]
    public string Temperament {get;set;}
    [Required]
    [StringLength(500)]
    public string Description {get;set;}
  }
}