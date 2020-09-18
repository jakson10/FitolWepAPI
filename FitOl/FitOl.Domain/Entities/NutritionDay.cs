using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Entities
{
    public class NutritionDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FKNutritionListId { get; set; }


        public virtual NutritionList NutritionList { get; set; }
        public virtual ICollection<ThatDay> ThatDays { get; set; }
    }
}
