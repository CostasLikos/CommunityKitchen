using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.IdentityModel;
using System.Data.Entity;
using Entities;

namespace MyDataBase
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("MyLinkDB", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()=> new ApplicationDbContext();

        public DbSet<Event> Events { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Item> Items { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //Configure primary key
        //    modelBuilder.Entity<Cause>().HasKey<Guid>(pk => pk.Id);
        //    modelBuilder.Entity<Event>().HasKey<Guid>(pk => pk.Id);
        //    modelBuilder.Entity<Story>().HasKey<Guid>(pk => pk.Id);
        //}

    }
}