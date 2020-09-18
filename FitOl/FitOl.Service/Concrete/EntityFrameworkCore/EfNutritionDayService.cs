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
    public class EfNutritionDayService : INutritionDayService
    {
        private readonly INutritionDayRepository _nutritionDayRepo;
        private readonly IMapper _mapper;
        public EfNutritionDayService(INutritionDayRepository nutritionDayRepo, IMapper mapper)
        {
            _nutritionDayRepo = nutritionDayRepo;
            _mapper = mapper;
        }

        public async Task<int> AddNutritionDayAsync(NutritionDayDto nutritionDayDto)
        {
            var nutritionDay = _mapper.Map<NutritionDay>(nutritionDayDto);
            return await _nutritionDayRepo.Add(nutritionDay);
        }


        public async Task<int> DeleteNutritionDayAsync(NutritionDayDto nutritionDayDto)
        {
            var nutritionDay = _mapper.Map<NutritionDay>(nutritionDayDto);
            return await _nutritionDayRepo.Delete(nutritionDay);
        }

        public async Task<int> EditNutritionDayAsync(NutritionDayDto nutritionDayDto)
        {
            var nutritionDay = _mapper.Map<NutritionDay>(nutritionDayDto);
            return await _nutritionDayRepo.Edit(nutritionDay);
        }

        public async Task<NutritionDayDto> NutritionDayById(int Id)
        {
            var getNutritionDay =_mapper.Map<NutritionDayDto>(await _nutritionDayRepo.Find(x => x.Id == Id).FirstOrDefaultAsync());
            return getNutritionDay;
        }

        public IEnumerable<NutritionDayDto> GetAllNutritionDayAsync()
        {
            return _mapper.Map<IEnumerable<NutritionDayDto>>(_nutritionDayRepo.GetAll().AsEnumerable());
        }

        public IEnumerable<NutritionDayDto> GetNutritionDaysByNutritionListId(int nutritionListId)
        {

            var daysForNutritionList =_mapper.Map<IEnumerable<NutritionDayDto>>(_nutritionDayRepo.Include(x => x.FKNutritionListId == nutritionListId).AsEnumerable());
            return daysForNutritionList;
        }
    }
}
