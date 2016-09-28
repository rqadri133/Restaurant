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
    public class OrderStatusController : ApiController
    {
        private OasisRestaurantEntities db = new OasisRestaurantEntities();

        // GET: api/OrderStatus
        public IQueryable<OrderStatu> GetOrderStatus()
        {
            return db.OrderStatus;
        }

        // GET: api/OrderStatus/5
        [ResponseType(typeof(OrderStatu))]
        public IHttpActionResult GetOrderStatu(Guid id)
        {
            OrderStatu orderStatu = db.OrderStatus.Find(id);
            if (orderStatu == null)
            {
                return NotFound();
            }

            return Ok(orderStatu);
        }

        // PUT: api/OrderStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderStatu(Guid id, OrderStatu orderStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderStatu.OrderStatusID)
            {
                return BadRequest();
            }

            db.Entry(orderStatu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderStatuExists(id))
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

        // POST: api/OrderStatus
        [ResponseType(typeof(OrderStatu))]
        public IHttpActionResult PostOrderStatu(OrderStatu orderStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderStatus.Add(orderStatu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderStatuExists(orderStatu.OrderStatusID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderStatu.OrderStatusID }, orderStatu);
        }

        // DELETE: api/OrderStatus/5
        [ResponseType(typeof(OrderStatu))]
        public IHttpActionResult DeleteOrderStatu(Guid id)
        {
            OrderStatu orderStatu = db.OrderStatus.Find(id);
            if (orderStatu == null)
            {
                return NotFound();
            }

            db.OrderStatus.Remove(orderStatu);
            db.SaveChanges();

            return Ok(orderStatu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderStatuExists(Guid id)
        {
            return db.OrderStatus.Count(e => e.OrderStatusID == id) > 0;
        }
    }
}