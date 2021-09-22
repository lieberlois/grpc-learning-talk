import { credentials } from "grpc";
import { SushiServiceClient } from "./proto/sushi_grpc_pb";
import { ListOrdersRequest } from "./proto/sushi_pb";

const url: string = "localhost:3333";

const grpcClient = new SushiServiceClient(url, credentials.createInsecure());

const request = new ListOrdersRequest();

grpcClient.listOrders(request, (err, res) => {
  if(err) {
    console.log("Error:", err);
  }

  const orders = res.getOrdersList()

  orders.forEach((o) => {
    console.log(o.toObject());
    console.log("\n");
  })
});