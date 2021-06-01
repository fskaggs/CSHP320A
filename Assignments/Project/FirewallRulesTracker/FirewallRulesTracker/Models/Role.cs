using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirewallRulesTracker.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int ParentService { get; set; }
        public List<FWRule> Rules { get; set; }
    }
}
