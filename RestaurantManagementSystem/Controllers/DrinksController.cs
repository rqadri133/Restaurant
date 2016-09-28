using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Controllers
{
    public class DrinkController : ApiController
    {
        private OasisRestaurantEntities db = new OasisRestaurantEntities();

        // GET: api/Drinks
        public IQueryable<Drink> GetDrinks()
        {
            return db.Drinks;
        }
        
        // GET: api/Drinks/5
        [ResponseType(typeof(Drink))]
        public IHttpActionResult GetDrink(Guid id)
        {
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }

        // PUT: api/Drinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrink(Guid id, Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drink.DrinkID)
            {
                return BadRequest();
            }

            db.Entry(drink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Drinks
        [ResponseType(typeof(Drink))]
        public IHttpActionResult PostDrink(Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drinks.Add(drink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DrinkExists(drink.DrinkID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = drink.DrinkID }, drink);
        }

        // DELETE: api/Drinks/5
        [ResponseType(typeof(Drink))]
        public IHttpActionResult DeleteDrink(Guid id)
        {
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return NotFound();
            }

            db.Drinks.Remove(drink);
            db.SaveChanges();

            return Ok(drink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrinkExists(Guid id)
        {
            return db.Drinks.Count(e => e.DrinkID == id) > 0;
        }
    }
}