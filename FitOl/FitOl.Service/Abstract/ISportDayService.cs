using FitOl.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface ISportDayService
    {

        IEnumerable<SportDayDto> GetAllSportDayAsync();
        Task<int> AddSportDayAsync(SportDayDto sportDayDto);

        Task<int> EditSportDayAsync(SportDayDto sportDayDto);

        Task<int> DeleteSportDayAsync(SportDayDto sportDayDto);

        Task<SportDayDto> SportDayById(int Id);

        IEnumerable<SportDayDto> GetSportDaysBySportListId(int sportListId);
    }
}
