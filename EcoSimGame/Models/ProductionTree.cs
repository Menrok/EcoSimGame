namespace EcoSimGame.Models;

public class ProductionTree
{
    public List<ProductionNode> Nodes { get; set; }

    public ProductionTree()
    {
        Nodes = new List<ProductionNode>
        {
            new ProductionNode("Narzędzia", 100, "Produkcja narzędzi", 1000),
            new ProductionNode("Odzież", 100, "Produkcja Odzieży", 1000),
        };
    }
}