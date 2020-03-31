using System;
using ScriptsManagers;
using UI.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory.Scritps
{
    public class InventoryItemDragHandler : MonoBehaviour
    {
        private InventorySlotController _inventorySlotController;

        private void Start()
        {
            _inventorySlotController = gameObject.GetComponent<InventorySlotController>();
        }
        public void OnBeginDrag()
        {
            PlacingManager.Main.StartPlacingObject(_inventorySlotController.itemObject);
            UIManager.Main.HideStoreDisplay();
            GameManager.Main.gameState = GameState.InPlacement;
        }

        public void OnDrop()
        {
            PlacingManager.Main.StopObjectPlacement(_inventorySlotController.itemObject);
            
            UIManager.Main.ShowStoreDisplay();
            GameManager.Main.gameState = GameState.InStore;
        }

    }
}
