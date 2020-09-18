using FitOl.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Models
{
    public class SelectMovementAndAreaModel
    {
        public List<MovementDto> allMovements { get; set; }
        public int areaId { get; set; }
        public string[] selectedMovementIdArray { get; set; }
    }
}
