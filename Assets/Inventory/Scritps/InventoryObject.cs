using System.Collections.Generic;
using Inventory.InventorySlots;
using UnityEngine;

namespace Inventory.Scritps
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject
    {
        [SerializeField]
        public List<InventorySlot> container = new List<InventorySlot>();
    }

}
