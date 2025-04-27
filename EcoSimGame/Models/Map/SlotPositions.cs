using EcoSimGame.Models.Slot;

namespace EcoSimGame.Models.Map;

public static class SlotPositions
{
    public static readonly Dictionary<int, SlotPosition> PowerPlantSlotPositions = new()
    {
        [0] = new SlotPosition { X = 800, Y = 400 },
        [1] = new SlotPosition { X = 920, Y = 400 },
        [2] = new SlotPosition { X = 1040, Y = 400 },
        [3] = new SlotPosition { X = 1160, Y = 400 },
        [4] = new SlotPosition { X = 1280, Y = 400 },
    };

    public static readonly Dictionary<int, SlotPosition> EnergyStorageSlotPositions = new()
    {
        [0] = new SlotPosition { X = 560, Y = 320 },
        [1] = new SlotPosition { X = 680, Y = 320 },
    };

    public static readonly Dictionary<int, SlotPosition> WarehouseSlotPositions = new()
    {
        [0] = new SlotPosition { X = 250, Y = 500 },
        [1] = new SlotPosition { X = 250, Y = 620 },
        [2] = new SlotPosition { X = 250, Y = 740 },
        [3] = new SlotPosition { X = 250, Y = 860 },
    };

    public static readonly Dictionary<int, SlotPosition> FactorySlotPositions = new()
    {
        [0] = new SlotPosition { X = 400, Y = 500 },
        [1] = new SlotPosition { X = 520, Y = 500 },
        [2] = new SlotPosition { X = 640, Y = 500 },
        [3] = new SlotPosition { X = 760, Y = 500 },
        [4] = new SlotPosition { X = 400, Y = 620 },
        [5] = new SlotPosition { X = 520, Y = 620 },
        [6] = new SlotPosition { X = 640, Y = 620 },
        [7] = new SlotPosition { X = 760, Y = 620 },
        [8] = new SlotPosition { X = 400, Y = 740 },
        [9] = new SlotPosition { X = 520, Y = 740 },
        [10] = new SlotPosition { X = 640, Y = 740 },
        [11] = new SlotPosition { X = 760, Y = 740 },
        [12] = new SlotPosition { X = 400, Y = 860 },
        [13] = new SlotPosition { X = 520, Y = 860 },
        [14] = new SlotPosition { X = 640, Y = 860 },
        [15] = new SlotPosition { X = 760, Y = 860 },
    };
}
