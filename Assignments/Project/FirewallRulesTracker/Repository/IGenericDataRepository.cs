using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericDataRepository<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        public TEntity Get(int Id);
        public TEntity GetByName(string Name);
        public void Add(TEntity Entity);
        public void Update(TEntity dbEntity, TEntity Entity);
        public void Delete(TEntity Entity);
    }
}
