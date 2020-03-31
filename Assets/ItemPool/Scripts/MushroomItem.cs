using UnityEngine;

namespace ItemPool.Scripts
{
    [CreateAssetMenu(fileName = "New Mushroom Item", menuName = "Inventory System/Items/Mushroom")]
    public class MushroomItem : ItemObject
    {
        private void Awake()
        {
            itemType = ItemType.Mushroom; 
        }
    }
}