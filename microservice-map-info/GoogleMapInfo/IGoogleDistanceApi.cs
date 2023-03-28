using GoogleMapInfo.ResponseModel;

namespace GoogleMapInfo;
public interface IGoogleDistanceApi
{
    Task<GoogleDistanceData> GetMapDistance(string originCity, string destinationCity);
}
