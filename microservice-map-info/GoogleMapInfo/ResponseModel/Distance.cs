namespace GoogleMapInfo.ResponseModel;

public record Distance
{
    public string Text { get; set; } = string.Empty;
    public int Value { get; set; }
}
