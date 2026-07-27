using Game.InventorySystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private Transform _slotsContainer;
        [SerializeField]
        private SlotsViewFactory _slotsFactory;

        private List<SlotView> _slotViews;

        private Inventory _inventory;

        public event Action<IInventoryItem> OnSlotDoubleClick;

        public void Bind(Inventory inventory)
        {
            _inventory  = inventory;
            _slotViews  = _slotsFactory.Create(_slotsContainer, inventory);

            InitViews(_slotViews);
        }

        private void InitViews(IEnumerable<SlotView> views)
        {
            foreach (var view in views)
                view.OnDoubleClick += OnDoubleClick;
        }

        private void OnDoubleClick(IInventoryItem item) => OnSlotDoubleClick.Invoke(item);

        private void OnDestroy()
        {
            foreach (var slot in _slotViews)
                slot.OnDoubleClick -= OnDoubleClick;
        }
    }
}
