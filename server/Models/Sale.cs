using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SalePrice { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
