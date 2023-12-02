using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Raythos_Aerospace.Models
{
    public class Aircraft
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int ModelId { get; set; } // Foreign key referencing Model model
        public Model Model { get; set; } // Navigation property to access related Model
        public float TotalPrice { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
