using FirewallRulesTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirewallRulesTracker.ViewModels
{
    public class FirewallRulesViewModel
    {
        FirewallRulesContext fwDbContext = null;

        public FirewallRulesViewModel()
        {
            fwDbContext = new FirewallRulesContext();

            //FWService = fwDbContext.Services.ToList<Service>();
            FWRules = fwDbContext.Rules.ToList<FWRule>();
        }

        public List<FWRule> FWRules { get; set; }
        public List<Service> FWService { get; set; }
        public List<Role> FWRole { get; set; }
    }
}
