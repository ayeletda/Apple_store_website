using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class AProduct
    {
        public int Id { get; set; }
        public string NameProduct { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int Price { get; set; }
        public string Details { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public bool NewFlag { get; set; }

        public int? SalePrice { get; set; }
    }
}
