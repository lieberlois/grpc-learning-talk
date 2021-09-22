using SushiOrderClient.Dtos;

namespace SushiOrderClient
{
    public interface IGrpcClient
    {
        void PlaceOrder(CreateOrderDto createOrderDto);
    }
}