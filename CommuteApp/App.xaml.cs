using CommuteApp.Data;
using CommuteApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CommuteApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = new MainWindow { DataContext = serviceProvider.GetService<MainWindowViewModel>() };
            mainWindow.Show();

            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDataServices();

            services.AddSingleton<MainWindowViewModel>();
        }
    }
}