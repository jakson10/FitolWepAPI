using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.Domain.Entities.MMRelation;
using FitOl.Repository.Abstract;
using FitOl.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FitOl.Domain.Enum.AllEnums;

namespace FitOl.Service.Concrete.EntityFrameworkCore
{
    public class EfNutritionListService : INutritionListService
    {
        private readonly INutritionListRepository _nutritionListRepo;
        private readonly INutritionDayRepository _nutritionDayRepo;
        private readonly IThatDayRepository _thatDayRepository;
        private readonly IGenericRepository<MealFoods> _mealFoodRepository;
        private readonly IMapper _mapper;

        public EfNutritionListService(
            INutritionListRepository nutritionListRepo,
            INutritionDayRepository nutritionDayRepo,
            IThatDayRepository thatDayRepository,
            IGenericRepository<MealFoods> mealFoodRepository,
            IMapper mapper)
        {
            _nutritionListRepo = nutritionListRepo;
            _nutritionDayRepo = nutritionDayRepo;
            _thatDayRepository = thatDayRepository;
            _mealFoodRepository = mealFoodRepository;
            _mapper = mapper;
        }

        public async Task<int> AddNutritionListAsync(NutritionListDto nutritionListDto)
        {
            var nutritionList = _mapper.Map<NutritionList>(nutritionListDto);
            var savedNutritionList = await _nutritionListRepo.AddEntityAndGetId(nutritionList);

            NutritionDay nDay = null;
            ThatDay tDay = null;
            int success = 0;

            for (int i = 1; i <= 7; i++)
            {
                nDay = new NutritionDay();
                nDay.Name = i + ".Gün";
                nDay.FKNutritionListId = savedNutritionList.Id;
                nDay = await _nutritionDayRepo.AddEntityAndGetId(nDay);
                for (int j = 1; j <= 5; j++)
                {
                    tDay = new ThatDay();
                    tDay.Name = "That " + j;
                    tDay.FKNutritionDayId = nDay.Id;
                    if (j == 1)
                    {
                        tDay.EnumMealType = EnumMealType.Morning;
                    }
                    else if (j == 2)
                    {
                        tDay.EnumMealType = EnumMealType.Snacks1;
                    }
                    else if (j == 3)
                    {
                        tDay.EnumMealType = EnumMealType.Noon;
                    }
                    else if (j == 4)
                    {
                        tDay.EnumMealType = EnumMealType.Snacks2;
                    }
                    else if (j == 5)
                    {
                        tDay.EnumMealType = EnumMealType.Evening;
                    }
                    success = await _thatDayRepository.Add(tDay);
                }
            }
            if (success > 0)
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> DeleteNutritionListAsync(NutritionList nutritionList)
        {
            return await _nutritionListRepo.Delete(nutritionList);
        }
        public async Task<NutritionList> NutritionListById(int id)
        {
            return await _nutritionListRepo.Find(x => x.Id == id).FirstOrDefaultAsync();

        }


        public async Task<int> EditNutritionListAsync(NutritionListDto nutritionListDto)
        {
            var nutritionList = _mapper.Map<NutritionList>(nutritionListDto);
            return await _nutritionListRepo.Edit(nutritionList);
        }

        public IEnumerable<NutritionListDto> GetAllNutritionListAsync()
        {
            return _mapper.Map<IEnumerable<NutritionListDto>>(_nutritionListRepo.GetAll().AsEnumerable());
        }

        public async Task<int> AddThatFoods(string[] stringFoodIdList, int thatId)
        {
            MealFoods newMealFood = null;
            int success = 0;

            foreach (var thatFood in stringFoodIdList)
            {
                newMealFood = new MealFoods();
                newMealFood.FKFoodId = Convert.ToInt32(thatFood);
                newMealFood.FKThatDayId = thatId;

                await _mealFoodRepository.Add(newMealFood);
                success = await _mealFoodRepository.Save();
            }

            if (success > 0)
            {
                return 1;
            }
            return 0;

        }


        //public async Task<int> DeleteNutritionListAsync(NutritionListDto nutritionListDto)
        //{
        //    var nutritionList = _mapper.Map<NutritionList>(nutritionListDto);
        //    return await _nutritionListRepo.Delete(nutritionList);
        //}
        //public async Task<NutritionListDto> NutritionListById(int id)
        //{
        //    return _mapper.Map<NutritionListDto>(await _nutritionListRepo.Find(x => x.Id == id).FirstOrDefaultAsync());

        //}

    }
}
