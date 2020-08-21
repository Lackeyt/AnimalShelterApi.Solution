using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalShelterApi.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private AnimalShelterApiContext _db;

    public AnimalsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    //GET api/animals -- Get animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get(string name, string type, string color)
    {
      var query = _db.Animals.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (type != null)
      {
        query = query.Where(entry => entry.Type == type);
      }
      if (color != null)
      {
        query = query.Where(entry => entry.Color == color);
      }
      return query.ToList();
    }

    // api/animals/random -- get random animal
    [HttpGet("random")]
    public ActionResult<IEnumerable<Animal>> Get()
    {
      var query = _db.Animals.AsQueryable();
      Random rdn = new Random();
      int MaxId = _db.Animals.Max(entry=>entry.AnimalId);
      query = query.Where(entry=>entry.AnimalId == rdn.Next(MaxId));
      return query.ToList();
    }

    //POST api/animals  -- Add animals
    [HttpPost]
    public void Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }

    //Get api/animals/5  -- get animal by id
    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
      return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
    }

    //PUT api/animals/5 -- update animal by id
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Animal animal)
    {
      animal.AnimalId = id;
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();

    }

    //DELETE api/animals/5 --delete animal by id
    [HttpDelete("{id}")]
    public void Delete(int id, string userName)
    {
      var reviewToDelete = _db.Animals.FirstOrDefault(entry=>entry.AnimalId == id);
      _db.Animals.Remove(reviewToDelete);
      _db.SaveChanges();
    }
  }
}