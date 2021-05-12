using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;
using WpfVectorViewer.Mappers;
using WpfVectorViewer.Services;
using WpfVectorViewer.ViewModel;

namespace WpfVectorViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer serviceProvider;
        public App()
        {
            serviceProvider = new UnityContainer();
            ConfigureServices(serviceProvider);
        }

        private void ConfigureServices(IUnityContainer container)
        {
            container.RegisterType<IReadPrimitivesService, ReadPrimitivesService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IComponentMapper, ComponentMapper>(new ContainerControlledLifetimeManager());
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            
            var mainWindow = serviceProvider.Resolve<MainWindow>();
            //mainWindow.DataContext = new PrimitiveShapesViewModel(serviceProvider.GetService<IReadPrimitivesService>());
            mainWindow.Show();
        }
    }
}