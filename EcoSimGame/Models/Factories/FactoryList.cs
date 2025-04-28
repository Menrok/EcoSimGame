namespace EcoSimGame.Models.Factories;

public static class FactoryList
{
    public static List<Factory> AllFactories { get; } = new()
    {
        new Factory("Fabryka Przetwórstwa", "Produkcja materiałów przetworzonych", new List<string>
        {
            "Ferron", "Plastium", "Quarzite", "Voltite"
        }, 1500, 3),

        new Factory("Fabryka Półproduktów", "Produkcja półproduktów z materiałów", new List<string>
        {
            "Ferron Frame", "Plastoid Sheet", "Quarz Chip", "Volt Core"
        }, 4000, 5),

        new Factory("Fabryka Komponentów", "Produkcja komponentów zaawansowanych", new List<string>
        {
            "NanoStructure", "Quantum CPU"
        }, 8000, 8),

        new Factory("Montownia", "Montaż finalnego projektu", new List<string>
        {
            "Stacja Kolonizacyjna"
        }, 20000, 15)
    };

    public static Factory GetByName(string name) =>
        AllFactories.FirstOrDefault(f => f.Name == name)
        ?? throw new Exception($"Fabryka {name} nie istnieje.");
}
