using Microsoft.EntityFrameworkCore;
using Register.Context;
using Register.Models;

namespace Register.Service
{
    public class StatusService : IStatusService
    {
        private readonly AppDbContext _context;

        public StatusService(AppDbContext context)
        {

            _context = context;

        }

        public async Task<IEnumerable<Civil_Status>> GetAllStatusAsync()
        {
            return await _context.Civil_Status.ToListAsync();
        }
    }
}
