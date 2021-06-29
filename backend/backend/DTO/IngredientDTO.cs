using System.ComponentModel.DataAnnotations;


namespace backend.DTO
{
    public class IngredientDTO
    {
        [Required]
        public string Name { get; set; }
        public string Origin { get; set; }
        public float KCAL { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
