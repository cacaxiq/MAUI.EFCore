using MAUI.EFCore.Infrastructure.Data;

namespace MAUI.EFCore.Migrator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Migrator running..");

            using (var context = new DatabaseDBContext())
            {
                var all = context.Products.ToList();
            }
        }
    }
}
