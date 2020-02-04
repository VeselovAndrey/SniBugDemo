namespace ConsoleDemo
{
    using System;
    using EFCore31Demo.Business;

    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            userService.DoSomeAsync().GetAwaiter().GetResult();

            Console.WriteLine("Press any key...");
            Console.ReadKey(intercept: true);
        }
    }
}
