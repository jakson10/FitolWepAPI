using FitOl.Domain.Entities.MMRelation;
using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Entities
{
    public class SportList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumSportType EnumSportType { get; set; }

        public virtual ICollection<SportDay> SportDays { get; set; }
        public virtual ICollection<UserSportLists> UserSportLists { get; set; }
    }
}
