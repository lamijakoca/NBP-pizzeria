using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class CustomerPizzaActuals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PizzaActualId { get; set; }

        [ForeignKey("Pizza")]
        public long PizzaId { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
