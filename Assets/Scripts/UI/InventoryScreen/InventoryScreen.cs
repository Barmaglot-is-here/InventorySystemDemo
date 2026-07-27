using Game.EquipmentSystem;
using Game.InventorySystem;
using UnityEngine;

namespace Game.UI
{
    public class InventoryScreen : MonoBehaviour
    {
        [SerializeField]
        private InventoryView _inventoryView;
        [SerializeField]
        private EquipmentView _equipmentView;

        private Inventory _inventory;
        private Equipment _equipment;

        public void Bind(Inventory inventory, Equipment equipment)
        {
            _inventory = inventory;
            _equipment = equipment;

            _inventoryView.Bind(inventory);
            _equipmentView.Bind(equipment);

            _inventoryView.OnSlotDoubleClick += OnInventorySlotDoubleClick;
            _equipmentView.OnSlotDoubleClick += OnEquipmentSlotDoubleClick;
        }

        private void OnInventorySlotDoubleClick(IInventoryItem item)
        {
            if (item is not IEquipmnentItem equipmnentItem)
                return;

            _inventory.Remove(item);
            _equipment.DisplacementEquip(equipmnentItem, out var displacedItem);

            if (displacedItem != null)
                _inventory.Add(displacedItem);
        }

        private void OnEquipmentSlotDoubleClick(IInventoryItem item)
        {
            if (_inventory.TryAdd(item))
                _equipment.Unequip(item);
        }

        private void OnDestroy()
        {
            _inventoryView.OnSlotDoubleClick -= OnInventorySlotDoubleClick;
            _equipmentView.OnSlotDoubleClick -= OnEquipmentSlotDoubleClick;
        }
    }
}
