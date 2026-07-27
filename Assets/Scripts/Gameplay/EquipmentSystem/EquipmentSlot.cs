using Game.InventorySystem;

namespace Game.EquipmentSystem
{
    public class EquipmentSlot : InventorySlot
    {
        protected override ItemValidator Validator => _validator;

        private readonly EquipmentValidator _validator;

        public SlotType SlotType { get; }

        public EquipmentSlot(SlotType slotType)
        {
            SlotType = slotType;

            _validator = new(this);
        }
    }
}
