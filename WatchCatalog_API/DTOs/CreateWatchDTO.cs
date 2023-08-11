using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WatchCatalog_API.DTOs
{
    public class CreateWatchDTO
    {
        public IFormFile? Image { get; set; }

        [Required]
        public string WatchName { get; set; } = null!;

        [Required]
        public string Short_description { get; set; } = null!;

        [Required]
        public string Full_Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Caliber { get; set; } = null!;

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Diameter { get; set; }

        [Required]
        public decimal Thickness { get; set; }

        [Required]
        public string Jewel { get; set; } = null!;

        [Required]
        public string Case { get; set; } = null!;

        [Required]
        public string Strap { get; set; } = null!;
    }
}
