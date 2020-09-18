using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Entities.MMRelation
{
    public class UserNutritionLists
    {
        public int Id { get; set; }
        public int FKUserId { get; set; }
        public int FKNutritionListId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual NutritionList NutritionList { get; set; }
    }
}
