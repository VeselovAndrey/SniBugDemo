namespace EFCore31Demo.Business
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using EFCore31Demo.DataAccess;

    public class UserService
    {
        public async Task DoSomeAsync()
        {
            var repo = new UserRepository();

            var name = await repo.GetNameAsync(1).ConfigureAwait(false);
            Trace.TraceInformation($"Name for Id == 1: {name ?? "Not found"}");
            Console.WriteLine($"Name for Id == 1: {name ?? "Not found"}");

            var newId = await repo.CreateUserAsync(Guid.NewGuid().ToString("N")).ConfigureAwait(false);
            Trace.TraceInformation($"New id: {newId}");
            Console.WriteLine($"New id: {newId}");

            var newName = await repo.GetNameAsync(newId);
            Trace.TraceInformation($"Name for Id == {newId}: {newName ?? "Not found"}");
            Console.WriteLine($"Name for Id == {newId}: {newName ?? "Not found"}");
        }
    }
}
