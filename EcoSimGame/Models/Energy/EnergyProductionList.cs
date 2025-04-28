namespace EcoSimGame.Models.Energy;

public class EnergyProductionList
{
    public static List<EnergyProduction> AllBuildings { get; } = new List<EnergyProduction>
    {
        new EnergyProduction("Elektrownia wiatrowa", 1, 500),
        new EnergyProduction("Elektrownia solarna", 3, 1100),
        new EnergyProduction("Elektrownia geotermalna", 6, 2100),
        new EnergyProduction("Elektrownia plazmowa", 10, 3500),
        new EnergyProduction("Elektrownia fuzyjna", 16, 5600),
        new EnergyProduction("Elektrownia antymaterii", 25, 8500),
    };
}