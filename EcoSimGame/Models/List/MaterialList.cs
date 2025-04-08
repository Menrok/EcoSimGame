namespace EcoSimGame.Models.List;

public class MaterialList
{
    public static List<Material> AllMaterials { get; } = new()
        {
            new Material("Drewno", 10),
            new Material("Deski", 30),

            new Material("Ruda żelaza", 10),
            new Material("Sztabka żelaza", 30),

            new Material("Glina", 10),
            new Material("Cegła", 30),

            new Material("Len", 10),
            new Material("Płótno", 30),

            new Material("Narzędzia", 200, "Produkcja narzędzi"),
            new Material("Odzież", 200, "Produkcja odzieży"),
        };

    public static Material GetByName(string name) =>
        AllMaterials.FirstOrDefault(m => m.Name == name)
        ?? throw new Exception($"Materiał {name} nie istnieje.");
}