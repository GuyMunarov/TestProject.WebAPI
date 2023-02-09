using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.WebAPI.Data;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Services.Abstractation;

namespace TestProject.WebAPI.Services
{
    public class UsersRepository: IUsersRepository
    {
        private readonly TestProjectContext context;

        public UsersRepository(TestProjectContext context)
        {
            this.context = context;
        }

        public async Task AddUsers(List<User> users)
        {

            context.Users.AddRange(users);
            await context.SaveChangesAsync();
        }
    }
}
