using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentLayer.IRepository
{
    public interface IGenericRepo<T> where T : class
    {
        void Save();
        void Add(T entity);
        void Update(Guid id);
        void Delete(Guid id);
        ICollection<T> GetAll();
        T GetById(Guid id);

    }
}
