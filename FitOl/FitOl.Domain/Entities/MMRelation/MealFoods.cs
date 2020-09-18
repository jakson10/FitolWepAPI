using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Entities.MMRelation
{
    public class MealFoods
    {
        public int Id { get; set; }
        public int FKFoodId { get; set; }
        public int FKThatDayId { get; set; }

        public virtual Food Food { get; set; }
        public virtual ThatDay ThatDay { get; set; }
    }
}
