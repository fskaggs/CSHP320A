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
        public void Add(FWRuleEntity FWRule)
        {
            // Convert the repository model to the database model
            var dbRule = ToFWRuleDB(FWRule);

            DatabaseManager.DBContext.Add<FWRuleDB>(dbRule);
            DatabaseManager.DBContext.SaveChanges();

            // Add a copy of the context and return it in a new FWRuleEntity object
        }
        
        public void Delete(FWRuleEntity Entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FWRuleEntity> FindByCondition(System.Linq.Expressions.Expression<Func<FWRuleEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public FWRuleEntity Get(int Id)
        {
            FWRuleDB dbRule = DatabaseManager.DBContext.Rules.Where<FWRuleDB>(r => r.FWRuleID == Id).FirstOrDefault();

            FWRuleEntity fwRule = new FWRuleEntity()
            {
                FWRuleID = dbRule.FWRuleID,
                RoleID = dbRule.RoleID,
                Direction = (Models.DataDirection)dbRule.Direction,
                Port = dbRule.Port,
                Protocol = (Models.ProtocolType)dbRule.Protocol,
                SRA = dbRule.SRA,
                WorkItem = dbRule.WorkItem,
                Version = dbRule.Version,
                RequestorID = dbRule.RequestorID
            };
            return fwRule;
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

        private FWRuleDB ToFWRuleDB(FWRuleEntity FWRule)
        {
            var dbRule = new FWRuleDB()
            {
                RoleID = FWRule.RoleID,
                Direction = (Database.Models.DataDirection)FWRule.Direction,
                Port = FWRule.Port,
                Protocol = (Database.Models.ProtocolType)FWRule.Protocol,
                SRA = FWRule.SRA,
                WorkItem = FWRule.WorkItem,
                Version = FWRule.Version,
            };

            return dbRule;
        }
    }
}
