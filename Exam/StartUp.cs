namespace FestivalManager
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Core.Commands.Factories;
    using Core.Commands.Factories.Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            IServiceProvider serviceProvider = ConfigureServices();

            IReader reader = serviceProvider.GetService<IReader>();
            IWriter writer = serviceProvider.GetService<IWriter>();

			IFestivalController festivalController = serviceProvider.GetService<IFestivalController>();
            ISetController setController = serviceProvider.GetService<ISetController>();

            ICommandFactory commandFactory = serviceProvider.GetService<ICommandFactory>();
            
			Engine engine = new Engine(reader, writer, festivalController, setController, commandFactory);
			engine.Run();
		}

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IInstrumentFactory, InstrumentFactory>();
            services.AddSingleton<ISetFactory, SetFactory>();
            services.AddSingleton<ICommandFactory, CommandFactory>();

            services.AddSingleton<IStage, Stage>();

            services.AddSingleton<IFestivalController, FestivalController>();
            services.AddSingleton<ISetController, SetController>();

            services.AddSingleton<IReader, ConsoleReader>();
            services.AddSingleton<IWriter, ConsoleWriter>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}