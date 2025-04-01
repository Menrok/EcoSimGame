namespace EcoSimGame.Models;

public class Inventory
{
    public Dictionary<string, int> Materials { get; set; }

    public Inventory()
    {
        Materials = new Dictionary<string, int>
        {
            { "Drewno", 0 },
            { "Ruda Żelaza", 0 },
            { "Sztabka Żelaza", 0 }
        };
    }

    public void AddMaterial(string material, int amount)
    {
        if (Materials.ContainsKey(material))
        {
            Materials[material] += amount;
        }
    }

    public bool RemoveMaterial(string material, int amount)
    {
        if (Materials.ContainsKey(material) && Materials[material] >= amount)
        {
            Materials[material] -= amount;
            return true;
        }
        return false;
    }

    public int GetMaterialAmount(string material)
    {
        return Materials.ContainsKey(material) ? Materials[material] : 0;
    }

    public Dictionary<string, int> GetAllMaterials()
    {
        return Materials.Where(m => m.Value > 0).ToDictionary(m => m.Key, m => m.Value);
    }
}