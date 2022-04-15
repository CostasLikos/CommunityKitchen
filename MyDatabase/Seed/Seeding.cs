using Entities;
using Entities.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Seed
{
    internal class Seeding
    {
        public List<Cause> CauseSeed()
        {
            List<Cause> causes = new List<Cause>()
            {
              new Cause() {Title = "For Those In Need",Description="Get money",TargetGoal=150,CurrentAmmount=25 },
              new Cause() {Title = "For Those Who Want to Help",Description="Give money",TargetGoal=210,CurrentAmmount=75 },
              new Cause() {Title = "Food For The Homeless",Description="Help us offer them a warm meal",TargetGoal=110,CurrentAmmount=32 },
              new Cause() {Title = "Clothing For The Poor",Description="Raise money to buy clothes for the poor",TargetGoal=350,CurrentAmmount=110 },
            };
            return causes;
        }
        public List<Event> EventSeed()
        {
            List<Event> events = new List<Event>()
            {
              new Event() {Title = "Agiou Meletiou Charity Meal",Description="Offering meal at Agiou Meletiou",Address="Agiou Meletiou 32, Athens, Pagrati 12443",EventDate=new DateTime(2022,02,05) },
              new Event() {Title = "St.Nicolas Church Food Festival",Description="Offering meal St.Nicolas Church",Address="Stratarxou Karaiskaki 22, Athens, Haidari 12461",EventDate=new DateTime(2022,05,07) },
              new Event() {Title = "Bazaar for the poor Souls",Description="Participate to our open Market to support the poor",Address="Dwdwkanisou 62, Athens, Egaleo 12364",EventDate=new DateTime(2022,04,05) },
              new Event() {Title = "Lending a hand",Description="Free grooming for poor people",Address="Dervenakiwn 87, Athens, Peristeri 12452",EventDate=new DateTime(2022,06,05) }
            };
            return events;
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
        public List<Item> ItemSeed()
        {
            List<Item> items = new List<Item>()
            {
                new Item() {ItemName = "Makaronia",Quantity = 1,Price=1.95m},
                new Item() {ItemName = "Aggouria",Quantity = 1,Price=1.7m},
                new Item() {ItemName = "Ntomates",Quantity = 1,Price=1.5m},
                new Item() {ItemName = "Feta",Quantity = 1,Price=3.95m},
                new Item() {ItemName = "Orange Juice",Quantity = 1,Price=1.85m},
                new Item() {ItemName = "Water",Quantity = 1,Price=1.75m},
                new Item() {ItemName = "Chicken",Quantity = 1,Price=1.95m},
                new Item() {ItemName = "Beef",Quantity = 1,Price=2.95m},
                new Item() {ItemName = "Salt",Quantity = 1,Price=0.75m},
                new Item() {ItemName = "Flour",Quantity = 1,Price=1.15m},
                new Item() {ItemName = "Tost Bread",Quantity = 1,Price=2.10m}
            };
            return items;
        }
    }
}
