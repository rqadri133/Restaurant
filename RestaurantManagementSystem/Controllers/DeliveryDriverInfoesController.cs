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
    public class DeliveryDriverInfoesController : ApiController
    {
        private OasisRestaurantEntities db = new OasisRestaurantEntities();

        // GET: api/DeliveryDriverInfoes
        public IQueryable<DeliveryDriverInfo> GetDeliveryDriverInfoes()
        {
            return db.DeliveryDriverInfoes;
        }

        // GET: api/DeliveryDriverInfoes/5
        [ResponseType(typeof(DeliveryDriverInfo))]
        public IHttpActionResult GetDeliveryDriverInfo(Guid id)
        {
            DeliveryDriverInfo deliveryDriverInfo = db.DeliveryDriverInfoes.Find(id);
            if (deliveryDriverInfo == null)
            {
                return NotFound();
            }

            return Ok(deliveryDriverInfo);
        }

        // PUT: api/DeliveryDriverInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeliveryDriverInfo(Guid id, DeliveryDriverInfo deliveryDriverInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryDriverInfo.DeliveryVanID)
            {
                return BadRequest();
            }

            db.Entry(deliveryDriverInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryDriverInfoExists(id))
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

        // POST: api/DeliveryDriverInfoes
        [ResponseType(typeof(DeliveryDriverInfo))]
        public IHttpActionResult PostDeliveryDriverInfo(DeliveryDriverInfo deliveryDriverInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliveryDriverInfoes.Add(deliveryDriverInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DeliveryDriverInfoExists(deliveryDriverInfo.DeliveryVanID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deliveryDriverInfo.DeliveryVanID }, deliveryDriverInfo);
        }

        // DELETE: api/DeliveryDriverInfoes/5
        [ResponseType(typeof(DeliveryDriverInfo))]
        public IHttpActionResult DeleteDeliveryDriverInfo(Guid id)
        {
            DeliveryDriverInfo deliveryDriverInfo = db.DeliveryDriverInfoes.Find(id);
            if (deliveryDriverInfo == null)
            {
                return NotFound();
            }

            db.DeliveryDriverInfoes.Remove(deliveryDriverInfo);
            db.SaveChanges();

            return Ok(deliveryDriverInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryDriverInfoExists(Guid id)
        {
            return db.DeliveryDriverInfoes.Count(e => e.DeliveryVanID == id) > 0;
        }
    }
}