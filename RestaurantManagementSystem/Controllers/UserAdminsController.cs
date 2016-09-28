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
    public class UserAdminsController : ApiController
    {
        private OasisRestaurantEntities db = new OasisRestaurantEntities();

        // GET: api/UserAdmins
        public IQueryable<UserAdmin> GetUserAdmins()
        {
            return db.UserAdmins;
        }

        // GET: api/UserAdmins/5
        [ResponseType(typeof(UserAdmin))]
        public IHttpActionResult GetUserAdmin(Guid id)
        {
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            if (userAdmin == null)
            {
                return NotFound();
            }

            return Ok(userAdmin);
        }

        // PUT: api/UserAdmins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAdmin(Guid id, UserAdmin userAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAdmin.UserID)
            {
                return BadRequest();
            }

            db.Entry(userAdmin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAdminExists(id))
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

        // POST: api/UserAdmins
        [ResponseType(typeof(UserAdmin))]
        public IHttpActionResult PostUserAdmin(UserAdmin userAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAdmins.Add(userAdmin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserAdminExists(userAdmin.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userAdmin.UserID }, userAdmin);
        }

        // DELETE: api/UserAdmins/5
        [ResponseType(typeof(UserAdmin))]
        public IHttpActionResult DeleteUserAdmin(Guid id)
        {
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            if (userAdmin == null)
            {
                return NotFound();
            }

            db.UserAdmins.Remove(userAdmin);
            db.SaveChanges();

            return Ok(userAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAdminExists(Guid id)
        {
            return db.UserAdmins.Count(e => e.UserID == id) > 0;
        }
    }
}