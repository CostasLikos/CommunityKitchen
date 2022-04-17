using Entities;
using Entities.CompositeFactoryDesign.Concrete;
using Entities.CompositeFactoryDesign.Factories;
using Entities.IdentityModel;
using Entities.IEntities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyDataBase;
using PersistentLayer.Repository;
using PersistentLayer.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposTestArea
{
    class Program
    {
        static void Main(string[] args)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            CauseRepository causeService = new CauseRepository(context);
            EventRepository eventService = new EventRepository(context);

            //Liquid l1 = new Liquid("water",5);
            //Console.WriteLine(l1.ConsumableType);
            //Console.WriteLine(l1.ItemName);
            //Console.WriteLine(l1.Quantity);
            //Solid s1 = new Solid();
            //Console.WriteLine(s1.ConsumableType);


            //IConsumableFactory liquidFactory = new LiquidFactory();
            //IConsumable liquid1 = liquidFactory.CreateConsumable("Tea",6);
            //Console.WriteLine(liquid1.ConsumableType);




            //IConsumableFactory solidFactory = new SolidFactory();

            //var store = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(store);

            //var passwordHash = new PasswordHasher();
            //Event eventTest = new Event()
            //{
            //    Title = "Agiou Meletiou Charity Meal",
            //    Description = "Offering meal at Agiou Meletiou street",
            //    Address = "Agiou Meletiou 32, Athens, Pagrati 12443",
            //    EventDate = new DateTime(2022, 04, 05),
            //    Photo = "food1.jpg"
            //};
            //var user = new ApplicationUser()
            //{
            //    UserName = "IreceiveNotice@gmail.com",
            //    Email = "IreceiveNotice@gmail.com",
            //    PasswordHash = passwordHash.HashPassword("321Member!")

            //};
            //var user1 = new ApplicationUser()
            //{
            //    UserName = "DateChangedInfo@gmail.com",
            //    Email = "DateChangedInfo@gmail.com",
            //    PasswordHash = passwordHash.HashPassword("321SAdmin!")

            //};
            //eventTest.observerList.Add(user);

            //Console.WriteLine(eventTest.EventDate.ToShortDateString());
            //eventTest.EventDate = new DateTime(2022, 04, 08);
            //Console.WriteLine(eventTest.EventDate.ToShortDateString());



            //var causes = causeService.GetAll();
            //foreach (var item in causes)
            //{
            //    Console.WriteLine($"{item.Title,-40}{item.Description,-40}{item.TargetGoal}{item.CurrentAmmount}");
            //}
            //Console.WriteLine("-------------------------------------------------------------");
            //Cause NeedMoney = new Cause() { Title = "Money Money", Description = "Raising Funds", TargetGoal = 150, CurrentAmmount = 25 };
            //causeService.Add(NeedMoney);
            //causeService.Save();
            //foreach (var item in causes)
            //{
            //    Console.WriteLine($"{item?.Title,-40} {item.TargetGoal,-30}{item.CurrentAmmount,-30}");
            //}
            //var key = causeService.GetId(NeedMoney);
            //Console.WriteLine(key);
            //causeService.Delete(key);
            //causeService.Save();
            //Console.WriteLine("################################");
            //foreach (var item in causes)
            //{
            //    Console.WriteLine($"{item?.Title,-40} {item.TargetGoal,-30}{item.CurrentAmmount,-30}");
            //}




            //var events = eventService.GetAll();
            //foreach (var item in events)
            //{
            //    Console.WriteLine($"{item.Title,-40}{item.Description,-40}{item.EventDate.ToShortDateString(),-40}");
            //}
            //IWatcher watcherAlpha = new ApplicationUser() { FirstName= "John", LastName="Doe"};
            //Event FoodPlus = new Event();
            //FoodPlus.Register(watcherAlpha);
            //FoodPlus.EventDate = new DateTime(05 / 05 / 2005);





        }

    }
}
