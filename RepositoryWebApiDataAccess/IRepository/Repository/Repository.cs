using Microsoft.EntityFrameworkCore;
using RepositoryWebApiDataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiDataAccess.IRepository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>();
        }
        public bool Add(T entity)
        {
            dbset.Add(entity);
            return Save();
        }

        public T Get(int Id)
        {
            return dbset.Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public bool Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }
    }
}
