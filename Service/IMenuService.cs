using Register.Models;

namespace Register.Service
{
    public interface IMenuService
    {
        Task<IList<Menu>> GetMenusByProfileAsync(int profileId);
    }
}
