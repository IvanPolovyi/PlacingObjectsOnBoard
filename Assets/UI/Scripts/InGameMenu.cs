
using ScriptsManagers;
using UnityEngine;


namespace UI.Scripts
{
    public class InGameMenu : MonoBehaviour
    {
        public GameObject menuScreen;

        public void OnResumeClick()
        {
            Time.timeScale = 1;
            LeanTween.scaleY(menuScreen, 0, 0.3f).setOnComplete(Resume);
        }

        public void OnRestartClick()
        {
            Time.timeScale = 1;
            GameManager.Main.gameState = GameState.InGame;
            SceneLoader.Main.LoadScene("Level1");
        }

        public void OnQuitClick()
        {
            Application.Quit();
        }

        public void OnMenuClick()
        {
            switch (GameManager.Main.gameState)
            {
                case GameState.InGame:
                    menuScreen.SetActive(true);
                    LeanTween.scaleY(menuScreen, 1, 0.3f).setOnComplete(Pause);
                    break;
                case GameState.InMenu:
                    OnResumeClick();
                    break;
            }
        }

        private void Resume()
        {
            menuScreen.SetActive(false);
            GameManager.Main.gameState = GameState.InGame;

        }

        private void Pause()
        {
            GameManager.Main.gameState = GameState.InMenu;
            Time.timeScale = 0;
        }
    }
}
