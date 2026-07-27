using Game.InventorySystem;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    public class SlotView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        [SerializeField]
        private Image _icon;

        private Transform _dragZone;

        private InventorySlot _slot;

        private RectTransform IconRect => _icon.rectTransform;

        public IInventoryItem CurrentItem => _slot.Item;

        public event Action<IInventoryItem> OnDoubleClick;

        [Inject]
        public void Construct(Transform dragZone)
        {
            _dragZone = dragZone;
        }

        public void Bind(InventorySlot slot)
        {
            OnPlace(slot.Item);

            _slot = slot;

            _slot.OnPlace += OnPlace;
        }

        protected virtual void OnPlace(IInventoryItem item)
        {
            if (item != null)
            {
                _icon.gameObject.SetActive(true);
                _icon.sprite = item.Icon;
            }
            else
                _icon.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _slot.OnPlace -= OnPlace;
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
            => OnBeginDrag(eventData);

        protected virtual void OnBeginDrag(PointerEventData eventData)
            => IconRect.SetParent(_dragZone);

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            IconRect.position = eventData.position;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
            => OnEndDrag(eventData);

        protected virtual void OnEndDrag(PointerEventData eventData)
        {
            IconRect.SetParent(transform);
            IconRect.anchoredPosition = Vector3.zero;

            var dragTarget = eventData.pointerCurrentRaycast.gameObject;
            var otherView = dragTarget?.GetComponent<SlotView>();

            if (otherView != null && otherView != this)
                _slot.Swap(otherView._slot);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.clickCount >= 2)
                OnDoubleClick.Invoke(_slot.Item);
        }
    }
}
