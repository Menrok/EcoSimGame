namespace EcoSimGame.Models;

public class ProductionTree
{
    public List<ProductionNode> Nodes { get; set; }

    public ProductionTree()
    {
        Nodes = new List<ProductionNode>
        {
            new ProductionNode("Przetapianie żelaza", 50, null, 100),
            new ProductionNode("Przetapianie mosiądzu", 100, "Przetapianie żelaza", 150),
            new ProductionNode("Przetapianie stali", 200, "Przetapianie mosiądzu", 200),
            new ProductionNode("Przetapianie złota", 300, "Przetapianie stali", 300),
            new ProductionNode("Przetapianie srebra", 250, "Przetapianie stali", 250),
            new ProductionNode("Przetapianie platyny", 400, "Przetapianie srebra", 350),
            new ProductionNode("Przetapianie mithrilu", 500, "Przetapianie platyny", 500)
        };
    }
}