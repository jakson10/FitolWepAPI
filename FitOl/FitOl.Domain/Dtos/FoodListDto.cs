using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Domain.Dtos
{
    public class FoodListDto
    {
        public int FKFoodId { get; set; }
        public string Name { get; set; }
        public int FKThatDayId { get; set; }
    }
}
