using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.Domain.Entities.MMRelation;
using FitOl.Domain.Enum;
using FitOl.Repository.Abstract;
using FitOl.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Concrete.EntityFrameworkCore
{
    public class EfMovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<AreaMovements> _areaMovementsService;
        private readonly IAreaRepository _areaRepository;
        public EfMovementService(IMovementRepository movementRepo, IMapper mapper, IGenericRepository<AreaMovements> areaMovementsService, IAreaRepository areaRepository)
        {
            _movementRepo = movementRepo;
            _mapper = mapper;
            _areaMovementsService = areaMovementsService;
            _areaRepository = areaRepository;
        }

        public async Task<int> AddMovementAsync(MovementDto movementDto)
        {
            var movement = _mapper.Map<Movement>(movementDto);
            return await _movementRepo.Add(movement);
        }


        public async Task<int> DeleteMovementAsync(Movement movement)
        {
            return await _movementRepo.Delete(movement);
        }

        public async Task<int> EditMovementAsync(Movement movement)
        {
            return await _movementRepo.Edit(movement);
        }

        public async Task<Movement> MovementById(int Id)
        {
            var getMovement = await _movementRepo.Find(x => x.Id == Id).FirstOrDefaultAsync();
            return getMovement;
        }

        public IEnumerable<MovementDto> GetAllMovementAsync()
        {
            var movements = _movementRepo.GetAll().AsEnumerable();
            var movementsDto = _mapper.Map<IEnumerable<MovementDto>>(movements);
            return movementsDto;
        }

        public IEnumerable<MovementListDto> GetAllMovementNameAsync()
        {
            var movements = _movementRepo.GetAll().AsEnumerable();
            var movementsNmae = movements.Select(o => new MovementListDto
            {
                FKMovementId = o.Id,
                MovementName = o.MovementName
            }).ToList();
            return movementsNmae;
        }



        //////////// ÇOKA ÇOK TABLOLAR 
        public async Task<int> AddAreaMovementsAsync(AreaMovementsDto areaMovementsDto)
        {
            var control = await _areaMovementsService.Find(x => x.FKAreaId == areaMovementsDto.FKAreaId && x.FKMovementId == areaMovementsDto.FKMovementId).FirstOrDefaultAsync();
            if (control == null)
            {
                return await _areaMovementsService.Add(new AreaMovements
                {
                    FKAreaId = areaMovementsDto.FKAreaId,
                    FKMovementId = areaMovementsDto.FKMovementId
                });
            }
            return 0;
        }


        public async Task<int> DeleteAreaMovementsAsync(AreaMovementsDto areaMovementsDto)
        {
            var control = await _areaMovementsService.Find(x => x.FKAreaId == areaMovementsDto.FKAreaId && x.FKMovementId == areaMovementsDto.FKMovementId).FirstOrDefaultAsync();
            if (control != null)
            {
                return await _areaMovementsService.Delete(control);
            }
            return 0;
        }

        public async Task<int> EditAreaMovementsAsync(AreaMovementsDto areaMovementsDto)
        {
            var mealFoods = _mapper.Map<AreaMovements>(areaMovementsDto);
            return await _areaMovementsService.Edit(mealFoods);
        }

        public async Task<AreaMovementsDto> AreaMovementsById(int id)
        {
            var getAreaMovement = _mapper.Map<AreaMovementsDto>(await _areaMovementsService.Find(p => p.Id == id).FirstOrDefaultAsync());
            return getAreaMovement;
        }

        public IEnumerable<AreaMovementsDto> GetAllAreaMovementsAsync()
        {
            return _mapper.Map<IEnumerable<AreaMovementsDto>>(_areaMovementsService.GetAll().AsEnumerable());
        }

        public IEnumerable<MovementListDto> SportListDetailsMovements(int sportListId)
        {
            var areaMovements = _mapper.Map<IEnumerable<AreaMovementsDto>>(_areaMovementsService.Include(x => x.Area.SportDay.FKSportListId == sportListId, x => x.Movement, x => x.Area).AsEnumerable());

            var movements = areaMovements.Select(o => new MovementListDto
            {
                FKMovementId = o.FKMovementId,
                MovementName = o.Movement.MovementName,
                FKAreaId = o.FKAreaId
            }).ToList();

            return movements;

        }

        public IEnumerable<AreaMovementsDto> SportListDetailsView(int sportListId)
        {
            var areaMovements = _mapper.Map<IEnumerable<AreaMovementsDto>>(_areaMovementsService.Include(x => x.Area.SportDay.FKSportListId == sportListId, x => x.Movement, x => x.Area, x => x.Area.SportDay).AsEnumerable());
            return areaMovements;
        }

        public IEnumerable<MovementListDto> SportListAreaMovementsDetailsView(int sportListId, int areaId)
        {
            //var area = _areaRepository.Find(x => x.FKDayId == gunId && x.EnumMovementType == (AllEnums.EnumMovementType)ogunId).FirstOrDefault();

            var area = _areaRepository.Find(x => x.Id == areaId).FirstOrDefault();

            var areaMovements = _mapper.Map<IEnumerable<AreaMovementsDto>>(_areaMovementsService.Include(x => x.FKAreaId == area.Id, x => x.Movement, x => x.Area));

            var movements = areaMovements.Select(o => new MovementListDto
            {
                FKMovementId = o.FKMovementId,
                MovementName = o.Movement.MovementName,
                FKAreaId = o.FKAreaId
            }).ToList();

            return movements;
        }



        //public async Task<int> DeleteMovementAsync(MovementDto movementDto)
        //{
        //    var movement = _mapper.Map<Movement>(movementDto);
        //    return await _movementRepo.Delete(movement);
        //}

        //public async Task<int> EditMovementAsync(MovementDto movementDto)
        //{
        //    var movement = _mapper.Map<Movement>(movementDto);
        //    return await _movementRepo.Edit(movement);
        //}

        //public async Task<MovementDto> MovementById(int Id)
        //{
        //    var getMovement = await _movementRepo.Find(x => x.Id == Id).FirstOrDefaultAsync();
        //    var getMovementDto = _mapper.Map<MovementDto>(getMovement);
        //    return getMovementDto;
        //}
    }
}
