namespace EcoSimGame.Models.Materials;

public class MaterialList
{
    public static List<Material> AllMaterials { get; } = new()
{
    // Surowce
    new Material("Ferronit", 40),
    new Material("Plastotyt", 45),
    new Material("Kwarcyn", 35),
    new Material("Voltanium", 60),

    // Materiały przetworzone
    new Material("Ferron", 100),
    new Material("Plastium", 110),
    new Material("Quarzite", 105),
    new Material("Voltite", 120),

    // Półprodukty
    new Material("Ferron Frame", 250, "Produkcja silnika głównego"),
    new Material("Plastoid Sheet", 230, "Produkcja komory spalania"),
    new Material("Quarz Chip", 230, "Produkcja komory spalania"),
    new Material("Volt Core", 230, "Produkcja komory spalania"),

    // Komponenty
    new Material("NanoStructure", 600, "Produkcja napędu rakietowego"),
    new Material("Quantum CPU", 580, "Produkcja komputera pokładowego"),

    // Produkt końcowy
    new Material("Stacja Kolonizacyjna", 3000, "Produkcja rakiety")
};

    public static Material GetByName(string name) =>
        AllMaterials.FirstOrDefault(m => m.Name == name)
        ?? throw new Exception($"Materiał {name} nie istnieje.");
}