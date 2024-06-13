using Autofac;
using Microsoft.EntityFrameworkCore;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Autofac Container'ını oluştur kadir can
            var builder = new ContainerBuilder();

            // Global hata işleyicileri kaydet
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler.HandleException;
            Application.ThreadException += GlobalExceptionHandler.HandleThreadException;

            // DbContext ve diğer bağımlılıkları kaydet
            builder.RegisterType<Context>().As<DbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(DbContextRepository<>)).As(typeof(DbContextRepository<>)).InstancePerLifetimeScope();

            // Formlar ve diğer bağımlılıkları kaydet
            builder.RegisterType<LoginForm>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<MNG_CargoForm>().AsSelf().InstancePerLifetimeScope();

            // Autofac Container'ını oluştur
            var container = builder.Build();

            // Autofac Container'ını kullanarak Dependency Injection'ı kur
            Application.Run(container.Resolve<LoginForm>());
        }
    }

}
