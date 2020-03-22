using Kanban.Model.Entities;
using Kanban.Model.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kanban.Repository.Collections
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly KanbanDbContext _context;

        public IQueryable<TEntity> Queryable => _context.Set<TEntity>().AsQueryable();

        public GenericRepository(KanbanDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>();

        public TEntity Get(int? id) => _context.Set<TEntity>().Find(id);

        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public void Delete(int id)
        {
            try
            {
                TEntity tentity = _context.Set<TEntity>().Find(id);
                _context.Set<TEntity>().Remove(tentity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
