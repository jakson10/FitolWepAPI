using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Dtos
{
    public class MealFoodsDto
    {
        public int Id { get; set; }
        public int FKFoodId { get; set; }
        public int FKThatDayId { get; set; }

        public virtual FoodDto Food { get; set; }
        public virtual ThatDayDto ThatDay { get; set; }
    }
}
