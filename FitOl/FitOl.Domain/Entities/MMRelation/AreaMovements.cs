using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Entities.MMRelation
{
    public class AreaMovements
    {
        public int Id { get; set; }
        public int FKAreaId { get; set; }
        public int FKMovementId { get; set; }


        public virtual Area Area { get; set; }
        public virtual Movement Movement { get; set; }
    }
}
