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

            //FWService = fwDbContext.Services.ToList<Service>();
            FWRules = (List<FWRuleDBModel>)fwRepo.GetAll();
        }

        public List<FWRuleDBModel> FWRules { get; set; }
        public List<Service> FWService { get; set; }
        public List<Role> FWRole { get; set; }
    }
}
