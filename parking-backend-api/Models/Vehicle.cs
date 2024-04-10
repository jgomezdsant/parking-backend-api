using System.ComponentModel.DataAnnotations;

namespace parking_banckend_api.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Brand field is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "The Model field is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "The Color field is required")]
        public string Color { get; set; }

        [Required(ErrorMessage = "The Plate field is required")]
        public string Plate { get; set; }

        [Required(ErrorMessage = "The Type field is required")]
        public int Type { get; set; }

        public bool isParking { get; set; }

        public int CompanyId { get; set; }
        //public Company Company { get; set; }
    }
}
