using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Ткани.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderproduct = new HashSet<Orderproduct>();
        }

        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public int? OrderUserId { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public string OrderPickupPoint { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderCode { get; set; }

        public virtual Status OrderStatus { get; set; }
        public virtual User OrderUser { get; set; }
        public virtual ICollection<Orderproduct> Orderproduct { get; set; }
    }
}
