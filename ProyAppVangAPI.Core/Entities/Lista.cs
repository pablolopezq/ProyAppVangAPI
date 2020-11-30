using System;
using System.Collections.Generic;
using System.Text;

namespace ProyAppVangAPI.Core.Entities
{
    public class Lista : BaseEntity
    {
        public Lista()
        {
            Items = new List<string>();
        }

        public ICollection<string> Items { get; set; }

        public string Name { get; set; }
    }
}
