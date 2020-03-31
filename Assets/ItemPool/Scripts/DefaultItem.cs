using UnityEngine;

namespace ItemPool.Scripts
{
    [CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Items/Default")]
    public class DefaultItem : ItemObject
    {
        private void Awake()
        {
            itemType = ItemType.Default; 
        }
    }
}
