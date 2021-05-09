using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpApi.Resources.persistence.repos.impl
{
    public class FamilyRepo : IFamilyRepo
    {
        public async Task<List<Family>> GetAllAsync()
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            return context.Families.Include(fam => fam.Adults)
                .Include(fam => fam.Children)
                .Include(fam => fam.Pets)
                .ToList();
        }

        public async Task<Family> GetByAdultAsync(int adultId)
        {
            Family family = null;
            await using SQLiteDBContext context = new SQLiteDBContext();
            var adult = context.Adults.Include(a => a.JobTitle).FirstOrDefault(a => a.Id == adultId);
            if (adult != null)
            {
                family = context.Families
                    .Include(fam => fam.Adults)
                    .FirstOrDefault(fam => fam.Adults.Contains(adult));
            }

            return family;
        }

        public async Task<Family> GetByFamilyNameAsync(string familyName)
        {
            Family family = null;
            await using SQLiteDBContext context = new SQLiteDBContext();
            family = context.Families.Include(fam => fam.Adults)
                .FirstOrDefault(fam => fam.Adults.First().LastName.Equals(familyName));
            return family;
        }

        public async Task AddAsync(Family family)
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            context.Families.Add(family);
            context.SaveChanges();
        }
    }
}