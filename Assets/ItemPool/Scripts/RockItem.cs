using UnityEngine;

namespace ItemPool.Scripts
{
    [CreateAssetMenu(fileName = "New Rock Item", menuName = "Inventory System/Items/Rock")]
    public class RockItem : ItemObject
    {
        private void Awake()
        {
            itemType = ItemType.Rock;
        }
    }
}
