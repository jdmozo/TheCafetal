using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace jdmozo.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseContainer;
        [SerializeField] private Button _playAgainBtn;

        private void Start() => _playAgainBtn.onClick.AddListener(() => LoadTitleScreen());


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseContainer.SetActive(!_pauseContainer.activeInHierarchy);
                Time.timeScale = _pauseContainer.activeInHierarchy ? 0 : 1;
            }
        }

        private void LoadTitleScreen() => SceneManager.LoadScene(0);
    }
}
