using Microsoft.EntityFrameworkCore;
using Register.Context;
using Register.Models;
using Register.Models.DTO;

namespace Register.Service
{
    public class EntityService : IEntityService
    {
        private readonly AppDbContext _context;



        public EntityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entity>> GetAllEntitiesAsync()
        {
            var entities = await _context.Entity
                .Select(e => new Entity
                {
                    Id = e.Id,
                    Tax_registration_number = e.Tax_registration_number,
                    Trad_registration = e.Trad_registration,
                    Created = e.Created,
                    Updated = e.Updated,
                    Exploitation_code = e.Exploitation_code,
                    Adress = e.Adress,
                    Email = e.Email,
                    Phone = e.Phone,
                    Creation_Date = e.Creation_Date,                  
                    RNE = e.RNE,
                    Social_security_sheme = e.Social_security_sheme
                })
                .ToListAsync();

            return entities;
        }


        public async Task<IEnumerable<EntityDto>> GetAllEntity()
        {
            var entities = await _context.Entity
                .Select(e => new EntityDto
                {
                    Email = e.Email,
                    Adress = e.Adress,
                    Phone = e.Phone
                    // Autres propriétés à mapper si nécessaire
                })
                .ToListAsync();

            return entities;
        }

    }
}
