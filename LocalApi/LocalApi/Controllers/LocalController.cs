using LocalApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LocalApi.Controllers
{
    public class LocalController : ApiController
    {
        private WebOtoCoreEntities3 db = new WebOtoCoreEntities3();
        public IQueryable<NoiDangki> GetNoiDangki()
        {
            return db.NoiDangkis;
        }
        [ResponseType(typeof(NoiDangki))]
        public IHttpActionResult GetNoiDangki(Int32 id)
        {
            NoiDangki noiDangki = db.NoiDangkis.Find(id);
            if (noiDangki == null)
            {
                return NotFound();
            }
            return Ok(noiDangki);
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNoiDangki(int IdDk, NoiDangki noidangky)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (IdDk != noidangky.IdDk)
            {
                return BadRequest();
            }

            db.Entry(noidangky).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoiDangkiExists(IdDk))
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

        // POST: api/Customers
        [ResponseType(typeof(NoiDangki))]
        public IHttpActionResult PostNoiDangki(NoiDangki noidangki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NoiDangkis.Add(noidangki);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NoiDangkiExists(noidangki.IdDk))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = noidangki.IdDk}, noidangki);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(NoiDangki))]
        public IHttpActionResult DeleteCustomer(int IdDk)
        {
            NoiDangki noidangky = db.NoiDangkis.Find(IdDk);
            if (noidangky == null)
            {
                return NotFound();
            }

            db.NoiDangkis.Remove(noidangky);
            db.SaveChanges();

            return Ok(noidangky);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoiDangkiExists(int IdDk)
        {
            return db.NoiDangkis.Count(e => e.IdDk == IdDk) > 0;
        }
    }
}
