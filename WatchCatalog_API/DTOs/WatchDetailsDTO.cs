using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WatchCatalog_API.DTOs
{
    public class WatchDetailsDTO
    {
        public int WatchId { get; set; }

        public string Image { get; set; } = null!;

        public string WatchName { get; set; } = null!;

        public string Short_description { get; set; } = null!;

        public string Full_Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string Chronograph { get; set; } = null!;

        public string Caliber { get; set; } = null!;

        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public decimal Diameter { get; set; }

        public decimal Thickness { get; set; }

        public string Jewel { get; set; } = null!;

        public string Case { get; set; } = null!;

        public string Strap { get; set; } = null!;

        public bool? IsActive { get; set; }
    }
}
