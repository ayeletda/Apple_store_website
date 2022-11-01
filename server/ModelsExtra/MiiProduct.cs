using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class MiiProduct : WaProduct
    // public partial class MiiProduct : AProduct
    {
        // public string Color { get; set; } = null!;
        public string Memory { get; set; } = null!;
        public string ScreenSize { get; set; } = null!;
    }
}

// // ----------------------------------------------------------
// // ---------- The Models That We Add For The Joins ----------
// // ----------------------------------------------------------
// // 1 Product
//     public int Id { get; set; }
//         public string NameProduct { get; set; } = null!;
//         public string Category { get; set; } = null!;
//         public int Price { get; set; }
//         public string Details { get; set; } = null!;
//         public string PictureUrl { get; set; } = null!;
//         public bool NewFlag { get; set; }

// // 2 Sale
//         // public int Id { get; set; }
//     public int ProductId { get; set; }
//         public int SalePrice { get; set; }


// // 3 first join - AProduct = Product + Sale
//     public int Id { get; set; }
//         public string NameProduct { get; set; } = null!;
//         public string Category { get; set; } = null!;
//         public int Price { get; set; }
//         public string Details { get; set; } = null!;
//         public string PictureUrl { get; set; } = null!;
//         public bool NewFlag { get; set; }
//         public int SalePrice { get; set; }

// // 4 MacIpadIphoneProduct
//         // public int Id { get; set; }
//     public int ProductId { get; set; }
//         public string Color { get; set; } = null!;
//         public string Memory { get; set; } = null!;
//         public string ScreenSize { get; set; } = null!;

// // 5 second join - MiiProduct = AProduct + MacIpadIphoneProduct
//     public int Id { get; set; }
//         public string NameProduct { get; set; } = null!;
//         public string Category { get; set; } = null!;
//         public int Price { get; set; }
//         public string Details { get; set; } = null!;
//         public string PictureUrl { get; set; } = null!;
//         public bool NewFlag { get; set; }
//         public int SalePrice { get; set; }
//         public string Color { get; set; } = null!;
//         public string Memory { get; set; } = null!;
//         public string ScreenSize { get; set; } = null!;

// // 6 WatchAirpodsProduct
//         // public int Id { get; set; }
//     public int ProductId { get; set; }
//         public string Color { get; set; } = null!;

// // 7 second join - WaProduct = AProduct + WatchAirpodsProduct
//     public int Id { get; set; }
//         public string NameProduct { get; set; } = null!;
//         public string Category { get; set; } = null!;
//         public int Price { get; set; }
//         public string Details { get; set; } = null!;
//         public string PictureUrl { get; set; } = null!;
//         public bool NewFlag { get; set; }
//         public int SalePrice { get; set; }
//         public string Color { get; set; } = null!;
// // ----------------------------------------------------------
// // ----------------------------------------------------------
// // ----------------------------------------------------------


