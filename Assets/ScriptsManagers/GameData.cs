using System.Collections.Generic;
using ItemPool.Scripts;
using UnityEngine;

namespace ScriptsManagers
{
    public class GameData : MonoBehaviour
    {
        public static GameData Main { get; set; } 
    
        public List<ItemObject> spawnedItems = new List<ItemObject>();
        private void Awake()
        {
            if (Main == null)
            { Main = this;}
            else
            {Destroy(this);}
        }

    }
}
