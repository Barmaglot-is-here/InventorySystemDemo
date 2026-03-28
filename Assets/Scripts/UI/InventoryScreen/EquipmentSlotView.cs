using Game.InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public class EquipmentSlotView : SlotView
    {
        [SerializeField]
        private GameObject _slotIcon;

        protected override void OnPlace(InventoryItem item)
        {
            base.OnPlace(item);

            _slotIcon.SetActive(item == null);
        }

        protected override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);

            _slotIcon.SetActive(true);
        }

        protected override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);

            _slotIcon.SetActive(CurrentItem == null);
        }
    }
}
