using FitOl.Domain.Entities.MMRelation;
using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Entities
{
    public class ThatDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FKNutritionDayId { get; set; }
        public EnumMealType EnumMealType { get; set; }

        public virtual NutritionDay NutritionDays { get; set; }
        public virtual ICollection<MealFoods> NutrientsInMeals { get; set; }
    }
}
