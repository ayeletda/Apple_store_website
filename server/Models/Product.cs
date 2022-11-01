using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class Product
    {
        public Product()
        {
            MacIpadIphoneProducts = new HashSet<MacIpadIphoneProduct>();
            Sales = new HashSet<Sale>();
            ShoppingCartProducts = new HashSet<ShoppingCartProduct>();
            ShoppingHistoryProducts = new HashSet<ShoppingHistoryProduct>();
            WatchAirpodsProducts = new HashSet<WatchAirpodsProduct>();
        }

        public int Id { get; set; }
        public string NameProduct { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int Price { get; set; }
        public string Details { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public bool NewFlag { get; set; }

        public virtual ICollection<MacIpadIphoneProduct> MacIpadIphoneProducts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public virtual ICollection<ShoppingHistoryProduct> ShoppingHistoryProducts { get; set; }
        public virtual ICollection<WatchAirpodsProduct> WatchAirpodsProducts { get; set; }
    }
}
