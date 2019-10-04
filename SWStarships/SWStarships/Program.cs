using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SWStarships.Domain.API;

namespace SWStarships
{
    class Program
    {
        #region [Properties]

        private static IServiceProvider _serviceProvider;

        #endregion

        static void Main( string[] args )
        {
            RegisterServices();

            ///Call the class which starts the app

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
