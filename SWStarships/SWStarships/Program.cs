using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SWStarships.Domain.API;
using SWStarships.Infrastructure.Implementations;
using SWStarships.Infrastructure.Interfaces;

namespace SWStarships
{
    class Program
    {
        #region [Properties]

        private static IServiceProvider _serviceProvider;

        #endregion

        static async Task Main( string[] args )
        {
            RegisterServices();

            IApi api = _serviceProvider.GetService<IApi>();
            IDownload download = _serviceProvider.GetService<IDownload>();

            App app = new App( download, api );
            await app.Start();

            DisposeServices();
        }

        /// <summary>
        /// Configures Autofac and register the services
        /// </summary>
        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            var builder = new ContainerBuilder();

            #region [Types]

            builder.RegisterType<StarWarsApi>().As<IApi>();
            builder.RegisterType<Download>().As<IDownload>();

            #endregion

            builder.Populate( collection );

            var appContainer = builder.Build();

            _serviceProvider = new AutofacServiceProvider( appContainer );
        }

        /// <summary>
        /// Dispose the services
        /// </summary>
        private static void DisposeServices()
        {
            if ( _serviceProvider is null )
                return;
            else if ( _serviceProvider is IDisposable )
                ( ( IDisposable ) _serviceProvider ).Dispose();
        }
    }
}
