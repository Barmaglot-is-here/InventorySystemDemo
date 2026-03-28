using Game.InventorySystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.EquipmentSystem
{
    public class Equipment
    {
        public EquipmentSlot Head { get; }
        public EquipmentSlot Body { get; }
        public EquipmentSlot Hand1 { get; }
        public EquipmentSlot Hand2 { get; }
        public EquipmentSlot Neck { get; }

        public InventorySlot Pouch1 { get; }
        public InventorySlot Pouch2 { get; }

        public IEnumerable<InventorySlot> Slots { get; }

        public Equipment()
        {
            Head    = new(SlotType.Helmet);
            Body    = new(SlotType.Armor);
            Hand1   = new(SlotType.Weapon);
            Hand2   = new(SlotType.Weapon);
            Neck    = new(SlotType.Necklace);
            Pouch1  = new();
            Pouch2  = new();

            Slots = new InventorySlot[] { Head, Body, Hand1, Hand2, Neck, Pouch1, Pouch2 };
        }

        public void Equip(EquipmnentItem item)
        {
            var slot = GetSlot(item.Type);

            slot.Place(item);
        }

        public void DisplacementEquip(EquipmnentItem item, out InventoryItem displcedItem)
        {
            var slot = GetSlot(item.Type);

            slot.DisplacementPlace(item, out displcedItem);
        }

        public void Unequip(InventoryItem item)
        {
            InventorySlot slot = GetSlotWithItem(item);

            slot.Emptify();
        }

        private InventorySlot GetSlot(SlotType type)
        {
            return type switch
            {
                SlotType.Helmet => Head,
                SlotType.Armor => Body,
                SlotType.Weapon => Hand1.IsEmpty ? Hand1 : Hand2,
                SlotType.Necklace => Neck,
                _ => throw new NotImplementedException(),
            };
        }

        private InventorySlot GetSlotWithItem(InventoryItem item)
        {
            var slot = Slots.FirstOrDefault(slot => slot.Item == item);

            if (slot == null)
                throw new Exception($"Equipment doesn't contains item: {item.Name}");
            else 
                return slot;
        }
    }
}
