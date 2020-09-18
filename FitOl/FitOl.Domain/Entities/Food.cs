using FitOl.Domain.Entities.MMRelation;
using System;
using System.Collections.Generic;
using System.Text;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Domain.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriValue { get; set; }
        public double ProteinValue { get; set; }
        public double CarbohydrateValue { get; set; }
        public double OilValue { get; set; }
        public double FiberValue { get; set; }
        public string ImagePath { get; set; } = "default.png";
        public EnumFoodType EnumFoodType { get; set; }


        public virtual ICollection<MealFoods> MealsIncluded { get; set; }
    }
}
