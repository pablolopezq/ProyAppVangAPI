using System;
using System.Collections.Generic;
using System.Text;

namespace ProyAppVangAPI.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
