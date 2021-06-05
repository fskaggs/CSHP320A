using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
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

    public class FWRuleDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int FWRuleID { get; set; }    // Primary key identifier for the rule

        [ForeignKey("RequestorID")]
        public int RequestorID { get; set; } // ID of user requesting the latest rule version

        [ForeignKey("RoleID")]
        public int RoleID { get; set; }      // Parent application role using the rule 

        public DataDirection Direction { get; set; }   // Data direction in, out or bi-directional
        public ProtocolType Protocol { get; set; }    // IP protocol ICMP, TCP, UDP, or custom
        public UInt16 Port { get; set; }        // Port number (0 - 65535)
        public string SRA { get; set; }         // Security Review Approval number
        public string WorkItem { get; set; }    // Work item number assigned to the request
        public int Version { get; set; }     // Rule version number

    }
}
