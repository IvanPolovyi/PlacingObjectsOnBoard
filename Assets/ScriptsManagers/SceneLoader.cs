using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ScriptsManagers
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Main { get; private set; }

        public GameObject loadingScreen;
        public Slider progressBar;
        public TextMeshProUGUI progressText;
        private string _nextSceneToBeLoaded;
        private void Awake()
        {
            if (Main == null)
            {
                Main = this;
            }
            else
            {
                Destroy(this);
            }
            loadingScreen.SetActive(false);
        }


        public void LoadScene(string sceneName, float waitTime = 0.3f)
        {
            _nextSceneToBeLoaded = sceneName;
            StartCoroutine(LoadNextScene());
        }

        private IEnumerator LoadNextScene()
        {
            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(_nextSceneToBeLoaded);
            loadingScreen.SetActive(true);
            
            while (!loadingScene.isDone)
            {
                float progress = Mathf.Clamp01(loadingScene.progress/0.9f);
                progressBar.value = progress;
                progressText.text = (progress * 100).ToString() + "%";
                print(progress);
                yield return null;
            }
        }
        
    }
}
