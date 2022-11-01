using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class User
    {
        public User()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
            ShoppingHistories = new HashSet<ShoppingHistory>();
        }

        public int Id { get; set; }
        public string FisrtName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Token { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<ShoppingHistory> ShoppingHistories { get; set; }
    }
}
