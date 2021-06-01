using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirewallRulesTracker.Models
{
    [Table("Services")]
    public class Service
    {
        [Column("ServiceID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ServiceID { get; set; }

        [Column("ServiceName")]
        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; }

        [ForeignKey("ServiceID")]
        public List<Role> Roles { get; set; }
    }
}
