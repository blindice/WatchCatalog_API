using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchCatalog_API.Model
{
    [Table("tbl_watch")]
    public partial class tbl_watch
    {
        [Key]
        public int WatchId { get; set; }
        [StringLength(100)]
        public string? Image { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string WatchName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Short_description { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Full_Description { get; set; } = null!;
        [Column(TypeName = "decimal(13, 4)")]
        public decimal Price { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Chronograph { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string Caliber { get; set; } = null!;
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Height { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Diameter { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Thickness { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Jewel { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string Case { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string Strap { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
}
