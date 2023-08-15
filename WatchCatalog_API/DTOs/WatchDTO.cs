using System.ComponentModel.DataAnnotations;

namespace WatchCatalog_API.DTOs
{
    public class WatchDTO
    {
        public int WatchId { get; set; }

        public string WatchName { get; set; } = null!;

        public string Image { get; set; } = null!;

        public string Short_description { get; set; } = null!;

        public decimal Price { get; set; }

        public bool? IsActive { get; set; }
    }
}
