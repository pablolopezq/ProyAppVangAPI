using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyAppVangAPI.Models
{
    public class ListDto
    {
        public int Id { get; set; }

        public ICollection<string> Items { get; set; }

        public string Name { get; set; }
    }
}
