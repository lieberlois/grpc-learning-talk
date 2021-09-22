using System;
using SushiOrderClient.Dtos;

namespace SushiOrderClient.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGrpcClient _grpcClient;

        public OrderService(IGrpcClient grpcClient)
        {
            this._grpcClient = grpcClient;
        }

        public void Start()
        {
            Console.WriteLine("**************************");
            Console.WriteLine("Winschel Tonis Sushi Spot");
            Console.WriteLine("**************************\n");

            var orderDto = HandleCreateOrder();

            Console.WriteLine($"Placing order: {orderDto}");

            this._grpcClient.PlaceOrder(orderDto);
        }

        private CreateOrderDto HandleCreateOrder()
        {
            Console.WriteLine("What is your name?");
            var userName = Console.ReadLine();

            if (userName == null)
            {
                throw new Exception("Bad input");
            }

            Console.WriteLine("Amount of M1 plates:");
            var m1 = Console.ReadLine();
            Console.WriteLine("Amount of M2 plates:");
            var m2 = Console.ReadLine();
            Console.WriteLine("Amount of M3 plates:");
            var m3 = Console.ReadLine();
            Console.WriteLine("Amount of M4 plates:");
            var m4 = Console.ReadLine();
            Console.WriteLine("Amount of vegetarian spring rolls:");
            var springRoll = Console.ReadLine();

            var orderDto = new CreateOrderDto()
            {
                UserName = userName,
                M1Count = int.Parse(m1 ?? "0"),
                M2Count = int.Parse(m2 ?? "0"),
                M3Count = int.Parse(m3 ?? "0"),
                M4Count = int.Parse(m4 ?? "0"),
                SpringRollCount = int.Parse(springRoll ?? "0"),
            };

            return orderDto;
        }
    }
}