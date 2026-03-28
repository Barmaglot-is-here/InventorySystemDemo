using Game.UI;
using Game.EquipmentSystem;
using Game.InventorySystem;
using Game.Tests;
using UnityEngine;

namespace Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private InventoryScreen _inventoryScreen;

        [SerializeField]
        private InventoryItemsGenerator _inventoryItemsGenerator; 
        [SerializeField]
        private EquipmentItemsGenerator _equipmentItemsGenerator;

        [SerializeField]
        private int _inventorySize = 128;
        [SerializeField]
        private int _inventoryStartItemsCount = 16;

        private void Start()
        {
            Inventory inventory = new(_inventorySize);
            Equipment equipment = new();

            _inventoryItemsGenerator.Fill(inventory, _inventoryStartItemsCount);
            _equipmentItemsGenerator.Fill(equipment);

            _inventoryScreen.Bind(inventory, equipment);
        }
    }
}
