using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FitOl.Domain.Entities;
using FitOl.Service.Tool.JWTTool;
using FitOl.WebAPI.Enums;
using FitOl.WebAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public AuthController(IJwtService jwtService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        [HttpGet("[action]/{userName}")]
        public async Task<IActionResult> ActiveUser(string userName) //active userın bılgılerını döner
        {
            var user = await _userManager.FindByNameAsync(userName);   
            return Ok(new AppUserViewModel { Id = user.Id, Name = user.UserName, Mail = user.Email });
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Gerekli alanları doldurunuz");
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Böyle bir kullanıcı yok");
                return BadRequest("Böyle bir kullanıcı yok");
            }
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                var token = _jwtService.GenerateJwt(user);
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                foreach (var role in _userManager.GetRolesAsync(user).Result)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                var activeUser = _mapper.Map<AppUserDtoss>(user);
                UserInformation userInformation = new UserInformation();
                userInformation.appUser = _mapper.Map<AppUserDtoss>(user);
                userInformation.Token = token.Token;
                _httpContextAccessor.HttpContext.Session.SetString("actieUserName", user.UserName);

                //await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
                await _signInManager.SignInAsync(user, null);
                return Created("", userInformation);
            }
            ModelState.AddModelError(string.Empty, "Giriş İşlemi Başarısız");
            return BadRequest("Login Failed");
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterPost(RegisterModel model)
        {
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Age = model.Age,
                ImagePath = "default.jpg",
                IsAdmin=false
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callBackUrl = Url.Action("ConfirmEmail", "Security", new { userId = user.Id, code = confirmationCode.Result });
                var thereIs = await _userManager.IsInRoleAsync(user, "User");
                if (thereIs == false)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
                return Created("", user);
            }
            return BadRequest("kullanıcı adı veya şifre hatalı");
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }

            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "Security", new { userId = user.Id, code = confirmationCode });

            //send callback Url with email
            return Created("", callbackUrl);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ResetPassword()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var code = await _userManager.GeneratePasswordResetTokenAsync(appUser);
            //var model = new ResetPasswordModel { Code = code };
            return Ok(new ResetPasswordModel { Code = code });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPasswordPost(ResetPasswordModel jsondata)
        {

            var user = await _userManager.FindByEmailAsync(jsondata.Email);
            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı");
            }
            var result = await _userManager.ResetPasswordAsync(user, jsondata.Code, jsondata.Password);
            if (result.Succeeded)
            {
                return Created("", result);
            }

            return BadRequest("Başarısız işlem");
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            await _signInManager.SignOutAsync();
            return Ok(0);
        }


        //public async Task<IActionResult> ConfirmEmail(string userId, string code)
        //{
        //    if (userId == null || code == null)
        //    {
        //        return RedirectToAction("Calculator", "Home");
        //    }
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        throw new ApplicationException("Unable to fin the user");
        //    }
        //    var result = await _userManager.ConfirmEmailAsync(user, code);
        //    if (result.Succeeded)
        //    {
        //        return View("ConfirmEmail");
        //    }
        //    return RedirectToAction("Calculator", "Home");
        //}




    }
}
