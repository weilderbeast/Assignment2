using System.Threading.Tasks;
using Assignment1.Data.Models;

namespace HttpApi.Resources.persistence.repos
{
    public interface IUsersRepo
    {
        Task<User> ValidateAsync(string username, string password);
    }
}