using System.ComponentModel.DataAnnotations;

namespace CalculateInventory.Models
{    public class ProductModel
    {
        [Required]
        public string Name { get ; set; }

        [Range(0,150)]
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float Totalqty { get; set; }
        public string Message1 { get; set; }

    }
 }