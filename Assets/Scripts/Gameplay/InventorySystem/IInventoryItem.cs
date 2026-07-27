using UnityEngine;

namespace Game.InventorySystem
{
    public interface IInventoryItem
    {
        public Sprite Icon { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
