using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResimDuzenleme.Services;
using ResimDuzenleme.Services.Cargo;
using ResimDuzenleme.Services.Cargo.Abstractions;
using ResimDuzenleme.Services.Database;
using ResimDuzenleme.Services.Forms;
using ResimDuzenleme.Services.Interceptors;
using System;
using System.Windows.Forms;

namespace ResimDuzenleme
{

    static class Program
    {
        [STAThread]
        static void Main( )
        {
            var host = CreateHostBuilder().Build();

            // Global hata işleyicileri kaydet
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler.HandleException;
            Application.ThreadException += GlobalExceptionHandler.HandleThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = host.Services.GetRequiredService<LoginForm>();

            Application.Run(mainForm);
        }

        static IHostBuilder CreateHostBuilder( )
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // ConnectionString instance
                    var connectionString = new ConnectionString();
                    var cnns = connectionString.GetConnectionString();

                    // Configure Context to use the ConnectionString
                    services.AddDbContext<Context>(options =>
                    {
                        options.UseSqlServer(cnns, sqlOptions => sqlOptions.CommandTimeout(1000));
                    }, ServiceLifetime.Transient);

                    services.AddTransient<LoginForm>();
                    services.AddTransient<Misigo>();
                    services.AddTransient<MNG_CargoForm>();
                    services.AddTransient<IMNG_CargoService, MNG_CargoService>();
                });
        }
    }

}
