using FirewallRulesTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Models;

namespace FirewallRulesTracker.ViewModels
{
    public class FirewallRulesViewModel
    {
        readonly FWRuleRepository fwRepo;

        public FirewallRulesViewModel()
        {
            fwRepo = new FWRuleRepository();

            FWRules = fwRepo.GetAll();

            //FWRules = (from r in FWRulesDTOs
            //           select new FWRule()
            //           {
            //               FWRuleID = r.FWRuleID,
            //               Direction = (Models.DataDirection)r.Direction,
            //               Port = r.Port,
            //               Protocol = (Models.ProtocolType)r.Protocol
            //           });
        }

        public IEnumerable<FWRuleEntity> FWRules { get; set; }
    }
}
