namespace EcoSimGame.Models;

public class ProductionNode
{
    public string Name { get; set; }
    public int RequiredExperience { get; set; }
    public string? RequiredSchematic { get; set; }
    public bool IsUnlocked { get; set; }
    public decimal CostMoney { get; set; }

    public ProductionNode(string name, int requiredExperience, string? requiredSchematic, decimal costMoney)
    {
        Name = name;
        RequiredExperience = requiredExperience;
        RequiredSchematic = requiredSchematic;
        IsUnlocked = false;
        CostMoney = costMoney;
    }
}
