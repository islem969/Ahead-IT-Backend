using Register.Models;


namespace Register.Service
{
    public interface IStatusService
    {
        Task<IEnumerable<Civil_Status>> GetAllStatusAsync();
    }
}
