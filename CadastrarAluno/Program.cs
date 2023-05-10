using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;


namespace CadastrarAluno
{
    internal static class Program
    {
        private static string conectionString = ConfigurationManager.ConnectionStrings["BancoDeAlunos"].ConnectionString;
        [STAThread]
        static void Main()
        {

            var builder = CriaHostBuilder();
            var servicesProvider = builder.Build().Services;
            var repositorio = servicesProvider.GetService<IRepositorio>();

            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaInicial(repositorio));
        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
            .AddSqlServer()
            .WithGlobalConnectionString(conectionString)
            .ScanIn(typeof(AddLogTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        }

        static IHostBuilder CriaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddScoped<IRepositorio, RepositorioBd>();
                });
        }
    }
}