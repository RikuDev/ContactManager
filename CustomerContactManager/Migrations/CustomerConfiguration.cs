namespace CustomerContactManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class CustomerConfiguration : DbMigrationsConfiguration<CustomerContactManager.Models.CustomerInfoContext>
    {
        public CustomerConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CustomerContactManager.Models.CustomerInfoContext";
        }

        protected override void Seed(CustomerContactManager.Models.CustomerInfoContext context)
        {

        }
    }
}
