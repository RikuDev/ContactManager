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
    public class CustomerInfoController : ApiController
    {
        private CustomerInfoContext db = new CustomerInfoContext();

        // GET: api/CustomerInfo
        public IEnumerable<CustomerInfo> GetCustomerInfo(string q = null, string sort = null, bool desc = false,
                                                        int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<CustomerInfo>();

            IQueryable<CustomerInfo> items = string.IsNullOrEmpty(sort)
                ? list.OrderBy(o => o.ID)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined")
                items = items.Where(t => t.Name.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET: api/CustomerInfo/5
        [ResponseType(typeof(CustomerInfo))]
        public IHttpActionResult GetCustomerInfo(int id)
        {
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            return Ok(customerInfo);
        }

        // PUT: api/CustomerInfo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerInfo(int id, CustomerInfo customerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(customerInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInfoExists(id))
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

        // POST: api/CustomerInfo
        [ResponseType(typeof(CustomerInfo))]
        public IHttpActionResult PostCustomerInfo(CustomerInfo customerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerInfoes.Add(customerInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerInfo.ID }, customerInfo);
        }

        // DELETE: api/CustomerInfo/5
        [ResponseType(typeof(CustomerInfo))]
        public IHttpActionResult DeleteCustomerInfo(int id)
        {
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            db.CustomerInfoes.Remove(customerInfo);
            db.SaveChanges();

            return Ok(customerInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerInfoExists(int id)
        {
            return db.CustomerInfoes.Count(e => e.ID == id) > 0;
        }
    }
}