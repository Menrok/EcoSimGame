namespace EcoSimGame.Models.Slot;

public class WarehouseSlot
{
    public bool IsBuilt { get; set; } = false;
    public int Level { get; set; } = 1;
    public int Capacity { get; set; } = 100;
    public decimal UpgradeCost { get; set; } = 1000;

    public void Upgrade()
    {
        Level++;
        Capacity += 100;
        UpgradeCost += 1000;
    }
}