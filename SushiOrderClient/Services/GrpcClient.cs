using System;
using Grpc.Net.Client;
using SushiOrderClient.Dtos;

namespace SushiOrderClient
{
    public class GrpcClient : IGrpcClient
    {
        public void PlaceOrder(CreateOrderDto createOrderDto)
        {
            var url = "http://localhost:3333";

            var channel = GrpcChannel.ForAddress(url);
            var client = new SushiService.SushiServiceClient(channel);

            var request = new CreateOrderRequest()
            {
                Order = new Order() {
                    Username = createOrderDto.UserName,
                    M1Count = createOrderDto.M1Count,
                    M2Count = createOrderDto.M2Count,
                    M3Count = createOrderDto.M3Count,
                    M4Count = createOrderDto.M4Count,
                    SpringRollCount = createOrderDto.SpringRollCount
                }
            };

            try
            {
                var response = client.CreateSushiOrder(request);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Failed to call the gRPC Server {ex}");
                return;
            }
        }
    }
}