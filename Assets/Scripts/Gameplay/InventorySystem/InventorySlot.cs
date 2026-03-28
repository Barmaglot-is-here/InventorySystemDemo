using System;

namespace Game.InventorySystem
{
    public class InventorySlot : ISlotData
    {
        private InventoryItem _item;

        public InventoryItem Item
        {
            get => _item;
            private set
            {
                _item = value;

                OnPlace?.Invoke(value);
            }
        }

        public bool IsEmpty => Item == null;

        public event Action<InventoryItem> OnPlace;

        public void Place(InventoryItem item)
        {
            if (!IsEmpty)
                throw new Exception("Slot is busy");

            ValidateItem(item);

            Item = item;
        }

        protected virtual void ValidateItem(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException("Item is null. Use Emptify() to remove item");
        }

        public void DisplacementPlace(InventoryItem item, out InventoryItem desplacedItem)
        {
            desplacedItem = Item;

            Emptify();
            Place(item);
        }

        public bool TryDisplacementPlace(InventoryItem item, out InventoryItem desplacedItem)
        {
            desplacedItem = Item;

            Emptify();

            if (!TryPlace(item))
            {
                Item = desplacedItem;

                desplacedItem = null;

                return false;
            }

            return true;
        }

        public bool TryPlace(InventoryItem item)
        {
            if (!IsEmpty || !IsItemValid(item))
                return false;

            Item = item;

            return true;
        }

        protected virtual bool IsItemValid(InventoryItem item)
        {
            if (item == null)
                return false;

            return true;
        }

        public void Swap(InventorySlot otherSlot)
        {
            if (!otherSlot.TryDisplacementPlace(Item, out var dispacedItem))
                return;

            Emptify();

            if (dispacedItem == null)
                return;

            if (!TryPlace(dispacedItem))
            {
                Place(otherSlot.Item);

                otherSlot.Emptify();
                otherSlot.Place(dispacedItem);
            }
        }

        public void Emptify() => Item = null;
    }
}
