namespace EcoSimGame.Models;

public class EnergyProduction
{
    public string Name { get; set; }
    public int EnergyPerTick { get; set; }
    public decimal Cost { get; set; }
    public int Count { get; set; } = 0;

    public EnergyProduction(string name, int energyPerTick, decimal cost)
    {
        Name = name;
        EnergyPerTick = energyPerTick;
        Cost = cost;
    }
}
