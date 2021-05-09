using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Data.Models;

namespace HttpApi.Resources.persistence.repos
{
    public interface IAdultsRepo
    {
        Task<List<Adult>> GetAllAsync();
        Task<Adult> GetByIdAsync(int id);
        Task AddAsync(Adult adult);
        Task RemoveAsync(int id);
        Task EditAsync(Adult newAdult);
    }
}