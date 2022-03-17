using Entities;
using MyDataBase;
using PersistentLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposTestArea
{
    public class CauseTest
    {
        //static void Main(string[] args)
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    CauseRepository causeService = new CauseRepository(db);
        //    var causes = causeService.GetAll();
        //    foreach (var item in causes)
        //    {
        //        Console.WriteLine($"{item.Title,-40}{item.Description,-40}{item.TargetGoal}{item.CurrentAmmount}");
        //    }
        //    Console.WriteLine("-------------------------------------------------------------");
        //    Cause NeedMoney = new Cause() { Title = "Money Money", Description = "Raising Funds", TargetGoal = 150, CurrentAmmount = 25 };
        //    causeService.Add(NeedMoney);
        //    causeService.Save();
        //    foreach (var item in causes)
        //    {
        //        Console.WriteLine($"{item?.Title,-40} {item.TargetGoal,-30}{item.CurrentAmmount,-30}");
        //    }
        //    var key = causeService.GetId(NeedMoney);
        //    Console.WriteLine(key);
        //    causeService.Delete(key);
        //    causeService.Save();
        //    Console.WriteLine("################################");
        //    foreach (var item in causes)
        //    {
        //        Console.WriteLine($"{item?.Title,-40} {item.TargetGoal,-30}{item.CurrentAmmount,-30}");
        //    }

        //}
    }
}
