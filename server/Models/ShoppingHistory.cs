using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class ShoppingHistory
    {
        public ShoppingHistory()
        {
            ShoppingHistoryProducts = new HashSet<ShoppingHistoryProduct>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int AllProductsAmount { get; set; }
        public int FinalPrice { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<ShoppingHistoryProduct> ShoppingHistoryProducts { get; set; }
    }
}
