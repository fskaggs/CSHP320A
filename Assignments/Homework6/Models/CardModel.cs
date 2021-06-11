//CSHP320A
//Frederick J. Skaggs - Homework 6

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework6.Models
{
    public class CardModel
    {
        [Required(ErrorMessage = "Please enter the name of the person to send to.")]
        public string ToName { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string FromName { get; set; }

        [Required(ErrorMessage = "Please enter a birthday message.")]
        public string Message { get; set; }
    }
}
