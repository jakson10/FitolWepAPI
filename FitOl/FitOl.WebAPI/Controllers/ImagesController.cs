using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitOl.Domain.Entities;
using FitOl.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IMovementService _movementService;
        private readonly UserManager<AppUser> _userManager;

        public ImagesController(IFoodService foodService,
            IMovementService movementService,
            UserManager<AppUser> userManager
            )
        {
            _foodService = foodService;
            _movementService = movementService;
            _userManager = userManager;
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetFoodImageById(int id)
        {
            var food = await _foodService.FoodById(id);
            if (string.IsNullOrWhiteSpace(food.ImagePath))
                return NotFound("Resim yok");
            return File($"/img/{food.ImagePath}", "image/jpeg");
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetMovementImageById(int id)
        {
            var movement = await _movementService.MovementById(id);
            if (string.IsNullOrWhiteSpace(movement.ImagePath))
                return NotFound("resim yok");
            return File($"/img/{movement.ImagePath}", "image/jpeg");
        }

        [HttpGet("[action]/{id}/{userName}")]
        public async Task<IActionResult> GetUserImageById(int id,string userName)
        {
            if (userName == null)
            {
               userName = User.Identity.Name;
            }
            var user = await _userManager.FindByNameAsync(userName);
            if (string.IsNullOrWhiteSpace(user.ImagePath))
                return NotFound("resim yok");
            return File($"/img/{user.ImagePath}", "image/jpeg");
        }
    }
}
