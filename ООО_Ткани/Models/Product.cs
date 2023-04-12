using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Ткани.Models
{
    public partial class Product
    {
        public Product()
        {
            Orderproduct = new HashSet<Orderproduct>();
        }

        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPhoto { get; set; }
        public decimal ProductCost { get; set; }
        public sbyte? ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public int ProductUnitId { get; set; }
        public int ProductSupplierId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductManufacturerId { get; set; }
        public sbyte? ProductDiscountMax { get; set; }

        public virtual Category ProductCategory { get; set; }
        public virtual Manufracturer ProductManufacturer { get; set; }
        public virtual Suppliers ProductSupplier { get; set; }
        public virtual Productunit ProductUnit { get; set; }
        public virtual ICollection<Orderproduct> Orderproduct { get; set; }
    }
}
