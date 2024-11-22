using Register.Models;
using Register.Models.DTO;

namespace Register.Service
{
    public interface IEntityService
    {
      Task<IEnumerable<EntityDto>> GetAllEntity();

      Task<IEnumerable<Entity>> GetAllEntitiesAsync();
    }
}
