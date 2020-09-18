using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Dtos
{
    public class NutritionDayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FKNutritionListId { get; set; }


        public virtual NutritionListDto NutritionList { get; set; }
        //public virtual ICollection<ThatDayDto> ThatDays { get; set; }
    }
}
