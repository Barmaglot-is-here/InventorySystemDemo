using Game.Configs;
using Game.EquipmentSystem;

namespace Game.Items
{
    public class Helmet : EquipmnentItem
    {
        public override SlotType Type => SlotType.Helmet;

        public Helmet(InventoryItemConfig config) : base(config)
        {
        }
    }
}
