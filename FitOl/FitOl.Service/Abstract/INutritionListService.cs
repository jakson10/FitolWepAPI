using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface INutritionListService
    {
        IEnumerable<NutritionListDto> GetAllNutritionListAsync();
        Task<int> AddNutritionListAsync(NutritionListDto nutritionListDto);

        Task<int> EditNutritionListAsync(NutritionListDto nutritionListDto);

        //Task<int> DeleteNutritionListAsync(NutritionListDto nutritionListDto);

        //Task<NutritionListDto> NutritionListById(int Id);

        Task<int> DeleteNutritionListAsync(NutritionList nutritionListDto);

        Task<NutritionList> NutritionListById(int Id);
        Task<int> AddThatFoods(string[] stringFoodIdList, int thatId);
    }
}
