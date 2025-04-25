namespace EcoSimGame.Models.List;

public static class FactoryList
{
    public static List<Factory> AllFactories { get; } = new()
    {
        new Factory("Fabryka przetwórstwa", "Produkcja materiałów przetworzonych", new List<string>
        {
            "Sztabka żelaza", "Sztabka miedzi", "Sztabka krzemu", "Sztabka litu", "Plastik", "Kompozyt węglowy"
        }, 100, 2),

        new Factory("Fabryka silników", "Produkcja komponentów do napędu", new List<string>
        {
            "Silnik główny", "Komora spalania"
        }, 250, 4),

        new Factory("Fabryka elektroniki", "Produkcja komponentów do komputera", new List<string>
        {
            "Płyta główna", "Moduł pamięci"
        }, 250, 4),

        new Factory("Fabryka zbiorników", "Produkcja komponentów zbiorników", new List<string>
        {
            "Stal konstrukcyjna", "Powłoka antykorozyjna"
        }, 250, 4),

        new Factory("Fabryka kadłubów", "Produkcja komponentów kadłuba", new List<string>
        {
            "Panel kompozytowy", "Stelaż wewnętrzny"
        }, 250, 4),

        new Factory("Fabryka zaawansowana", "Składanie komponentów zaawansowanych", new List<string>
        {
            "Napęd rakietowy", "Komputer pokładowy", "Zbiornik paliwa", "Kadłub rakiety"
        }, 400, 6),

        new Factory("Fabryka rakiet", "Produkcja finalnej rakiety kosmicznej", new List<string>
        {
            "Rakieta kosmiczna"
        }, 800, 10),
    };

    public static Factory GetByName(string name) =>
        AllFactories.FirstOrDefault(f => f.Name == name)
        ?? throw new Exception($"Fabryka {name} nie istnieje.");
}
