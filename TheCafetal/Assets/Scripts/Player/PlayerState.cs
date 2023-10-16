using UnityEngine;

namespace jdmozo.Player
{
    public class PlayerState : MonoBehaviour
    {
        public static PlayerState Instance;

        public bool canOpenStore;

        [SerializeField] private Color _baseColor = Color.white;
        [SerializeField] private SpriteRenderer _playerSprite;

        private void Awake() => Instance = this;

        private void Update()
        {
            if (canOpenStore &&
                PlayerMenus.Instance.openMenus <= 1 &&
                Input.GetKeyDown(KeyCode.Space))
            {
                PlayerMenus.Instance.SetShop(!PlayerMenus.Instance.menuIsOpen);
                PlayerMenus.Instance.menuIsOpen = !PlayerMenus.Instance.menuIsOpen;
            }

            if (PlayerMenus.Instance.openMenus <= 1 &&
                Input.GetKeyDown(KeyCode.I))
            {
                PlayerMenus.Instance.SetInventory(!PlayerMenus.Instance.menuIsOpen);
                PlayerMenus.Instance.menuIsOpen = !PlayerMenus.Instance.menuIsOpen;
            }
        }

        public void CanOpenStore(bool value) => canOpenStore = value;

        public void ChangeClothesColor(Color color) => _playerSprite.color = color;

        public void ChangeClothesColor() => _playerSprite.color = _baseColor;

    }
}
