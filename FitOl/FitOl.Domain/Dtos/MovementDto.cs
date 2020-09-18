using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Dtos
{
    public class MovementDto
    {
        public int Id { get; set; }
        public string MovementName { get; set; }
        public string ImagePath { get; set; } 
        public string MovementDescription { get; set; }
        public EnumMovementType EnumMovementType { get; set; }

        //public virtual ICollection<AreaMovementsDto> AreaMovements { get; set; }
    }
}

