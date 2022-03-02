using PersistentLayer.IRepository;
using PersistentLayer.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentLayer.Repository
{
    public class Event : GenericRepo<Event>, IEventRepository
    {
        public void Add(Entities.Event entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Entities.Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entities.Event GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
