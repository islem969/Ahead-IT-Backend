using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Models;
using Register.Service;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationsController : ControllerBase
    {
        private readonly IQualificationService _qualificationService;


        public QualificationsController(IQualificationService qualificationService)
        {
            _qualificationService = qualificationService;
        }


        // GET: api/Qualifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qualification>>> GetAllQualifications()
        {
            var qualifications = await _qualificationService.GetAllQualificationsAsync();
            return Ok(qualifications);
        }
    }
}

