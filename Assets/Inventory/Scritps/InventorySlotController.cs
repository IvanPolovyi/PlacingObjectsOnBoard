using ItemPool.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Inventory.Scritps
{
    public class InventorySlotController : MonoBehaviour
    {
        public ItemObject itemObject { get; private set; }
        public GameObject titleDisplay;
        public GameObject imageDisplay;

        private TextMeshProUGUI _titleDisplay;
        private Image _imageDisplay;
    
 
        private void Start()
        {
            _titleDisplay = titleDisplay.GetComponent<TextMeshProUGUI>();
            _imageDisplay = imageDisplay.GetComponent<Image>();

            SetDisplay();
        }

        private void Update()
        {
            SetDisplay();
        }

        public void Initialise(ItemObject item)
        {
            this.itemObject = item;
        }
        
        private void SetDisplay()
        {
            _titleDisplay.text = itemObject.title;
            _imageDisplay.sprite = itemObject.inventorySprite;
        }
    }
}

