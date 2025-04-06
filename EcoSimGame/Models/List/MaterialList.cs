namespace EcoSimGame.Models.List;

public class MaterialList
{
    public static List<Material> AllMaterials { get; } = new()
        {
            new Material("Drewno", 10),
            new Material("Ruda żelaza", 15),
            new Material("Miedź", 20),
            new Material("Cyna", 25),
            new Material("Ruda złota", 50),
            new Material("Ruda srebra", 30),
            
            new Material("Sztabka żelaza", 40, "Przetapianie żelaza"),
            new Material("Sztabka mosiądzu", 60, "Przetapianie mosiądzu"),
            new Material("Sztabka stali", 80, "Przetapianie stali"),
            new Material("Sztabka złota", 120, "Przetapianie złota"),
            new Material("Sztabka srebra", 100, "Przetapianie srebra"),
            new Material("Sztabka platyny", 150, "Przetapianie platyny"),
            
            new Material("Sztabka mithrilu", 200, "Przetapianie mithrilu")
        };

    public static Material GetByName(string name) =>
        AllMaterials.FirstOrDefault(m => m.Name == name)
        ?? throw new Exception($"Materiał {name} nie istnieje.");
}