using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Context;
using Register.Models;
using Register.Models.DTO;
using Register.Service;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityDtoController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        private readonly IEntityService _entityService;

        private readonly IMapper _mapper;
        public EntityDtoController(AppDbContext appDbContext, IEntityService entityService, IMapper mapper)
        {
            _authContext = appDbContext;
            _entityService = entityService;
            _mapper = mapper;
        }
   
        // Route: GET api/entity
        [HttpGet("entity")]
        public async Task<ActionResult<IEnumerable<Entity>>> GetAllEntities()
        {
            var entities = await _entityService.GetAllEntitiesAsync();
            return Ok(entities);
        }

        [HttpGet("entitydto")]
        public async Task<ActionResult<IEnumerable<EntityDto>>> GetEntityDtos()
        {
            var entities = await _entityService.GetAllEntitiesAsync();
            var entityDtos = _mapper.Map<IEnumerable<EntityDto>>(entities);
            return Ok(entityDtos);
        }
    }
}
