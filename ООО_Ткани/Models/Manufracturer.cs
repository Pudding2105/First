using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Ткани.Models
{
    public partial class Manufracturer
    {
        public Manufracturer()
        {
            Product = new HashSet<Product>();
        }

        public int IdManufracturer { get; set; }
        public string ManufracturerName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
