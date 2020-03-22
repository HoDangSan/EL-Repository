using System.Collections.Generic;
using System.Linq;

namespace Kanban.Model.Shared.Repository
{
    public interface IGenericRepository<TEntity>
    {

        IQueryable<TEntity> Queryable { get; }
        TEntity Get(int? id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    }
}
