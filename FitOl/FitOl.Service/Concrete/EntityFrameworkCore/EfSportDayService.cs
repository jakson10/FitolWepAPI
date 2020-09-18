using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
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
    public class EfSportDayService : ISportDayService
    {
        private readonly ISportDayRepository _sportDayRepo;
        private readonly IMapper _mapper;
        public EfSportDayService(ISportDayRepository sportDayRepo, IMapper mapper)
        {
            _sportDayRepo = sportDayRepo;
            _mapper = mapper;
        }

        public async Task<int> AddSportDayAsync(SportDayDto sportDayDto)
        {
            var sportDay = _mapper.Map<SportDay>(sportDayDto);
            return await _sportDayRepo.Add(sportDay);
        }


        public async Task<int> DeleteSportDayAsync(SportDayDto sportDayDto)
        {
            var sportDay = _mapper.Map<SportDay>(sportDayDto);
            return await _sportDayRepo.Delete(sportDay);
        }

        public async Task<int> EditSportDayAsync(SportDayDto sportDayDto)
        {
            var sportDay = _mapper.Map<SportDay>(sportDayDto);
            return await _sportDayRepo.Edit(sportDay);
        }

        public async Task<SportDayDto> SportDayById(int id)
        {
            var getSportDay = _mapper.Map<SportDayDto>(await _sportDayRepo.Find(x => x.Id == id).FirstOrDefaultAsync());
            return getSportDay;
        }

        public IEnumerable<SportDayDto> GetAllSportDayAsync()
        {
            return _mapper.Map<IEnumerable<SportDayDto>>(_sportDayRepo.GetAll().AsEnumerable());
        }

        public IEnumerable<SportDayDto> GetSportDaysBySportListId(int sportListId)
        {
            return _mapper.Map<IEnumerable<SportDayDto>>(_sportDayRepo.Include(x => x.FKSportListId == sportListId).AsEnumerable());
        }
    }
}
