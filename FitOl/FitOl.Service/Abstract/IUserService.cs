using FitOl.Domain.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface IUserService
    {
        IEnumerable<AppUserDto> GetAllUserAsync();
        Task<int> AddUserAsync(AppUserDto userDto);

        Task<int> EditUserAsync(AppUserDto userDto);

        Task<int> DeleteUserAsync(AppUserDto userDto);

        Task<AppUserDto> UserByName(string username);
        Task<string> GetUserByName(int id);





        // IUserNutritionListsService
        IEnumerable<UserNutritionListsDto> GetAllUserNutritionListsAsync();
        Task<int> AddUserNutritionListsAsync(UserNutritionListsDto userNutritionListsDto);

        Task<int> EditUserNutritionListsAsync(UserNutritionListsDto userNutritionListsDto);

        Task<int> DeleteUserNutritionListsAsync(UserNutritionListsDto userNutritionListsDto);

        Task<UserNutritionListsDto> UserNutritionListsById(int id);

        IEnumerable<UserNutritionListsDto> UserNutritionLists(int userId);

        Task<UserNutritionListsDto> UserNutritionList(int userId);

        Task<int> AddUserNutritionListsAsync(int userId, int nutritionListId);
        Task<bool> UserNutritionListIsThere(int userId, int nutritionListId);


        //IUserSportListsService

        IEnumerable<UserSportListsDto> GetAllUserSportListsAsync();
        Task<int> AddUserSportListsAsync(UserSportListsDto userSportListsDto);
        Task<int> EditUserSportListsAsync(UserSportListsDto userSportListsDto);
        Task<int> DeleteUserSportListsAsync(UserSportListsDto userSportListsDto);
        Task<UserSportListsDto> UserSportListsById(int id);
        Task<UserSportListsDto> UserSportList(int userId);
        IEnumerable<UserSportListsDto> UserSportLists(int userId);
        Task<int> AddUserSportListsAsync(int userId, int sportListId);
        Task<bool> UserSportListIsThere(int userId, int sportListId);


    }
}
