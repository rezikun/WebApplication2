using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class ClubHasTitle
    {
        public int ClubAndTitleId { get; set; }
        public int ClubId { get; set; }
        public int TitleId { get; set; }
        public string DateOfAcquisition { get; set; }

        public virtual Clubs Club { get; set; }
        public virtual Titles Title { get; set; }
    }
}
