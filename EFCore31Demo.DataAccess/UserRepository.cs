namespace EFCore31Demo.DataAccess
{
    using System.Linq;
    using System.Threading.Tasks;
    using EFCore31Demo.DataAccess.Entities;

    public class UserRepository
    {
        public async Task<int> CreateUserAsync(string userName)
        {
            var contextFactory = new DemoContextFactory();
            await using DemoContext context = contextFactory.Create();

            var user = new User() {
                Name = userName
            };

            context.Users.Add(user);

            await context.SaveChangesAsync()
                .ConfigureAwait(false);

            return user.Id;
        }

        public async Task<string> GetNameAsync(int id)
        {
            var contextFactory = new DemoContextFactory();
            await using var context = contextFactory.Create();

            var user = context.Users.FirstOrDefault(x => x.Id == id);

            return user?.Name;
        }
    }
}
