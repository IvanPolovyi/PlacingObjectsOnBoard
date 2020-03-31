using ItemPool.Scripts;
using UnityEngine;

namespace Inventory.InventorySlots
{
    [System.Serializable]
    public class InventorySlot
    {
        public ItemObject item;

        public InventorySlot(ItemObject item, int amount)
        {
            this.item = item;
        }
        
    }
}
