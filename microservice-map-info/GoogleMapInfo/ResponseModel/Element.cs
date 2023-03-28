namespace GoogleMapInfo.ResponseModel;

public record Element
{
    public Distance Distance { get; set; } = new();
    public Duration Duration { get; set; } = new();
    public string Status { get; set; } = string.Empty;
}
