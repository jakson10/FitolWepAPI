using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface IMovementService
    {
        IEnumerable<MovementDto> GetAllMovementAsync();
        Task<int> AddMovementAsync(MovementDto movementDto);

        //Task<int> EditMovementAsync(MovementDto movementDto);

        //Task<int> DeleteMovementAsync(MovementDto movementDto);

        //Task<MovementDto> MovementById(int Id);


        Task<int> EditMovementAsync(Movement movementDto);

        Task<int> DeleteMovementAsync(Movement movementDto);

        Task<Movement> MovementById(int Id);

        IEnumerable<MovementListDto> GetAllMovementNameAsync();

        ////////////ÇOKA ÇOK TABLOLAR

        Task<int> AddAreaMovementsAsync(AreaMovementsDto areaMovementsDto);
        Task<int> DeleteAreaMovementsAsync(AreaMovementsDto areaMovementsDto);

        Task<int> EditAreaMovementsAsync(AreaMovementsDto areaMovementsDto);
        Task<AreaMovementsDto> AreaMovementsById(int id);
        IEnumerable<AreaMovementsDto> GetAllAreaMovementsAsync();
        IEnumerable<MovementListDto> SportListDetailsMovements(int sportListId);
        IEnumerable<AreaMovementsDto> SportListDetailsView(int sportListId);

        IEnumerable<MovementListDto> SportListAreaMovementsDetailsView(int sportListId, int areaId);
        //IEnumerable<MovementListDto> SportListAreaMovementsDetailsView(int sportListId, int gunId, int ogunId);

    }
}
