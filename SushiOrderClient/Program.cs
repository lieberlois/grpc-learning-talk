using System;
using Autofac;
using SushiOrderClient.Services;

namespace SushiOrderClient
{
    class Program
    {
        private static IContainer _container { get; set; }
        static void Main(string[] args)
        {
            ConfigureDependencyInjection();

            using (var scope = _container.BeginLifetimeScope())
            {
                var orderService = scope.Resolve<IOrderService>();
                orderService.Start();
            }
        }

        private static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GrpcClient>().As<IGrpcClient>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            _container = builder.Build();
        }
    }
}
