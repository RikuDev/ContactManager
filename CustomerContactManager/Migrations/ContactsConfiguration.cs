namespace CustomerContactManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ContactsConfiguration : DbMigrationsConfiguration<CustomerContactManager.Models.ContactInfoContext>
    {
        public ContactsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CustomerContactManager.Models.ContactInfoContext";
        }

        protected override void Seed(CustomerContactManager.Models.ContactInfoContext context)
        {
            context.ContactInfoes.Add(new Models.ContactInfo
            {
                ID = 1,
                Name = "User",
                Email = "blabla@bla.com",
                ContactNumber = "0321456785",
                CustomerID = 1,
            });

            context.ContactInfoes.Add(new Models.ContactInfo
            {
                ID = 2,
                Name = "Patrick",
                Email = "bla@bla.com",
                ContactNumber = "0321451235",
                CustomerID = 2,
            });

            context.ContactInfoes.Add(new Models.ContactInfo
            {
                ID = 3,
                Name = "Jane",
                Email = "blablabla@bla.com",
                ContactNumber = "0321455432",
                CustomerID = 3,
            });

            context.ContactInfoes.Add(new Models.ContactInfo
            {
                ID = 4,
                Name = "Carl",
                Email = "blablabla@bla.com",
                ContactNumber = "0321451312",
                CustomerID = 4,
            });

            context.ContactInfoes.Add(new Models.ContactInfo
            {
                ID = 5,
                Name = "Dianna",
                Email = "blablabla@bla.com",
                ContactNumber = "0321415232",
                CustomerID = 5,
            });
            context.SaveChanges();
        }
    }
}
