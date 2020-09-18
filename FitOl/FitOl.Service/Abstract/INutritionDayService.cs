using FitOl.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface INutritionDayService
    {
        IEnumerable<NutritionDayDto> GetAllNutritionDayAsync();
        Task<int> AddNutritionDayAsync(NutritionDayDto nutritionDayDto);

        Task<int> EditNutritionDayAsync(NutritionDayDto nutritionDayDto);

        Task<int> DeleteNutritionDayAsync(NutritionDayDto nutritionDayDto);

        Task<NutritionDayDto> NutritionDayById(int Id);

        IEnumerable<NutritionDayDto> GetNutritionDaysByNutritionListId(int nutritionListId);


    }
}
