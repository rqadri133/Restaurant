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
    public class FeedsController : ApiController
    {
        private OasisRestaurantEntities db = new OasisRestaurantEntities();

        // GET: api/Feeds
        public IQueryable<Feed> GetFeeds()
        {
            return db.Feeds;
        }

        // GET: api/Feeds/5
        [ResponseType(typeof(Feed))]
        public IHttpActionResult GetFeed(Guid id)
        {
            Feed feed = db.Feeds.Find(id);
            if (feed == null)
            {
                return NotFound();
            }

            return Ok(feed);
        }

        // PUT: api/Feeds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeed(Guid id, Feed feed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feed.FeedID)
            {
                return BadRequest();
            }

            db.Entry(feed).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedExists(id))
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

        // POST: api/Feeds
        [ResponseType(typeof(Feed))]
        public IHttpActionResult PostFeed(Feed feed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Feeds.Add(feed);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FeedExists(feed.FeedID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = feed.FeedID }, feed);
        }

        // DELETE: api/Feeds/5
        [ResponseType(typeof(Feed))]
        public IHttpActionResult DeleteFeed(Guid id)
        {
            Feed feed = db.Feeds.Find(id);
            if (feed == null)
            {
                return NotFound();
            }

            db.Feeds.Remove(feed);
            db.SaveChanges();

            return Ok(feed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedExists(Guid id)
        {
            return db.Feeds.Count(e => e.FeedID == id) > 0;
        }
    }
}