using System;
using System.Collections.Generic;

namespace Game.InventorySystem
{
    public class Inventory
    {
        private readonly List<InventorySlot> _slots;

        public int Size { get; }
        public int ItemsCount { get; private set; }

        public InventorySlot this[int slot] => _slots[slot];

        public Inventory(int size)
        {
            Size = size;

            _slots = new(size);

            for (; size > 0; size--)
                _slots.Add(new InventorySlot());
        }

        public void Add(IInventoryItem item, int slot = -1)
        {
            if (item == null)
                throw new ArgumentNullException();

            if (ItemsCount >= Size)
                throw new InvalidOperationException("Inventory overflow");

            if (slot == -1)
                PlaceAtFirstEmptySlot(item);
            else
            {
                if (slot >= Size || slot < -1)
                    throw new IndexOutOfRangeException($"Slot index out of range: -1..{Size - 1}");

                PlaceAtSlot(item, slot);
            }
        }

        public bool TryAdd(IInventoryItem item, int slot = -1)
        {
            if (item == null || ItemsCount >= Size || slot >= Size || slot < -1)
                return false;

            if (slot == -1)
                PlaceAtFirstEmptySlot(item);
            else
                PlaceAtSlot(item, slot);

            return true;
        }

        private void PlaceAtSlot(IInventoryItem item, int index)
        {
            var slot = _slots[index];

            if (slot.IsEmpty)
                slot.Place(item);
            else
            {
                slot.DisplacementPlace(item, out var desplacedItem);

                PlaceAtFirstEmptySlot(desplacedItem);
            }

            ItemsCount++;
        }

        private void PlaceAtFirstEmptySlot(IInventoryItem item)
        {
            var emptySlot = GetEmptySlot();

            emptySlot.Place(item);

            ItemsCount++;
        }

        private InventorySlot GetEmptySlot()
        {
            foreach (var slot in _slots)
                if (slot.IsEmpty)
                    return slot;

            throw new InvalidOperationException("Inventory has no empty slots");
        }

        public void Remove(IInventoryItem item)
        {
            var slot = GetSlotWithItem(item);
            
            slot.Emptify();

            ItemsCount--;
        }

        private InventorySlot GetSlotWithItem(IInventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            foreach (var slot in _slots)
                if (slot.Item == item)
                    return slot;

            throw new InvalidOperationException($"Inventory does not contain item of type {item.GetType()}");
        }
    }
}
