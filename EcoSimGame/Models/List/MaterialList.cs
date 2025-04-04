namespace EcoSimGame.Models.List;

public class MaterialList
{
    public static List<Material> AllMaterials { get; } = new()
    {
        new Material { Name = "Drewno", Price = 10 },
        new Material { Name = "Ruda żelaza", Price = 15 },
        new Material { Name = "Sztabka żelaza", Price = 40 }
    };

    public static Material GetByName(string name) =>
        AllMaterials.FirstOrDefault(m => m.Name == name)
        ?? throw new Exception($"Materiał {name} nie istnieje.");
}