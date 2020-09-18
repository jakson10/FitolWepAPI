using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Entities
{
    public class SportDay
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FKSportListId { get; set; }

        public virtual SportList SportList { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
