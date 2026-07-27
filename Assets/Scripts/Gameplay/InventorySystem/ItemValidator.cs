using System;

namespace Game.InventorySystem
{
    public class ItemValidator
    {
        public virtual bool IsItemValid(IInventoryItem item)
        {
            if (item == null)
                return false;

            return true;
        }

        public virtual void ValidateItem(IInventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException("Item is null. Use Emptify() to remove them");
        }
    }
}
