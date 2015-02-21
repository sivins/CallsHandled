namespace CallsHandled.Migrations
{
    using CallsHandled.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CallsHandled.Models.CallContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CallsHandled.Models.CallContext context)
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
            //
            context.Calls.AddOrUpdate(
                    new Call
                    {
                        ID = 0,
                        Seconds = 515,
                        Flag = true,
                        Details = "Travel Dreams 333-012394801 Lynn 401-893-5288",
                        Resolution = "Follow-Up",
                        Timestamp = DateTime.Parse("02-20-2015 8:00AM")
                    },
                    new Call
                    {
                        ID = 1,
                        Seconds = 420,
                        Flag = false,
                        Resolution = "Ticket",
                        Timestamp = DateTime.Parse("02-20-2015 8:09AM")
                    },
                    new Call
                    {
                        ID = 2,
                        Seconds = 3040,
                        Flag = false,
                        Resolution = "Transfer",
                        Timestamp = DateTime.Parse("02-20-2015 9:09AM")
                    },
                    new Call
                    {
                        ID = 3,
                        Seconds = 65,
                        Flag = false,
                        Resolution = "Resolved",
                        Timestamp = DateTime.Parse("02-20-2015 9:19AM")
                    }
                );
        }
    }
}
