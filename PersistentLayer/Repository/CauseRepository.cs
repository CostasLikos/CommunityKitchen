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
    public class CauseRepository : GenericRepo<Cause>, ICauseRepository
    {
        public CauseRepository(ApplicationDbContext context) : base(context)
        {
           
        }
        //Testing ASsistant
        public Guid GetId(Cause entity) => entity.Id;


    }
}
