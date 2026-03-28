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

        public void Add(InventoryItem item, int slot = -1)
        {
            if (item == null)
                throw new ArgumentNullException();

            if (ItemsCount >= Size)
                throw new Exception("Inventory overflow");

            if (slot == -1)
                PlaceAtFirstEmptySlot(item);
            else
            {
                if (slot >= Size || slot < -1)
                    throw new IndexOutOfRangeException($"Slot index out of range: -1..{Size - 1}");

                PlaceAtSlot(item, slot);
            }
        }

        public bool TryAdd(InventoryItem item, int slot = -1)
        {
            if (ItemsCount >= Size || slot >= Size || slot < -1)
                return false;

            if (slot == -1)
                PlaceAtFirstEmptySlot(item);
            else
                PlaceAtSlot(item, slot);

            return true;
        }

        private void PlaceAtSlot(InventoryItem item, int index)
        {
            var slot = _slots[index];

            slot.DisplacementPlace(item, out var desplacedItem);

            if (desplacedItem != null)
                PlaceAtFirstEmptySlot(desplacedItem);

            ItemsCount++;
        }

        private void PlaceAtFirstEmptySlot(InventoryItem item)
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

            throw new Exception("Inventory has no one empty slot");
        }

        public void Remove(InventoryItem item)
        {
            var slot = GetSlotWithItem(item);
            
            slot.Emptify();
        }

        private InventorySlot GetSlotWithItem(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            foreach (var slot in _slots)
                if (slot.Item == item)
                    return slot;

            throw new Exception($"Inventory has no one slot with item: {item.GetType()}");
        }
    }
}
