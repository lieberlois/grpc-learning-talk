# Commands
```sh
# Go

protoc --proto_path=proto --go_out=plugins=grpc:./sushi_order_server proto/**/*.proto

# NodeJS / TypeScript

cd restaurant-order-client

yarn run grpc_tools_node_protoc \
    --proto_path=../proto \
    --js_out=import_style=commonjs,binary:./proto \
    --grpc_out=./proto \
    --plugin=protoc-gen-grpc=./node_modules/.bin/grpc_tools_node_protoc_plugin \
    ../proto/**/*.proto

yarn run grpc_tools_node_protoc \
    --proto_path=../proto \
    --plugin=protoc-gen-ts=./node_modules/.bin/protoc-gen-ts \
    --ts_out=./proto \
    ../proto/**/*.proto

# .NET Core

dotnet build
```

# Protobuf

```protobuf
syntax = "proto3";

option csharp_namespace = "SushiOrderClient";
option go_package = "./sushi_order_server";

message Order {
    string username = 1;
    int32 m1_count = 2;
    int32 m2_count = 3;
    int32 m3_count = 4;
    int32 m4_count = 5;
    int32 spring_roll_count = 6;
}

message CreateOrderRequest {
    Order order = 1;
}

message CreateOrderResponse {}

message ListOrdersRequest {}

message ListOrdersResponse {
    repeated Order orders = 1;
}

service SushiService {
    rpc CreateSushiOrder (CreateOrderRequest) returns (CreateOrderResponse);
    rpc ListOrders (ListOrdersRequest) returns (ListOrdersResponse);
}
```

# Architecture
![alt text](./Architecture.jpg)
