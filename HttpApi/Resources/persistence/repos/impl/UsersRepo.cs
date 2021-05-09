using System;
using System.Threading.Tasks;
using Assignment1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpApi.Resources.persistence.repos.impl
{
    public class UsersRepo : IUsersRepo
    {
        public UsersRepo()
        {
            var file = new FileContext();
             var users = file.Users;
             foreach (var user in users)
             {
                 using SQLiteDBContext context = new SQLiteDBContext();
                 context.Users.Add(user);
                 context.SaveChanges();
             }
        }
        
        public async Task<User> ValidateAsync(string username, string password)
        {
            await using SQLiteDBContext context = new SQLiteDBContext();
            var temp = await context.Users.FirstOrDefaultAsync(user => user.Username.Equals(username));
            if (temp == null)
            {
                throw new Exception("user not found");
            }

            if (!temp.Password.Equals(password))
            {
                throw new Exception("password is wrong");
            }

            return temp;
        }
    }
}