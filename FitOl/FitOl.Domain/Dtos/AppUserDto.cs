using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Dtos
{
    public class AppUserDto
    {
        public int Age { get; set; }
        public int Calorie { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public double FatRate { get; set; }

        public bool IsAdmin { get; set; }

        public string ImagePath { get; set; }  
        //public virtual ICollection<UserNutritionListsDto> NutritionLists { get; set; }
        //public virtual ICollection<UserSportListsDto> UserSportLists { get; set; }
    }
}
