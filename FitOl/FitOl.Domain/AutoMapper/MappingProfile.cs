using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.Domain.Entities.MMRelation;
using FitOl.WebAPI.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Domain.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Food, FoodDto>();
            CreateMap<FoodDto, Food>().ReverseMap();

            CreateMap<MealFoodsDto, FoodListDto>();
            CreateMap<FoodListDto, MealFoodsDto>().ReverseMap();

            CreateMap<AreaMovementsDto, MovementListDto>();
            CreateMap<MovementListDto, AreaMovementsDto>().ReverseMap();

            CreateMap<Movement, MovementDto>();
            CreateMap<MovementDto, Movement>().ReverseMap();

            CreateMap<NutritionList, NutritionListDto>();
            CreateMap<NutritionListDto, NutritionList>().ReverseMap();

            CreateMap<SportList, SportListDto>();
            CreateMap<SportListDto, SportList>().ReverseMap();

            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>().ReverseMap();

            CreateMap<Area, AreaDto>();
            CreateMap<AreaDto, Area>().ReverseMap();

            CreateMap<AreaMovements, AreaMovementsDto>();
            CreateMap<AreaMovementsDto, AreaMovements>().ReverseMap();

            CreateMap<MealFoods, MealFoodsDto>();
            CreateMap<MealFoodsDto, MealFoods>().ReverseMap();

            CreateMap<NutritionDay, NutritionDayDto>();
            CreateMap<NutritionDayDto, NutritionDay>().ReverseMap();

            CreateMap<SportDay, SportDayDto>();
            CreateMap<SportDayDto, SportDay>().ReverseMap();

            CreateMap<ThatDay, ThatDayDto>();
            CreateMap<ThatDayDto, ThatDay>().ReverseMap();

            CreateMap<UserNutritionLists, UserNutritionListsDto>();
            CreateMap<UserNutritionListsDto, UserNutritionLists>().ReverseMap();

            CreateMap<UserSportLists, UserSportListsDto>();
            CreateMap<UserSportListsDto, UserSportLists>().ReverseMap();
        }
    }
}
