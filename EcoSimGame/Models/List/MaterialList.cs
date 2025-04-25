using EcoSimGame.Models;

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
    new Material("Sztabka krzemu", 90),
    new Material("Sztabka litu", 120),
    new Material("Plastik", 130),
    new Material("Kompozyt węglowy", 125),

    // Do Napędu rakietowego
    new Material("Silnik główny", 230, "Produkcja silnika głównego"),
        // Sztabka żelaza, Sztabka miedzi
    new Material("Komora spalania", 220, "Produkcja komory spalania"),
        // Sztabka żelaza, Sztabka krzemu

    // Do Komputera pokładowego
    new Material("Płyta główna", 210, "Produkcja płyt głównych"),
        // Sztabka krzemu, Sztabka miedzi
    new Material("Moduł pamięci", 190, "Produkcja pamięci"),
        // Sztabka krzemu, Plastik

    // Do Zbiornika paliwa
    new Material("Stal konstrukcyjna", 200, "Produkcja stali konstrukcyjnej"),
        // Sztabka żelaza, Kompozyt węglowy
    new Material("Powłoka antykorozyjna", 190, "Produkcja powłok"),
        // Plastik, Sztabka litu

    // Do Kadłuba rakiety
    new Material("Panel kompozytowy", 195, "Produkcja paneli kompozytowych"),
        // Kompozyt węglowy, Sztabka krzemu
    new Material("Stelaż wewnętrzny", 180, "Produkcja stelaży"),
        // Sztabka żelaza, Plastik

    // Zaawansowane komponenty
    new Material("Napęd rakietowy", 400, "Produkcja napędu rakietowego"),
    new Material("Komputer pokładowy", 380, "Produkcja komputera pokładowego"),
    new Material("Zbiornik paliwa", 360, "Produkcja zbiorników"),
    new Material("Kadłub rakiety", 340, "Produkcja kadłubów"),

    // Produkt końcowy
    new Material("Rakieta kosmiczna", 2200, "Produkcja rakiety")
};

    public static Material GetByName(string name) =>
        AllMaterials.FirstOrDefault(m => m.Name == name)
        ?? throw new Exception($"Materiał {name} nie istnieje.");
}