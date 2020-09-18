using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Dtos
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriValue { get; set; }
        public double ProteinValue { get; set; }
        public double CarbohydrateValue { get; set; }
        public double OilValue { get; set; }
        public double FiberValue { get; set; }
        public string ImagePath { get; set; }  
        public EnumFoodType EnumFoodType { get; set; }


        //public virtual ICollection<MealFoodsDto> MealsIncluded { get; set; }
    }
}
