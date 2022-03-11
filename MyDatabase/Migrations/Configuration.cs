﻿namespace MyDatabase.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDataBase.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDataBase.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var causes = CauseSeed();
            var events = EventSeed();
            context.Causes.AddRange(causes);
            context.Events.AddRange(events);
            context.SaveChanges();
        }
        public List<Cause> CauseSeed()
        {
            List<Cause> causes = new List<Cause>()
            {
              new Cause() {Title = "Poor one Helpers",Description="Get money",TargetGoal=150,CurrentAmmount=25 },
              new Cause() {Title = "Rich one Helpers",Description="Give money",TargetGoal=210,CurrentAmmount=75 },
              new Cause() {Title = "Food for Homeless",Description="Support their feedin needs",TargetGoal=110,CurrentAmmount=32 },
              new Cause() {Title = "Clothing for Poor",Description="Raise money to buy clothes for the poor",TargetGoal=350,CurrentAmmount=110 },
            };
            return causes;
        }
        public List<Event> EventSeed()
        {
            List<Event> events = new List<Event>()
            {
              new Event() {Title = "14th Street Charity Meal",Description="Offering meal at 14th Street",EventDate=new DateTime(2022,04,05) },
              new Event() {Title = "St.Nicolas Church Food Festival",Description="Offering meal St.Nicolas Church",EventDate=new DateTime(2022,05,07) },
              new Event() {Title = "Bazaar of poor Souls",Description="Open Market to support the poor",EventDate=new DateTime(2022,04,05) },
              new Event() {Title = "Lending a hand",Description="Free grooming for poor people",EventDate=new DateTime(2022,06,05) }
            };
            return events;
        }
    }
}
