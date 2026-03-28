using Game.Configs;
using Game.InventorySystem;
using Game.Items;
using UnityEngine;

namespace Game.Tests
{
    public class InventoryItemsGenerator : MonoBehaviour
    {
        [SerializeField]
        private InventoryItemConfig[] _weaponConfigs;
        [SerializeField]
        private InventoryItemConfig[] _helmetConfigs;

        public void Fill(Inventory inventory, int itemsCount)
        {
            for (; itemsCount > 0; itemsCount--)
            {
                var item = GenerateRandom();

                inventory.Add(item);
            }
        }

        private InventoryItem GenerateRandom()
        {
            var typeIndex = Random.Range(0, 2);

            return typeIndex == 0 ? GenerateWeapon() : GenerateHelmet();
        }

        private Weapon GenerateWeapon()
        {
            int configIndex = Random.Range(0, _weaponConfigs.Length);
            var config      = _weaponConfigs[configIndex];

            return new Weapon(config);
        }

        private Helmet GenerateHelmet()
        {
            int configIndex = Random.Range(0, _helmetConfigs.Length);
            var config      = _helmetConfigs[configIndex];

            return new Helmet(config);
        }
    }
}
