namespace CustomerContactManager.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerContactManager.Models.CustomerInfoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CustomerContactManager.Models.CustomerInfoContext";
            //Configuration configuration = new Configuration();
            //configuration.ContextType = typeof(CustomerInfoContext);
            //var migrator = new DbMigrator(configuration);

            ////This will get the SQL script which will update the DB and write it to debug
            //var scriptor = new MigratorScriptingDecorator(migrator);
            //string script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null).ToString();
            //Debug.Write(script);

            ////This will run the migration update script and will run Seed() method
            //migrator.Update();
        }

        protected override void Seed(CustomerContactManager.Models.CustomerInfoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            context.CustomerInfoes.Add(new Models.CustomerInfo
            {
                ID = 1,
                Name = "User",
                Latitude = 26.1231,
                Longitude = 28.3123,
            });

            context.CustomerInfoes.Add(new Models.CustomerInfo
            {
                ID = 2,
                Name = "Patrick",
                Latitude = 26.1231,
                Longitude = 28.3123,
            });

            context.CustomerInfoes.Add(new Models.CustomerInfo
            {
                ID = 3,
                Name = "Jane",
                Latitude = 26.1231,
                Longitude = 28.3123,
            });

            context.CustomerInfoes.Add(new Models.CustomerInfo
            {
                ID = 4,
                Name = "Carl",
                Latitude = 26.1231,
                Longitude = 28.3123,
            });

            context.CustomerInfoes.Add(new Models.CustomerInfo
            {
                ID = 5,
                Name = "Dianna",
                Latitude = 26.1231,
                Longitude = 28.3123,
            });
            context.SaveChanges();
        }
    }
}
