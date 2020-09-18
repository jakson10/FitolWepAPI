using FitOl.Domain.Entities;
using FitOl.Service.StringInfos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.Service.Tool.JWTTool
{
    public class JwtManager : IJwtService
    {
        private readonly UserManager<AppUser> _userManager;
        public JwtManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public JwtToken GenerateJwt(AppUser appUser)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtInfo.Issuer, audience: JwtInfo.Audience, claims: null,
                notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(JwtInfo.Expires), signingCredentials: signingCredentials);

            JwtToken jwtToken = new JwtToken();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            jwtToken.Token = handler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }


        private List<Claim> SetClaims(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            //claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            //claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
            //var appUserRole = SetRol(appUser).Result.ToList();
            //foreach (var role in appUserRole)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}
   
            return claims;

        }

        private async Task<IList<string>> SetRol(AppUser appUser)
        {
            return (await _userManager.GetRolesAsync(appUser));
        }
    }
}
