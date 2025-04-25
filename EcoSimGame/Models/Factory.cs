namespace EcoSimGame.Models;

public class Factory
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> Productions { get; set; }
    public decimal BuildCost { get; set; }
    public int EnergyCostPerTick { get; set; }
    public Factory(string name, string description, List<string> productions, decimal buildCost, int energyCostPerTick)
    {
        Name = name;
        Description = description;
        Productions = productions;
        BuildCost = buildCost;
        EnergyCostPerTick = energyCostPerTick;
    }
}