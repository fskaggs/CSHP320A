using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository
{
    public class FWRuleRepository: IGenericDataRepository<FWRuleDBModel>
    {
        DatabaseManager db = new DatabaseManager();

        public void Add(FWRuleDBModel Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(FWRuleDBModel Entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FWRuleDBModel> FindByCondition(System.Linq.Expressions.Expression<Func<FWRuleDBModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public FWRuleDBModel Get(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWRuleDBModel> GetAll()
        {
            var data = DatabaseManager.DBContext.Rules.ToList();
            return data;
        }

        public FWRuleDBModel GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void Update(FWRuleDBModel dbEntity, FWRuleDBModel Entity)
        {
            throw new NotImplementedException();
        }
    }
}
