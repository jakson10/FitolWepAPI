using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.WebAPI.Models
{
    public class MovementAddModel
    {
        public string MovementName { get; set; }
        public string ImagePath { get; set; }
        public string MovementDescription { get; set; }
        public EnumMovementType EnumMovementType { get; set; }

        public IFormFile Image { get; set; }
    }
}
