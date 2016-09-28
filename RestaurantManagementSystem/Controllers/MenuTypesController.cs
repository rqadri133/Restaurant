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
    public class MenuTypesController : ApiController
    {
        private OasisRestaurantEntities db = new OasisRestaurantEntities();

        // GET: api/MenuTypes
        public IQueryable<MenuType> GetMenuTypes()
        {
            return db.MenuTypes;
        }

        // GET: api/MenuTypes/5
        [ResponseType(typeof(MenuType))]
        public IHttpActionResult GetMenuType(Guid id)
        {
            MenuType menuType = db.MenuTypes.Find(id);
            if (menuType == null)
            {
                return NotFound();
            }

            return Ok(menuType);
        }

        // PUT: api/MenuTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenuType(Guid id, MenuType menuType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuType.MenuTypeID)
            {
                return BadRequest();
            }

            db.Entry(menuType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuTypeExists(id))
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

        // POST: api/MenuTypes
        [ResponseType(typeof(MenuType))]
        public IHttpActionResult PostMenuType(MenuType menuType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuTypes.Add(menuType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MenuTypeExists(menuType.MenuTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = menuType.MenuTypeID }, menuType);
        }

        // DELETE: api/MenuTypes/5
        [ResponseType(typeof(MenuType))]
        public IHttpActionResult DeleteMenuType(Guid id)
        {
            MenuType menuType = db.MenuTypes.Find(id);
            if (menuType == null)
            {
                return NotFound();
            }

            db.MenuTypes.Remove(menuType);
            db.SaveChanges();

            return Ok(menuType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuTypeExists(Guid id)
        {
            return db.MenuTypes.Count(e => e.MenuTypeID == id) > 0;
        }
    }
}