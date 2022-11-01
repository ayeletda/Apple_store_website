using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class ShoppingHistoryProduct
    {
        public int Id { get; set; }
        public int ShoppingHistoryId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ShoppingHistory ShoppingHistory { get; set; } = null!;
    }
}
