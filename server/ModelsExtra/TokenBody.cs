using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class TokenBody
    {
        public string Username { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
