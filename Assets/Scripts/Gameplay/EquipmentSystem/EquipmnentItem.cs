using Game.Configs;
using Game.InventorySystem;

namespace Game.EquipmentSystem
{
    public abstract class EquipmnentItem : InventoryItem
    {
        public abstract SlotType Type { get; }

        protected EquipmnentItem(InventoryItemConfig config) : base(config)
        {

        }
    }
}
