namespace EcoSimGame.Models.Materials;

public class MaterialList
{
    public static List<Material> AllMaterials { get; } = new()
{
    // Surowce
    new Material("Ruda żelaza", 40),
    new Material("Ruda miedzi", 45),
    new Material("Ruda krzemu", 35),
    new Material("Ruda litu", 60),
    new Material("Ropa naftowa", 65),
    new Material("Włókno węglowe", 55),

    // Materiały przetworzone
    new Material("Sztabka żelaza", 100),
    new Material("Sztabka miedzi", 110),
    new Material("Sztabka krzemu", 105),
    new Material("Sztabka litu", 120),
    new Material("Plastik", 130),
    new Material("Kompozyt węglowy", 140),

    // Do Napędu rakietowego
    new Material("Silnik główny", 250, "Produkcja silnika głównego"),
        // Sztabka żelaza, Sztabka miedzi
    new Material("Komora spalania", 230, "Produkcja komory spalania"),
        // Sztabka żelaza, Sztabka krzemu

    // Do Komputera pokładowego
    new Material("Płyta główna", 240, "Produkcja płyt głównych"),
        // Sztabka krzemu, Sztabka miedzi
    new Material("Moduł pamięci", 210, "Produkcja pamięci"),
        // Sztabka krzemu, Plastik

    // Do Zbiornika paliwa
    new Material("Stal konstrukcyjna", 220, "Produkcja stali konstrukcyjnej"),
        // Sztabka żelaza, Kompozyt węglowy
    new Material("Powłoka antykorozyjna", 200, "Produkcja powłok"),
        // Plastik, Sztabka litu

    // Do Kadłuba rakiety
    new Material("Panel kompozytowy", 230, "Produkcja paneli kompozytowych"),
        // Kompozyt węglowy, Sztabka krzemu
    new Material("Stelaż wewnętrzny", 190, "Produkcja stelaży"),
        // Sztabka żelaza, Plastik

    // Zaawansowane komponenty
    new Material("Napęd rakietowy", 600, "Produkcja napędu rakietowego"),
    new Material("Komputer pokładowy", 580, "Produkcja komputera pokładowego"),
    new Material("Zbiornik paliwa", 560, "Produkcja zbiorników"),
    new Material("Kadłub rakiety", 540, "Produkcja kadłubów"),

    // Produkt końcowy
    new Material("Rakieta kosmiczna", 3000, "Produkcja rakiety")
};

    public static Material GetByName(string name) =>
        AllMaterials.FirstOrDefault(m => m.Name == name)
        ?? throw new Exception($"Materiał {name} nie istnieje.");
}