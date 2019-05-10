using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Titles
    {
        public Titles()
        {
            ClubHasTitle = new HashSet<ClubHasTitle>();
            PlayerHasTitle = new HashSet<PlayerHasTitle>();
        }

        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public int FederationId { get; set; }

        public virtual Federations Federation { get; set; }
        public virtual ICollection<ClubHasTitle> ClubHasTitle { get; set; }
        public virtual ICollection<PlayerHasTitle> PlayerHasTitle { get; set; }
    }
}
