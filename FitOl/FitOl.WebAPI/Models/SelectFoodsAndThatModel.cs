using FitOl.Domain.Dtos;
using FitOl.WebAPI.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Models
{
    public class SelectFoodsAndThatModel
    {
        public List<FoodListDto> allFoods { get; set; }
        public int thatId { get; set; }
        public string[] selectedFoodIdArray { get; set; }
    }
}
