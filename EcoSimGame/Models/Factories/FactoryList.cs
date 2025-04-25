namespace EcoSimGame.Models.Factories;

public static class FactoryList
{
    public static List<Factory> AllFactories { get; } = new()
    {
        new Factory("Fabryka przetwórstwa", "Produkcja materiałów przetworzonych", new List<string>
        {
            "Sztabka żelaza", "Sztabka miedzi", "Sztabka krzemu", "Sztabka litu", "Plastik", "Kompozyt węglowy"
        }, 1500, 3),

        new Factory("Fabryka silników", "Produkcja komponentów do napędu", new List<string>
        {
            "Silnik główny", "Komora spalania"
        }, 5000, 5),

        new Factory("Fabryka elektroniki", "Produkcja komponentów do komputera", new List<string>
        {
            "Płyta główna", "Moduł pamięci"
        }, 5000, 5),

        new Factory("Fabryka zbiorników", "Produkcja komponentów zbiorników", new List<string>
        {
            "Stal konstrukcyjna", "Powłoka antykorozyjna"
        }, 5000, 5),

        new Factory("Fabryka kadłubów", "Produkcja komponentów kadłuba", new List<string>
        {
            "Panel kompozytowy", "Stelaż wewnętrzny"
        }, 5000, 5),

        new Factory("Fabryka zaawansowana", "Składanie komponentów zaawansowanych", new List<string>
        {
            "Napęd rakietowy", "Komputer pokładowy", "Zbiornik paliwa", "Kadłub rakiety"
        }, 12000, 10),

        new Factory("Fabryka rakiet", "Produkcja finalnej rakiety kosmicznej", new List<string>
        {
            "Rakieta kosmiczna"
        }, 25000, 50),
    };

    public static Factory GetByName(string name) =>
        AllFactories.FirstOrDefault(f => f.Name == name)
        ?? throw new Exception($"Fabryka {name} nie istnieje.");
}
