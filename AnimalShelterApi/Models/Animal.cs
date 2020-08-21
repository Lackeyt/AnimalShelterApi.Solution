using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    
    [StringLength(20)]
    [Required]
    public string Name { get; set; }
    [Required]
    [StringLength(20)]
    public string Type { get; set; }
    [Required]
    [StringLength(20)]
    public string Color { get; set; }
    [Required]
    [StringLength(250)]
    public string Description { get; set; }
  }
}