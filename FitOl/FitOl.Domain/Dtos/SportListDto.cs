using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Dtos
{
    public class SportListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumSportType EnumSportType { get; set; }

        //public virtual ICollection<SportDayDto> SportDays { get; set; }
        //public virtual ICollection<UserSportListsDto> UserSportLists { get; set; }
    }
}
