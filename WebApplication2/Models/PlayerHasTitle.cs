using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class PlayerHasTitle
    {
        public int PlayerAndTitleId { get; set; }
        public int PlayerId { get; set; }
        public int TitleId { get; set; }
        public string DateOfAcquisition { get; set; }

        public virtual Players Player { get; set; }
        public virtual Titles Title { get; set; }
    }
}
