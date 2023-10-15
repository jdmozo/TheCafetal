using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace jdmozo.UI
{
    public class TitleScreenMenu : MonoBehaviour
    {
        [SerializeField] private Button _playBtn;
        [SerializeField] private TMP_Text _version;

        private void Start()
        {
            _playBtn.onClick.AddListener(() => ChangeScene(1));
            _version.text = Application.version;
        }

        private void ChangeScene(int scene) => SceneManager.LoadScene(scene);
    }
}
