using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Federations
    {
        public Federations()
        {
            Titles = new HashSet<Titles>();
        }

        public int FederationId { get; set; }
        public string FederationName { get; set; }

        public virtual ICollection<Titles> Titles { get; set; }
    }
}
