using ScriptsManagers;
using UnityEngine;

namespace UI.Scripts
{
    public class StoreButton : MonoBehaviour
    {
        public GameObject storeText;
        public GameObject crossImage;
        public AudioClip clickAudio;

        public void OnButtonClick()
        {
            LeanAudio.play(clickAudio,0.5f);
            
            switch(GameManager.Main.gameState){
                case GameState.InGame:
                    GameManager.Main.gameState = GameState.InStore;
                    storeText.SetActive(false);
                    crossImage.SetActive(true);
                    UIManager.Main.ShowStoreDisplay();
                    break;
                
                case GameState.InStore:
                    GameManager.Main.gameState = GameState.InGame;
                    storeText.SetActive(true);
                    crossImage.SetActive(false);
                    UIManager.Main.HideAndSetActiveFalse();
                    break;
                case GameState.InMenu:
                    break;
            }
        }
    }
}
