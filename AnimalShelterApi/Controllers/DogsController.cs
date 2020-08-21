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
  public class DogsController : ControllerBase
  {
    private AnimalShelterApiContext _db;

    public DogsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    //GET api/dogs -- Get dogs
    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get(string name, string color, string temperament)
    {
      var query = _db.Dogs.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (color != null)
      {
        query = query.Where(entry => entry.Color == color);
      }
      if (temperament != null)
      {
        query = query.Where(entry => entry.Temperament == temperament);
      }
      return query.ToList();
    }

    // api/dogs/random -- get random dog
    [HttpGet("random")]
    public ActionResult<IEnumerable<Dog>> Get()
    {
      var query = _db.Dogs.AsQueryable();
      Random rdn = new Random();
      int MaxId = _db.Dogs.Max(entry=>entry.DogId) + 1;
      int rand = rdn.Next(1, MaxId);
      query = query.OrderBy(entry=>entry.DogId == rand).Where(entry=>entry.DogId == rand);
      return query.ToList();
    }

    //POST api/dogs  -- Add dogs
    [HttpPost]
    public void Post([FromBody] Dog dog)
    {
      _db.Dogs.Add(dog);
      _db.SaveChanges();
    }

    //Get api/dogs/5  -- get dog by id
    [HttpGet("{id}")]
    public ActionResult<Dog> Get(int id)
    {
      return _db.Dogs.FirstOrDefault(entry => entry.DogId == id);
    }

    //PUT api/dogs/5 -- update dog by id
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Dog dog)
    {
      dog.DogId = id;
      _db.Entry(dog).State = EntityState.Modified;
      _db.SaveChanges();

    }

    //DELETE api/dogs/5 --delete dog by id
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var reviewToDelete = _db.Dogs.FirstOrDefault(entry=>entry.DogId == id);
      _db.Dogs.Remove(reviewToDelete);
      _db.SaveChanges();
    }
  }
}