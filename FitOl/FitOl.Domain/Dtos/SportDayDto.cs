using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Dtos
{
    public class SportDayDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FKSportListId { get; set; }

        public virtual SportListDto SportList { get; set; }

        //public virtual ICollection<AreaDto> Areas { get; set; }
    }
}
