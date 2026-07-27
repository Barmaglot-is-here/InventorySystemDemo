using System;

namespace Game.InventorySystem
{
    public class InventorySlot : ISlotData
    {
        private IInventoryItem _item;

        public IInventoryItem Item
        {
            get => _item;
            private set
            {
                _item = value;

                OnPlace?.Invoke(value);
            }
        }

        public bool IsEmpty => Item == null;

        public event Action<IInventoryItem> OnPlace;

        public void Place(IInventoryItem item)
        {
            ValidateItem(item);

            if (!IsEmpty)
                throw new InvalidOperationException("Slot is busy");

            Item = item;
        }

        public bool TryPlace(IInventoryItem item)
        {
            if (CanPlace(item))
                Item = item;

            return false;
        }

        private bool CanPlace(IInventoryItem item)
        {
            if (!IsEmpty || !IsItemValid(item))
                return false;

            return true;
        }

        protected virtual void ValidateItem(IInventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException("Item is null. Use Emptify() to remove them");
        }

        protected virtual bool IsItemValid(IInventoryItem item)
        {
            if (item == null)
                return false;

            return true;
        }

        public void DisplacementPlace(IInventoryItem item, out IInventoryItem desplacedItem)
        {
            ValidateItem(item);

            desplacedItem = Item;
            Item = item;
        }

        public bool TryDisplacementPlace(IInventoryItem item, out IInventoryItem desplacedItem)
        {
            if (!IsItemValid(item))
            {
                desplacedItem = null;

                return false;
            }

            desplacedItem = Item;
            Item = item;

            return true;
        }

        public void Swap(InventorySlot otherSlot)
        {
            if (otherSlot == null)
                throw new ArgumentNullException(nameof(otherSlot));

            if (ReferenceEquals(this, otherSlot))
                throw new InvalidOperationException("Can't swap by it self");

            var currentSlotItem = _item;
            var otherSlotItem   = otherSlot.Item;

            if ((currentSlotItem == null || otherSlot.IsItemValid(currentSlotItem)) && 
                (otherSlotItem == null || IsItemValid(otherSlotItem)))
            {
                Item            = otherSlotItem;
                otherSlot.Item  = currentSlotItem;
            }
        }

        public void Emptify() => Item = null;
    }
}
