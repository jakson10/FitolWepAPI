using FitOl.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Enums
{
    public class AppUserDtoss
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
        public int Calorie { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public double FatRate { get; set; }

        public bool IsAdmin { get; set; }

        public string ImagePath { get; set; }

    }
}
