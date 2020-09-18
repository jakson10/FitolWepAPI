using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitOl.Domain.Dtos;
using FitOl.Service.Abstract;
using FitOl.WebAPI.Enums;
using FitOl.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementsController : BaseController
    {
        private readonly IMovementService _movementService;
        private readonly IMapper _mapper;
        public MovementsController(IMovementService movementService, IMapper mapper)
        {
            _movementService = movementService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_movementService.GetAllMovementAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _movementService.MovementById(id));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MovementAddModel movementAddModel)
        {
            var uploadModel = await UploadFileAsync(movementAddModel.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                movementAddModel.ImagePath = uploadModel.NewName;
                try
                {
                    int result = await _movementService.AddMovementAsync(_mapper.Map<MovementDto>(movementAddModel));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

                return Created("", movementAddModel);
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                movementAddModel.ImagePath = "spor.jpg";
                await _movementService.AddMovementAsync(_mapper.Map<MovementDto>(movementAddModel));
                return Created("", movementAddModel);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] MovementUpdateModel movementUpdateModel)
        {
            if (id != movementUpdateModel.Id)
                return BadRequest("geçersiz id");

            var uploadModel = await UploadFileAsync(movementUpdateModel.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                var updateMovement = await _movementService.MovementById(movementUpdateModel.Id);
                updateMovement.MovementName = movementUpdateModel.MovementName;
                updateMovement.MovementDescription = movementUpdateModel.MovementDescription;
                updateMovement.EnumMovementType = movementUpdateModel.EnumMovementType;
                updateMovement.ImagePath = uploadModel.NewName;

                await _movementService.EditMovementAsync(updateMovement);
                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                var updateMovement = await _movementService.MovementById(movementUpdateModel.Id);
                updateMovement.MovementName = movementUpdateModel.MovementName;
                updateMovement.MovementDescription = movementUpdateModel.MovementDescription;
                updateMovement.EnumMovementType = movementUpdateModel.EnumMovementType;

                await _movementService.EditMovementAsync(updateMovement);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _movementService.DeleteMovementAsync(await _movementService.MovementById(id));
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _movementService.MovementById(id));

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddToAreaMovement(AreaMovementsDto areaMovementsDto)
        {
            await _movementService.AddAreaMovementsAsync(areaMovementsDto);
            return Created("", areaMovementsDto);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteToAreaMovement([FromQuery] AreaMovementsDto areaMovementsDto)
        {
            await _movementService.DeleteAreaMovementsAsync(areaMovementsDto);
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult SportListDetails(int id)
        {
            return Ok(_movementService.SportListDetailsView(id));
        }

        [HttpGet("[action]/{sportListId}/{areaId}")]
        public IActionResult SportListAreaMovementDetails([FromRoute] int sportListId, [FromRoute] int areaId)
        {
            return Ok(_movementService.SportListAreaMovementsDetailsView(sportListId, areaId));
        }


        [HttpGet("[action]/{id}")]
        public IActionResult SportListMovementDetails(int id)
        {
            return Ok(_movementService.SportListDetailsMovements(id));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllMovementName()
        {
            return Ok(_movementService.GetAllMovementNameAsync());
        }


    }
}
