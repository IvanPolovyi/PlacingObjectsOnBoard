using ScriptsManagers;
using UnityEngine;

namespace UI.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject curtain;
        
        public void OnStartClick()
        {
            LeanTween.scaleY(curtain, 1, 0.3f);
            SceneLoader.Main.LoadScene("Level1", 0.3f);
        }

        public void OnExitClick()
        {
            Application.Quit();
        }
    }
}
