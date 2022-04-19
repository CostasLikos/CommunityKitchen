using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Entities;
using MyDataBase;
using System.Web.Http.Cors;


namespace CommunityKitchen.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class APICausesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APICauses
        public IQueryable<Cause> GetCauses()
        {
            return db.Causes;
        }

        // GET: api/APICauses/
        [ResponseType(typeof(Cause))]
        public async Task<IHttpActionResult> GetCause(Guid id)
        {
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return NotFound();
            }

            return Ok(cause);
        }

        // PUT: api/APICauses/
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCause(Guid id, Cause cause)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cause.Id)
            {
                return BadRequest();
            }

            db.Entry(cause).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CauseExists(id))
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

        // POST: api/APICauses
        [ResponseType(typeof(Cause))]
        public async Task<IHttpActionResult> PostCause(Cause cause)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Causes.Add(cause);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cause.Id }, cause);
        }

        // DELETE: api/APICauses/
        [ResponseType(typeof(Cause))]
        public async Task<IHttpActionResult> DeleteCause(Guid id)
        {
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return NotFound();
            }

            db.Causes.Remove(cause);
            await db.SaveChangesAsync();

            return Ok(cause);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CauseExists(Guid id)
        {
            return db.Causes.Count(e => e.Id == id) > 0;
        }
    }
}