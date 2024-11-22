using Microsoft.EntityFrameworkCore;
using Register.Context;
using Register.Models;

namespace Register.Service
{
    public class QualificationService : IQualificationService
    {
        private readonly AppDbContext _context;
      
        public QualificationService(AppDbContext context) {

            _context = context;

        }
        public async Task<IEnumerable<Qualification>> GetAllQualificationsAsync()
        {
            return await _context.Qualifications.ToListAsync();
        }

      
    }
}
