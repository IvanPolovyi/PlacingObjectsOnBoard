using System.Collections.Generic;
using Inventory.InventorySlots;
using TMPro;
using UnityEngine;

namespace Inventory.Scritps
{
    public class InventoryDisplay : MonoBehaviour
    {
        public InventoryObject inventory;
        public GameObject inventorySlotPrefab;
        public float spaceBtwItems;
        public int columns;
        public Vector2 offSet;
        public GameObject content;

        Dictionary<InventorySlot, GameObject> inventoryItems = new Dictionary<InventorySlot, GameObject>();    
        private void Start()
        {    
            CreateDisplay();
        }

        private void CreateDisplay()
        {
            for (int i = 0; i < inventory.container.Count; i++)
            {
                var slot = Instantiate(inventorySlotPrefab, Vector3.zero, transform.rotation, content.transform);
                slot.GetComponent<InventorySlotController>().Initialise(inventory.container[i].item);
                slot.GetComponent<RectTransform>().localPosition = Vector3.zero;
            }
        }
        private Vector3 GetPosition(int i)
        {
            return new Vector3(offSet.x + spaceBtwItems * (i % columns), offSet.y - spaceBtwItems * (i / columns), 0) ;
        }
    }
}
