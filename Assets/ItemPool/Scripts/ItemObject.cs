using UnityEngine;

namespace ItemPool.Scripts
{
    public enum ItemType
    {
        Rock,
        Tree,
        Mushroom,
        Default
    }
    public abstract class ItemObject : ScriptableObject
    {
        public ItemType itemType;
        public string title;
        public GameObject prefab;
        public Sprite inventorySprite;
        public int sizeOnGrid;
        
        [TextArea(5,10)] 
        public string description;
        
    }
}
