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

            App app = _serviceProvider.GetService<App>();
            long userInput = GetUserInput();
            await app.Start( userInput );

            DisposeServices();
        }

        // <summary>
        /// Gets the user's input
        /// </summary>
        /// <returns></returns>
        private static long GetUserInput()
        {
            long convertedValue = 0;
            Console.Write( "Type the distance in MGLT: " );
            string value = Console.ReadLine();

            long.TryParse( value, out convertedValue );

            return convertedValue;
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
            builder.RegisterType<Function>().As<IFunction>();
            builder.RegisterType<ConsoleLogger>().As<IConsoleLogger>();
            builder.RegisterType<App>();

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
