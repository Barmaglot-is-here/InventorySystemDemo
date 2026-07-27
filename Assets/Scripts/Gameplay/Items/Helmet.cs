using Assets.Scripts.Gameplay.Items;
using Game.Configs;
using Game.EquipmentSystem;

namespace Game.Items
{
    public class Helmet : BaseItem
    {
        public override SlotType Type => SlotType.Helmet;

        public Helmet(InventoryItemConfig config) : base(config)
        {
        }
    }
}
