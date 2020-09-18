using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Dtos
{
    public class UserNutritionListsDto
    {
        
        public int Id { get; set; }
        public int FKUserId { get; set; }
        public int FKNutritionListId { get; set; }

        public virtual AppUserDto User { get; set; }
        public virtual NutritionListDto NutritionList { get; set; }
    }
}
