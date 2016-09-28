using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;


using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestaurantManagementSystem.Models;
using Newtonsoft.Json;

namespace RestaurantManagementSystem.Controllers
{
    public class FoodsController : ApiController
    {
        private OasisRestaurantEntities db = new OasisRestaurantEntities();

        // GET: api/Foods
        public IQueryable<Food> GetFoods()
        {
            return db.Foods;
        }

        // GET: api/Foods/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult GetFood(Guid id)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        public class FoodProxy
        {

            public string FoodID { get; set; }
            public string FoodName { get; set; }
            public string Notes { get; set; }
            public decimal? Price { get; set; }
            public decimal? DiscountPrice { get; set; }
            public string MenuTypeID { get; set; }
    

        }

        
        [Route("menutypes/foods/{id}")]
        public IQueryable<FoodProxy> GetFoodsByMenuType(string id)
        {
            List<Food> foods = db.Foods.ToList<Food>().FindAll(p=>p.MenuTypeID == Guid.Parse(id))  ;
            var allFoods = from fd in foods
                           select new FoodProxy()
                           {
                               DiscountPrice = fd.DiscountPrice,
                               FoodID = fd.FoodID.ToString(),
                               FoodName = fd.FoodName,
                               Notes = fd.Notes,
                               Price = fd.Price,
                               MenuTypeID = ""
                           };
         
            
            return allFoods.AsQueryable<FoodProxy>();
        }


        // PUT: api/Foods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFood(Guid id, Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != food.FoodID)
            {
                return BadRequest();
            }

            db.Entry(food).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
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

        // POST: api/Foods
        [ResponseType(typeof(Food))]
        public IHttpActionResult PostFood(Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Foods.Add(food);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FoodExists(food.FoodID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = food.FoodID }, food);
        }

        // DELETE: api/Foods/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult DeleteFood(Guid id)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            db.Foods.Remove(food);
            db.SaveChanges();

            return Ok(food);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodExists(Guid id)
        {
            return db.Foods.Count(e => e.FoodID == id) > 0;
        }
    }
}