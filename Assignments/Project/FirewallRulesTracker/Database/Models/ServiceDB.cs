using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    [Table("Services")]
    public class ServiceDB
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
    }
}
