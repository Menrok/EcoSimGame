namespace EcoSimGame.Models.Map;

public class ProductionMapState
{
    public double OffsetX { get; set; } = 0;
    public double OffsetY { get; set; } = 0;
    public double Scale { get; set; } = 1.0;

    public bool IsDragging { get; set; } = false;
    public double LastMouseX { get; set; }
    public double LastMouseY { get; set; }

    public double ContainerWidth { get; set; }
    public double ContainerHeight { get; set; }
    public double MapWidth { get; set; } = 2457;
    public double MapHeight { get; set; } = 1638;

    public string GetTransformStyle()
    {
        return $"transform: translate({(int)OffsetX}px, {(int)OffsetY}px); transition: none;";
    }
}