using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Models
{
    public class ProfileEditing
    {
        public string UserName { get; set; }
        public int Calorie { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public double FatRate { get; set; }
        public int Age { get; set; }
    }
}
