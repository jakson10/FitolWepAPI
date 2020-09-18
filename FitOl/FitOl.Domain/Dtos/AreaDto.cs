using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Dtos
{
    public class AreaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FKDayId { get; set; }

        public virtual SportDayDto SportDay { get; set; }
        //public virtual ICollection<AreaMovementsDto> AreaMovements { get; set; }
    }
}
