using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    [Table("Roles")]
    public class RoleDB
    {
        [Key]
        public int RoleID { get; set; }

        [Column("RoleName")]
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [ForeignKey("ServiceID")]
        public int ServiceID { get; set; }
    }
}