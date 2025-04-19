namespace EcoSimGame.Models.List;

public class EnergyProductionList
{
    public static List<EnergyProduction> AllBuildings { get; } = new List<EnergyProduction>
    {
        new EnergyProduction("Wiatrak", 1, 500),
        new EnergyProduction("Panele słoneczne", 4, 1500),
        new EnergyProduction("Elektrownia wodna", 15, 5000)
    };
}