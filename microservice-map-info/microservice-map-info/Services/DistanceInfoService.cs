using GoogleMapInfo;
using Grpc.Core;
using microservice_map_info.Protos;

namespace microservice_map_info.Services;

public class DistanceInfoService : DistanceInfo.DistanceInfoBase
{
    private readonly ILogger<DistanceInfoService> logger;
    private readonly IGoogleDistanceApi googleDistanceApi;

    public DistanceInfoService(ILogger<DistanceInfoService> logger, IGoogleDistanceApi googleDistanceApi)
    {
        this.logger = logger;
        this.googleDistanceApi = googleDistanceApi;
    }

    public override async Task<DistanceData> GetDistance(Cities cities, ServerCallContext context)
    {
        var totalMiles = "0";
        var distanceData = await this.googleDistanceApi.GetMapDistance(cities.OriginCity, cities.DestinationCity);

        foreach (var ddr in distanceData.Rows)
            foreach (var e in ddr.Elements)
                totalMiles = e.Distance.Text;

        return new DistanceData
        {
            Miles = totalMiles
        };
    }
}
