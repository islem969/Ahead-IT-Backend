using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Register.Context;
using Register.Models;
using Register.Models.DTO;
using Register.Service;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase
    {
        private readonly ICareerService _carrierService;
        private readonly AppDbContext _authContext;

        public CareerController(ICareerService carrierService, AppDbContext appDbContext )
        {
            _carrierService = carrierService;
            _authContext = appDbContext;
        }




        [HttpPost]
        public async Task<IActionResult> AddCarrier([FromBody] CarrierDto carrierDto)
        {
            if (carrierDto == null)
            {
                return BadRequest("Carrier object is null");
            }

            if (carrierDto.UserId == 0)
            {
                return BadRequest("UserId is required");
            }

            var user = await _authContext.Users.FindAsync(carrierDto.UserId);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            // Récupérer la qualification par son identifiant
            var qualification = await _authContext.Qualifications.FindAsync(carrierDto.QualificationId);
            var Civil_Status = await _authContext.Civil_Status.FindAsync(carrierDto.Civil_StatusId);

            if (qualification == null)
            {
                return BadRequest("Qualification not found");
            }

            var carrier = new Carrier
            {
                Salary = carrierDto.Salary,
                Bban = carrierDto.Bban,
                From = carrierDto.From,
                To = carrierDto.To,
                RIB = carrierDto.RIB,
                UserId = carrierDto.UserId,
                User = user,
                Qualification = qualification,
                Civil_Status = Civil_Status,
                // Associer la qualification
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var addedCarrier = await _carrierService.AddCarrierAsync(carrier);
            return CreatedAtAction(nameof(GetCarrierById), new { id = addedCarrier.Id }, addedCarrier);
           
        }




        [HttpGet]
        public async Task<IActionResult> GetAllCarriers()
        {
            var carriers = await _carrierService.GetAllCarriersAsync();
            return Ok(carriers);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCarriersByUserId(int userId)
        {
            var carriers = await _carrierService.GetCarriersByUserIdAsync(userId);
            if (carriers == null || !carriers.Any())
            {
                return NotFound();
            }
            return Ok(carriers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrierById(int id)
        {
            var carrier = await _authContext.Carrieres.FindAsync(id);
            if (carrier == null)
            {
                return NotFound();
            }
            return Ok(carrier);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarrier(int id, [FromBody] CarrierDto carrierDto)
        {
            if (carrierDto == null)
            {
                return BadRequest("Carrier object is null");
            }

            var carrier = new Carrier
            {
                Id = id,
                Salary = carrierDto.Salary,
                Bban = carrierDto.Bban,
                From = carrierDto.From,
                To = carrierDto.To,
                RIB = carrierDto.RIB,
                UpdatedAt = DateTime.Now
            };
       
            var updatedCarrier = await _carrierService.UpdateCarrierAsync(id, carrier);
            if (updatedCarrier == null)
            {
                return NotFound();
            }
            return Ok(updatedCarrier);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrier(int id)
        {
            await _carrierService.DeleteCarrierAsync(id);
            return NoContent();
        }
    }


}

