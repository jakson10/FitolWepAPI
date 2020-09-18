using FitOl.Domain.Entities.MMRelation;
using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FKDayId { get; set; }
        public EnumMovementType EnumMovementType { get; set; }


        public virtual SportDay SportDay { get; set; }
        public virtual ICollection<AreaMovements> AreaMovements { get; set; }
    }
}
