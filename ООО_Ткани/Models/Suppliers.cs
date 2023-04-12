using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Ткани.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Product = new HashSet<Product>();
        }

        public int IdSuppliers { get; set; }
        public string SupplierName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
