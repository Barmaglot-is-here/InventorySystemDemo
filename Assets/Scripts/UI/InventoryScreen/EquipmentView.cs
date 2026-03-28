using Game.EquipmentSystem;
using Game.InventorySystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class EquipmentView : MonoBehaviour
    {
        [SerializeField]
        private SlotView _helmetSlot;
        [SerializeField]
        private SlotView _armorSlot;
        [SerializeField]
        private SlotView _weapon1Slot;
        [SerializeField]
        private SlotView _weapon2Slot;
        [SerializeField]
        private SlotView _necklaceSlot;
        [SerializeField]
        private SlotView _pouch1Slot;
        [SerializeField]
        private SlotView _pouch2Slot;

        private IEnumerable<SlotView> _slots;

        private Equipment _equipment;

        public event Action<InventoryItem> OnSlotDoubleClick;

        private void Awake()
        {
            _slots = new SlotView[]
            {
                _helmetSlot,
                _armorSlot,
                _weapon1Slot,
                _weapon2Slot,
                _necklaceSlot,
                _pouch1Slot,
                _pouch2Slot
            };
        }

        public void Bind(Equipment equipment)
        {
            _equipment = equipment;

            _helmetSlot.Bind(equipment.Head);
            _armorSlot.Bind(equipment.Body);
            _weapon1Slot.Bind(equipment.Hand1);
            _weapon2Slot.Bind(equipment.Hand2);
            _necklaceSlot.Bind(equipment.Neck);
            _pouch1Slot.Bind(equipment.Pouch1);
            _pouch2Slot.Bind(equipment.Pouch2);
        }

        private void OnEnable()
        {
            foreach (var slot in _slots)
                slot.OnDoubleClick += OnDoubleClick;
        }

        private void OnDisable()
        {
            foreach (var slot in _slots)
                slot.OnDoubleClick -= OnDoubleClick;
        }

        private void OnDoubleClick(InventoryItem item) => OnSlotDoubleClick.Invoke(item);
    }
}
