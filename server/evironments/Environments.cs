// export const environments = {
//   CONTEXT: "Server=localhost;Database=AppleDB;Trusted_Connection=False;password=<YourStrong@Passw0rd>;user=SA;",
//   CONTEXT: process.env.APPLE_DB_CONTEXT
// };

using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class Environments
    {
        public string Context { get; set; } = "Server=localhost;Database=AppleDB;Trusted_Connection=False;password=<YourStrong@Passw0rd>;user=SA;";
    }
}

