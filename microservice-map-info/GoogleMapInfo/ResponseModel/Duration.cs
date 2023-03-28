namespace GoogleMapInfo.ResponseModel;

public record Duration
{
    public string Text { get; set; } = string.Empty;
    public int Value { get; set; }
}