using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SWStarships;
using SWStarships.Domain.API;
using SWStarships.Infrastructure.Implementations;
using SWStarships.Infrastructure.Interfaces;

namespace SWStarshipsTest
{
    public class Base
    {
        #region [Properties]

        private static IServiceProvider _serviceProvider;

        #endregion

        #region [Constructor]

        public Base()
        {
            RegisterServices();
        }

        #endregion

        #region [Methods]

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
        /// Returns the service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        #endregion
    }
}
