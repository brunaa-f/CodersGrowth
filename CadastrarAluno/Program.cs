
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CadastrarAluno
{
    internal static class Program
    {
        static void Main()
        {
            var builder = CriaHostBuilder();
            var servicesProvider = builder.Build().Services;

            var repositorio = servicesProvider.GetService<IRepositorio>();

            ApplicationConfiguration.Initialize();
            Application.Run(new TelaInicial(repositorio));
        }

        public static IHostBuilder CriaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IRepositorio, RepositorioBd>();
                });
        }
    }
}