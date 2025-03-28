using EcoSimGame.Models.AuthModels;

namespace EcoSimGame.Models.GameModels;

public class Player
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}