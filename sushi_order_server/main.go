package main

import (
	"log"
	"net"
	"sushi_order_server/pb"
	"sushi_order_server/server"

	"google.golang.org/grpc"
)

func main() {
	server := server.NewServer()
	grpcServer := grpc.NewServer()

	pb.RegisterSushiServiceServer(grpcServer, server)

	listener, err := net.Listen("tcp", "0.0.0.0:3333")

	if err != nil {
		log.Fatal("cannot start server: ", err)
	}

	log.Println("Serving gRPC Server at 0.0.0.0:3333...")

	err = grpcServer.Serve(listener)
	if err != nil {
		log.Fatal("cannot start server: ", err)
	}
}
