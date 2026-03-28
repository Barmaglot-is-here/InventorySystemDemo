using Game.InventorySystem;
using UnityEngine.EventSystems;

namespace Game.UI.DescriptionSystem
{
    public class SlotDescriptionProvider : DescriptionProvider<SlotDescriptionView, DescriptionData>, 
        IBeginDragHandler
    {
        private SlotView _slotView;

        private InventoryItem Item => _slotView.CurrentItem;

        protected override bool CanShow => Item != null;

        protected override void Awake()
        {
            base.Awake();

            _slotView = GetComponent<SlotView>();
        }

        protected override DescriptionData GetViewData()
            => new(Item.Name, Item.Description);

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
            => CancelShowTask();
    }
}
