using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Service.Abstract;
using FitOl.WebAPI.Enums;
using FitOl.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : BaseController
    {
        private readonly IFoodService _foodService;
        private readonly IMapper _mapper;
        public FoodsController(IFoodService foodService, IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_foodService.GetAllFoodAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _foodService.FoodById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] FoodAddModel foodAddModel)
        {
            var uploadModel = await UploadFileAsync(foodAddModel.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                foodAddModel.ImagePath = uploadModel.NewName;
                await _foodService.AddFoodAsync(_mapper.Map<FoodDto>(foodAddModel));
                return Created("", foodAddModel);
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                foodAddModel.ImagePath = "gida.jpg";
                await _foodService.AddFoodAsync(_mapper.Map<FoodDto>(foodAddModel));
                return Created("", foodAddModel);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] FoodUpdateModel foodUpdateModel)
        {
            if (id != foodUpdateModel.Id)
                return BadRequest("geçersiz id");

            var uploadModel = await UploadFileAsync(foodUpdateModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                var updatedFood = await _foodService.FoodById(foodUpdateModel.Id);
                updatedFood.Name = foodUpdateModel.Name;
                updatedFood.CaloriValue = foodUpdateModel.CaloriValue;
                updatedFood.ProteinValue = foodUpdateModel.ProteinValue;
                updatedFood.CarbohydrateValue = foodUpdateModel.CarbohydrateValue;
                updatedFood.OilValue = foodUpdateModel.OilValue;
                updatedFood.FiberValue = foodUpdateModel.FiberValue;
                updatedFood.EnumFoodType = foodUpdateModel.EnumFoodType;
                updatedFood.ImagePath = uploadModel.NewName;


                await _foodService.EditFoodAsync(updatedFood);
                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                var updatedFood = await _foodService.FoodById(foodUpdateModel.Id);
                updatedFood.Name = foodUpdateModel.Name;
                updatedFood.CaloriValue = foodUpdateModel.CaloriValue;
                updatedFood.ProteinValue = foodUpdateModel.ProteinValue;
                updatedFood.CarbohydrateValue = foodUpdateModel.CarbohydrateValue;
                updatedFood.OilValue = foodUpdateModel.OilValue;
                updatedFood.FiberValue = foodUpdateModel.FiberValue;
                updatedFood.EnumFoodType = foodUpdateModel.EnumFoodType;

                await _foodService.EditFoodAsync(updatedFood);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _foodService.DeleteFoodAsync(await _foodService.FoodById(id));
            return NoContent();
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _foodService.FoodById(id));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddToMealFood(MealFoodsDto mealFoodDto)
        {
            await _foodService.AddMealFoodsAsync(mealFoodDto);
            return Created("", mealFoodDto);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteToMealFood([FromQuery] MealFoodsDto mealFoodDto)
        {
            await _foodService.DeleteMealFoodsAsync(mealFoodDto);
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult NutritionListDetails(int id)
        {
            return Ok(_foodService.NutritionListDetailsView(id));
        }

        [HttpGet("[action]/{nutritionListId}/{thatDayId}")]
        public IActionResult NutritionListThatDayDetails([FromRoute] int nutritionListId, [FromRoute] int thatDayId)
        {
            return Ok(_foodService.NutritionListThatDayDetailsView(nutritionListId, thatDayId));
        }


        [HttpGet("[action]/{id}")]
        public IActionResult NutritionListFoodDetails(int id)
        {
            return Ok(_foodService.NutritionListDetailsFood(id));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllFoodName()
        {
            return Ok(_foodService.GetAllFoodNameAsync());
        }

    }
}

