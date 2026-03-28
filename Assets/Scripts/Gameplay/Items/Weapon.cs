using Game.Configs;
using Game.EquipmentSystem;

namespace Game.Items
{
    public class Weapon : EquipmnentItem
    {
        public override SlotType Type => SlotType.Weapon;

        public Weapon(InventoryItemConfig config) : base(config)
        {
        }
    }
}
