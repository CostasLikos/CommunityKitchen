﻿namespace MyDatabase.Migrations
{
    using Entities;
    using Entities.IdentityModel;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
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
            var items = ItemSeed();
            context.Causes.AddRange(causes);
            context.Events.AddRange(events);
            context.Items.AddRange(items);

            if (!context.Roles.Any(r => r.Name == "Guest"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Guest" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "SuperAdmin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Member" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Donor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Donor" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "admin@gmail.com", Email = "admin@gmail.com", PasswordHash = passwordHash.HashPassword("Admin1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "SuperAdmin");
            }
            if (!context.Users.Any(u => u.UserName == "member@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "member@gmail.com", Email = "member@gmail.com", PasswordHash = passwordHash.HashPassword("Member1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Member");
            }
            if (!context.Users.Any(u => u.UserName == "organizer@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "organizer@gmail.com", Email = "organizer@gmail.com", PasswordHash = passwordHash.HashPassword("Organizer1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            context.SaveChanges();
        }
        public List<Cause> CauseSeed()
        {
            List<Cause> causes = new List<Cause>()
            {
              new Cause() {Title = "Help the poor",Description="Help those in need",TargetGoal=150,CurrentAmmount=25 , Photo = "106052.jpg"},
              new Cause() {Title = "Those who have should share",Description="Help your fellow people by giving something, you are going to feel better",TargetGoal=210,CurrentAmmount=75, Photo = "6646987.jpg" },
              new Cause() {Title = "Food for Homeless",Description="Support the feeding needs of those in need",TargetGoal=110,CurrentAmmount=32 , Photo = "6647128.jpg" },
              new Cause() {Title = "Clothing for Poor",Description="Raise money to buy clothes for the poor",TargetGoal=350,CurrentAmmount=110, Photo = "6994869.jpg" },
              new Cause() {Title = "Build a shelter for stray animals",Description="Help us build a warm house for dozens stray animals that need your help now",TargetGoal=23000,CurrentAmmount=5200 },
              new Cause() {Title = "Help victims of wildfires",Description="The Greek arm of the Red Cross is providing financial support and food for those affected by the fires",TargetGoal=10000,CurrentAmmount=50 },
              new Cause() {Title = "Support the Ukrainian war immigrants",Description="Everyday more and more war immigrants need your help, help us gather money and help them stand in their feet",TargetGoal=20000,CurrentAmmount=9850 },
              new Cause() {Title = "Help victims of floods",Description="Help us provide for the victims of floods",TargetGoal=350,CurrentAmmount=50 },
              new Cause() {Title = "Support the organization : Save the children",Description="We strongly support the non-profitable organization save the children",TargetGoal=500,CurrentAmmount=100 },
              new Cause() {Title = "Support the organization : Hamogelo tou paidiou",Description="We strongly support the non-profitable organization hamogelo tou paidiou",TargetGoal=600,CurrentAmmount=250 },
              new Cause() {Title = "Provide for those in need",Description="After the resent events more and more come in need, help them to stand in their feet",TargetGoal=500,CurrentAmmount=250 },
              new Cause() {Title = "Help Elena to beat cancer",Description="Support Elena a true fighter, to overcome her illness, we gather money for her surgery",TargetGoal=870,CurrentAmmount=850 },
              new Cause() {Title = "George Papanikolaou needs your help",Description="With your help George will soon be able to walk again",TargetGoal=1250,CurrentAmmount=500 },
              new Cause() {Title = "Support Ukraine",Description="In co-operation with the Greek embassy in Ukraine we provide help to the non-profitable org. Support Ukraine",TargetGoal=800,CurrentAmmount=500 },
              new Cause() {Title = "Help the homeless",Description="Help those with nothing start fresh",TargetGoal=550,CurrentAmmount=500 },
              new Cause() {Title = "Support the victims of tornado Martha",Description="We support the victims of tornado to recover from this hardship",TargetGoal=950,CurrentAmmount=500 }
            };
            return causes;
        }
        public List<Event> EventSeed()
        {
            List<Event> events = new List<Event>()
            {
              new Event() {Title = "14th Street Charity Meal",Description="Offering meal at 14th Street",Address="Agiou Meletiou 32, Athens, Pagrati 12443",
                  EventDate=new DateTime(2022,04,05), Photo = "106052.jpg"},
              new Event() {Title = "St.Nicolas Church Food Festival",Description="Offering meal St.Nicolas Church",Address="Stratarxou Karaiskaki 22, Athens, Haidari 12461",
                  EventDate=new DateTime(2022,05,07), Photo = "9169661.jpg" },
              new Event() {Title = "Bazaar of poor Souls",Description="Open Market to support the poor",Address="Dwdwkanisou 62, Athens, Egaleo 12364",
                  EventDate=new DateTime(2022,04,05), Photo = "9168809.jpg" },
              new Event() {Title = "Lending a hand",Description="Free grooming for poor people",Address="Dervenakiwn 87, Athens, Peristeri 12452",
                  EventDate=new DateTime(2022,06,05), Photo = "9090746.jpg" },
              new Event() {Title = "Lending two hands",Description="Free grooming for extra poor people",Address="Dervenakiwn 87, Athens, Peristeri 12452",
                  EventDate=new DateTime(2022,02,05), Photo = "8078392.jpg" },
              new Event() {Title = "Soup Kitchen at Iroon Square",Description="Offering free meals at Plateia Iroon in Chaidari from 12:00 to 18:00.",
                  Address="Pl. Ir. 1940 41, Chaidari 124 61",EventDate=new DateTime(2022,06,06), Photo = "7551595.jpg" },

              new Event() {Title = "Soup Kitchen at Amerikis Square",Description="Offering free meals at Plateia Amerikis in Athens from 14:00 to 18:00",
                  Address="Amerikis Square, Athens 112 52",EventDate=new DateTime(2022,09,05), Photo = "7551591.jpg" },

              new Event() {Title = "Soup Kitchen at Kanigos Square",Description="Offering free meals at Plateia Kaniggos in Athens from 13:00 to 17:00",
                  Address="Akadimias 92, Athens 106 77",EventDate=new DateTime(2022,08,05), Photo = "7475725.jpg" },

              new Event() {Title = "Soup Kitchen at Omonia Square",Description="Offering free meals at Plateia Omonoias in Athens from 12:00 to 17:00",
                  Address="Square, District of Freedom 8573311, Athens 104 31",EventDate=new DateTime(2022,10,12) , Photo = "7298844.jpg"},

              new Event() {Title = "Soup Kitchen at Exarcheia Square",Description="Offering free meals at Plateia Exarcheion in Athens from 15:00 to 19:00",
                  Address="Stournari 5, Athens 106 83",EventDate=new DateTime(2022,09,02) },

              new Event() {Title = "Soup Kitchen at Karaiskaki Square",Description="Offering free meals at Plateia Karaiskaki in Athens from 12:00 to 18:00",
                  Address="Pl. Karaiskaki, Athens 104 37",EventDate=new DateTime(2022,06,04) },

              new Event() {Title = "Soup Kitchen at Kolonaki Square",Description="Offering free meals at Plateia Kolonakiou in Athens from 13:00 to 15:00",
                  Address="Pl. Filikis Eterias 11, Athens 106 74",EventDate=new DateTime(2022,08,06) },

              new Event() {Title = "Soup Kitchen at Syntagma Square",Description="Offering free meals at Plateia Syntagmatos in Athens from 12:00 to 15:00",
                  Address="Pl. Sintagmatos, Athens 105 63",EventDate=new DateTime(2022,06,06) },

              new Event() {Title = "Soup Kitchen at Davaki Square",Description="Offering free meals at Plateia Davaki in Kallithea from 13:00 to 17:00",
                  Address="Mantzagriotaki 68, Kallithea 176 72",EventDate=new DateTime(2022,05,05), Photo = "7475725.jpg"  },

              new Event() {Title = "Soup Kitchen at Estavromenos Square",Description="Offering free meals at Plateia Estavromenoy in Egaleo from 12:00 to 18:00",
                  Address="Dimarchiou 1, Egaleo 122 42",EventDate=new DateTime(2022,06,06) }
            };
            return events;
        }

        public List<Item> ItemSeed()
        {
            List<Item> items = new List<Item>()
            {
                new Item() {Id = Guid.NewGuid(), ItemName = "Makaronia",Quantity = 3,Price=1.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Aggouria",Quantity = 1,Price=1.7m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Ntomates",Quantity = 4,Price=1.5m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Feta",Quantity = 1,Price=3.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Orange Juice",Quantity = 1,Price=1.85m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Water",Quantity = 2,Price=1.75m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Chicken",Quantity = 3,Price=1.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Beef",Quantity = 1,Price=2.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Salt",Quantity = 5,Price=0.75m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Flour",Quantity = 1,Price=1.15m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Canned Tomatoes",Quantity = 4,Price=4.10m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Tost Bread",Quantity = 6,Price=2.10m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Canned Beans",Quantity = 3,Price=2.40m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Canned Tuna",Quantity = 7,Price=1.80m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Canned Vegetables",Quantity = 6,Price=1.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Milk",Quantity = 4,Price=3.10m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Beer",Quantity = 8,Price=1.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Bottled Water",Quantity = 8,Price=0.90m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Sprinkling Water",Quantity = 9,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Potatoes",Quantity = 15,Price=1.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Bread",Quantity = 10,Price=1.10m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Chicken Noodles",Quantity = 15,Price=0.60m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Beef Noodles",Quantity = 15,Price=0.60m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Oatmeal",Quantity = 3,Price=0.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Peanut Butter Jar",Quantity = 3,Price=0.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Powdered milk",Quantity = 3,Price=1.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Rice",Quantity = 1,Price=0.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Pink Salt",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Oregano",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Pepper",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Coriander",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Garlic powder",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Bay leaves",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Paprika",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Cumin",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Chili powder",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Red Wine",Quantity = 4,Price=5.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "White Wine",Quantity = 2,Price=4.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Baby Potatoes",Quantity = 15,Price=1.50m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Spinach",Quantity = 7,Price=0.80m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Lettuce",Quantity = 9,Price=0.90m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Water Mellon",Quantity = 6,Price=2.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Mellon",Quantity = 6,Price=1.60m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Coca-Cola",Quantity = 12,Price=0.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Pepsi-Cola",Quantity = 12,Price=0.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Vikos-Cola",Quantity = 12,Price=0.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Chocolate",Quantity = 8,Price=1.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Tea",Quantity = 9,Price=0.60m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Orange Juice",Quantity = 3,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Lemon Juice",Quantity = 2,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Mash Tomato",Quantity = 4,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Olive Oil",Quantity = 2,Price=4.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Sunflower Oil",Quantity = 2,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Onion",Quantity = 7,Price=1.60m},
                new Item() {Id = Guid.NewGuid(), ItemName= "Red Sugar",Quantity=1,Price=0.60m}

            };
            return items;
        }
        public void CreateRoles(MyDataBase.ApplicationDbContext context)
        {
            // ***** New Role ***** \\
            if (!context.Roles.Any(r => r.Name == "Guest"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "guest" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "SuperAdmin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Member" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Donor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Donor" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "admin@gmail.com", Email = "admin@gmail.com", PasswordHash = passwordHash.HashPassword("Admin1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "SuperAdmin");
            }
            if (!context.Users.Any(u => u.UserName == "member@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "member@gmail.com", Email = "member@gmail.com", PasswordHash = passwordHash.HashPassword("Member1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Member");
            }
            if (!context.Users.Any(u => u.UserName == "organizer@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "organizer@gmail.com", Email = "organizer@gmail.com", PasswordHash = passwordHash.HashPassword("Organizer1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        public List<ApplicationUser> RegisteredUsersSeed()
        {
            List<ApplicationUser> users = new List<ApplicationUser>()
        {
            new ApplicationUser() {FirstName="Takis",LastName="Mpompos",Address ="Kratira 12,Athens",UserName="Helper"},
            new ApplicationUser() {FirstName="Balya",LastName="Papaki",Address ="Xomateri 20,Traxanoplagia",UserName="Polar"},
            new ApplicationUser() {FirstName="John",LastName="Doe",Address ="3rd Avenue 112,Manhattan",UserName="Foreigner"}
        };
            return users;
        }
    }
}
