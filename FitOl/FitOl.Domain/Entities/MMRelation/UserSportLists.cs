using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Entities.MMRelation
{
    public class UserSportLists
    {
        public int Id { get; set; }
        public int FKUserId { get; set; }
        public int FKSportListId { get; set; }


        public virtual AppUser User { get; set; }
        public virtual SportList SportList { get; set; }
    }
}
