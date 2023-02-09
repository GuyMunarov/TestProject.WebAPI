using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.WebAPI.Data;

namespace TestProject.WebAPI.Services.Abstractation
{
    public interface IUsersRepository
    {
        Task AddUsers(List<User> users);
    }
}
