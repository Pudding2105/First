using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Ткани.Models
{
    public partial class Pickuppoint
    {
        public int IdPickupPoint { get; set; }
        public string Index { get; set; }
        public int IdCitiy { get; set; }
        public string Street { get; set; }
        public int? Home { get; set; }

        public virtual Cities IdCitiyNavigation { get; set; }
    }
}
