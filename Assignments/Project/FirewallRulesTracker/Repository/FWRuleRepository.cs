using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Database.Models;
using Repository.Models;

namespace Repository
{
    public class FWRuleRepository: IGenericDataRepository<FWRuleEntity>
    {
        DatabaseManager db = new DatabaseManager();

        public void Add(FWRuleEntity Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(FWRuleEntity Entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FWRuleEntity> FindByCondition(System.Linq.Expressions.Expression<Func<FWRuleEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public FWRuleEntity Get(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWRuleEntity> GetAll()
        {
            IEnumerable<FWRuleEntity> data = (from rule in DatabaseManager.DBContext.Set<FWRuleDB>()
                       join role in DatabaseManager.DBContext.Set<RoleDB>()
                       on rule.RoleID equals role.RoleID
                       //join service in DatabaseManager.DBContext.Set<ServiceDB>()
                       //on role.ServiceID equals service.ServiceID
                       select new FWRuleEntity
                       {
                           RoleID = role.RoleID,
                           RoleName = role.RoleName,
                           FWRuleID = rule.FWRuleID,
                           Direction = (Models.DataDirection)rule.Direction,
                           Port = rule.Port,
                           Protocol = (Models.ProtocolType)rule.Protocol,
                           SRA = rule.SRA,
                           WorkItem = rule.WorkItem,
                           ServiceName = "Not Set",
                           Version = rule.Version,
                           RequestorID = rule.RequestorID,
                           RequestorName = "Not Set"
                       }).ToList<FWRuleEntity>();
            return data;
        }

        //public IEnumerable<FWRuleEntity> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public FWRuleEntity GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void Update(FWRuleEntity dbEntity, FWRuleEntity Entity)
        {
            throw new NotImplementedException();
        }
    }
}
