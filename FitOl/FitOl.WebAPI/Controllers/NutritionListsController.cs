using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.Service.Abstract;
using FitOl.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionListsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IThatDayService _thatDayService;
        private readonly INutritionListService _nutritionListService;
        private readonly INutritionDayService _nutritionDayService;
        private readonly IFoodService _foodService;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public NutritionListsController(IThatDayService thatDayService,
            INutritionListService nutritionListService,
            INutritionDayService nutritionDayService,
            IFoodService foodService,
            IUserService userService,
            IMapper mapper,
            UserManager<AppUser> userManager)
        {
            _nutritionListService = nutritionListService;
            _nutritionDayService = nutritionDayService;
            _thatDayService = thatDayService;
            _foodService = foodService;
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nutritionListService.GetAllNutritionListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Create(NutritionListDto nutritionListDto)
        {
            await _nutritionListService.AddNutritionListAsync(nutritionListDto);
            return Created("", nutritionListDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _nutritionListService.DeleteNutritionListAsync(await _nutritionListService.NutritionListById(id));
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _nutritionListService.NutritionListById(id));
        }

        [HttpGet("[action]/{ogunGun}/{nutritionListId}")]
        public IActionResult AddFoodForThat([FromRoute] int ogunGun, [FromRoute] int nutritionListId)
        {
            int sayi = ogunGun;
            int hangiOgun = (ogunGun / 10);
            int hangiOgun1 = hangiOgun;
            hangiOgun--;
            sayi = sayi - (hangiOgun1 * 10);
            int hangiGun = sayi;
            hangiGun--;

            var tmpOgun = $"{hangiOgun}{hangiGun}";

            var getNDays = _nutritionDayService.GetNutritionDaysByNutritionListId(nutritionListId).ToList();
            NutritionDayDto selectedDay = getNDays[hangiGun];

            var getDayThats = _thatDayService.GetThatDaysByNutritionDayId(selectedDay.Id).ToList();

            ThatDayDto selectedThat = getDayThats[hangiOgun];

            return Ok(selectedThat.Id);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult Foods(int id)
        {
            SelectFoodsAndThatModel vm = new SelectFoodsAndThatModel();
            vm.allFoods = _foodService.GetAllFoodNameAsync().ToList();
            vm.thatId = id;
            return Ok(vm);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult NutritionListView(int id)
        {
            return Ok(_foodService.NutritionListDetailsView(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FoodsPost(SelectFoodsAndThatModel model)
        {
            await _nutritionListService.AddThatFoods(model.selectedFoodIdArray, model.thatId);
            return Created("", model);

        }


        [HttpPost("[action]/{userName}")]
        public async Task<IActionResult> QuestionsResult(string userName,QuestionModel jsonData)
        {
            if (userName == null)
            {
                userName = User.Identity.Name;
            }
            var user = await _userManager.FindByNameAsync(userName);
            double calori = user.Calorie;


            if (calori == 0)
            {
                return BadRequest("Lütfen kalori miktarı giriniz");
            }

            if (jsonData.Vejeteryan == Vejeteryan.Evet)
            {
                if (jsonData.BesinDegeri == BesinDegeri.DusukBesinDegeri)
                {
                    if (calori > 1700 && calori <= 1800)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 18);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);

                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1800 && calori <= 1900)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 21);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1900 && calori <= 2000)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 24); 29 liste
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2000 && calori <= 2100)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 9);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2100 && calori <= 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 12);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 15);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                }
                else if (jsonData.BesinDegeri == BesinDegeri.OrtaBesinDegeri)
                {
                    if (calori > 1700 && calori <= 1800)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 19);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1800 && calori <= 1900)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 22);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1900 && calori <= 2000)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 25);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2000 && calori <= 2100)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 10);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2100 && calori <= 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 13);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 16);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                }
                else if (jsonData.BesinDegeri == BesinDegeri.YuksekBesinDegeri)
                {
                    if (calori > 1700 && calori <= 1800)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 18);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1800 && calori <= 1900)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 23);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1900 && calori <= 2000)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 26);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2000 && calori <= 2100)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 11);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2100 && calori <= 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 14);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 17);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                }
            }
            else if (jsonData.Vejeteryan == Vejeteryan.Hayır)
            {
                if (jsonData.BesinDegeri == BesinDegeri.DusukBesinDegeri)
                {
                    if (calori > 1700 && calori <= 1800)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 18);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1800 && calori <= 1900)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 21);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1900 && calori <= 2000)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 24);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2000 && calori <= 2100)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 9);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2100 && calori <= 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 12);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 51);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 15);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                }
                else if (jsonData.BesinDegeri == BesinDegeri.OrtaBesinDegeri)
                {
                    if (calori > 1700 && calori <= 1800)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 19);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1800 && calori <= 1900)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 22);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1900 && calori <= 2000)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 25);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2000 && calori <= 2100)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 10);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2100 && calori <= 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 13);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 52);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 16);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                }
                else if (jsonData.BesinDegeri == BesinDegeri.YuksekBesinDegeri)
                {
                    if (calori > 1700 && calori <= 1800)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 18);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1800 && calori <= 1900)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 23);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 1900 && calori <= 2000)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 26);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2000 && calori <= 2100)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 11);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2100 && calori <= 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 14);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                    else if (calori > 2200)
                    {
                        int success = await _userService.AddUserNutritionListsAsync(user.Id, 53);
                        //bool thereIs = await _userNutritionListService.UserNutritionListIsThere(user.Id, 17);
                        //if (thereIs == true)
                        //{
                        //    return Json(new { status = 4, message = "Beslenme Listeniz zaten güncel !", redirect = "/NutritionList/Questions" });
                        //}

                        if (success > 0)
                        {
                            return Created("", jsonData);
                        }
                        return BadRequest("Bir hata oluştu tekrar deneyiniz");
                    }
                }
            }

            return BadRequest("Bir hata oluştu tekrar deneyiniz");
        }
    }
}
