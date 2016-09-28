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
    public class OrderDeliveriesController : ApiController
    {
        private OasisRestaurantEntities db = new OasisRestaurantEntities();

        // GET: api/OrderDeliveries
        public IQueryable<OrderDelivery> GetOrderDeliveries()
        {
            return db.OrderDeliveries;
        }

        // GET: api/OrderDeliveries/5
        [ResponseType(typeof(OrderDelivery))]
        public IHttpActionResult GetOrderDelivery(Guid id)
        {
            OrderDelivery orderDelivery = db.OrderDeliveries.Find(id);
            if (orderDelivery == null)
            {
                return NotFound();
            }

            return Ok(orderDelivery);
        }

        // PUT: api/OrderDeliveries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderDelivery(Guid id, OrderDelivery orderDelivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDelivery.OrderDeliveryID)
            {
                return BadRequest();
            }

            db.Entry(orderDelivery).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDeliveryExists(id))
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

        // POST: api/OrderDeliveries
        [ResponseType(typeof(OrderDelivery))]
        public IHttpActionResult PostOrderDelivery(OrderDelivery orderDelivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderDeliveries.Add(orderDelivery);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderDeliveryExists(orderDelivery.OrderDeliveryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderDelivery.OrderDeliveryID }, orderDelivery);
        }

        // DELETE: api/OrderDeliveries/5
        [ResponseType(typeof(OrderDelivery))]
        public IHttpActionResult DeleteOrderDelivery(Guid id)
        {
            OrderDelivery orderDelivery = db.OrderDeliveries.Find(id);
            if (orderDelivery == null)
            {
                return NotFound();
            }

            db.OrderDeliveries.Remove(orderDelivery);
            db.SaveChanges();

            return Ok(orderDelivery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderDeliveryExists(Guid id)
        {
            return db.OrderDeliveries.Count(e => e.OrderDeliveryID == id) > 0;
        }
    }
}