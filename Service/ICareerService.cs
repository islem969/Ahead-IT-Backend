using Register.Models;

namespace Register.Service
{
    public interface ICareerService
    {

        Task<Carrier> AddCarrierAsync(Carrier carrier);
        Task<IEnumerable<Carrier>> GetAllCarriersAsync();
        Task<Carrier> GetCarrierByIdAsync(int id);
        Task<Carrier> UpdateCarrierAsync(int id, Carrier carrier);
        Task DeleteCarrierAsync(int id);
        Task<IEnumerable<Carrier>> GetCarriersByUserIdAsync(int userId);
    }
}
