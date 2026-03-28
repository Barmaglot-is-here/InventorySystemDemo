using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "InventoryItemConfig", menuName = "Configs/InventoryItemConfig")]
    public class InventoryItemConfig : ScriptableObject
    {
        [field: SerializeField]
        public Sprite Icon { get; private set; }
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string Description { get; private set; }
    }
}
