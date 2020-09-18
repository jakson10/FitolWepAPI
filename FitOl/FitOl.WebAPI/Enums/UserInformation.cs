using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.Service.Tool.JWTTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Enums
{
    public class UserInformation
    {
        public string Token { get; set; }

        public AppUserDtoss appUser { get; set; }

    }
}
