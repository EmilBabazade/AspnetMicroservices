using System.Text.Json;

namespace Monolith;

public interface IDistanceInfoSvc
{
    Task<(int, string)> GetDistanceAsync(string originCity, string destinationCity);
}

public class DistanceInfoSvc : IDistanceInfoSvc
{
    private readonly IHttpClientFactory httpClientFactory;

    public DistanceInfoSvc(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Call the micoservice to retrieve distance between two cities.
    /// </summary>
    /// <param name="originCity"></param>
    /// <param name="destinationCity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<(int, string)> GetDistanceAsync(string originCity, string destinationCity)
    {
        var httpClient = this.httpClientFactory.CreateClient("DistanceMicroservice");
        var microserviceUrl = $"?originCity={originCity}&destinationCity={destinationCity}";
        var responseStream = await httpClient.GetStreamAsync(microserviceUrl);
        var distanceData = await JsonSerializer.DeserializeAsync<MapDistanceInfo>(responseStream);
        var distance = 0;

        var distanceType = "";
        foreach (var row in distanceData.Rows)
            foreach (var rowElement in row.Elements)
            {
                if (int.TryParse(CleanDistanceInfo(rowElement.Distance.Text), out var distanceConverted))
                {
                    distance += distanceConverted;
                    if (rowElement.Distance.Text.EndsWith("mi")) distanceType = "miles";
                    if (rowElement.Distance.Text.EndsWith("km")) distanceType = "kilometers";
                }
            }
        return (distance, distanceType);
    }

    private static string CleanDistanceInfo(string value) =>
        value
            .Replace("mi", "")
            .Replace("km", "")
            .Replace(",", "")
}

// Classes are based on the data structure returned by distance API

public record MapDistanceInfo
{
    public string[] DestinationAddresses { get; set; } = Array.Empty<string>();
    public string[] OriginAddresses { get; set; } = Array.Empty<string>();
    public Row[] Rows { get; set; } = Array.Empty<Row>();
    public string Status { get; set; } = string.Empty;
}

public record Row
{
    public Element[] Elements { get; set; } = Array.Empty<Element>();
}

public record Element
{
    public Distance Distance { get; set; } = new();
    public Duration Duration { get; set; } = new();
    public string Status { get; set; } = string.Empty;
}

public record Distance
{
    public string Text { get; set; } = string.Empty;
    public int Value { get; set; }
}

public record Duration
{
    public string Text { get; set; } = string.Empty;
    public int Value { get; set; }
}
