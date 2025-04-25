using EcoSimGame.Models.Energy;

namespace EcoSimGame.Models.Slot;

public class PowerPlantSlot
{
    public bool IsOccupied { get; set; }
    public EnergyProduction? Building { get; set; }

    public int EnergyPerTick => Building?.EnergyPerTick ?? 0;
}
