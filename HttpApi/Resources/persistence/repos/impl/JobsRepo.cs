using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Data.Models;

namespace HttpApi.Resources.persistence.repos.impl
{
    public class JobsRepo : IJobsRepo
    {
        public async Task<List<Job>> GetAllAsync()
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            return context.Jobs.ToList();
        }
    }
}