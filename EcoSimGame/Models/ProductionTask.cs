namespace EcoSimGame.Models;

public class ProductionTask
{
    public string ProductName { get; set; }
    public int DurationSeconds { get; set; }
    public int TimeRemaining { get; set; }
    public int EnergyCost { get; set; }
    public Dictionary<string, int> Ingredients { get; set; } = new();
    public string OutputMaterial { get; set; }
    public int OutputQuantity { get; set; } = 1;
    public DateTime StartTime { get; set; }
}