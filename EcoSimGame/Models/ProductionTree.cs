namespace EcoSimGame.Models;

public class ProductionTree
{
    public List<ProductionNode> Nodes { get; set; }

    public ProductionTree()
    {
        Nodes = new List<ProductionNode>
        {
            new ProductionNode("Narzędzia", 2, null, 1000),
            new ProductionNode("Odzież", 2, null, 1000)        
        };
    }
}