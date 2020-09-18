using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Dtos
{
    public class ThatDayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FKNutritionDayId { get; set; }
        public EnumMealType EnumMealType { get; set; }

        public virtual NutritionDayDto NutritionDays { get; set; }
        //public virtual ICollection<MealFoodsDto> NutrientsInMeals { get; set; }
    }
}
