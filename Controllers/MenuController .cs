using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Service;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [HttpGet("GetMenusByProfile/{profileId}")]
        public async Task<IActionResult> GetMenusByProfile(int profileId)
        {
            var menus = await _menuService.GetMenusByProfileAsync(profileId);
            if (menus == null || !menus.Any())
            {
                return NotFound();
            }
            return Ok(menus);
        }
    }
    }
