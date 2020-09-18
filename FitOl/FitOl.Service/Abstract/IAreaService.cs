using FitOl.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface IAreaService
    {
        IEnumerable<AreaDto> GetAllAreaAsync();
        Task<int> AddAreaAsync(AreaDto areaDto);

        Task<int> EditAreaAsync(AreaDto areaDto);

        Task<int> DeleteAreaAsync(AreaDto areaDto);

        Task<AreaDto> AreaById(int Id);

        IEnumerable<AreaDto> GetAreasBySportDayId(int sportDayId);

        ////////////////////// COKA COK TABLO KAYITLARI ///////////

        IEnumerable<AreaMovementsDto> GetAllAreaMovementsAsync();
        Task<int> AddAreaMovementsAsync(AreaMovementsDto areaMovementsDto);

        Task<int> EditAreaMovementsAsync(AreaMovementsDto areaMovementsDto);

        Task<int> DeleteAreaMovementsAsync(AreaMovementsDto areaMovementsDto);

        Task<AreaMovementsDto> AreaMovementsById(int id);

        IEnumerable<AreaMovementsDto> SportListDetailsView(int sportListId);
    }
}
