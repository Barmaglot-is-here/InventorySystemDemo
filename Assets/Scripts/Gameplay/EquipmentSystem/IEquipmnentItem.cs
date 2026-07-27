using Game.InventorySystem;

namespace Game.EquipmentSystem
{
    public interface IEquipmnentItem : IInventoryItem
    {
        public abstract SlotType Type { get; }
    }
}
