using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitOl.Domain.Entities;
using FitOl.Service.Abstract;
using FitOl.WebAPI.Enums;
using FitOl.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitOl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ProfileEditing(ProfileEditing profileEditing)
        {
            var appUser = await _userManager.FindByNameAsync(profileEditing.UserName);
            appUser.Calorie = profileEditing.Calorie;
            appUser.Weight = profileEditing.Weight;
            appUser.Height = profileEditing.Height;
            appUser.FatRate = profileEditing.FatRate;
            appUser.Age = profileEditing.Age;
            var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded)
            {
                return Created("", appUser);
            }
            else
            {
                return BadRequest("Güncelleme işlemi başarısız");
            }
        }

        [HttpGet("[action]/{userName}")]
        public async Task<IActionResult> Profile(string userName)
        {
            if (userName == null)
            {
                userName = User.Identity.Name;
            }
            var appUser = await _userManager.FindByNameAsync(userName);
            ProfileInfoViewModel profileInfo = new ProfileInfoViewModel
            {
                Id = appUser.Id,
                Calorie = appUser.Calorie,
                Weight = appUser.Weight,
                Height = appUser.Height,
                FatRate = appUser.FatRate,
                Age = appUser.Age,
                Email = appUser.Email,
                ImagePath = appUser.ImagePath
            };

            return Ok(profileInfo);
        }

        [HttpGet("[action]/{userName}")]
        public async Task<IActionResult> UserNutritionListDetails(string userName,[FromServices] IFoodService _foodService)
        {
            if (userName == null)
            {
                userName = User.Identity.Name;
            }
            var appUser = await _userManager.FindByNameAsync(userName);
            var userNutritionList = _userService.UserNutritionLists(appUser.Id);
            var count = userNutritionList.LastOrDefault();
            var mealFoods = _foodService.NutritionListDetailsView(count.FKNutritionListId);
            return Ok(mealFoods);
        }

        [HttpGet("[action]/{userName}")]
        public async Task<IActionResult> UserSportListDetails(string userName,[FromServices] IAreaService _areaService)
        {
            if (userName == null)
            {
                userName = User.Identity.Name;
            }
            var appUser = await _userManager.FindByNameAsync(userName);
            var userSportLists = _userService.UserSportLists(appUser.Id);
            var count = userSportLists.LastOrDefault();
            var sporttLists = _areaService.SportListDetailsView(count.FKSportListId);
            return Ok(sporttLists);
        }

        [HttpGet("[action]")]
        public IActionResult GetUserNameList()
        {
            var users = _userService.GetAllUserAsync();
            var usersList = new SelectList(users, "Id", "UserName");
            return Ok(usersList);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddRoles(string userName, string rolName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.IsInRoleAsync(appUser, rolName);//Rol kontrolu yapıyor
            if (result == false)
            {
                await _userManager.AddToRoleAsync(appUser, rolName);
                return Created("", rolName);
            }
            else
            {
                return BadRequest("Aynı rol daha önce eklenmiş");
            }
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> ProfileSettingAdd([FromForm] ProfileInfo jsondata)
        {
            var appUser = await _userService.UserByName(User.Identity.Name);
            var uploadModel = await UploadFileAsync(jsondata.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                appUser.ImagePath = uploadModel.NewName;
                appUser.Calorie = jsondata.Calorie;
                appUser.Weight = jsondata.Weight;
                appUser.Height = jsondata.Height;
                appUser.FatRate = jsondata.FatRate;
                await _userManager.UpdateAsync(_mapper.Map<AppUser>(appUser));
                return Created("", appUser);
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                await _userManager.UpdateAsync(_mapper.Map<AppUser>(appUser));
                return Created("", appUser);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }
    }
}
