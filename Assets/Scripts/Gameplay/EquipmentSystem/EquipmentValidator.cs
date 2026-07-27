using Game.InventorySystem;
using System;

namespace Game.EquipmentSystem
{
    internal class EquipmentValidator : ItemValidator
    {
        private readonly EquipmentSlot _slot;

        public EquipmentValidator(EquipmentSlot slot) => _slot = slot;

        public override bool IsItemValid(IInventoryItem item) 
            => base.IsItemValid(item) && IsTypeCorrect(item);

        public override void ValidateItem(IInventoryItem item)
        {
            base.ValidateItem(item);

            if (!IsTypeCorrect(item))
                throw new Exception($"Type mismatch. Excepted: {_slot.SlotType}");
        }

        private bool IsTypeCorrect(IInventoryItem item)
        {
            if (item is IEquipmnentItem equipmnentItem)
                return _slot.SlotType == equipmnentItem?.Type;
            else
                return false;
        }
    }
}
