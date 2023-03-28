using GoogleMapInfo;
using GoogleMapInfo.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace microservice_map_info.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MapInfoController : ControllerBase
{
    private readonly IGoogleDistanceApi googleDistanceApi;

    public MapInfoController(IGoogleDistanceApi googleDistanceApi)
    {
        this.googleDistanceApi = googleDistanceApi;
    }

    [HttpGet]
    public async Task<GoogleDistanceData> GetDistance(string originCity, string destinationCity) =>
        await this.googleDistanceApi.GetMapDistance(originCity, destinationCity);
}
