using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.WebAPI.Models
{
    public class FoodUpdateModel
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

        public IFormFile Image { get; set; }
    }
}
