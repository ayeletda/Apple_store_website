using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class WatchAirpodsProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Color { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
