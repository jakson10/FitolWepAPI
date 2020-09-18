using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.Domain.Entities.MMRelation;
using FitOl.WebAPI.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Abstract
{
    public interface IFoodService
    {
        IEnumerable<FoodDto> GetAllFoodAsync();

        IEnumerable<FoodListDto> GetAllFoodNameAsync();
        Task<int> AddFoodAsync(FoodDto foodDto);

        //Task<int> DeleteFoodAsync(FoodDto foodDto);

        //Task<FoodDto> FoodById(int Id);

        //Task<int> EditFoodAsync(FoodDto foodDto);

        Task<int> DeleteFoodAsync(Food food);

        Task<Food> FoodById(int Id);

        Task<int> EditFoodAsync(Food food);



        // Çoka Çok Tablolar

        IEnumerable<MealFoodsDto> GetAllMealFoodsAsync();
        Task<int> AddMealFoodsAsync(MealFoodsDto mealFoods);

        Task<int> EditMealFoodsAsync(MealFoodsDto mealFoods);

        Task<int> DeleteMealFoodsAsync(MealFoodsDto mealFoods);

        Task<MealFoodsDto> MealFoodsById(int id);

        IEnumerable<MealFoodsDto> NutritionListDetailsView(int nutritionListId);

        //IEnumerable<FoodListDto> NutritionListThatDayDetailsView(int nutritionListId, int gunId, int ogunId);

        IEnumerable<FoodListDto> NutritionListThatDayDetailsView(int nutritionListId, int thatDayId);

        IEnumerable<FoodListDto> NutritionListDetailsFood(int nutritionListId);

    }
}
