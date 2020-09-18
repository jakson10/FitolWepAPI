using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Models
{
    public class ProfileInfo
    {
        public int Calorie { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public double FatRate { get; set; }
        public double Age { get; set; }
        public string Email { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }
    }
}
