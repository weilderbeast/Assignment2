using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Data.Models;

namespace HttpApi.Resources.persistence.repos
{
    public interface IJobsRepo
    {
        Task<List<Job>> GetAllAsync();
    }
}