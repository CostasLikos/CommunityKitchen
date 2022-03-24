using Entities;
using MyDataBase;
using PersistentLayer.IRepository;
using PersistentLayer.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentLayer.Repository
{
    class ItemRepository : GenericRepo<Item>, IItemReposiory
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
