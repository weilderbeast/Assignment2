using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Data.Models;

namespace HttpApi.Resources.persistence.repos
{
    public interface IFamilyRepo
    {
        Task<List<Family>> GetAllAsync();
        Task<Family> GetByAdultAsync(int adultId);
        Task<Family> GetByFamilyNameAsync(string familyName);
        Task AddAsync(Family family);
    }
}