namespace EcoSimGame.Models;

public class Player
{
    public string Name { get; set; }
    public decimal Money { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public Inventory Inventory { get; set; }
    public DateTime? LastProcessingTime { get; set; }
    public List<string> OwnedSchematics { get; set; }

    public Player()
    {
        Name = "Menrok";
        Money = 100.0m;
        Level = 1;
        Experience = 0;
        Inventory = new Inventory();
        OwnedSchematics = new List<string>();
    }

    public void AddExperience(int amount)
    {
        Experience += amount;
        if (Experience >= 100)
        {
            Experience -= 100;
            Level++;
        }
    }

    public bool BuySchematioc(string schematicName)
    {
        if(!OwnedSchematics.Contains(schematicName))
        {
            OwnedSchematics.Add(schematicName);
            return true;
        }
        return false;
    }

    public bool HasSchematic(string schematicName) => OwnedSchematics.Contains(schematicName);
}