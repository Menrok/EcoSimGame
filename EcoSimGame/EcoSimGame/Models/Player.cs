namespace EcoSimGame.Models;

public class Player
{
    public string Name { get; set; }
    public decimal Money { get; set; }
    public Inventory Inventory { get; set; }
    public DateTime? LastProcessingTime { get; set; }

    public Player()
    {
        Name = "Menrok";
        Money = 100.0m;
        Inventory = new Inventory();
    }
}