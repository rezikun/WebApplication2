using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Leagues
    {
        public Leagues()
        {
            Clubs = new HashSet<Clubs>();
        }

        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public short LeagueLevel { get; set; }
        public int CountryId { get; set; }
        public int? NumberOfClplaces { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Clubs> Clubs { get; set; }
    }
}
