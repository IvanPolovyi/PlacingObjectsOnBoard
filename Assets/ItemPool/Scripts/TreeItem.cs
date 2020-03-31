using UnityEngine;

namespace ItemPool.Scripts
{
    [CreateAssetMenu(fileName = "New Tree Item", menuName = "Inventory System/Items/Tree")]
    public class TreeItem : ItemObject
    {
        private void Awake()
        {
            itemType = ItemType.Tree; 
        }
    }
}