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
    public class EfUserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IGenericRepository<UserNutritionLists> _userNutritionListService;
        private readonly IGenericRepository<UserSportLists> _userSportListService;
        private readonly IMapper _mapper;

        public EfUserService(IUserRepository userRepo,
            IGenericRepository<UserNutritionLists> userNutritionListService,
            IGenericRepository<UserSportLists> userSportListService,
            IMapper mapper)
        {
            _userRepo = userRepo;
            _userNutritionListService = userNutritionListService;
            _userSportListService = userSportListService;
            _mapper = mapper;
        }


        public async Task<int> AddUserAsync(AppUserDto userDto)
        {
            var user = _mapper.Map<AppUser>(userDto);
            return await _userRepo.Add(user);
        }


        public async Task<int> DeleteUserAsync(AppUserDto userDto)
        {
            var user = _mapper.Map<AppUser>(userDto);
            return await _userRepo.Delete(user);
        }

        public async Task<int> EditUserAsync(AppUserDto userDto)
        {
            var user = _mapper.Map<AppUser>(userDto);
            return await _userRepo.Edit(user);
        }

        public async Task<AppUserDto> UserByName(string username)
        {
            return _mapper.Map<AppUserDto>(await _userRepo.Find(x => x.UserName.ToLower() == username.ToLower()).FirstOrDefaultAsync());
        }

        public async Task<string> GetUserByName(int id)
        {
            return await _userRepo.Find(x => x.Id == id).Select(x => x.UserName).FirstOrDefaultAsync();
        }


        public IEnumerable<AppUserDto> GetAllUserAsync()
        {
            return _mapper.Map<IEnumerable<AppUserDto>>(_userRepo.GetAll());
        }


        //EfUserNutritionListService

        public async Task<int> AddUserNutritionListsAsync(UserNutritionListsDto userNutritionListsDto)
        {
            var userNutritionLists = _mapper.Map<UserNutritionLists>(userNutritionListsDto);
            return await _userNutritionListService.Add(userNutritionLists);
        }

        public async Task<int> DeleteUserNutritionListsAsync(UserNutritionListsDto userNutritionListsDto)
        {
            var userNutritionLists = _mapper.Map<UserNutritionLists>(userNutritionListsDto);
            return await _userNutritionListService.Delete(userNutritionLists);
        }

        public async Task<int> EditUserNutritionListsAsync(UserNutritionListsDto userNutritionListsDto)
        {
            var userNutritionLists = _mapper.Map<UserNutritionLists>(userNutritionListsDto);
            return await _userNutritionListService.Edit(userNutritionLists);
        }

        public async Task<UserNutritionListsDto> UserNutritionListsById(int id)
        {
            return _mapper.Map<UserNutritionListsDto>(await _userNutritionListService.Find(p => p.Id == id).FirstOrDefaultAsync());
        }

        public IEnumerable<UserNutritionListsDto> GetAllUserNutritionListsAsync()
        {
            return _mapper.Map<IEnumerable<UserNutritionListsDto>>(_userNutritionListService.GetAll().AsEnumerable());
        }

        public async Task<bool> UserNutritionListIsThere(int userId, int nutritionListId)
        {
            //int sayisi = await _sportDatabaseContext.UserNutritionLists.Where(x => x.UserSecret == userId && x.FKNutritionListId == nutritionListId).CountAsync();
            int sayisi = await _userNutritionListService.Find(x => x.FKUserId == userId && x.FKNutritionListId == nutritionListId).CountAsync();
            if (sayisi > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<int> AddUserNutritionListsAsync(int userId, int nutritionListId)
        {
            UserNutritionLists userList = new UserNutritionLists();
            userList.FKUserId = userId;
            userList.FKNutritionListId = nutritionListId;
            int succes = 0;
            try
            {
                await _userNutritionListService.Add(userList);
                return 1;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return succes;
        }

        public IEnumerable<UserNutritionListsDto> UserNutritionLists(int userId)
        {
            return _mapper.Map<IEnumerable<UserNutritionListsDto>>(_userNutritionListService.Include(x => x.FKUserId == userId, x => x.NutritionList).AsEnumerable());
        }

        public async Task<UserNutritionListsDto> UserNutritionList(int userId)
        {
            return _mapper.Map<UserNutritionListsDto>(await _userNutritionListService.Include(x => x.FKUserId == userId, x => x.NutritionList).FirstOrDefaultAsync());
        }


        //EfUserSportListService

        public async Task<int> AddUserSportListsAsync(UserSportListsDto userSportListsDto)
        {
            var userSportLists = _mapper.Map<UserSportLists>(userSportListsDto);
            return await _userSportListService.Add(userSportLists);
        }


        public async Task<int> DeleteUserSportListsAsync(UserSportListsDto userSportListsDto)
        {
            var userSportLists = _mapper.Map<UserSportLists>(userSportListsDto);
            return await _userSportListService.Delete(userSportLists);
        }

        public async Task<int> EditUserSportListsAsync(UserSportListsDto userSportListsDto)
        {
            var userSportLists = _mapper.Map<UserSportLists>(userSportListsDto);
            return await _userSportListService.Edit(userSportLists);
        }

        public async Task<UserSportListsDto> UserSportListsById(int id)
        {
            return _mapper.Map<UserSportListsDto>(await _userSportListService.Find(x => x.Id == id).FirstOrDefaultAsync());
        }

        public IEnumerable<UserSportListsDto> GetAllUserSportListsAsync()
        {
            return _mapper.Map<IEnumerable<UserSportListsDto>>(_userSportListService.GetAll().AsEnumerable());
        }

        public async Task<bool> UserSportListIsThere(int userId, int sportListId)
        {
            int sayisi = await _userSportListService.Include(x => x.FKUserId == userId && x.FKSportListId == sportListId).CountAsync();
            if (sayisi > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<int> AddUserSportListsAsync(int userId, int sportListId)
        {
            UserSportLists userList = new UserSportLists();
            userList.FKUserId = userId;
            userList.FKSportListId = sportListId;
            int succes = 0;
            try
            {
                await _userSportListService.Add(userList);
                return 1;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return succes;
        }
        public IEnumerable<UserSportListsDto> UserSportLists(int userId)
        {
            return _mapper.Map<IEnumerable<UserSportListsDto>>(_userSportListService.Include(x => x.FKUserId == userId).AsEnumerable());
        }

        public async Task<UserSportListsDto> UserSportList(int userId)
        {
            return _mapper.Map<UserSportListsDto>( await _userSportListService.Include(x => x.FKUserId == userId, x => x.SportList).FirstOrDefaultAsync());
        }

    }
}
