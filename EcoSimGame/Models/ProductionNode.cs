namespace EcoSimGame.Models;

public class ProductionNode
{
    public string Name { get; set; }
    public int RequiredLevel { get; set; }
    public string? RequiredSchematic { get; set; }
    public bool IsUnlocked { get; set; }
    public decimal CostMoney { get; set; }

    public ProductionNode(string name, int requiredLevel, string? requiredSchematic, decimal costMoney)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        RequiredSchematic = requiredSchematic;
        IsUnlocked = false;
        CostMoney = costMoney;
    }

    public ProductionNode() { }
}