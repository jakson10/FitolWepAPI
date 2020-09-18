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

namespace FitOl.Service.Concrete.EntityFrameworkCore
{
    public class EfAreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepo;
        private IGenericRepository<AreaMovements> _areaMovementsService;
        private readonly IMapper _mapper;
        public EfAreaService(IAreaRepository areaRepo, IGenericRepository<AreaMovements> areaMovementsService, IMapper mapper)
        {
            _areaRepo = areaRepo;
            _areaMovementsService = areaMovementsService;
            _mapper = mapper;
        }

        public async Task<int> AddAreaAsync(AreaDto areaDto)
        {
            var area = _mapper.Map<Area>(areaDto);
            return await _areaRepo.Add(area);
        }


        public async Task<int> DeleteAreaAsync(AreaDto areaDto)
        {
            var area = _mapper.Map<Area>(areaDto);
            return await _areaRepo.Delete(area);
        }

        public async Task<int> EditAreaAsync(AreaDto areaDto)
        {
            var area = _mapper.Map<Area>(areaDto);
            return await _areaRepo.Edit(area);
        }

        public async Task<AreaDto> AreaById(int id)
        {
            var getArea =_mapper.Map<AreaDto>(await _areaRepo.Find(x => x.Id == id).FirstOrDefaultAsync());
            return getArea;
        }

        public IEnumerable<AreaDto> GetAllAreaAsync()
        {
            var areas =_mapper.Map<IEnumerable<AreaDto>>(_areaRepo.GetAll().AsEnumerable());
            return areas;
        }

        public IEnumerable<AreaDto> GetAreasBySportDayId(int sportDayId)
        {
            return _mapper.Map<IEnumerable<AreaDto>>(_areaRepo.Include(x => x.FKDayId == sportDayId).AsEnumerable());
        }

        /////////////////////////// Coka Cok Tablo Kayıtları //////////////////
        ///
        public async Task<int> AddAreaMovementsAsync(AreaMovementsDto areaMovementsDto)
        {
            var areaMovements = _mapper.Map<AreaMovements>(areaMovementsDto);
            return await _areaMovementsService.Add(areaMovements);
        }


        public async Task<int> DeleteAreaMovementsAsync(AreaMovementsDto areaMovementsDto)
        {
            var areaMovements = _mapper.Map<AreaMovements>(areaMovementsDto);
            return await _areaMovementsService.Delete(areaMovements);
        }

        public async Task<int> EditAreaMovementsAsync(AreaMovementsDto areaMovementsDto)
        {
            var areaMovements = _mapper.Map<AreaMovements>(areaMovementsDto);
            return await _areaMovementsService.Edit(areaMovements);
        }

        public async Task<AreaMovementsDto> AreaMovementsById(int id)
        {
            var getAreaMovements = _mapper.Map<AreaMovementsDto>(await _areaMovementsService.Find(p => p.Id == id).FirstOrDefaultAsync());
            return getAreaMovements;
        }

        public IEnumerable<AreaMovementsDto> GetAllAreaMovementsAsync()
        {
            return _mapper.Map<IEnumerable<AreaMovementsDto>>(_areaMovementsService.GetAll().AsEnumerable());
        }

        public IEnumerable<AreaMovementsDto> SportListDetailsView(int sportListId)
        {
            //List<AreaMovements> areaMovements = _context.AreaMovements.Include(x => x.Area).Include(x => x.Movement).Include(x => x.Area.SportDay).Where(x => x.Area.SportDay.SportList.Id == sportListId).ToList();
            var areaMovements = _mapper.Map<IEnumerable<AreaMovementsDto>>(_areaMovementsService.Include(x => x.Area.SportDay.SportList.Id == sportListId, x => x.Area, x => x.Movement, x => x.Area.SportDay).AsEnumerable());
            return areaMovements;
        }
    }
}
