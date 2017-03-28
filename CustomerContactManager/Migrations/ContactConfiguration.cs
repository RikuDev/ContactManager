namespace CustomerContactManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ContactConfiguration : DbMigrationsConfiguration<CustomerContactManager.Models.ContactInfoContext>
    {
        public ContactConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CustomerContactManager.Models.ContactInfoContext";
        }

        protected override void Seed(CustomerContactManager.Models.ContactInfoContext context)
        {
            //    var r = new Random();
            //    var items = Enumerable.Range(1, 50).Select(o => new Contact
            //    {
            //        DueDate = new DateTime(2012, r.Next(1, 12), r.Next(1, 28)),
            //        Priority = (byte)r.Next(10),
            //        Todo = o.ToString()
            //    }).ToArray();
            //    context.TodoItems.AddOrUpdate(item => new { item.Todo }, items);
        }
    }
 }
