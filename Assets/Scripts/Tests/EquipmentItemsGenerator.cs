using Game.Configs;
using Game.EquipmentSystem;
using Game.Items;
using UnityEngine;

namespace Game.Tests
{
    public class EquipmentItemsGenerator : MonoBehaviour
    {
        [SerializeField]
        private InventoryItemConfig _weaponConfig;
        [SerializeField]
        private InventoryItemConfig _helmetConfig;

        public void Fill(Equipment equipment)
        {
            Weapon item     = new(_weaponConfig);
            Helmet helmet   = new(_helmetConfig);

            equipment.Equip(item);
            equipment.Equip(helmet);
        }
    }
}
