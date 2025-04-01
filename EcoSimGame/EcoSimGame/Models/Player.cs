namespace EcoSimGame.Models;

public class Player
{
    public decimal Money { get; set; }
    public Dictionary<string, int> Materials { get; set; }
    public int IronBars { get; set; } 
    public DateTime? LastProcessingTime { get; set; }

    public Player()
    {
        Money = 100.0m;
        Materials = new Dictionary<string, int>
        {
            { "Drewno", 0 },
            { "Ruda Żelaza", 0 }
        };
        IronBars = 0;
    }
}
