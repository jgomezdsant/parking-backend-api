using System.ComponentModel.DataAnnotations;

namespace parking_banckend_api.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Address field is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The Telephone field is required")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "The Number of spaces for motorcycles field is required")]
        public int NumberMotorcycleSpaces { get; set; }

        [Required(ErrorMessage = "The Number of spaces for cars field is required")]
        public int NumberCarSpaces { get; set; }

       // public List<Vehicle> Vehiculos { get; set; }
    }
}

