using Assets.Scripts.Gameplay.Items;
using Game.Configs;
using Game.EquipmentSystem;

namespace Game.Items
{
    public class Weapon : BaseItem
    {
        public override SlotType Type => SlotType.Weapon;

        public Weapon(InventoryItemConfig config) : base(config)
        {
        }
    }
}
