using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Ткани.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Pickuppoint = new HashSet<Pickuppoint>();
        }

        public int IdCities { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Pickuppoint> Pickuppoint { get; set; }
    }
}
