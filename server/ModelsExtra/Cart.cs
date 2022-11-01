using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int AllProductsAmount { get; set; }
        public int FinalPrice { get; set; }
        public int ProductAmount { get; set; }
        public int ProductId { get; set; }
        public string NameProduct { get; set; } = null!;
        public string PictureURL { get; set; } = null!;
        public int Price { get; set; }
        public int? SalePrice { get; set; }
    }
}
