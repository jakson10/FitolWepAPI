using FitOl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Service.Tool.JWTTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
