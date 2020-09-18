using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.Domain.Entities.MMRelation;
using FitOl.Domain.Enum;
using FitOl.Repository.Abstract;
using FitOl.Service.Abstract;
using FitOl.WebAPI.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Concrete.EntityFrameworkCore
{
    public class EfFoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<MealFoods> _mealFoodService;

        private readonly IThatDayRepository _thatDayRepository;
        public EfFoodService(IFoodRepository foodRepo, IMapper mapper, IGenericRepository<MealFoods> mealFoodService, IThatDayRepository thatDayRepository)
        {
            _foodRepo = foodRepo;
            _mapper = mapper;
            _mealFoodService = mealFoodService;
            _thatDayRepository = thatDayRepository;
        }

        public async Task<int> AddFoodAsync(FoodDto foodDto)
        {
            var foodEntity = _mapper.Map<Food>(foodDto);
            return await _foodRepo.Add(foodEntity);
        }



        public async Task<Food> FoodById(int Id)
        {
            var getFood = await _foodRepo.Find(x => x.Id == Id).FirstOrDefaultAsync();
            return getFood;
        }

        public async Task<int> DeleteFoodAsync(Food food)
        {
            return await _foodRepo.Delete(food);

        }
        public async Task<int> EditFoodAsync(Food food)
        {
            return await _foodRepo.Edit(food);

        }

        public IEnumerable<FoodDto> GetAllFoodAsync()
        {
            return _mapper.Map<IEnumerable<FoodDto>>(_foodRepo.GetAll().AsEnumerable());
        }

        public IEnumerable<FoodListDto> GetAllFoodNameAsync()
        {
            var foods = _foodRepo.GetAll().AsEnumerable();
            var foodsName = foods.Select(o => new FoodListDto
            {
                FKFoodId = o.Id,
                Name = o.Name
            }).ToList();
            return foodsName;
        }


        //////////// ÇOKA ÇOK TABLOLAR 
        public async Task<int> AddMealFoodsAsync(MealFoodsDto mealFoodsDto)
        {
            var control = await _mealFoodService.Find(x => x.FKFoodId == mealFoodsDto.FKFoodId && x.FKThatDayId == mealFoodsDto.FKThatDayId).FirstOrDefaultAsync();
            if (control == null)
            {
                return await _mealFoodService.Add(new MealFoods
                {
                    FKFoodId = mealFoodsDto.FKFoodId,
                    FKThatDayId = mealFoodsDto.FKThatDayId
                });
            }
            return 0;
        }


        public async Task<int> DeleteMealFoodsAsync(MealFoodsDto mealFoodsDto)
        {
            var control = await _mealFoodService.Find(x => x.FKFoodId == mealFoodsDto.FKFoodId && x.FKThatDayId == mealFoodsDto.FKThatDayId).FirstOrDefaultAsync();
            if (control != null)
            {
                return await _mealFoodService.Delete(control);
            }
            return 0;
        }

        public async Task<int> EditMealFoodsAsync(MealFoodsDto mealFoodsDto)
        {
            var mealFoods = _mapper.Map<MealFoods>(mealFoodsDto);
            return await _mealFoodService.Edit(mealFoods);
        }

        public async Task<MealFoodsDto> MealFoodsById(int id)
        {
            var getMealFoods = _mapper.Map<MealFoodsDto>(await _mealFoodService.Find(p => p.Id == id).FirstOrDefaultAsync());
            return getMealFoods;
        }

        public IEnumerable<MealFoodsDto> GetAllMealFoodsAsync()
        {
            return _mapper.Map<IEnumerable<MealFoodsDto>>(_mealFoodService.GetAll().AsEnumerable());
        }

        public IEnumerable<FoodListDto> NutritionListDetailsFood(int nutritionListId)
        {

            var mealFoods = _mapper.Map<IEnumerable<MealFoodsDto>>(_mealFoodService.Include(x => x.ThatDay.NutritionDays.FKNutritionListId == nutritionListId, x => x.Food, x => x.ThatDay).AsEnumerable());

            var food = mealFoods.Select(o => new FoodListDto
            {
                FKFoodId = o.FKFoodId,
                Name = o.Food.Name,
                FKThatDayId = o.FKThatDayId
            }).ToList();

            return food;

        }

        public IEnumerable<MealFoodsDto> NutritionListDetailsView(int nutritionListId)
        {

            var mealFoods = _mapper.Map<IEnumerable<MealFoodsDto>>(_mealFoodService.Include(x => x.ThatDay.NutritionDays.FKNutritionListId == nutritionListId, x => x.Food, x => x.ThatDay, x => x.ThatDay.NutritionDays).AsEnumerable());
            return mealFoods;
        }

        public IEnumerable<FoodListDto> NutritionListThatDayDetailsView(int nutritionListId, int thatDayId)
        {
            //var thatThay = _thatDayRepository.Find(x => x.FKNutritionDayId == gunId && x.EnumMealType == (AllEnums.EnumMealType)ogunId).FirstOrDefault();

            var thatDay = _thatDayRepository.Find(x => x.Id == thatDayId).FirstOrDefault();

            var mealFoods = _mapper.Map<IEnumerable<MealFoodsDto>>(_mealFoodService.Include(x => x.FKThatDayId == thatDay.Id, x => x.Food, x => x.ThatDay));

            var food = mealFoods.Select(o => new FoodListDto
            {
                FKFoodId = o.FKFoodId,
                Name = o.Food.Name,
                FKThatDayId = o.FKThatDayId
            }).ToList();
            return food;
        }



        //public async Task<int> DeleteFoodAsync(FoodDto foodDto)
        //{
        //    try
        //    {
        //        var foodEntity = _mapper.Map<Food>(foodDto);
        //        return await _foodRepo.Delete(foodEntity);
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }

        //}

        //public async Task<FoodDto> FoodById(int Id)
        //{
        //    var getFood = await _foodRepo.Find(x => x.Id == Id).FirstOrDefaultAsync();
        //    var foodDto = _mapper.Map<FoodDto>(getFood);
        //    return foodDto;
        //}

        //public async Task<int> EditFoodAsync(FoodDto foodDto)
        //{
        //    try
        //    {
        //        var foodEntity = _mapper.Map<Food>(foodDto);
        //        return await _foodRepo.Edit(foodEntity);
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }

        //}

    }
}
