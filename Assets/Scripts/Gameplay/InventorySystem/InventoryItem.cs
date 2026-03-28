using Game.Configs;
using UnityEngine;

namespace Game.InventorySystem
{
    public abstract class InventoryItem
    {
        public Sprite Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected InventoryItem(InventoryItemConfig config)
        {
            Icon        = config.Icon;
            Name        = config.Name;
            Description = config.Description;
        }
    }
}
