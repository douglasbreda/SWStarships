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
            try
            {
                RegisterServices();
                string value = "";
                App app = _serviceProvider.GetService<App>();

                do
                {
                    long convertedValue = 0;
                    Console.Write( "Type the distance in MGLT: " );
                    value = Console.ReadLine();

                    if ( long.TryParse( value, out convertedValue ) )
                        await app.Start( convertedValue );
                    else
                    {
                        if ( value != "exit" )
                            Console.WriteLine( "The value typed is not valid." );
                    }

                    DisposeServices();

                } while ( value != "exit" );

            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.Message );
            }
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
