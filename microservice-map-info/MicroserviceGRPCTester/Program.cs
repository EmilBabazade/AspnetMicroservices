using Grpc.Net.Client;
using microservice_map_info.Protos;

var channel = GrpcChannel.ForAddress(new Uri("https://localhost:7253"));
var client = new DistanceInfo.DistanceInfoClient(channel);
var response = await client
    .GetDistanceAsync(new Cities
    {
        OriginCity = "Riga, LV",
        DestinationCity = "Baku, AZE"
    });
Console.WriteLine(response.Miles);
Console.ReadKey();