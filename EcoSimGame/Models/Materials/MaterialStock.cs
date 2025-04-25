using System.Text.Json.Serialization;

namespace EcoSimGame.Models.Materials;

public class MaterialStock
{
    public string MaterialName { get; set; }
    public int Quantity { get; set; }

    [JsonIgnore]
    public Material Material => MaterialList.GetByName(MaterialName);

    public MaterialStock(string name)
    {
        MaterialName = name;
        Quantity = 0;
    }

    public MaterialStock() { }
}