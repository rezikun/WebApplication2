using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Leagues = new HashSet<Leagues>();
        }

        public int CountryId { get; set; }
        public string Countryname { get; set; }

        public virtual ICollection<Leagues> Leagues { get; set; }
    }
}
