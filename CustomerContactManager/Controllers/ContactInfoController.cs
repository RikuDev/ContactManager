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
using CustomerContactManager.Models;

namespace CustomerContactManager.Controllers
{
    public class ContactInfoController : ApiController
    {
        private ContactInfoContext db = new ContactInfoContext();

        // GET: api/ContactInfo
        public IQueryable<ContactInfo> GetContactInfoes()
        {
            return db.ContactInfoes;
        }

        // GET: api/ContactInfo/5
        [ResponseType(typeof(ContactInfo))]
        public IHttpActionResult GetContactInfo(int id)
        {
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return Ok(contactInfo);
        }

        // PUT: api/ContactInfo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactInfo(int id, ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(contactInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInfoExists(id))
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

        // POST: api/ContactInfo
        [ResponseType(typeof(ContactInfo))]
        public IHttpActionResult PostContactInfo(ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactInfoes.Add(contactInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactInfo.ID }, contactInfo);
        }

        // DELETE: api/ContactInfo/5
        [ResponseType(typeof(ContactInfo))]
        public IHttpActionResult DeleteContactInfo(int id)
        {
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            db.ContactInfoes.Remove(contactInfo);
            db.SaveChanges();

            return Ok(contactInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactInfoExists(int id)
        {
            return db.ContactInfoes.Count(e => e.ID == id) > 0;
        }
    }
}