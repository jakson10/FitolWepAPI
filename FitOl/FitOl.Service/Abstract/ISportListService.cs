using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface ISportListService
    {
        IEnumerable<SportListDto> GetAllSportListAsync();
        Task<int> AddSportListAsync(SportListDto sportListDto);

        Task<int> EditSportListAsync(SportListDto sportListDto);

        //Task<int> DeleteSportListAsync(SportListDto sportListDto);

        //Task<SportListDto> SportListById(int Id);

        Task<int> DeleteSportListAsync(SportList sportList);

        Task<SportList> SportListById(int Id);

        Task<int> AddAreaMovements(string[] stringMovementIdList, int areaId);


    }
}
