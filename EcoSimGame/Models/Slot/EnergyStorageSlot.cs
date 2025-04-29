namespace EcoSimGame.Models.Slot;

public class EnergyStorageSlot
{
    public bool IsBuilt { get; set; } = false;
    public int Level { get; set; } = 1;
    public int Capacity { get; set; } = 1000;
    public int UpgradeCost => 1000 * Level;

    public SlotPosition SlotPosition { get; set; } = new SlotPosition();

    public void Upgrade()
    {
        Level++;
        Capacity += 100;
    }
}