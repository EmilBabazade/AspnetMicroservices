namespace GoogleMapInfo.ResponseModel;

public record Row
{
    public Element[] Elements { get; set; } = Array.Empty<Element>();
}
