using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Dtos
{
    public class AreaMovementsDto
    {
        public int Id { get; set; }
        public int FKAreaId { get; set; }
        public int FKMovementId { get; set; }


        public virtual AreaDto Area { get; set; }
        public virtual MovementDto Movement { get; set; }
    }
}
