using FitOl.Domain.Entities.MMRelation;
using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Entities
{
    public class Movement
    {
        public int Id { get; set; }
        public string MovementName { get; set; }
        public string ImagePath { get; set; } = "default.jpg";
        public string MovementDescription { get; set; }
        public EnumMovementType EnumMovementType { get; set; }

        public virtual ICollection<AreaMovements> AreaMovements { get; set; }
    }
}
