using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class PizzaActual
    {
        [Key]
        [ForeignKey("Pizza")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
