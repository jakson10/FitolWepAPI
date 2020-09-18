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
    public class EfThatDayService : IThatDayService
    {
        private readonly IThatDayRepository _thatDayRepo;
        private readonly IMapper _mapper;
        public EfThatDayService(IThatDayRepository thatDayRepo, IMapper mapper)
        {
            _thatDayRepo = thatDayRepo;
            _mapper = mapper;
        }

        public async Task<int> AddThatDayAsync(ThatDayDto thatDayDto)
        {
            var thatDay = _mapper.Map<ThatDay>(thatDayDto);
            return await _thatDayRepo.Add(thatDay);
        }


        public async Task<int> DeleteThatDayAsync(ThatDayDto thatDayDto)
        {
            var thatDay = _mapper.Map<ThatDay>(thatDayDto);
            return await _thatDayRepo.Delete(thatDay);
        }

        public async Task<int> EditThatDayAsync(ThatDayDto thatDayDto)
        {
            var thatDay = _mapper.Map<ThatDay>(thatDayDto);
            return await _thatDayRepo.Edit(thatDay);
        }

        public async Task<ThatDayDto> ThatDayById(int id)
        {
           return _mapper.Map<ThatDayDto>(await _thatDayRepo.Find(x => x.Id == id).FirstOrDefaultAsync());
        }

        public IEnumerable<ThatDayDto> GetAllThatDayAsync()
        {
            return _mapper.Map<IEnumerable<ThatDayDto>>(_thatDayRepo.GetAll().AsEnumerable());
        }

        public IEnumerable<ThatDayDto> GetThatDaysByNutritionDayId(int nutritionDayId)
        {
            return _mapper.Map<IEnumerable<ThatDayDto>>(_thatDayRepo.Include(x => x.FKNutritionDayId == nutritionDayId).AsEnumerable());
        }
    }
}
