using System;

namespace Game.InventorySystem
{
    public interface ISlotData
    {
        bool IsEmpty { get; }
        InventoryItem Item { get; }
        event Action<InventoryItem> OnPlace;
    }
}