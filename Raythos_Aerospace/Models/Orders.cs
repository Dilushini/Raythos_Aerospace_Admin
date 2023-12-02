using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Raythos_Aerospace.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Date { get; set; }
        public int AircraftId { get; set; } // Foreign key referencing Model model
        public Aircraft Aircraft { get; set; } // Navigation property to access related Model
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string CustomSize { get; set; }
        public string CustomColor { get; set; }
    }
}
