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
  public class CatsController : ControllerBase
  {
    private AnimalShelterApiContext _db;

    public CatsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    //GET api/cats -- Get cats
    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get(string name, string color, string temperament)
    {
      var query = _db.Cats.AsQueryable();
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

    // api/cats/random -- get random cat
    [HttpGet("random")]
    public ActionResult<IEnumerable<Cat>> Get()
    {
      var query = _db.Cats.AsQueryable();
      Random rdn = new Random();
      int MaxId = _db.Cats.Max(entry=>entry.CatId) + 1;
      int rand = rdn.Next(1, MaxId);
      query = query.OrderBy(entry=>entry.CatId == rand).Where(entry=>entry.CatId == rand);
      return query.ToList();
    }

    //POST api/cats  -- Add cats
    [HttpPost]
    public void Post([FromBody] Cat cat)
    {
      _db.Cats.Add(cat);
      _db.SaveChanges();
    }

    //Get api/cats/5  -- get cat by id
    [HttpGet("{id}")]
    public ActionResult<Cat> Get(int id)
    {
      return _db.Cats.FirstOrDefault(entry => entry.CatId == id);
    }

    //PUT api/cats/5 -- update cat by id
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Cat cat)
    {
      cat.CatId = id;
      _db.Entry(cat).State = EntityState.Modified;
      _db.SaveChanges();

    }

    //DELETE api/cats/5 --delete cat by id
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var reviewToDelete = _db.Cats.FirstOrDefault(entry=>entry.CatId == id);
      _db.Cats.Remove(reviewToDelete);
      _db.SaveChanges();
    }
  }
}