using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Register.Context;
using Register.Models;

namespace Register.Service
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;

        public MenuService(AppDbContext context)
        {

            _context = context;

        }
        public async Task<IList<Menu>> GetMenusByProfileAsync(int userId)
        {
            var user = _context.Users.Where(mp => mp.Id == userId).FirstOrDefault();                                      ;

            var menus = await _context.MenuProfils
                                      .Where(mp => mp.ProfilId == user.ProfilId)
                                      .Select(mp => mp.Menu)
                                      .ToListAsync();
            return menus;
        }


    }
}
