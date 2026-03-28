using Game.InventorySystem;
using System;

namespace Game.EquipmentSystem
{
    public class EquipmentSlot : InventorySlot
    {
        public SlotType SlotType { get; }

        public EquipmentSlot(SlotType slotType)
        {
            SlotType = slotType;
        }

        protected override void ValidateItem(InventoryItem item)
        {
            base.ValidateItem(item);

            if (!IsTypeCorrect(item))
                throw new Exception($"Type mismatch. Excepted: {SlotType}");
        }

        protected override bool IsItemValid(InventoryItem item) 
            => base.IsItemValid(item) && IsTypeCorrect(item);

        private bool IsTypeCorrect(InventoryItem item)
        {
            if (item is EquipmnentItem equipmnentItem)
                return SlotType == equipmnentItem?.Type;
            else
                return false;
        }
    }
}
