using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirewallRulesTracker.Models
{
    public enum DataDirection
    {
        Inbound,
        Outbound,
        BiDirectional
    }

    public enum ProtocolType
    {
        ICMP,
        TCP,
        UDP
    }

    public enum RuleState
    {
        Enabled,
        Disabled
    }

    public class FWRule
    {
        public int           FWRuleID { get; set; }    // Primary key identifier for the rule
        public int           RoleID { get; set; }      // Parent application role using the rule 
        public DataDirection Direction { get; set; }   // Data direction in, out or bi-directional
        public ProtocolType  Protocol { get; set; }    // IP protocol ICMP, TCP, UDP, or custom
        public UInt16        Port { get; set; }        // Port number (0 - 65535)
        public string        SRA { get; set; }         // Security Review Approval number
        public string        WorkItem { get; set; }    // Work item number assigned to the request
        public int           Version { get; set; }     // Rule version number
        public int           RequestorID { get; set; } // ID of user requesting the latest rule version
    }
}
