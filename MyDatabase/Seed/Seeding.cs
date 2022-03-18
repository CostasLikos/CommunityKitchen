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
              new Event() {Title = "14th Street Charity Meal",Description="Offering meal at 14th Street",Address="Agiou Meletiou 32, Athens, Pagrati 12443",EventDate=new DateTime(2022,02,05) },
              new Event() {Title = "St.Nicolas Church Food Festival",Description="Offering meal St.Nicolas Church",Address="Stratarxou Karaiskaki 22, Athens, Haidari 12461",EventDate=new DateTime(2022,05,07) },
              new Event() {Title = "Bazaar of poor Souls",Description="Open Market to support the poor",Address="Dwdwkanisou 62, Athens, Egaleo 12364",EventDate=new DateTime(2022,04,05) },
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
    }
}
