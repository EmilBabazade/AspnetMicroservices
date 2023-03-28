using GoogleMapInfo.ResponseModel;
using Microsoft.Extensions.Configuration;

namespace GoogleMapInfo;
public class GoogleDistanceApi : IGoogleDistanceApi
{
    private readonly IConfiguration configuration;

    public GoogleDistanceApi(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public async Task<GoogleDistanceData> GetMapDistance(string originCity, string destinationCity)
    {
        await Task.Delay(3000);
        var rnd = new Random();
        var distance = rnd.Next(1, 1000);
        var distanceValue = rnd.Next(1, 10000);
        var durationHour = rnd.Next(24);
        var durationMinute = rnd.Next(1, 60);
        var durationValue = rnd.Next(1, 10000);
        return new GoogleDistanceData
        {
            DestinationAddresses = new[] { destinationCity },
            OriginAddresses = new[] { originCity },
            Rows = new Row[]
            {
                new Row
                {
                    Elements = new Element[]
                    {
                        new Element
                        {
                            Distance = new Distance
                            {
                                Text = $"{distance} km",
                                Value = distanceValue
                            },
                            Duration = new Duration
                            {
                                Text = $"{durationHour} hours {durationMinute} mins",
                                Value = durationValue
                            },
                            Status = "OK"
                        }
                    }
                },
            },
            Status = "OK"
        };
    }
}
