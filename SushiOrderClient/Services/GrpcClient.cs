using System;
using System.Collections.Generic;
using SushiOrderClient.Dtos;

namespace SushiOrderClient
{
    public class GrpcClient : IGrpcClient
    {
        public void PlaceOrder(CreateOrderDto createOrderDto)
        {
            Console.WriteLine($"TODO: Send order {createOrderDto.ToString()} to order server");
        }
    }
}