using System.Linq.Expressions;

namespace GoogleMapInfo.ResponseModel;
public record GoogleDistanceData
{
    public string[] DestinationAddresses { get; set; } = Array.Empty<string>();
    public string[] OriginAddresses { get; set; } = Array.Empty<string>();
    public Row[] Rows { get; set; } = Array.Empty<Row>();
    public string Status { get; set; } = string.Empty;
}
