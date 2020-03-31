using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptsManagers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Main { get; private set; }
        public GameState gameState;

        private void Awake()
        {
            if (Main == null)
            {Main = this;}
            else
            {Destroy(this);}
            gameState = GameState.InGame;    
        }
    }

    public enum GameState
    {
        InGame,
        InMenu,
        InStore,
        InPlacement,
    }
}