using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpApi.Resources.persistence.repos.impl
{
    public class AdultsRepo : IAdultsRepo
    {
        public async Task<List<Adult>> GetAllAsync()
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            return context.Adults.Include(a => a.JobTitle).ToList();
        }

        public async Task<Adult> GetByIdAsync(int id)
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            return context.Adults.Include(a => a.JobTitle).FirstOrDefault(a => a.Id == id);
        }

        public async Task AddAsync(Adult adult)
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            var j = await context.Jobs.FirstOrDefaultAsync(j => j.Id == adult.JobTitle.Id);
            adult.JobTitle = j;
            context.Adults.Add(adult);
            context.SaveChanges();
        }

        public async Task RemoveAsync(int id)
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            var adultToRemove = await GetByIdAsync(id);
            context.Adults.Remove(adultToRemove);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(Adult newAdult)
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            await RemoveAsync(newAdult.Id);
            await AddAsync(newAdult);
            await context.SaveChangesAsync();
        }
    }
}