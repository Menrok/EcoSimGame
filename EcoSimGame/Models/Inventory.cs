using EcoSimGame.Models.List;

namespace EcoSimGame.Models;

public class Inventory
{
    public List<MaterialStock> Stocks { get; set; }

    public Inventory()
    {
        Stocks = MaterialList.AllMaterials.Select(m => new MaterialStock(m.Name)).ToList();
    }

    public void Add(string materialName, int amount)
    {
        var stock = Stocks.FirstOrDefault(s => s.MaterialName == materialName);
        if (stock != null)
            stock.Quantity += amount;
    }

    public bool Remove(string materialName, int amount)
    {
        var stock = Stocks.FirstOrDefault(s => s.MaterialName == materialName);
        if (stock != null && stock.Quantity >= amount)
        {
            stock.Quantity -= amount;
            return true;
        }
        return false;
    }

    public int GetQuantity(string materialName)
    {
        return Stocks.FirstOrDefault(s => s.MaterialName == materialName)?.Quantity ?? 0;
    }

    public List<MaterialStock> GetAllWithQuantity()
    {
        return Stocks.Where(s => s.Quantity > 0).ToList();
    }
}