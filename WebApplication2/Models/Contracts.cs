using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Contracts
    {
        public int ContractId { get; set; }
        public int ClubId { get; set; }
        public int PlayerId { get; set; }
        public decimal? AnnualSalary { get; set; }
        public DateTime? ValidUntill { get; set; }
        public DateTime? ValidFrom { get; set; }

        public virtual Clubs Club { get; set; }
        public virtual Players Player { get; set; }
    }
}
