using System;
using System.Collections.Generic;

namespace SchoolFinances.Models
{
    public partial class LUserToClass
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }

        public virtual Classe Class { get; set; }
        public virtual User User { get; set; }
    }
}
