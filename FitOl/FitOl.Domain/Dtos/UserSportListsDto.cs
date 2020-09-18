using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Dtos
{
    public class UserSportListsDto
    {
        public int Id { get; set; }
        public int FKUserId { get; set; }
        public int FKSportListId { get; set; }


        public virtual AppUserDto User { get; set; }
        public virtual SportListDto SportList { get; set; }
    }
}
