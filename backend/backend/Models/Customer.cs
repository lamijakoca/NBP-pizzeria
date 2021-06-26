using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }
        public DateTime DOP { get; set; }
    }
}
