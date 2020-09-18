using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.WebAPI.Enums;
using FitOl.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.CustomCollectionExtensions
{
    public class ProfileUI : Profile
    {
        public ProfileUI()
        {
            CreateMap<FoodDto, FoodAddModel>();
            CreateMap<FoodAddModel, FoodDto>().ReverseMap();

            CreateMap<AppUser, AppUserDtoss>();
            CreateMap<AppUserDtoss, AppUser>().ReverseMap();

            CreateMap<MovementDto, MovementAddModel>();
            CreateMap<MovementAddModel, MovementDto>().ReverseMap();

            CreateMap<FoodDto, FoodUpdateModel>();
            CreateMap<FoodUpdateModel, FoodDto>().ReverseMap();

            CreateMap<MovementDto, MovementUpdateModel>();
            CreateMap<MovementUpdateModel, MovementDto>().ReverseMap();

        }
    }
}
