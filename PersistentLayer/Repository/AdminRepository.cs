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
    public class AdminRepository : GenericRepo<Moderator>, IAdminRepository
    {
        public AdminRepository(ApplicationDbContext context) : base(context)
        {
        }

        
    }
}
