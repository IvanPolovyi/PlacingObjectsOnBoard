using System;
using ItemPool.Scripts;
using UnityEngine;

namespace Decorations.Scripts
{
    public class ItemInfoHolder : MonoBehaviour
    {
        public ItemObject itemObject { get; set; }
        public int id;

        public void DisplayItemInfo()
        {
            if(itemObject == null)
                return;
            
            Debug.Log("ID: "+id+"; ItemType: "+ itemObject.itemType +"; Title: " + itemObject.title +"; Description: " + itemObject.description + ";");
           
        }
    }
}
