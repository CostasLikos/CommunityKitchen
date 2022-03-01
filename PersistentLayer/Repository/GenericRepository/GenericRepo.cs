using MyDataBase;
using PersistentLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistentLayer.Repository.GenericRepository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> _table = null;

        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Add(T entity)=> _table.Add(entity);
        public void Save()=>_context.SaveChanges();
        public void Delete(Guid id)
        {
            var existing = _table.Find(id);
            _context.Entry(existing).State = EntityState.Deleted;
        }
        public ICollection<T> GetAll() => _table.ToList();
        public T GetById(Guid id) => _table.Find(id);
        public void Update(Guid id)
        {
            var existing = _table.Find(id);
            _context.Entry(existing).State = EntityState.Modified;
        }
    }
}
