package server

import (
	"context"
	"log"
	"sushi_order_server/pb"
)

type Server struct {
	orders []*pb.Order
}

func NewServer() *Server {
	server := &Server{}
	server.orders = make([]*pb.Order, 0)

	return server
}

func (s *Server) ListOrders(ctx context.Context, request *pb.ListOrdersRequest) (*pb.ListOrdersResponse, error) {
	log.Println("Handling ListOrders")

	response := &pb.ListOrdersResponse{
		Orders: s.orders,
	}

	return response, nil
}

func (s *Server) CreateSushiOrder(ctx context.Context, request *pb.CreateOrderRequest) (*pb.CreateOrderResponse, error) {
	log.Println("Handling CreateSushiOrder")

	order := request.GetOrder()
	s.orders = append(s.orders, order)

	return &pb.CreateOrderResponse{}, nil
}
