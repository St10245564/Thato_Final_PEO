using System;
using System.Collections.Generic;

#nullable disable

namespace Thato_final_PEO.Models
{
    public partial class AuthorisedUser
    {
        public Guid UserId { get; set; }
        public string UserNames { get; set; }
        public string UserPassword { get; set; }
    }
}
