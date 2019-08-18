using System;
using System.Collections.Generic;

namespace SchoolFinances.Models
{
    public partial class LUserToKid
    {
        public int Id { get; set; }
        public int KidId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }

        public virtual Kid Kid { get; set; }
        public virtual User User { get; set; }
    }
}
