using FitOl.Domain.Entities.MMRelation;
using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Entities
{
    public class NutritionList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalCaloriValue { get; set; }

        public EnumNutritionType EnumNutritionType { get; set; }
        public EnumNutritionKind EnumNutritionKind { get; set; }

        public virtual ICollection<NutritionDay> NutritionDays { get; set; }
        public virtual ICollection<UserNutritionLists> UserNutritionLists { get; set; }
    }
}
