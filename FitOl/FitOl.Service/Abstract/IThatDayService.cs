using FitOl.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface IThatDayService
    {
        IEnumerable<ThatDayDto> GetAllThatDayAsync();
        Task<int> AddThatDayAsync(ThatDayDto thatDayDto);

        Task<int> EditThatDayAsync(ThatDayDto thatDayDto);

        Task<int> DeleteThatDayAsync(ThatDayDto thatDayDto);

        Task<ThatDayDto> ThatDayById(int id);

        IEnumerable<ThatDayDto> GetThatDaysByNutritionDayId(int nutritionDayId);

    }
}
