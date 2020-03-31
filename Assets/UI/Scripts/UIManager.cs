using UnityEngine;

namespace UI.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Main { get; private set; }
        public GameObject storeDisplay;

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
        }

        public void ShowStoreDisplay()
        {
            storeDisplay.SetActive(true);
            LeanTween.moveLocalY(storeDisplay, -100, 0.3f);
        }

        public void HideStoreDisplay()
        {
            LeanTween.moveLocalY(storeDisplay, -storeDisplay.GetComponent<RectTransform>().rect.height * 1.2f, 0.3f);
        }

        public void HideAndSetActiveFalse()
        {
            LeanTween.moveLocalY(storeDisplay, -storeDisplay.GetComponent<RectTransform>().rect.height * 1.2f, 0.3f)
                .setOnComplete(SetActiveFalseDisplay);
        }

        private  void SetActiveFalseDisplay()
        {
            storeDisplay.SetActive(false);
        }
    }
}
