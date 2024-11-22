using Register.Models;

namespace Register.Service
{
    public interface IQualificationService
    {
        Task<IEnumerable<Qualification>> GetAllQualificationsAsync();
    }

}
