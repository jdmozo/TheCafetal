using UnityEngine;
using UnityEngine.UI;

namespace jdmozo.UI
{
    public class TutorialMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _tutorialContainer;
        [SerializeField] private Button _closeBtn;

        private void Start()
        {
            _closeBtn.onClick.AddListener(() => CloseTutorial());
            Time.timeScale = _tutorialContainer.activeInHierarchy ? 0 : 1;
            _tutorialContainer.SetActive(true);
        }

        void CloseTutorial()
        {
            _tutorialContainer.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
