using FitOl.Domain.Entities.MMRelation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public int Age { get; set; }
        public int Calorie { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public double FatRate { get; set; }

        public bool IsAdmin { get; set; }

        public string ImagePath { get; set; } = "default.jpg";
        public virtual ICollection<UserNutritionLists> NutritionLists { get; set; }
        public virtual ICollection<UserSportLists> UserSportLists { get; set; }
    }
}
