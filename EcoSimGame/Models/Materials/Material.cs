namespace EcoSimGame.Models.Materials;

public class Material
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string RequiredSchematic { get; set; }

    public Material(string name, decimal price, string requiredSchematic = null)
    {
        Name = name;
        Price = price;
        RequiredSchematic = requiredSchematic;
    }

    public Material(string name, decimal price) : this(name, price, null) { }
}