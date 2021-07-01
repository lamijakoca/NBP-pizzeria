using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Pizza
    {
        public Pizza()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
