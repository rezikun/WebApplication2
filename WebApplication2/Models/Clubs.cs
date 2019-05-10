using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Clubs
    {
        public Clubs()
        {
            ClubHasTitle = new HashSet<ClubHasTitle>();
            Contracts = new HashSet<Contracts>();
        }

        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string Location { get; set; }
        public int? YearOfFoundation { get; set; }
        public int LeagueId { get; set; }
        public string Description { get; set; }

        public virtual Leagues League { get; set; }
        public virtual ICollection<ClubHasTitle> ClubHasTitle { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
