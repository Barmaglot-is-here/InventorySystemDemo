using Game.Configs;
using Game.EquipmentSystem;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Items
{
    public abstract class BaseItem : IEquipmnentItem
    {
        public abstract SlotType Type { get; }

        public Sprite Icon { get; }
        public string Name { get; }

        public string Description { get; }

        public BaseItem(InventoryItemConfig config)
        {
            Icon = config.Icon;
            Name = config.Name;
            Description = config.Description;
        }
    }
}
