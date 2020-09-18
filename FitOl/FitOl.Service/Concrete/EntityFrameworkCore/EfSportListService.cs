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
    public class EfSportListService : ISportListService
    {
        private readonly ISportListRepository _sportListRepo;
        private readonly ISportDayRepository _sportDayRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<AreaMovements> _areaMovementsRepository;
        public EfSportListService(ISportListRepository sportListRepo,
            ISportDayRepository sportDayRepository,
            IAreaRepository areaRepository,
            IMapper mapper,
            IGenericRepository<AreaMovements> areaMovementsRepository)
        {
            _sportListRepo = sportListRepo;
            _sportDayRepository = sportDayRepository;
            _areaRepository = areaRepository;
            _mapper = mapper;
            _areaMovementsRepository = areaMovementsRepository;
        }

        public async Task<int> AddSportListAsync(SportListDto sportListDto)
        {
            var sportList = _mapper.Map<SportList>(sportListDto);
            var savedNutritionList = await _sportListRepo.AddEntityAndGetId(sportList);

            SportDay sDay = null;
            Area aDay = null;
            int success = 0;

            for (int i = 1; i <= 7; i++)
            {
                sDay = new SportDay();
                sDay.Name = i + ".Gün";
                sDay.FKSportListId = savedNutritionList.Id;
                sDay = await _sportDayRepository.AddEntityAndGetId(sDay);

                for (int j = 1; j <= 8; j++)
                {
                    aDay = new Area();
                    if (j == 1)
                    {
                        aDay.Name = "Göğüs";
                        aDay.EnumMovementType = EnumMovementType.Breast;
                    }
                    else if (j == 2)
                    {
                        aDay.Name = "Sırt";
                        aDay.EnumMovementType = EnumMovementType.Back;
                    }
                    else if (j == 3)
                    {
                        aDay.Name = "Omuz";
                        aDay.EnumMovementType = EnumMovementType.Shoulder;
                    }
                    else if (j == 4)
                    {
                        aDay.Name = "Ön Kol";
                        aDay.EnumMovementType = EnumMovementType.Biceps;
                    }
                    else if (j == 5)
                    {
                        aDay.Name = "Arka Kol";
                        aDay.EnumMovementType = EnumMovementType.Triceps;
                    }
                    else if (j == 6)
                    {
                        aDay.Name = "Bacak";
                        aDay.EnumMovementType = EnumMovementType.Leg;
                    }
                    else if (j == 7)
                    {
                        aDay.Name = "Kardiyo";
                        aDay.EnumMovementType = EnumMovementType.Cardio;
                    }
                    else
                    {
                        aDay.Name = "Karın";
                        aDay.EnumMovementType = EnumMovementType.Abdomen;
                    }

                    aDay.FKDayId = sDay.Id;
                    success = await _areaRepository.Add(aDay);
                }
            }
            if (success > 0)
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> DeleteSportListAsync(SportList sportList)
        {
            return await _sportListRepo.Delete(sportList);
        }

        public async Task<SportList> SportListById(int id)
        {
            return await _sportListRepo.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> EditSportListAsync(SportListDto sportListDto)
        {
            var sportList = _mapper.Map<SportList>(sportListDto);
            return await _sportListRepo.Edit(sportList);
        }

  

        public IEnumerable<SportListDto> GetAllSportListAsync()
        {
            return _mapper.Map<IEnumerable<SportListDto>>(_sportListRepo.GetAll().AsEnumerable());
        }

        public async Task<int> AddAreaMovements(string[] stringMovementIdList, int areaId)
        {
            AreaMovements newAreaMovement = null;
            int success = 0;

            foreach (var thatMovement in stringMovementIdList)
            {
                newAreaMovement = new AreaMovements();
                newAreaMovement.FKMovementId = Convert.ToInt32(thatMovement);
                newAreaMovement.FKAreaId = areaId;

                await _areaMovementsRepository.Add(newAreaMovement);
                success = await _areaMovementsRepository.Save();
            }

            if (success > 0)
            {
                return 1;
            }
            return 0;
        }


        //public async Task<int> DeleteSportListAsync(SportListDto sportListDto)
        //{
        //    var sportList = _mapper.Map<SportList>(sportListDto);
        //    return await _sportListRepo.Delete(sportList);
        //}

        //public async Task<SportListDto> SportListById(int id)
        //{
        //    return _mapper.Map<SportListDto>(await _sportListRepo.Find(x => x.Id == id).FirstOrDefaultAsync());
        //}
    }
}

