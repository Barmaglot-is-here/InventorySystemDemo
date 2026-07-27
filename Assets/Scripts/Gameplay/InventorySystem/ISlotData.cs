using System;

namespace Game.InventorySystem
{
    public interface ISlotData
    {
        bool IsEmpty { get; }
        IInventoryItem Item { get; }
        event Action<IInventoryItem> OnPlace;
    }
}