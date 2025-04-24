namespace EcoSimGame.Models.List;

public class EnergyProductionList
{
    public static List<EnergyProduction> AllBuildings { get; } = new List<EnergyProduction>
    {
        new EnergyProduction("Elektrownia wiatrowa", 1, 500),
        new EnergyProduction("Elektrownia słoneczna", 3, 1100),
        new EnergyProduction("Elektrownia wodna", 6, 2100),
        new EnergyProduction("Elektrownia geotermalna", 10, 3500),
        new EnergyProduction("Elektrownia na biomasę", 16, 5600),
        new EnergyProduction("Elektrownia węglowa", 25, 8500),
        new EnergyProduction("Elektrownia gazowa", 35, 12000),
        new EnergyProduction("Elektrownia jądrowa", 50, 17000),
        new EnergyProduction("Elektrownia wodorowa", 70, 22000)
    };
}