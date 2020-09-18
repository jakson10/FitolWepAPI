using System.Linq;
using System.Threading.Tasks;
using FitOl.Domain.Dtos;
using FitOl.Domain.Entities;
using FitOl.Service.Abstract;
using FitOl.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportListsController : ControllerBase
    {
        private readonly ISportListService _sportListService;
        private readonly ISportDayService _sportDayService;
        private readonly IAreaService _areaService;
        private readonly IMovementService _movementService;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;


        public SportListsController(ISportListService sportListService,
            ISportDayService sportDayService,
            IAreaService areaService,
            IMovementService movementService,
            IUserService userService,
            UserManager<AppUser> userManager)
        {
            _sportListService = sportListService;
            _sportDayService = sportDayService;
            _areaService = areaService;
            _movementService = movementService;
            _userService = userService;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_sportListService.GetAllSportListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SportListDto sportListDto)
        {
            await _sportListService.AddSportListAsync(sportListDto);
            return Created("", sportListDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sportListService.DeleteSportListAsync(await _sportListService.SportListById(id));
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _sportListService.SportListById(id));

        }

        [HttpGet("[action]/{bolgeGun}/{sportListId}")]
        public IActionResult AddMovementForArea(int bolgeGun, int sportListId)
        {
            int sayi = bolgeGun;
            int hangiOgun = (bolgeGun / 10);
            int hangiOgun1 = hangiOgun;
            hangiOgun--;
            sayi = sayi - (hangiOgun1 * 10);
            int hangiGun = sayi;
            hangiGun--;

            var getSDays = _sportDayService.GetSportDaysBySportListId(sportListId).ToList();
            SportDayDto selectedDay = getSDays[hangiGun];

            var getDayAreas = _areaService.GetAreasBySportDayId(selectedDay.Id).ToList();

            AreaDto selectedArea = getDayAreas[hangiOgun];

            return Ok(selectedArea.Id);

        }


        [HttpGet("[action]/{id}")]
        public IActionResult Movements(int id)
        {
            SelectMovementAndAreaModel vm = new SelectMovementAndAreaModel();
            vm.allMovements = _movementService.GetAllMovementAsync().ToList();
            vm.areaId = id;
            return Ok(vm);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult SportListView(int id)
        {
            return Ok(_areaService.SportListDetailsView(id));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> MovementsPost(SelectMovementAndAreaModel jsonData)
        {
            await _sportListService.AddAreaMovements(jsonData.selectedMovementIdArray, jsonData.areaId);
            return Created("", jsonData);
        }


        [HttpPost("[action]/{userName}")]
        public async Task<IActionResult> QuestionsSportResult(string userName,QuestionSportModel jsonData)
        {
            if (userName == null)
            {
                userName = User.Identity.Name;
            }
            var user = await _userManager.FindByNameAsync(userName);
            if (jsonData.Bolge == Bolge.FullBody)
            {
                int success = await _userService.AddUserSportListsAsync(user.Id, 10);
                if (success > 0)
                {
                    return Created("", jsonData);
                }
                return BadRequest("Bir hata oluştu tekrar deneyiniz");
            }
            else if (jsonData.Bolge == Bolge.Karın)
            {
                int success = await _userService.AddUserSportListsAsync(user.Id, 11);
                if (success > 0)
                {
                    return Created("", jsonData);
                }
                return BadRequest("Bir hata oluştu tekrar deneyiniz");
            }
            else if (jsonData.Bolge == Bolge.Omuz)
            {
                int success = await _userService.AddUserSportListsAsync(user.Id, 12);
                if (success > 0)
                {
                    return Created("", jsonData);
                }
                return BadRequest("Bir hata oluştu tekrar deneyiniz");
            }
            else if (jsonData.Bolge == Bolge.Bacak)
            {
                int success = await _userService.AddUserSportListsAsync(user.Id, 10);
                if (success > 0)
                {
                    return Created("", jsonData);
                }
                return BadRequest("Bir hata oluştu tekrar deneyiniz");
            }
            return BadRequest("Bir hata oluştu tekrar deneyiniz");
        }
    }
}
