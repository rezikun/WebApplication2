using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Players
    {
        public Players()
        {
            Contracts = new HashSet<Contracts>();
            PlayerHasTitle = new HashSet<PlayerHasTitle>();
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ContractId { get; set; }
        public int HeightCm { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
        public virtual ICollection<PlayerHasTitle> PlayerHasTitle { get; set; }
    }
}
