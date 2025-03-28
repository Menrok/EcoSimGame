using EcoSimGame.Models.AuthModels;

namespace EcoSimGame.Models.GameModels;

public class Inventory
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; }

    public int MaterialId { get; set; }
    public Material Material { get; set; }
    public int MaterialQuantity { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int ProductQuantity { get; set; }
}